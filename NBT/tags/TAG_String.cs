using System;
using System.Text;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG_String : TAG
    {
        public const int _TypeID = 8;
        public override byte TypeID { get => _TypeID; }
        public ushort datalen;
        public override object body => this.data;
        public string data;

        //struct
        //[datalen:2][data:datalen]
        public TAG_String(byte[] raw, ref int offset)
        {
            datalen = BitConverter.ToUInt16(raw.BigEndian(offset, 2), 0);
            offset += 2;
            data = Encoding.UTF8.GetString(raw, offset, datalen);
            offset += datalen;
        }
        public TAG_String(string data, string name = "")
        {
            this.name = name;
            namelen = (short)name.Length;
            this.data = data;
            if (data != null)
                this.datalen = (ushort)data.Length;
        }
        public static implicit operator TAG_String(string t) => new TAG_String(t);
        public static implicit operator string(TAG_String tag) => tag.data;
        public override byte[] Bytes => ModifiedUTF8WithLen(data);
        public override string ToString()
        {
            return $"TAG_String({namelen}'{name}'): {datalen}'{data}'";
        }
        public override bool Equals(TAG tag)
        {
            return tag is TAG_String t && string.Equals(data, t.data);
        }
        private static byte[] ModifiedUTF8WithLen(string text)
        {
            char[] chars = text.ToCharArray();
            byte[] result = new byte[chars.Length * 3 + 2];
            int offset = 2;
            foreach (var c in chars)
            {
                int t = c;
                if (t == 0)//zero is encoded by two bytes
                {
                    offset += 2;
                }
                else if (t <= 0x007F)//single byte
                {
                    result[offset++] = (byte)(t & 0b0111_1111);
                }
                else if (t <= 0x07FF)//pair bytes
                {
                    result[offset++] = (byte)(((t >> 6) & 0b0001_1111) | 0b1100_0000);//Byte 1 //0x1F | 0xC0
                    result[offset++] = (byte)((t & 0b0011_1111) | 0b1000_0000);//Byte 2 //0x3F | 0x80
                }
                else//three bytes
                {
                    result[offset++] = (byte)(((t >> 12) & 0b0000_1111) | 0b1110_0000);//Byte 1 //0x0F | 0xE0
                    result[offset++] = (byte)(((t >> 6) & 0b0011_1111) | 0b1000_0000);//Byte 2 //0x3F | 0x80
                    result[offset++] = (byte)((t & 0b0011_1111) | 0b1000_0000);//Byte 3 //0x3F | 0x80
                }
            }
            result[0] = (byte)(((offset - 2) >> 8) & 0xFF);
            result[1] = (byte)((offset - 2) & 0xFF);
            return result.Take(offset);
        }
    }
}