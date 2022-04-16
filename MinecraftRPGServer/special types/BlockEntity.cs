using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineServer;
public class BlockEntity : ISerializable, IDeserializable
{
    public byte blockX 
    { 
        get => (byte)(PackedXZ >> 4);
        set => PackedXZ = (byte)((value << 4) | PackedXZ & 0x0F);
    }
    public byte blockZ
    {
        get => (byte)(PackedXZ & 0x0F);
        set => PackedXZ = (byte)((PackedXZ & 0xF0) | value);
    }
    public byte PackedXZ;
    public short Y;
    public VarInt Type;
    public NBTTag Data;
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

    public static Dictionary<string, VarInt> Types;

    public static void Init(byte[] block_entity_types_json)
    {
        var timer = new System.Diagnostics.Stopwatch();
        timer.Start();

        if (Types != null) return;
        Types = new Dictionary<string, VarInt>();
        var t = JsonConvert.DeserializeObject<Dictionary<string, int>>(Encoding.UTF8.GetString(block_entity_types_json));
        foreach (var type in t)
            Types.Add(type.Key, type.Value);

        timer.Stop();
        Console.WriteLine($"Block entities loaded for {((double)timer.ElapsedTicks / TimeSpan.TicksPerMillisecond):N3} ms");
    }
}
