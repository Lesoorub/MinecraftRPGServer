using System;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG_Double : TAG
    {
        public const int _TypeID = 6;
        public override byte TypeID { get => _TypeID; }
        public override object body => this.data;
        public double data;
        //struct
        //[data:8]
        public TAG_Double(byte[] raw, ref int offset) : base("")
        {
            data = BitConverter.ToDouble(raw.BigEndian(offset, 8), 0);
            offset += 8;
        }
        public TAG_Double(double data, string name = "") : base(name)
        {
            this.data = data;
        }
        public override byte[] Bytes => BitConverter.GetBytes(data).Reverse();
        public static implicit operator TAG_Double(double t) => new TAG_Double(t);
        public static implicit operator double(TAG_Double tag) => tag.data;
        public override string ToString()
        {
            return $"TAG_Double({namelen}'{name}'): {data}";
        }
        public override bool Equals(TAG tag)
        {
            return tag is TAG_Double t && data == t.data;
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