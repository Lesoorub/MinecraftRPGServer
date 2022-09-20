//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG_Byte : TAG
    {
        public const int _TypeID = 1;
        public override byte TypeID { get => _TypeID; }
        public override object body => this.data;
        public sbyte data;
        //struct
        //[data:1]
        public TAG_Byte(byte[] raw, ref int offset) : base("")
        {
            data = (sbyte)raw[offset++];
        }
        public TAG_Byte(byte data, string name = "") : base(name)
        {
            this.data = (sbyte)data;
        }
        public override byte[] Bytes => new byte[] { (byte)data };
        public static implicit operator TAG_Byte(byte t) => new TAG_Byte(t);
        public static implicit operator byte(TAG_Byte tag) => (byte)tag.data;
        public static implicit operator sbyte(TAG_Byte tag) => tag.data;
        public override string ToString()
        {
            return $"TAG_Byte({namelen}'{name}'): {data}b";
        }
        public override bool Equals(TAG tag)
        {
            return tag is TAG_Byte t && data == t.data;
        }
    }
}