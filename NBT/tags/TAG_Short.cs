using System;
using System.Buffers.Binary;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG_Short : TAG
    {
        public const int _TypeID = 2;
        public override byte TypeID { get => _TypeID; }
        public override object body => this.data;
        public short data;
        //big endian
        //struct
        //[data:2]
        public TAG_Short(byte[] raw, ref int offset) : base("")
        {
            data = BinaryPrimitives.ReadInt16BigEndian(new Span<byte>(raw, offset, 2));
            offset += 2;
        }
        public TAG_Short(short data, string name = "") : base(name)
        {
            this.data = data;
        }
        public override byte[] Bytes => BitConverter.GetBytes(data).Reverse();
        public static implicit operator TAG_Short(short t) => new TAG_Short(t);
        public static implicit operator short(TAG_Short tag) => tag.data;
        public override string ToString()
        {
            return $"TAG_Short({namelen}'{name}'): {data}";
        }
        public override bool Equals(TAG tag)
        {
            return tag is TAG_Short t && data == t.data;
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