//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG_END : TAG
    {
        public const int _TypeID = 0;
        public override byte TypeID { get => _TypeID; }
        public override byte[] Bytes => new byte[] { 0x00 };
        public override string ToString()
        {
            return $"TAG_END";
        }
        public override bool Equals(TAG tag)
        {
            return tag is TAG_END;
        }
    }
}