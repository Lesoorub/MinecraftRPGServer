using MineServer;
using Packets.Login;
using Packets.Play;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Security;
using System.IO;
using Org.BouncyCastle.OpenSsl;
using System.Net.Sockets;

namespace Authentication
{
    public static class Yggdrasil
    {
        public static void OnLoginStart(IClient client)
        {
            var server = client.server as RPGServer;
            var con_cl = client as ConnectedClient;

            if (server.config.OnlineMode)
                EncryptionKeyRequest(con_cl);
            else
                LoginSucces(con_cl);
        }
        public static void EncryptionKeyRequest(ConnectedClient client)
        {
            using (var rnd = RandomNumberGenerator.Create())
            {
                client.VerifyToken = new byte[32];
                rnd.GetBytes(client.VerifyToken);
            }
            client.rsa = RSA.Create();
            var rsaKeyPair = DotNetUtilities.GetRsaPublicKey(client.rsa.ExportParameters(false));
            var writer = new StringWriter();
            var pemWriter = new PemWriter(writer);
            pemWriter.WriteObject(rsaKeyPair);
            var pemKey = writer.ToString()
                .Replace("-----BEGIN PUBLIC KEY-----", "")
                .Replace("-----END PUBLIC KEY-----", "").Trim();
            var PublicKey = Convert.FromBase64String(pemKey);
            client.network.Send(new EncryptionRequest()
            {
                ServerID = "",
                PublicKey = PublicKey,
                VerifyToken = client.VerifyToken,
            });
        }
        public static void OnEncryptionKeyResponse(IClient client, byte[] SharedSecret, byte[] VerifyToken)
        {
            var con_cl = client as ConnectedClient;
            con_cl.SharedSecret = con_cl.rsa.Decrypt(SharedSecret, RSAEncryptionPadding.Pkcs1);
            var verifyToken = con_cl.rsa.Decrypt(VerifyToken, RSAEncryptionPadding.Pkcs1);
            if (!verifyToken.SequenceEqual(con_cl.VerifyToken))
            {
                DisconnectWithReason(client, "Ошибка проверки лицензии клиента");
                return;
            }
            LoginSucces(client as ConnectedClient);
        }
        public static void LoginSucces(ConnectedClient client)
        {
            var server = client.server as RPGServer;
            if (server.LoginIn(client, client.username, out var player, out var reason))
            {
                player.network.history.Enqueue(new StringHistoryElement("Encrypt enabled"));
                player.network.Send(new LoginSuccess()
                {
                    username = player.data.username
                });
                player.network.Send(new JoinGame()
                {
                    EntityID = player.EntityID,
                    isHardcore = false,
                    Gamemode = (byte)player.Gamemode,
                    PreviousGamemode = -1,
                    DimensionsNames = new string[] { "minecraft:overworld" },
                    DimensionCodec = SupportedProtocol.allprotocols[client.protocolVersion].DimensionCodec,
                    Dimension = SupportedProtocol.allprotocols[client.protocolVersion].Dimension,
                    DimensionName = player.world.publicName,
                    HashedSeed = 0,
                    MaxPlayers = server.maxPlayers,
                    ViewDistance = server.config.world.MaxViewDistance,
                    ReducedDebugInfo = false,
                    EnableRespawnScreen = false,
                    IsDebug = false,
                    IsFlat = true
                });
            }
            else
            {
                DisconnectWithReason(client, reason);
            }
        }

        private static void DisconnectWithReason(IClient client, string reason)
        {
            client.network.Send(new Disconnect()
            {
                reason = reason
            });
            client.network.Disconnect();
        }
    }
}

public class AesNetworkProvider
{
    ICryptoTransform encryptor;
    ICryptoTransform decryptor;
    byte[] SharedSecret;
    RijndaelManaged aes => new RijndaelManaged()
    {
        BlockSize = 128,
        KeySize = 128,
        Mode = CipherMode.CFB,
        FeedbackSize = 8,
        Padding = PaddingMode.None,
        Key = SharedSecret.ToArray(),
        IV = SharedSecret.ToArray(),
    };
    public AesNetworkProvider(byte[] SharedSecret)
    {
        this.SharedSecret = SharedSecret;
        var aes = this.aes;
        encryptor = aes.CreateEncryptor();
        decryptor = aes.CreateDecryptor();
    }
    public byte[] OnSendData(byte[] data)
    {
        byte[] buffer = new byte[data.Length];
        encryptor.TransformBlock(data, 0, data.Length, buffer, 0);
        return buffer;
    }
    public byte[] OnRecieveData(byte[] data)
    {
        byte[] buffer = new byte[4096];
        int readed = decryptor.TransformBlock(data, 0, data.Length, buffer, 0);
        return buffer.Take(readed);
    }
}