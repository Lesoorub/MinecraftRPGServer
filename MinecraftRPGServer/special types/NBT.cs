using System;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using MineServer;

public class NBTTag : ISerializable, IDeserializable
{
    TAG body = default;
#if DEBUG
    public string _ToString { get => ToString(); }
#endif
    public TAG this[string name]
    {
        get => body[name];
        set => body[name] = value;
    }
    public NBTTag() { }
    public NBTTag(byte[] raw, bool gzipCompressed = false)
    {
        if (gzipCompressed)
            raw = GZip.Decompress(raw);
        FromByteArray(raw, 0, out var len);
    }
    public NBTTag(TAG_Compound body)
    {
        this.body = body;
    }
    public byte[] Bytes { get => body.NamedBytes; set => FromByteArray(value, 0, out var _); }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }
    public override string ToString()
    {
        body.SetDepth(0);
        return body.ToString();
    }

    public byte[] ToByteArray()
    {
        return Bytes;
    }

    public void FromByteArray(byte[] bytes, int offset, out int length)
    {
        int init_offset = offset;
        body = TAG.Read(bytes[offset++], bytes, ref offset, true);
        length = offset - init_offset;
    }

    public static NBTTag emptyCompaund => new NBTTag(new TAG_Compound(new List<TAG>()));
    public static implicit operator TAG_Compound(NBTTag nbt) => nbt == null ? null : nbt.body as TAG_Compound;
}
public class TAG
{
    public short namelen;
    public string name = "";
    public int depth = 0;
#if DEBUG
    public string _ToString { get => ToString(); }
#endif
    public virtual TAG this[int index] { get => throw new Exception("Not supported"); set => throw new Exception("Not supported"); }
    public virtual TAG this[string name] { get => throw new Exception("Not supported"); set => throw new Exception("Not supported"); }

    public virtual void SetDepth(int d) { depth = d; }
    public virtual byte TypeID { get => 0; }
    public virtual byte[] Bytes { get => new byte[0]; }
    public virtual byte[] NamedBytes => new byte[] { TypeID }
        .Combine(BitConverter.GetBytes(namelen).Reverse()
        .Combine(Encoding.UTF8.GetBytes(name))
        .Combine(Bytes));
    public void ReadHeader(byte[] raw, ref int offset)
    {
        namelen = BitConverter.ToInt16(raw.BigEndian(offset, 2), 0);
        offset += 2;
        if (namelen > 256)
            throw new Exception("Long string?");
        if (namelen < 0)
            throw new Exception("Negative string len?");
        if (namelen != 0)
        {
            name = Encoding.UTF8.GetString(raw, offset, namelen);
            offset += namelen;
        }
    }
    public static TAG Read(int type, byte[] raw, ref int offset, bool nammed)
    {
        if (type == TAG_END._TypeID)
            return new TAG_END();

        TAG tmp = new TAG();
        if (nammed)
            tmp.ReadHeader(raw, ref offset);

        TAG Switch(ref int o)
        {
            switch (type)
            {
                //1
                case TAG_Byte._TypeID: return new TAG_Byte(raw, ref o);
                //2
                case TAG_Short._TypeID: return new TAG_Short(raw, ref o);
                //3
                case TAG_Int._TypeID: return new TAG_Int(raw, ref o);
                //4
                case TAG_Long._TypeID: return new TAG_Long(raw, ref o);
                //5
                case TAG_Float._TypeID: return new TAG_Float(raw, ref o);
                //6
                case TAG_Double._TypeID: return new TAG_Double(raw, ref o);
                //7
                case TAG_Byte_Array._TypeID: return new TAG_Byte_Array(raw, ref o);
                //8
                case TAG_String._TypeID: return new TAG_String(raw, ref o);
                //9
                case TAG_List._TypeID: return new TAG_List(raw, ref o);
                //10
                case TAG_Compound._TypeID: return new TAG_Compound(raw, ref o);
                //11
                case TAG_Int_Array._TypeID: return new TAG_Int_Array(raw, ref o);
                //12
                case TAG_Long_Array._TypeID: return new TAG_Long_Array(raw, ref o);
            }
            throw new Exception("Unsupported type with id: " + type);
        }

        TAG parsed = Switch(ref offset);
        parsed.namelen = tmp.namelen;
        parsed.name = tmp.name;
        return parsed;
    }
    public static implicit operator NBTTag(TAG tag) => tag is TAG_Compound compound ? new NBTTag(compound) : throw new Exception($"Can't convert {tag.GetType()} to {typeof(NBTTag)}");

    public new virtual string ToString()
    {
        return $"TAG({namelen}'{name}')";
    }
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
}
public class TAG_Byte : TAG
{
    public const int _TypeID = 1;
    public override byte TypeID { get => _TypeID; }
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
}
public class TAG_Short : TAG
{
    public const int _TypeID = 2;
    public override byte TypeID { get => _TypeID; }
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
}
public class TAG_Int : TAG
{
    public const byte _TypeID = 3;
    public override byte TypeID { get => _TypeID; }
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
}
public class TAG_Long : TAG
{
    public const byte _TypeID = 4;
    public override byte TypeID { get => _TypeID; }
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
}
public class TAG_Float : TAG
{
    public const int _TypeID = 5;
    public override byte TypeID { get => _TypeID; }
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
}
public class TAG_Double : TAG
{
    public const int _TypeID = 6;
    public override byte TypeID { get => _TypeID; }
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
}
public class TAG_Byte_Array : TAG
{
    public const int _TypeID = 7;
    public override byte TypeID { get => _TypeID; }
    public int size;
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
    public override byte[] Bytes => data;
    public static implicit operator TAG_Byte_Array(byte[] t) => new TAG_Byte_Array(t);
    public static implicit operator byte[](TAG_Byte_Array tag) => tag?.data;
    public override string ToString()
    {
        return $"TAG_Byte_Array({namelen}'{name}'): {data.Length} longs";
    }
}
public class TAG_String : TAG
{
    public const int _TypeID = 8;
    public override byte TypeID { get => _TypeID; }
    public ushort datalen;
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
        this.datalen = (ushort)data.Length;
    }
    public static implicit operator TAG_String(string t) => new TAG_String(t);
    public static implicit operator string(TAG_String tag) => tag.data;
    public override byte[] Bytes => BitConverter.GetBytes(datalen).Reverse().Combine(Encoding.UTF8.GetBytes(data));
    public override string ToString()
    {
        return $"TAG_String({namelen}'{name}'): {datalen}'{data}'";
    }
}
public class TAG_List : TAG
{
    public const int _TypeID = 9;
    public override byte TypeID { get => _TypeID; }
    public byte elementsType;
    public int size;
    public List<TAG> data = new List<TAG>(10);
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

        sb.AppendLine(d + "}");
        return sb.ToString();
    }
}
public class TAG_Compound : TAG, IList<TAG>
{
    public const int _TypeID = 10;
    public override byte TypeID { get => _TypeID; }
    public List<TAG> body = new List<TAG>(10);
    public override TAG this[int index]
    {
        get => body[index];
        set => body[index] = value;
    }
    public override TAG this[string name]
    {
        get => body.FirstOrDefault(x => x.name == name);
        set
        {
            for (int k = 0; k < body.Count; k++)
                if (body[k].name == name)
                {
                    body[k] = value;
                    return;
                }
            if (value == null) return;
            value.name = name;
            value.namelen = (short)name.Length;
            body.Add(value);
        }
    }
    public TAG_Compound(string name = "")
    {
        this.name = name;
        body = new List<TAG>();
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
        this.body = body;
    }
    public override void SetDepth(int d)
    {
        base.SetDepth(d);
        foreach (TAG tag in body)
        {
            tag.SetDepth(d + 1);
        }
    }
    public override byte[] Bytes
    {
        get
        {
            byte[] buffer = new byte[0];
            foreach (var d in body)
                if (d is TAG tag)
                    buffer = buffer.Combine(tag.NamedBytes);
            return buffer.Combine(new TAG_END().Bytes);
        }
    }
    public static implicit operator List<TAG>(TAG_Compound tag) => tag.body;
    public static implicit operator NBTTag(TAG_Compound tag) => new NBTTag(tag);
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        string d = new string(' ', depth);
        sb.AppendLine($"TAG_Compound({namelen}'{name}'): ");
        sb.AppendLine(d + "{");

        foreach (var x in body)
        {
            sb.AppendLine(d + " " + x.ToString());
        }

        sb.AppendLine(d + "}");
        return sb.ToString();
    }

    public TAG_Compound RemoveTag(string name)
    {
        body.RemoveAll(x => x.name.Equals(name));
        return this;
    }
    public TAG_Compound RemoveTags(string[] names)
    {
        body.RemoveAll(x => names.Contains(x.name));
        return this;
    }

    #region listinterface
    public int Count => ((ICollection<TAG>)body).Count;

    public bool IsReadOnly => ((ICollection<TAG>)body).IsReadOnly;
    public int IndexOf(TAG item)
    {
        return ((IList<TAG>)body).IndexOf(item);
    }

    public void Insert(int index, TAG item)
    {
        ((IList<TAG>)body).Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        ((IList<TAG>)body).RemoveAt(index);
    }

    public void Add(TAG item)
    {
        ((ICollection<TAG>)body).Add(item);
    }

    public void Clear()
    {
        ((ICollection<TAG>)body).Clear();
    }

    public bool Contains(TAG item)
    {
        return ((ICollection<TAG>)body).Contains(item);
    }

    public void CopyTo(TAG[] array, int arrayIndex)
    {
        ((ICollection<TAG>)body).CopyTo(array, arrayIndex);
    }

    public bool Remove(TAG item)
    {
        return ((ICollection<TAG>)body).Remove(item);
    }

    public IEnumerator<TAG> GetEnumerator()
    {
        return ((IEnumerable<TAG>)body).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)body).GetEnumerator();
    }

    #endregion listinterface
}
public class TAG_Int_Array : TAG
{
    public const int _TypeID = 11;
    public override byte TypeID { get => _TypeID; }
    public int size;
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
        return $"TAG_Int_Array({namelen}'{name}'): {data.Length} longs";
    }
}
public class TAG_Long_Array : TAG
{
    public const int _TypeID = 12;
    public override byte TypeID { get => _TypeID; }
    public int size;
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
}