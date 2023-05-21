using System;
using System.Buffers.Binary;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG_Int : TAG
    {
        public const byte _TypeID = 3;
        public override byte TypeID { get => _TypeID; }
        public override object body => this.data;
        public int data;
        //big endian
        //struct
        //[data:4]
        public TAG_Int(byte[] raw, ref int offset) : base("")
        {
            data = BinaryPrimitives.ReadInt32BigEndian(new Span<byte>(raw, offset, 4));
            offset += 4;
        }
        public TAG_Int(int data, string name = "") : base(name)
        {
            this.data = data;
        }
        public override byte[] Bytes => BitConverter.GetBytes(data).Reverse();

        public static implicit operator TAG_Int(int t) => new TAG_Int(t);
        public static implicit operator int(TAG_Int tag) => tag == null ? 0 : tag.data;
        public override string ToString()
        {
            return $"TAG_Int({namelen}'{name}'): {data}";
        }
        public override bool Equals(TAG tag)
        {
            return tag is TAG_Int t && data == t.data;
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