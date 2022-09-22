using NBT;

namespace MineServer
{
    public class SerializableToBytes : ISerializable, IDeserializable
    {
        public void FromByteArray(byte[] bytes, int offset, out int length)
        {
            var reader = new ArrayReader(bytes, offset);
            reader.Fill(this);
            length = reader.offset - offset;
        }
        public byte[] ToByteArray()
        {
            var writer = new ArrayWriter();
            writer.From(this);
            return writer.ToArray();
        }
    }
    public class SerializableToBytesBigEndian : ISerializable, IDeserializable
    {
        public void FromByteArray(byte[] bytes, int offset, out int length)
        {
            var reader = new ArrayReader(bytes, offset, true);
            reader.Fill(this);
            length = reader.offset - offset;
        }
        public byte[] ToByteArray()
        {
            var writer = new ArrayWriter(true);
            writer.From(this);
            return writer.ToArray();
        }
    }
}