using System;
using System.Buffers.Binary;
using System.Linq;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG_Long_Array : TAG
    {
        public const int _TypeID = 12;
        public override byte TypeID { get => _TypeID; }
        public int size;
        public override object body => this.data;
        public long[] data;
        public override TAG this[int index] { get => new TAG_Long(data[index]); set => data[index] = (value is TAG_Long tag ? tag.data : default); }
        public TAG_Long_Array(byte[] raw, ref int offset)
        {
            size = BinaryPrimitives.ReadInt32BigEndian(raw.AsSpan(offset));
            offset += 4;
            if (size < 0)
                throw new Exception("size can't been < 0");
            data = new long[size];
            for (int k = 0; k < size; k++)
            {
                data[k] = BinaryPrimitives.ReadInt64BigEndian(raw.AsSpan(offset));
                offset += 8;
            }
        }
        public TAG_Long_Array(long[] data, string name = "")
        {
            this.name = name;
            namelen = (short)name.Length;
            this.data = data;
            size = data.Length;
        }
        public override byte[] Bytes
        {
            get
            {
                byte[] buffer = BitConverter.GetBytes(size).Reverse();
                foreach (var d in data)
                    buffer = buffer.Combine(BitConverter.GetBytes(d).Reverse());
                return buffer;
            }
        }
        public static implicit operator TAG_Long_Array(long[] t) => new TAG_Long_Array(t);
        public static implicit operator long[](TAG_Long_Array tag) => tag.data;
        public override string ToString()
        {
            return $"TAG_Long_Array({namelen}'{name}'): {data.Length} longs";
        }
        public override bool Equals(TAG tag)
        {
            return tag is TAG_Long_Array t && data.SequenceEqual(t.data);
        }
    }
}