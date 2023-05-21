using System;
using System.Buffers.Binary;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG_Long : TAG
    {
        public const byte _TypeID = 4;
        public override byte TypeID { get => _TypeID; }
        public override object body => this.data;
        public long data;
        //big endian
        //struct
        //[data:8]
        public TAG_Long(byte[] raw, ref int offset) : base("")
        {
            data = BinaryPrimitives.ReadInt64BigEndian(new Span<byte>(raw, offset, 8));
            offset += 8;
        }
        public TAG_Long(long data, string name = "") : base(name)
        {
            this.data = data;
        }
        public override byte[] Bytes => BitConverter.GetBytes(data).Reverse();
        public static implicit operator TAG_Long(long t) => new TAG_Long(t);
        public static implicit operator long(TAG_Long tag) => tag.data;
        public override string ToString()
        {
            return $"TAG_Long({namelen}'{name}'): {data}";
        }
        public override bool Equals(TAG tag)
        {
            return tag is TAG_Long t && data == t.data;
        }
        public override dynamic ToDynamic()
        {
            return data;
        }
        public override string ToJson()
        {
            return data.ToString();
        }
    }
}