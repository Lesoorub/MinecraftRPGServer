using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections;
using NBT;

namespace MineServer
{
    public class ArrayReader
    {
        public byte[] buffer;
        public int offset = 0;
        bool isBigEndian = false;
        public bool isEnd => offset == buffer.Length;
        public ArrayReader(byte[] data, int offset = 0, bool isBigEndian = false)
        {
            buffer = data;
            this.offset = offset;
            this.isBigEndian = isBigEndian;
        }
        public object Fill(object obj)
        {
            var type_t = obj.GetType();
            foreach (var field in type_t.GetFields())
            {
                if (field.IsStatic ||
                    field.IsInitOnly ||
                    field.IsPrivate) continue;
                //int init_offset = offset;
                var val = Read(field.FieldType);
                //Console.WriteLine($"[Reader] {buffer.Take(init_offset, offset - init_offset).ToDump()} -> {val} ({field.FieldType})");
                field.SetValue(obj, val);
            }
            return obj;
        }

        public T Read<T>() => (T)Read(typeof(T));
        public object Read(Type type)
        {
            if (buffer.Length <= offset) return null;
            if (type.IsArray)
                return readArray(type.GetElementType());
            return readSingle(type);
        }

        public static T FromBytes<T>(byte[] bytes)
        {
            GCHandle gcHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var data = (T)Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), typeof(T));
            gcHandle.Free();
            return data;
        }
        public static object FromBytes(byte[] bytes, Type type)
        {
            GCHandle gcHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var data = Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), type);
            gcHandle.Free();
            return data;
        }

        object readArray(Type element_type)
        {
            var len = (VarInt)readSingle(typeof(VarInt));

            if (element_type.Equals(typeof(byte)))
            {
                var a = new byte[len.value];
                Buffer.BlockCopy(buffer, offset, a, 0, a.Length);
                offset += a.Length;
                return a;
            }

            var arr = Array.CreateInstance(element_type, len.value);
            for (int k = 0; k < len.value; k++)
            {
                var x = Read(element_type);
                if (x == null) continue;
                arr.SetValue(Convert.ChangeType(x, element_type), k);
            }
            return arr;
        }
        object readSingle(Type type)
        {

            if (typeof(IDictionary).IsAssignableFrom(type))
                return ReadDicrionary(type);
            if (Nullable.GetUnderlyingType(type) != null &&
                buffer[offset++] == 0)
                return null;

            if (typeof(IDeserializable).IsAssignableFrom(type))
            {
                var obj = Activator.CreateInstance(type) as IDeserializable;
                obj.FromByteArray(buffer, offset, out var len);
                offset += len;
                return obj;
            }

            if (type.BaseType == typeof(Enum))
            {
                return Enum.ToObject(type, readSingle(Enum.GetUnderlyingType(type)));
            }

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    return buffer[offset++] > 0;
                case TypeCode.String:
                    {
                        var len = ReadVarInt();
                        if (offset >= buffer.Length)
                            throw new Exception("Error on parsing string");
                        offset += len.value;
                        return Encoding.UTF8.GetString(buffer, offset - len.value, len.value);
                    }
            }

            int size = Marshal.SizeOf(type);
            var b = buffer.Take(offset, size);
            offset += size;
            if (isBigEndian)
                b = b.Reverse();
            return Convert.ChangeType(FromBytes(b, type), type);
        }

        public VarInt ReadVarInt()
        {
            VarInt t = new VarInt(buffer, offset);
            offset += t.length;
            return t;
        }
        public byte ReadByte() => buffer.Take(offset++, 1)[0];
        public byte[] ReadBytes(int count)
        {
            var t = buffer.Take(offset, count);
            offset += count;
            return t;
        }
        decimal BytesToDecimal(byte[] buffer, int offset = 0)
        {
            var decimalBits = new int[4];

            for (int k = 0; k < 4; k++)
                for (int i = 0; i < 4; i++)
                    decimalBits[k] |= buffer[offset + i + k * 4] << (i * 8);

            return new Decimal(decimalBits);
        }
        object ReadDicrionary(Type t)
        {
            var args = t.GetGenericArguments();
            var key_type = args[0];
            var value_type = args[1];

            var inst = Activator.CreateInstance(t) as IDictionary;
            int count = ReadVarInt();
            for (int k = 0; k < count; k++)
            {
                var key = Read(key_type);
                var val = Read(value_type);
                inst.Add(key, val);
            }
            return Convert.ChangeType(inst, t);
        }
    }
}