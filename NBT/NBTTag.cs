using Newtonsoft.Json;
using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
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
        public static object ToObject(TAG tag, Type type)
        {
            if (tag is TAG_List list)
            {
                var el_type = TAG.TagTypes[list.elementsType].C;
                var arr = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(el_type), list.Count);
                for (int k = 0; k < list.Count; k++)
                {
                    var el = list[k];
                    arr.Add(ToObject(el, el.body.GetType()));
                }
                return arr;
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

        public static NBTTag Parse(byte[] bytes, ref int offset)
        {
            throw new NotImplementedException();
        }
        static TAG Get(byte[] bytes, ref int offset)
        {
            byte type = bytes[offset++];
            TAG.ReadHeader(bytes, ref offset, out var name, out var namelen);
            TAG t = ReadUnNammed(bytes, ref offset, type);
            if (t == null)
                return new TAG_END();
            t.name = name;
            t.namelen = namelen;
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
                case TAG_Compound._TypeID:

                    break;
                case TAG_List._TypeID:
                    {
                        byte eltype = bytes[offset++];
                        int size = BinaryPrimitives.ReadInt32BigEndian(new Span<byte>(bytes, offset, 4));
                        offset += 4;
                        List<TAG> list = new List<TAG>(size);
                        for (int k = 0; k < size; k++)
                            list.Add(ReadUnNammed(bytes, ref offset, eltype));
                        t = new TAG_List(list, eltype);
                    }
                    break;
            }
            return t;
        }
    }
}