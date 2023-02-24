using MineServer;

namespace Packets.Handhaking
{
    [BoundToServerPackage(State.Handhaking)]
    public class Handhake : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x00;

        public VarInt protocol_version;
        public string server_address;
        public ushort server_port;
        public VarInt next_state;
    }
    [BoundToServerPackage(State.Handhaking)]
    public class Request : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x01;
    }
}
