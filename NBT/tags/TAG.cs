using System;
using System.Collections.Generic;
using System.Text;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    public class TAG
    {
        public short namelen;
        public string name = "";
        public int depth = 0;
#if DEBUG
        public string _ToString { get { SetDepth(0); return ToString(); } }
#endif
        public virtual TAG this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual TAG this[string name] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public virtual void SetDepth(int d) { depth = d; }
        public virtual byte TypeID { get => 0; }
        public virtual byte[] Bytes { get => new byte[0]; }
        public virtual byte[] NamedBytes => new byte[] { TypeID }
            .Combine(BitConverter.GetBytes(namelen).Reverse()
            .Combine(Encoding.UTF8.GetBytes(name))
            .Combine(Bytes));
        public virtual object body { get => throw new NotImplementedException(); }

        public static void ReadHeader(byte[] raw, ref int offset, out string name, out short namelen)
        {
            namelen = BitConverter.ToInt16(raw.BigEndian(offset, 2), 0);
            offset += 2;
            if (namelen >= 256)
                throw new Exception("Long string?");
            if (namelen < 0)
                throw new Exception("Negative string len?");
            if (namelen != 0)
            {
                name = Encoding.UTF8.GetString(raw, offset, namelen);
                offset += namelen;
            }
            else
            {
                name = "";
            }
        }
        public class TagType
        {
            public Type C;
            public Type NBT;

            public TagType(Type c, Type nBT)
            {
                C = c;
                NBT = nBT;
            }
        }
        public static Dictionary<int, TagType> TagTypes = new Dictionary<int, TagType>()
        {
            {  0, new TagType(typeof(Nullable), typeof(TAG_END)) },
            {  1, new TagType(typeof(byte),     typeof(TAG_Byte)) },
            {  2, new TagType(typeof(short),    typeof(TAG_Short)) },
            {  3, new TagType(typeof(int),      typeof(TAG_Int)) },
            {  4, new TagType(typeof(long),     typeof(TAG_Long)) },
            {  5, new TagType(typeof(float),    typeof(TAG_Float)) },
            {  6, new TagType(typeof(double),   typeof(TAG_Double)) },
            {  7, new TagType(typeof(byte[]),   typeof(TAG_Byte_Array)) },
            {  8, new TagType(typeof(string),   typeof(TAG_String)) },
            {  9, new TagType(typeof(Array),    typeof(TAG_List)) },
            { 10, new TagType(typeof(object),   typeof(TAG_Compound)) },
            { 11, new TagType(typeof(int[]),    typeof(TAG_Int_Array)) },
            { 12, new TagType(typeof(long[]),   typeof(TAG_Long_Array)) },
        };
        public static TAG Read(int type, byte[] raw, ref int offset, bool nammed)
        {
            if (type == TAG_END._TypeID)
                return new TAG_END();
            string name = "";
            short namelen = 0;
            if (nammed)
                ReadHeader(raw, ref offset, out name, out namelen);

            TAG parsed = null;
            switch (type)
            {
                case TAG_Byte._TypeID:  parsed = new TAG_Byte(raw, ref offset);  break;
                case TAG_Short._TypeID: parsed = new TAG_Short(raw, ref offset); break;
                case TAG_Int._TypeID:   parsed = new TAG_Int(raw, ref offset);   break;
                case TAG_Long._TypeID:  parsed = new TAG_Long(raw, ref offset);  break;
                case TAG_Float._TypeID:  parsed = new TAG_Float(raw, ref offset);  break;
                case TAG_Double._TypeID:  parsed = new TAG_Double(raw, ref offset);  break;
                case TAG_Byte_Array._TypeID:  parsed = new TAG_Byte_Array(raw, ref offset);  break;
                case TAG_String._TypeID:  parsed = new TAG_String(raw, ref offset);  break;
                case TAG_List._TypeID:  parsed = new TAG_List(raw, ref offset);  break;
                case TAG_Compound._TypeID:  parsed = new TAG_Compound(raw, ref offset);  break;
                case TAG_Int_Array._TypeID:  parsed = new TAG_Int_Array(raw, ref offset);  break;
                case TAG_Long_Array._TypeID:  parsed = new TAG_Long_Array(raw, ref offset);  break;
            }
            parsed.namelen = namelen;
            parsed.name = name;
            return parsed;
        }
        public static implicit operator NBTTag(TAG tag) => tag is TAG_Compound compound ? new NBTTag(compound) : throw new Exception($"Can't convert {tag.GetType()} to {typeof(NBTTag)}");

        public T ToObject<T>() where T : new()
        {
            return (T)ToObject(typeof(T));
        }
        public object ToObject(Type type)
        {
            return NBTTag.ToObject(this, type);
        }

        public new virtual string ToString()
        {
            return $"TAG({namelen}'{name}')";
        }
        public virtual bool Equals(TAG tag)
        {
            return name.Equals(tag.name);
        }
        public static bool Equals(TAG a, TAG b)
        {
            if (a == null && b == null) return true;
            if (a != null && b != null) return a.Equals(b);
            return false;
        }

        public static implicit operator TAG(bool value) => new TAG_Byte((byte)(value ? 1 : 0));
        public static implicit operator TAG(byte value) => new TAG_Byte(value);
        public static implicit operator TAG(int value) => new TAG_Int(value);
        public static implicit operator TAG(long value) => new TAG_Long(value);
        public static implicit operator TAG(short value) => new TAG_Short(value);
        public static implicit operator TAG(float value) => new TAG_Float(value);
        public static implicit operator TAG(double value) => new TAG_Double(value);
        public static implicit operator TAG(string value) => value != null ? new TAG_String(value) : null;
        public static implicit operator TAG(byte[] value) => value != null ? new TAG_Byte_Array(value) : null;
        public static implicit operator TAG(int[] value) => value != null ? new TAG_Int_Array(value) : null;
        public static implicit operator TAG(long[] value) => value != null ? new TAG_Long_Array(value) : null;

        public static explicit operator bool(TAG tag) => (tag as TAG_Byte).data != 0;
        public static explicit operator byte(TAG tag) => (byte)(tag as TAG_Byte).data;
        public static explicit operator sbyte(TAG tag) => (tag as TAG_Byte).data;
        public static explicit operator int(TAG tag) => (tag as TAG_Int).data;
        public static explicit operator long(TAG tag) => (tag as TAG_Long).data;
        public static explicit operator short(TAG tag) => (tag as TAG_Short).data;
        public static explicit operator float(TAG tag) => (tag as TAG_Float).data;
        public static explicit operator double(TAG tag) => (tag as TAG_Double).data;
        public static explicit operator string(TAG tag) => (tag as TAG_String)?.data;
        public static explicit operator byte[](TAG tag) => (tag as TAG_Byte_Array)?.data;
        public static explicit operator int[](TAG tag) => (tag as TAG_Int_Array)?.data;
        public static explicit operator long[](TAG tag) => (tag as TAG_Long_Array)?.data;
    }
}