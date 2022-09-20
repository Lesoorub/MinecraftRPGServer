using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG_List : TAG, IEnumerable
    {
        public const int _TypeID = 9;
        public override byte TypeID { get => _TypeID; }
        public byte elementsType;
        public int size;
        public override object body => this.data;
        public List<TAG> data = new List<TAG>(10);
        public int Count => data.Count;
        //struct
        //[elementsType:1][size:4][data:]
        public override TAG this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }
        public override TAG this[string name]
        {
            get
            {
                return data.FirstOrDefault(x => x.name == name);
            }
            set
            {
                for (int k = 0; k < data.Count; k++)
                    if (data[k].name == name)
                        data[k] = value;
            }
        }
        public TAG_List(byte[] raw, ref int offset) : base("")
        {
            elementsType = raw[offset++];
            size = BinaryPrimitives.ReadInt32BigEndian(raw.AsSpan(offset));
            offset += 4;
            if (size < 0)
                throw new Exception("Size of list < 0, see wiki.vg");

            for (int k = 0; k < size; k++)
            {
                data.Add(Read(elementsType, raw, ref offset, false));
            }
        }
        public TAG_List(List<TAG> data, byte elementsType, string name = "") : base(name)
        {
            this.data = data;
            size = data.Count;
            this.elementsType = elementsType;
        }
        public override void SetDepth(int d)
        {
            base.SetDepth(d);
            foreach (TAG tag in data)
            {
                tag.SetDepth(d + 1);
            }
        }
        public override byte[] Bytes
        {
            get
            {
                ArrayOfBytesBuilder builder = new ArrayOfBytesBuilder();
                builder.Append(new byte[] { elementsType });
                builder.Append(BitConverter.GetBytes(data.Count).Reverse());
                foreach (var d in data)
                    if (d is TAG tag)
                        builder.Append(tag.Bytes);
                return builder.ToArray();
            }
        }
        public static implicit operator List<TAG>(TAG_List tag) => tag.data;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string d = new string(' ', depth);
            sb.AppendLine($"TAG_List({namelen}'{name}'): {size} elements with type {elementsType}");
            sb.AppendLine(d + "{");

            foreach (var x in data)
            {
                sb.AppendLine(d + " " + x.ToString());
            }

            sb.Append(d + "}");
            return sb.ToString();
        }
        public override bool Equals(TAG tag)
        {
            if (tag is TAG_List t &&
                elementsType == t.elementsType &&
                data.Count == t.data.Count)
            {
                for (int k = 0; k < data.Count; k++)
                {
                    if (!Equals(data[k], t.data[k]))
                        return false;
                }
                return true;
            }
            return false;
        }

        public TAG[] ToArray() => data.ToArray();

        public IEnumerator GetEnumerator() => data.GetEnumerator();
    }
}