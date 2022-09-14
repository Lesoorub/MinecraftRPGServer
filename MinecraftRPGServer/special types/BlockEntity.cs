using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineServer;
using NBT;

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

    public static string[] BlockEntityNames = Enum.GetNames(typeof(BlockEntityID));
    public static bool GetByNameID(string nameid, out BlockEntityID BlockEntity)
    {
        int index = Array.IndexOf(BlockEntityNames, nameid.Replace("minecraft:", ""));
        BlockEntity = default;
        if (index != -1)
        {
            BlockEntity = (BlockEntityID)index;
            return true;
        }
        return false;
    }
    public static bool GetNameIDByType(BlockEntityID type, out string nameId)
    {
        byte t = (byte)type;
        if (t < 0 || t >= BlockEntityNames.Length)
        {
            nameId = null;
            return false;
        }
        nameId = BlockEntityNames[t];
        return true;
    }
}