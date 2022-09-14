using MineServer;

[PacketListener(0x01, State.Login)]
public class EncryptionResponse : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var response = packet as Packets.Login.EncryptionResponse;
        if (response == null) return;
        Authentication.Yggdrasil.OnEncryptionKeyResponse(client, response.SharedSecret, response.VerifyToken);
    }
}