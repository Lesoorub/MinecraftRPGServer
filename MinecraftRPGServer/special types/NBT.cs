using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using MineServer;

//Documentation https://wiki.vg/NBT
public class NBTTag : ISerializable, IDeserializable
{
    public TAG root = new TAG_Compound();
#if DEBUG
    public string _ToString { get => ToString(); }
#endif
    public byte[] Bytes { get => root.NamedBytes; set => FromByteArray(value, 0, out _); }
    public TAG this[string name]
    {
        get => root[name];
        set => root[name] = value;
    }
    public NBTTag() { }
    public NBTTag(byte[] raw, bool gzipCompressed = false)
    {
        if (gzipCompressed)
            raw = GZip.Decompress(raw);
        FromByteArray(raw, 0, out var len);
    }
    public NBTTag(TAG body)
    {
        this.root = body;
    }
    public NBTTag(object obj)
    {
        root = Parse(obj).root;
    }
    public bool HasTag(string name) => (root is TAG_Compound c) && c.HasTag(name);
    /// <summary>
    /// Путь разделенный символом '/'
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public bool HasPath(string path)
    {
        try
        {
            return GetTagByPath(path) != null;
        }
        catch (TagNotFoundException)
        {
            return false;
        }
    }
    public TAG GetTagByPath(string path)
    {
        TAG current = root;
        string[] splittedPath = path.Split('/');
        int index = 0;
        while (current is TAG_Compound c)
        {
            string t = splittedPath[index++];
            if (!c.HasTag(t)) throw new TagNotFoundException();

            current = c[t];
            if (splittedPath.Length - 1 == index) return current;
        }
        return current;
    }
    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }
    public override string ToString()
    {
        root.SetDepth(0);
        return root.ToString();
    }

    public byte[] ToByteArray()
    {
        return Bytes;
    }

    public void FromByteArray(byte[] bytes, int offset, out int length)
    {
        int init_offset = offset;
        root = TAG.Read(bytes[offset++], bytes, ref offset, true);
        length = offset - init_offset;
    }
    /// <summary>
    /// Need tests
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (!(obj is NBTTag tag)) return false;
        if (tag.root == null && root == null) return true;
        if (!(tag.root != null && root != null)) return false;

        if (tag.root is TAG_Compound obj_compound && root is TAG_Compound compound)
        {
            if (obj_compound.data.Count != compound.data.Count) return false;
        }
        return tag.root.Equals(root);
    }
    public static bool Equals(NBTTag a, NBTTag b)
    {
        if (a == null && b == null) return true;
        if (a != null && b != null) return a.Equals(b);
        return false;
    }
    public static NBTTag emptyCompaund => new NBTTag(new TAG_Compound(new List<TAG>()));
    public static implicit operator TAG_Compound(NBTTag nbt) => nbt == null ? null : nbt.root as TAG_Compound;

    public static NBTTag Parse(object obj)
    {
        var type = obj.GetType();
        if (type.IsArray)
            return new NBTTag(ParseValue(obj));
        return new NBTTag(ParseObject(obj));
    }

    static TAG_Compound ParseObject(object anon)
    {
        var type = anon.GetType();
        NBTTag tag = new NBTTag();
        var root = tag.root as TAG_Compound;
        const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;
        foreach (var property in type.GetProperties(bindingFlags))
        {
            if (property.GetCustomAttributes(typeof(Newtonsoft.Json.JsonIgnoreAttribute), false).Length == 0)
                root[property.Name] = ParseValue(property.GetValue(anon));
        }
        foreach (var property in type.GetFields(bindingFlags))
        {
            if (property.GetCustomAttributes(typeof(Newtonsoft.Json.JsonIgnoreAttribute), false).Length == 0)
                root[property.Name] = ParseValue(property.GetValue(anon));
        }

        return tag;
    }
    static TAG ParseValue(object value)
    {
        if (value == null) return new TAG_Byte(0);
        Type val_type = value.GetType();
        var type_pair = TAG.TagTypes.FirstOrDefault(x => x.Value.C.Equals(val_type));
        Type nbt_type = null;
        if (type_pair.Value != default)
        {
            nbt_type = type_pair.Value.NBT;
        }
        else if (val_type.IsArray)
        {
            Type genericType = val_type.GetElementType();
            var list = new List<TAG>();
            var arr = value as Array;
            var len = arr.GetLength(0);
            for (int k = 0; k < len; k++)
                list.Add(ParseValue(arr.GetValue(k)));
            return new TAG_List(list, list.First().TypeID);
        }
        else if (val_type.IsSubclassOf(typeof(IEnumerable)))
        {
            Type genericType = val_type.GetElementType();
            var enumerable = val_type as IEnumerable;
            var list = new List<TAG>();
            var iterator = enumerable.GetEnumerator();
            while (iterator.MoveNext())
                list.Add(ParseValue(iterator.Current));
            if (list.Count == 0) return new TAG_List(list, TAG_Byte._TypeID);
            return new TAG_List(list, list.First().TypeID);
        }
        else if (val_type.IsSubclassOf(typeof(IDictionary)))
        {
            return ParseObject(value);
        }
        else if (val_type == typeof(bool))
        {
            return new TAG_Byte((byte)((bool)value ? 1 : 0));
        }


        if (nbt_type != null)
        {
            return (TAG)Activator.CreateInstance(nbt_type, value, "");
        }
        else
        {
            return ParseObject(value);
        }
    }

    public T ToObject<T>() where T : new()
    {
        return (T)ToObject(typeof(T));
    }
    public object ToObject(Type type)
    {
        return ToObject(root, type);
    }
    static object ToObject(TAG tag, Type type)
    {
        if (tag is TAG_List list)
        {
            var arr = new ArrayList(list.Count);
            for (int k = 0; k < list.Count; k++)
            {
                var el = list[k];
                arr.Add(ToObject(el, el.body.GetType()));
            }
            var el_type = TAG.TagTypes[list.elementsType].C;
            return arr.ToArray().Select(x => Convert.ChangeType(x, el_type)).ToList();
        }
        else if (tag is TAG_Compound compound)
        {
            //ToObject(new { x = 1, y = 2}, typeof(v2i));
            var obj = Activator.CreateInstance(type);
            foreach (var element in compound.data)
            {
                var field = type.GetField(element.name);
                if (field == null) continue;
                if (element.body == null) continue;
                field.SetValue(obj, ToObject(element, field.FieldType));
            }
            return obj;
        }
        else
        {
            return tag.body;
        }
    }
}
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
        { 0, new TagType(typeof(Nullable), typeof(TAG_END)) },
        { 1, new TagType(typeof(byte), typeof(TAG_Byte)) },
        { 2, new TagType(typeof(short), typeof(TAG_Short)) },
        { 3, new TagType(typeof(int), typeof(TAG_Int)) },
        { 4, new TagType(typeof(long), typeof(TAG_Long)) },
        { 5, new TagType(typeof(float), typeof(TAG_Float)) },
        { 6, new TagType(typeof(double), typeof(TAG_Double)) },
        { 7, new TagType(typeof(byte[]), typeof(TAG_Byte_Array)) },
        { 8, new TagType(typeof(string), typeof(TAG_String)) },
        { 9, new TagType(typeof(Array), typeof(TAG_List)) },
        { 10, new TagType(typeof(object), typeof(TAG_Compound)) },
        { 11, new TagType(typeof(int[]), typeof(TAG_Int_Array)) },
        { 12, new TagType(typeof(long[]), typeof(TAG_Long_Array)) },
    };
    public static TAG Read(int type, byte[] raw, ref int offset, bool nammed)
    {
        if (type == TAG_END._TypeID)
            return new TAG_END();
        string name = "";
        short namelen = 0;
        if (nammed)
            ReadHeader(raw, ref offset, out name, out namelen);

        var args = new object[] { raw, offset };
        TAG parsed = (TAG)Activator.CreateInstance(TagTypes[type].NBT, args);
        offset = (int)args[1];
        parsed.namelen = namelen;
        parsed.name = name;
        return parsed;
    }
    public static implicit operator NBTTag(TAG tag) => tag is TAG_Compound compound ? new NBTTag(compound) : throw new Exception($"Can't convert {tag.GetType()} to {typeof(NBTTag)}");

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
public class TAG_END : TAG
{
    public const int _TypeID = 0;
    public override byte TypeID { get => _TypeID; }
    public override byte[] Bytes => new byte[] { 0x00 };
    public override string ToString()
    {
        return $"TAG_END";
    }
    public override bool Equals(TAG tag)
    {
        return tag is TAG_END;
    }
}
public class TAG_Byte : TAG
{
    public const int _TypeID = 1;
    public override byte TypeID { get => _TypeID; }
    public override object body => this.data;
    public sbyte data;
    //struct
    //[data:1]
    public TAG_Byte(byte[] raw, ref int offset)
    {
        data = (sbyte)raw[offset++];
    }
    public TAG_Byte(byte data, string name = "")
    {
        this.name = name;
        namelen = (short)name.Length;
        this.data = (sbyte)data;
    }
    public override byte[] Bytes => new byte[] { (byte)data };
    public static implicit operator TAG_Byte(byte t) => new TAG_Byte(t);
    public static implicit operator byte(TAG_Byte tag) => (byte)tag.data;
    public static implicit operator sbyte(TAG_Byte tag) => tag.data;
    public override string ToString()
    {
        return $"TAG_Byte({namelen}'{name}'): {data}b";
    }
    public override bool Equals(TAG tag)
    {
        return tag is TAG_Byte t && data == t.data;
    }
}
public class TAG_Short : TAG
{
    public const int _TypeID = 2;
    public override byte TypeID { get => _TypeID; }
    public override object body => this.data;
    public short data;
    //big endian
    //struct
    //[data:2]
    public TAG_Short(byte[] raw, ref int offset)
    {
        data = BitConverter.ToInt16(raw.BigEndian(offset, 2), 0);
        offset += 2;
    }
    public TAG_Short(short data, string name = "")
    {
        this.name = name;
        namelen = (short)name.Length;
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
}
public class TAG_Int : TAG
{
    public const byte _TypeID = 3;
    public override byte TypeID { get => _TypeID; }
    public override object body => this.data;
    public int data;
    //big endian
    //struct
    //[data:4]
    public TAG_Int(byte[] raw, ref int offset)
    {
        data = BitConverter.ToInt32(raw.BigEndian(offset, 4), 0);
        offset += 4;
    }
    public TAG_Int(int data, string name = "")
    {
        this.name = name;
        namelen = (short)name.Length;
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
}
public class TAG_Long : TAG
{
    public const byte _TypeID = 4;
    public override byte TypeID { get => _TypeID; }
    public override object body => this.data;
    public long data;
    //big endian
    //struct
    //[data:8]
    public TAG_Long(byte[] raw, ref int offset)
    {
        data = BitConverter.ToInt64(raw.BigEndian(offset, 8), 0);
        offset += 8;
    }
    public TAG_Long(long data, string name = "")
    {
        this.name = name;
        namelen = (short)name.Length;
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
}
public class TAG_Float : TAG
{
    public const int _TypeID = 5;
    public override byte TypeID { get => _TypeID; }
    public override object body => this.data;
    public float data;
    //struct
    //[data:4]
    public TAG_Float(byte[] raw, ref int offset)
    {
        data = BitConverter.ToSingle(raw.BigEndian(offset, 4), 0);
        offset += 4;
    }
    public TAG_Float(float data, string name = "")
    {
        this.name = name;
        namelen = (short)name.Length;
        this.data = data;
    }
    public override byte[] Bytes => BitConverter.GetBytes(data).Reverse();
    public static implicit operator TAG_Float(float t) => new TAG_Float(t);
    public static implicit operator float(TAG_Float tag) => tag.data;
    public override string ToString()
    {
        return $"TAG_Float({namelen}'{name}'): {data}";
    }
    public override bool Equals(TAG tag)
    {
        return tag is TAG_Float t && data == t.data;
    }
}
public class TAG_Double : TAG
{
    public const int _TypeID = 6;
    public override byte TypeID { get => _TypeID; }
    public override object body => this.data;
    public double data;
    //struct
    //[data:8]
    public TAG_Double(byte[] raw, ref int offset)
    {
        data = BitConverter.ToDouble(raw.BigEndian(offset, 8), 0);
        offset += 8;
    }
    public TAG_Double(double data, string name = "")
    {
        this.name = name;
        namelen = (short)name.Length;
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
}
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
        size = BitConverter.ToInt32(raw.BigEndian(offset, 4), 0);
        offset += 4;
        if (size < 0)
            throw new Exception("size can't been < 0");
        data = new byte[size];
        for (int k = 0; k < size; k++)
            data[k] = (byte)(Read(TAG_Byte._TypeID, raw, ref offset, false) as TAG_Byte).data;
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
                result[offset++] = (byte)(  t        & 0b0111_1111);
            } 
            else if (t <= 0x07FF)//pair bytes
            {
                result[offset++] = (byte)(((t >> 6)  & 0b0001_1111) | 0b1100_0000);//Byte 1 //0x1F | 0xC0
                result[offset++] = (byte)(( t        & 0b0011_1111) | 0b1000_0000);//Byte 2 //0x3F | 0x80
            }
            else//three bytes
            {
                result[offset++] = (byte)(((t >> 12) & 0b0000_1111) | 0b1110_0000);//Byte 1 //0x0F | 0xE0
                result[offset++] = (byte)(((t >> 6)  & 0b0011_1111) | 0b1000_0000);//Byte 2 //0x3F | 0x80
                result[offset++] = (byte)(( t        & 0b0011_1111) | 0b1000_0000);//Byte 3 //0x3F | 0x80
            }
        }
        result[0] = (byte)(((offset - 2) >> 8) & 0xFF);
        result[1] = (byte)( (offset - 2)       & 0xFF);
        return result.Take(offset);
    }
}
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
    public TAG_List(byte[] raw, ref int offset)
    {
        elementsType = raw[offset++];
        size = BitConverter.ToInt32(raw.BigEndian(offset, 4), 0);
        offset += 4;
        if (size < 0)
            throw new Exception("Size of list < 0, see wiki.vg");

        for (int k = 0; k < size; k++)
        {
            data.Add(Read(elementsType, raw, ref offset, false));
        }
    }
    public TAG_List(List<TAG> data, byte elementsType, string name = "")
    {
        this.name = name;
        namelen = (short)name.Length;
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
            byte[] buffer = new byte[] { elementsType }.Combine(BitConverter.GetBytes(data.Count).Reverse());
            foreach (var d in data)
                if (d is TAG tag)
                    buffer = buffer.Combine(tag.Bytes);
            return buffer;
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
public class TAG_Compound : TAG, IList<TAG>
{
    public const int _TypeID = 10;
    public override byte TypeID { get => _TypeID; }
    public override object body => this.data;
    public List<TAG> data = new List<TAG>(10);
    public override TAG this[int index]
    {
        get => data[index];
        set => data[index] = value;
    }
    public override TAG this[string name]
    {
        get => data.FirstOrDefault(x => x.name.Equals(name));
        set
        {
            if (name == null) return;
            if (value == null)
            {
                RemoveTag(name);
                return;
            }
            value.name = name;
            value.namelen = (short)name.Length;

            for (int k = 0; k < data.Count; k++)
                if (data[k].name.Equals(name))
                {
                    data[k] = value;
                    return;
                }
            data.Add(value);
        }
    }
    public TAG_Compound(string name = "")
    {
        this.name = name;
        data = new List<TAG>();
    }
    public TAG_Compound(byte[] raw, ref int offset)
    {
        TAG t;
        while ((t = Read(raw[offset++], raw, ref offset, true)).TypeID != TAG_END._TypeID)
        {
            Add(t);
        }
    }
    public TAG_Compound(List<TAG> body, string name = "")
    {
        this.name = name;
        namelen = (short)name.Length;
        this.data = body;
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
            var ab = new ArrayOfBytesBuilder();
            foreach (var d in data)
                if (d is TAG tag)
                    ab.Append(tag.NamedBytes);
            ab.Append(new TAG_END().Bytes);
            return ab.ToArray();
        }
    }
    public static implicit operator List<TAG>(TAG_Compound tag) => tag.data;
    public static implicit operator NBTTag(TAG_Compound tag) => new NBTTag(tag);
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        string d = new string(' ', depth);
        sb.AppendLine($"TAG_Compound({namelen}'{name}'): ");
        sb.AppendLine(d + "{");

        foreach (var x in data)
        {
            sb.AppendLine(d + " " + x.ToString());
        }

        sb.Append(d + "}");
        return sb.ToString();

    }
    public bool HasTag(string name) => data.Any(x => x.name.Equals(name));
    public TAG_Compound RemoveTag(string name)
    {
        int index = data.FindIndex(x => x.name.Equals(name));
        if (index == -1) return this;
        data.RemoveAt(index);
        return this;
    }
    public TAG_Compound RemoveTags(string[] names)
    {
        data.RemoveAll(x => names.Contains(x.name));
        return this;
    }
    public override bool Equals(TAG tag)
    {
        if (tag is TAG_Compound t &&
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

    #region listinterface
    public int Count => ((ICollection<TAG>)data).Count;

    public bool IsReadOnly => ((ICollection<TAG>)data).IsReadOnly;
    public int IndexOf(TAG item)
    {
        return ((IList<TAG>)data).IndexOf(item);
    }

    public void Insert(int index, TAG item)
    {
        ((IList<TAG>)data).Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        ((IList<TAG>)data).RemoveAt(index);
    }

    public void Add(TAG item)
    {
        ((ICollection<TAG>)data).Add(item);
    }

    public void Clear()
    {
        ((ICollection<TAG>)data).Clear();
    }

    public bool Contains(TAG item)
    {
        return ((ICollection<TAG>)data).Contains(item);
    }

    public void CopyTo(TAG[] array, int arrayIndex)
    {
        ((ICollection<TAG>)data).CopyTo(array, arrayIndex);
    }

    public bool Remove(TAG item)
    {
        return ((ICollection<TAG>)data).Remove(item);
    }

    public IEnumerator<TAG> GetEnumerator()
    {
        return ((IEnumerable<TAG>)data).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)data).GetEnumerator();
    }

    #endregion listinterface
}
public class TAG_Int_Array : TAG
{
    public const int _TypeID = 11;
    public override byte TypeID { get => _TypeID; }
    public int size;
    public override object body => this.data;
    public int[] data;
    public override TAG this[int index] { get => new TAG_Int(data[index]); set => data[index] = (value is TAG_Int tag ? tag.data : default); }
    public TAG_Int_Array(byte[] raw, ref int offset)
    {
        size = BitConverter.ToInt32(raw.BigEndian(offset, 4), 0);
        offset += 4;
        if (size < 0)
            throw new Exception("size can't been < 0");
        data = new int[size];
        for (int k = 0; k < size; k++)
        {
            var tag = Read(TAG_Int._TypeID, raw, ref offset, false) as TAG_Int;
            data[k] = tag.data;
        }
    }
    public TAG_Int_Array(int[] data, string name = "")
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
        size = BitConverter.ToInt32(raw.BigEndian(offset, 4), 0);
        offset += 4;
        if (size < 0)
            throw new Exception("size can't been < 0");
        data = new long[size];
        for (int k = 0; k < size; k++)
        {
            var tag = Read(TAG_Long._TypeID, raw, ref offset, false) as TAG_Long;
            data[k] = tag.data;
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

[Serializable]
internal class TagNotFoundException : Exception
{
    public TagNotFoundException()
    {
    }

    public TagNotFoundException(string message) : base(message)
    {
    }

    public TagNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected TagNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
    {
    }
}
