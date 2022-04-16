using MineServer;

namespace Packets.Status
{

    [BoundToServerPackage(State.Status)]
    public class Response : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x00;

        public string response;
    }

    [BoundToServerPackage(State.Status)]
    public class Ping : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x01;
        public long Payload;
    }

    [BoundToClientPackage(State.Status)]
    public class Pong : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x01;
        public long Payload;
    }
}