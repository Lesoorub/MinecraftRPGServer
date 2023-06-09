using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

//Documentation https://wiki.vg/NBT
namespace NBT
{
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
        public NBTTag(byte[] raw)
        {
            byte first_byte = raw[0];
            switch (first_byte)
            {
                case TAG_Compound._TypeID:
                    break;
                case 0x1F:
                    raw = GZip.Decompress(raw);
                    break;
                case 0x78:
                    throw new Exception("zlib is not supported");
            }
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
        public dynamic ToDynamic() => root.ToDynamic();
        public string ToJson() => root.ToJson();
        public byte[] ToByteArray()
        {
            return Bytes;
        }

        public void FromByteArray(byte[] bytes, int offset, out int length)
        {
            int init_offset = offset;
            //root = ParseRecursive(bytes, ref offset).root;
            root = ParseNotRecursive(bytes, ref offset).root;
            //root = TAG.Read(bytes[offset++], bytes, ref offset, true);
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
                if (property.GetCustomAttributes(typeof(JsonIgnoreAttribute), false).Length == 0)
                    root[property.Name] = ParseValue(property.GetValue(anon));
            }
            foreach (var property in type.GetFields(bindingFlags))
            {
                if (property.GetCustomAttributes(typeof(JsonIgnoreAttribute), false).Length == 0)
                    root[property.Name] = ParseValue(property.GetValue(anon));
            }

            return tag;
        }
        static TAG ParseValue(object value)
        {
            if (value == null) return new TAG_Compound();
            Type val_type = value.GetType();
            var type_pair = TAG.TagTypes.FirstOrDefault(x => x.Value.C.Any(y => y.Equals(val_type)));
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
            else if (value is IDictionary idict)
            {
                var comp = new TAG_Compound();
                if (idict.Count != 0)
                {
                    foreach (var pair in idict)
                    {
                        comp.Add(ParseValue(pair));
                    }
                }
                return comp;
            }
            else if (value is IEnumerable enumerable)
            {
                Type genericType = val_type.GetElementType();
                var list = new List<TAG>();
                var iterator = enumerable.GetEnumerator();
                while (iterator.MoveNext())
                    list.Add(ParseValue(iterator.Current));
                if (list.Count == 0) return new TAG_List(list, TAG_Byte._TypeID);
                return new TAG_List(list, list.First().TypeID);
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

        public T ToObject<T>()
        {
            return (T)ToObject(typeof(T));
        }
        public object ToObject(Type type)
        {
            return ToObject(root, type);
        }
        public static object ToObject(TAG tag, Type type)
        {
            if (tag is TAG_List list)
            {
                Type el_type = null;
                if (type.IsSubclassOf(typeof(Array)))
                    el_type = type.GetElementType();
                else if (type.IsSubclassOf(typeof(IList)))
                    el_type = type.GenericTypeArguments[0];
                else
                    el_type = TAG.TagTypes[list.elementsType].C.First();
                var arr = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(el_type), list.Count);
                for (int k = 0; k < list.Count; k++)
                {
                    var el = list[k];
                    arr.Add(ToObject(el, el.body.GetType()));
                }
                if (type.IsSubclassOf(typeof(Array)))
                {
                    var a = Array.CreateInstance(el_type, arr.Count);
                    arr.CopyTo(a, 0);
                    return a;
                }
                return arr;
            }
            else if (tag is TAG_Compound compound)
            {
                var obj = Activator.CreateInstance(type);

                if (obj is IDictionary idict)
                {
                    foreach (var element in compound.data)
                    {
                        var key = ToObject(element["Key"], type.GenericTypeArguments[0]);
                        var value = ToObject(element["Value"], type.GenericTypeArguments[1]);
                        idict.Add(key, value);
                    }
                    return obj;
                }

                foreach (var element in compound.data)
                {
                    Type fieldType = null;
                    var field = type.GetField(element.name);
                    var property = type.GetProperty(element.name);
                    if (field != null)
                        fieldType = field.FieldType;
                    if (property != null)
                        fieldType = property.PropertyType;
                    if (fieldType == null)
                    {
                        continue;
                    }
                    if (element.body == null) continue;
                    var d = ToObject(element, fieldType);
                    if (fieldType != d.GetType())
                        d = Convert.ChangeType(d, fieldType);
                    if (field != null)
                        field.SetValue(obj, d);
                    if (property != null)
                        property.SetValue(obj, d);
                }
                return obj;
            }
            else
            {
                return tag.body;
            }
        }

        public static NBTTag ParseRecursive(byte[] bytes, ref int offset)
        {
            return new NBTTag(ReadNamed(bytes, ref offset));
        }
        static TAG ReadNamed(byte[] bytes, ref int offset)
        {
            byte type = bytes[offset++];
            if (type == TAG_END._TypeID)
                return new TAG_END();
            TAG.ReadHeader(bytes, ref offset, out var name);
            TAG t = ReadUnNammed(bytes, ref offset, type);
            if (t == null)
                return new TAG_END();
            t.name = name;
            return t;
        }
        static TAG ReadUnNammed(byte[] bytes, ref int offset, int type)
        {
            TAG t = null;
            switch (type)
            {
                case TAG_Byte._TypeID: t = new TAG_Byte(bytes[offset++]); break;
                case TAG_Short._TypeID:
                    t = new TAG_Short(BinaryPrimitives.ReadInt16BigEndian(new Span<byte>(bytes, offset, 2))); offset += 2; break;
                case TAG_Int._TypeID:
                    t = new TAG_Int(BinaryPrimitives.ReadInt32BigEndian(new Span<byte>(bytes, offset, 4))); offset += 4; break;
                case TAG_Long._TypeID:
                    t = new TAG_Long(BinaryPrimitives.ReadInt64BigEndian(new Span<byte>(bytes, offset, 8))); offset += 8; break;
                case TAG_Float._TypeID: t = new TAG_Float(bytes, ref offset); break;
                case TAG_Double._TypeID: t = new TAG_Double(bytes, ref offset); break;
                case TAG_Byte_Array._TypeID: t = new TAG_Byte_Array(bytes, ref offset); break;
                case TAG_Int_Array._TypeID: t = new TAG_Int_Array(bytes, ref offset); break;
                case TAG_Long_Array._TypeID: t = new TAG_Long_Array(bytes, ref offset); break;
                case TAG_String._TypeID: t = new TAG_String(bytes, ref offset); break;
                case TAG_Compound._TypeID:
                    {
                        var list = new List<TAG>(10);
                        TAG temp;
                        while ((temp = ReadNamed(bytes, ref offset)).TypeID != TAG_END._TypeID)
                            list.Add(temp);
                        return new TAG_Compound(list);
                    }
                case TAG_List._TypeID:
                    {
                        byte eltype = bytes[offset++];
                        int size = BinaryPrimitives.ReadInt32BigEndian(new Span<byte>(bytes, offset, 4));
                        offset += 4;
                        List<TAG> list = new List<TAG>(size);
                        for (int k = 0; k < size; k++)
                            list.Add(ReadUnNammed(bytes, ref offset, eltype));
                        return new TAG_List(list, eltype);
                    }
            }
            return t;
        }
        public static NBTTag ParseNotRecursive(byte[] bytes, ref int offset)
        {
            var tagstack = new Stack<TAG>();
            var namingstack = new Stack<bool>();
            var listSizeStack = new Stack<(int counter, TAG_List list)>();

            namingstack.Push(true);

            while (offset < bytes.Length)
            {
                int type;
                if (listSizeStack.Count > 0 && listSizeStack.Peek().counter > 0)
                    type = listSizeStack.Peek().list.elementsType;
                else
                    type = bytes[offset++];

                string name = "";
                if (type != 0 && namingstack.Peek())
                    TAG.ReadHeader(bytes, ref offset, out name);
                TAG t = null;
                switch (type)
                {
                    case TAG_Byte._TypeID: t = new TAG_Byte(bytes[offset++]); break;
                    case TAG_Short._TypeID:
                        t = new TAG_Short(BinaryPrimitives.ReadInt16BigEndian(new Span<byte>(bytes, offset, 2))); offset += 2; break;
                    case TAG_Int._TypeID:
                        t = new TAG_Int(BinaryPrimitives.ReadInt32BigEndian(new Span<byte>(bytes, offset, 4))); offset += 4; break;
                    case TAG_Long._TypeID:
                        t = new TAG_Long(BinaryPrimitives.ReadInt64BigEndian(new Span<byte>(bytes, offset, 8))); offset += 8; break;
                    case TAG_Float._TypeID: t = new TAG_Float(bytes, ref offset); break;
                    case TAG_Double._TypeID: t = new TAG_Double(bytes, ref offset); break;
                    case TAG_Byte_Array._TypeID: t = new TAG_Byte_Array(bytes, ref offset); break;
                    case TAG_Int_Array._TypeID: t = new TAG_Int_Array(bytes, ref offset); break;
                    case TAG_Long_Array._TypeID: t = new TAG_Long_Array(bytes, ref offset); break;
                    case TAG_String._TypeID: t = new TAG_String(bytes, ref offset); break;
                    case TAG_Compound._TypeID:
                        t = new TAG_Compound(null);
                        namingstack.Push(true);
                        listSizeStack.Push((-1, null));
                        break;
                    case TAG_END._TypeID:
                        {
                            namingstack.Pop();
                            listSizeStack.Pop();
                            var l = new List<TAG>();
                            while (tagstack.Peek().TypeID != TAG_Compound._TypeID)
                            {
                                if (tagstack.Peek().TypeID == TAG_END._TypeID)
                                    tagstack.Pop();
                                l.Add(tagstack.Pop());
                            }
                            l.Reverse();
                            (tagstack.Peek() as TAG_Compound).data = l;
                            tagstack.Push(new TAG_END());
                        }
                        break;
                    case TAG_List._TypeID:
                        {
                            byte eltype = bytes[offset++];
                            int size = BinaryPrimitives.ReadInt32BigEndian(new Span<byte>(bytes, offset, 4));
                            offset += 4;
                            t = new TAG_List(new List<TAG>(size), eltype);
                            if (size > 0)
                            {
                                namingstack.Push(false);
                                listSizeStack.Push((size + 1, t as TAG_List));
                            }
                        }
                        break;
                }
                if (t != null)
                {
                    t.name = name;

                    tagstack.Push(t);
                }

                while (listSizeStack.Count > 0)
                {
                    var pair = listSizeStack.Pop();
                    pair.counter--;
                    if (pair.counter == 0)
                    {
                        namingstack.Pop();
                        while (pair.list.data.Count < pair.list.data.Capacity)
                        {
                            if (tagstack.Peek().TypeID == TAG_END._TypeID)
                            {
                                tagstack.Pop();
                                continue;
                            }
                            pair.list.data.Add(tagstack.Pop());
                        }
                        pair.list.data.Reverse();
                        pair.list.size = pair.list.data.Count;
                    }
                    else
                    {
                        listSizeStack.Push(pair);
                        break;
                    }
                }

                if (tagstack.Count == 2 &&
                    tagstack.First().TypeID == TAG_END._TypeID &&
                    tagstack.Last().TypeID == TAG_Compound._TypeID)
                {
                    break;
                }
            }
            if (tagstack.Peek().TypeID == TAG_END._TypeID)
                tagstack.Pop();
            return tagstack.Pop();
        }
    }
}