using System;
using System.Buffers.Binary;
using System.Linq;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG_Int_Array : TAG
    {
        public const int _TypeID = 11;
        public override byte TypeID { get => _TypeID; }
        public int size;
        public override object body => this.data;
        public int[] data;
        public override TAG this[int index] { get => new TAG_Int(data[index]); set => data[index] = (value is TAG_Int tag ? tag.data : default); }
        public TAG_Int_Array(byte[] raw, ref int offset) : base("")
        {
            size = BinaryPrimitives.ReadInt32BigEndian(raw.AsSpan(offset));
            offset += 4;
            if (size < 0)
                throw new Exception("size can't been < 0");
            //data = new int[size];
            //for (int k = 0; k < size; k++)
            //{
            //    var tag = Read(TAG_Int._TypeID, raw, ref offset, false) as TAG_Int;
            //    data[k] = tag.data;
            //}
            data = new int[size];
            for (int k = 0; k < size; k++)
            {
                data[k] = BinaryPrimitives.ReadInt32BigEndian(raw.AsSpan(offset));
                offset += 4;
            }
        }
        public TAG_Int_Array(int[] data, string name = "") : base(name)
        {
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
        public static implicit operator TAG_Int_Array(int[] t) => new TAG_Int_Array(t);
        public static implicit operator int[](TAG_Int_Array tag) => tag.data;
        public override string ToString()
        {
            return $"TAG_Int_Array({namelen}'{name}'): {data.Length} ints";
        }
        public override bool Equals(TAG tag)
        {
            return tag is TAG_Int_Array t && data.SequenceEqual(t.data);
        }
    }
}