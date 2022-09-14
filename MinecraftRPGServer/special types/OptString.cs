using MineServer;
using NBT;

public struct OptString : ISerializable, IDeserializable
{
    public string data;

    public OptString(string data)
    {
        this.data = data;
    }

    public void FromByteArray(byte[] bytes, int offset, out int length)
    {
        if (bytes[offset++] == 0)
        {
            data = null;
            length = 1;
            return;
        }
        var reader = new ArrayReader(bytes, offset, true);
        data = reader.Read<string>();
        length = reader.offset - offset + 1;
    }

    public byte[] ToByteArray()
    {
        if (data == null)
            return new byte[1] { 0 };
        var writer = new ArrayWriter(true);
        writer.Write((byte)1);
        writer.Write(data);
        return writer.ToArray();
    }

    public static implicit operator string(OptString str) => str.data;
    public static implicit operator OptString(string str) => new OptString(str);
}