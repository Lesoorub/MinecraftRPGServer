using MineServer;

public struct OptBlockID : ISerializable, IDeserializable
{
    public VarInt BlockID;
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

    public readonly static OptBlockID Absent = new OptBlockID();
}