using System;
using System.Buffers.Binary;
using System.Linq;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG_Byte_Array : TAG
    {
        public const int _TypeID = 7;
        public override byte TypeID { get => _TypeID; }
        public int size;
        public override object body => this.data;
        public byte[] data;
        public override TAG this[int index]
        {
            get => new TAG_Byte(data[index]);
            set => data[index] = (value is TAG_Byte tag ? (byte)tag.data : default);
        }
        public TAG_Byte_Array(byte[] raw, ref int offset)
        {
            size = BinaryPrimitives.ReadInt32BigEndian(raw.AsSpan(offset));
            offset += 4;
            if (size < 0)
                throw new Exception("size can't been < 0");

            data = new byte[size];
            Buffer.BlockCopy(raw, offset, data, 0, size);
            offset += size;
        }
        public TAG_Byte_Array(byte[] data, string name = "")
        {
            this.name = name;
            namelen = (short)name.Length;
            this.data = data;
            size = data.Length;
        }
        public override byte[] Bytes => BitConverter.GetBytes(data.Length).Reverse().Combine(data);
        public static implicit operator TAG_Byte_Array(byte[] t) => new TAG_Byte_Array(t);
        public static implicit operator byte[](TAG_Byte_Array tag) => tag?.data;
        public override string ToString()
        {
            return $"TAG_Byte_Array({namelen}'{name}'): {data.Length} bytes";
        }
        public override bool Equals(TAG tag)
        {
            return tag is TAG_Byte_Array t && data.SequenceEqual(t.data);
        }
    }
}