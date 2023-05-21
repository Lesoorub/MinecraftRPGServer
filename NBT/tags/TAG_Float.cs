using System;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG_Float : TAG
    {
        public const int _TypeID = 5;
        public override byte TypeID { get => _TypeID; }
        public override object body => this.data;
        public float data;
        //struct
        //[data:4]
        public TAG_Float(byte[] raw, ref int offset) : base("")
        {
            data = BitConverter.ToSingle(raw.BigEndian(offset, 4), 0);
            offset += 4;
        }
        public TAG_Float(float data, string name = "") : base(name)
        {
            this.data = data;
        }
        public override byte[] Bytes => BitConverter.GetBytes(data).Reverse();
        public static implicit operator TAG_Float(float t) => new TAG_Float(t);
        public static implicit operator float(TAG_Float tag) => tag.data;
        public override string ToString()
        {
            return $"TAG_Float({namelen}'{name}'): {data}";
        }
        public override bool Equals(TAG tag)
        {
            return tag is TAG_Float t && data == t.data;
        }
        public override dynamic ToDynamic()
        {
            return data;
        }
        public override string ToJson()
        {
            return data.ToString().Replace(",", ".");
        }
    }
}