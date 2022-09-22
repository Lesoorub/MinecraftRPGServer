using NBT;
using System.Collections;

namespace MineServer
{
    public class BytesBasedPacket : ISerializable
    {
        public byte[] data;
        public BytesBasedPacket(byte[] rawdata)
        {
            data = rawdata;
        }
        public BytesBasedPacket(IPacket data)
        {
            this.data = (data as ISerializable).ToByteArray();
        }
        public byte[] ToByteArray()
        {
            return data;
        }
    }
}