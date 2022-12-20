using Newtonsoft.Json;
using System;
using System.Linq;
using System.IO;
using Packets.Status;
using MineServer;

[PacketListener(0x00, State.Status)]
public sealed class Status : PacketListener
{
    static string favicon = null;
    int last_motd_index = 0;

    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var con_client = client as ConnectedClient;
        if (con_client == null) return;
        var server = (con_client.server as RPGServer);

        if (favicon == null)
        {
            var favicon_path = server.config.motd.faviconPath;
            if (File.Exists(favicon_path))
            {
                favicon = "data:image/png;base64," +
                    Convert.ToBase64String(
                        File.ReadAllBytes(favicon_path),
                        Base64FormattingOptions.None);
            }
            else
            {
                favicon = null;
            }
        }

        var response = new Response()
        {
            response = JsonConvert.SerializeObject(new Motd()
            {
                version_name = "1.18.1, 1.18.2",
                version_protocol = SupportedProtocol.allprotocols.ContainsKey(con_client.protocolVersion) ? con_client.protocolVersion : SupportedProtocol.allprotocols.First().Key,
                players_max = server.maxPlayers,
                players_online = server.online,
                description = Chat.ColoredText(server.config.motd.descriptions[last_motd_index++]),
                favicon = favicon,
            }, Formatting.None, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore })
        };
        if (last_motd_index >= server.config.motd.descriptions.Length)
            last_motd_index = 0;
        client.network.Send(response.ToByteArray());
        return;
    }
    class Motd
    {
        [JsonIgnore]
        public string version_name { get => version.name; set => version.name = value; }
        [JsonIgnore]
        public int version_protocol { get => version.protocol; set => version.protocol = value; }


        [JsonIgnore]
        public int players_max { get => players.max; set => players.max = value; }

        [JsonIgnore]
        public int players_online { get => players.online; set => players.online = value; }


        [JsonIgnore]
        public string description_text { get => description.text; set => description.text = value; }

        public Version version = new Version();
        public Players players = new Players();
        public Chat description = new Chat(null);
        public string favicon;

        public class Version
        {
            public string name;
            public int protocol;
        }
        public class Players
        {
            public int max;
            public int online;
        }
    }
}
