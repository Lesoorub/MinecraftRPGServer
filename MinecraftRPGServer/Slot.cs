namespace MinecraftTypes
{
    public struct Slot : IType
    {
        public bool Present;
        public VarInt ItemID;
        public byte ItemCount;
        public NBTTag NBT;
        public byte[] Bytes
        {
            get
            {
                if (!Present) return new byte[] { 0 };
                var NBTBytes = NBT?.Bytes;
                return new byte[] { 1 }
                    .Combine(ItemID.Bytes)
                    .Combine(ItemCount)
                    .Combine((NBTBytes != null && NBTBytes.Length != 0) ? NBTBytes : new byte[] { 0 });
            }
        }
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

        public int LoadFrom(byte[] raw, int offset, int ArrayLength)
        {
            Present = raw[offset++] == 1 ? true : false;
            if (Present)
            {
                ItemID = new VarInt(raw, ref offset);
                ItemCount = raw[offset++];
                if (raw[offset] != 0)
                    NBT = new NBTTag(raw, ref offset);
                else
                    offset++;
            }
            return offset;
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
    }
}
