using MineServer;
public struct Slot : ISerializable, IDeserializable
{
    public bool Present;
    public VarInt ItemID;
    public byte ItemCount;
    public NBTTag NBT;
    public Slot(VarInt itemID, byte itemCount, NBTTag nBT)
    {
        Present = true;
        ItemID = itemID;
        ItemCount = itemCount;
        NBT = nBT;
    }
    public Slot(int itemID, byte itemCount, NBTTag nBT)
    {
        Present = true;
        ItemID = itemID;
        ItemCount = itemCount;
        NBT = nBT;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Slot slot)) return false;
        if (!slot.Present && !Present) return true;

        return slot.ItemID == ItemID && (slot.NBT != null && slot.NBT.Equals(NBT));
    }
    public override int GetHashCode()
    {
        if (!Present) return 0;
        return ItemID.value * ItemCount * (NBT != null ? NBT.GetHashCode() : 1);
    }
    public override string ToString()
    {
        if (Present)
            return $"({ItemID.value}, {ItemCount}, {(NBT != null ? "hasNBT" : "null")})";
        else
            return $"(null)";
    }

    public byte[] ToByteArray()
    {
        if (!Present) return new byte[] { 0 };
        var NBTBytes = NBT?.Bytes;
        return new byte[] { 1 }
            .Combine(ItemID.Bytes)
            .Combine(ItemCount)
            .Combine((NBTBytes != null && NBTBytes.Length != 0) ? NBTBytes : new byte[] { 0 });
    }

    public void FromByteArray(byte[] bytes, int offset, out int length)
    {
        ArrayReader reader = new ArrayReader(bytes, offset, true);
        Present = reader.ReadByte() != 0;
        if (Present)
        {
            ItemID = reader.ReadVarInt();
            ItemCount = reader.ReadByte();
            if (bytes[reader.offset] != 0)
            {
                NBT = new NBTTag();
                NBT.FromByteArray(bytes, reader.offset, out var nbt_len);
                reader.offset += nbt_len;
            }
            else
                reader.offset++;
        }
        length = reader.offset - offset;
    }
}
