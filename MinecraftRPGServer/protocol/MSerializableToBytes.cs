using MineServer;
using System.IO;

public class MSerializableToBytes : ISerializable, IDeserializable
{
    public virtual int package_id { get; }
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
        var data = writer.ToArray();
        var packet_id = new VarInt(package_id);
        var len = new VarInt(data.Length + packet_id.length);
        using (MemoryStream ms = new MemoryStream())
        {
            ms.Write(len.Bytes, 0, len.length);
            ms.Write(packet_id.Bytes, 0, packet_id.length);
            ms.Write(data, 0, data.Length);
            return ms.ToArray();
        }
    }
}