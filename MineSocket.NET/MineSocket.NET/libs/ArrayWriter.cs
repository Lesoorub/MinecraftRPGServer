using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using NBT;

namespace MineServer
{
    public class ArrayWriter : IDisposable
    {
        MemoryStream ms = new MemoryStream();
        bool isBigEndian;
#if DEBUG
        public byte[] DEBUG_Bytes => ms.ToArray();
#endif
        static byte[] tempbuffer = new byte[1024];
        public ArrayWriter(bool isBigEndian = false)
        {
            this.isBigEndian = isBigEndian;
        }
        public void From(object obj)
        {
            var type_t = obj.GetType();
            foreach (var field in type_t.GetFields())
            {
                if (field.IsStatic ||
                    field.IsInitOnly ||
                    field.IsPrivate) continue;

                Write(field.GetValue(obj), field.FieldType);
            }
        }
        public void WriteRaw(byte[] bytes, int offset = 0) => ms.Write(bytes, offset, bytes.Length);
        public void WriteRaw(byte[] bytes, int offset, int length) => ms.Write(bytes, offset, length);
        public void Write<T>(T obj) => Write(obj, typeof(T));
        public void Write(object obj, Type type)
        {
            if (type.IsArray)
            {
                if (type == typeof(VarInt[]))
                {
                    var b = VarInt.ArrayOfVarIntsToByteArray((VarInt[])obj);
                    ms.Write(b, 0, b.Length);
                    return;
                }
                if (type == typeof(long[]))
                {
                    WriteBytesLongs((long[])obj);
                    return;
                }
                writeArray(obj, type.GetElementType());
                return;
            }
            writeSingle(obj, type);
        }

        void writeArray(object obj, Type el_t)
        {
            var arr = (Array)obj;
            if (arr == null || arr.Length == 0)
            {
                ms.WriteByte(0);
                return;
            }
            writeSingle(new VarInt(arr.Length), typeof(VarInt));
            if (el_t.Equals(typeof(byte)))
            {
                var t = (byte[])obj;
                ms.Write(t, 0, t.Length);
                return;
            }
            for (int k = 0; k < arr.Length; k++)
                Write(arr.GetValue(k), el_t);
        }
        void writeSingle(object obj, Type type_t)
        {
            void w(byte[] buffer)
            {
                //Console.WriteLine($"[Writer] {obj}  ({type_t}) -> {buffer.ToDump()}");
                ms.Write(buffer, 0, buffer.Length);
            }
            if (obj is IDictionary dict)
            {
                WriteDictionary(dict);
                return;
            }
            if (Nullable.GetUnderlyingType(type_t) != null)
            {
                if (obj == null)
                {
                    ms.WriteByte(0);
                    return;
                }
                else
                {
                    ms.WriteByte(1);
                    var newtype = Nullable.GetUnderlyingType(type_t);
                    writeSingle(Convert.ChangeType(obj, newtype), newtype);
                    return;
                }
            }

            if (obj == null)
            {
                //Console.WriteLine($"[Writer] null ({type_t}) -> 0");
                ms.WriteByte(0);
                return;
            }

            if (obj is ISerializable t)
            {
                w(t.ToByteArray());
                return;
            }

            if (type_t.BaseType == typeof(Enum))
            {
                var newtype = Enum.GetUnderlyingType(type_t);
                Write(Convert.ChangeType(obj, newtype), newtype);
                return;
            }

            switch (Type.GetTypeCode(type_t))
            {
                case TypeCode.Boolean:
                    w(BitConverter.GetBytes((bool)obj));
                    return;
                case TypeCode.String:
                    {
                        string str = (string)obj;
                        var dat = Encoding.UTF8.GetBytes(str);
                        w(new VarInt(dat.Length).Bytes);
                        w(dat);
                    }
                    return;
                case TypeCode.Int32:
                    {
                        //w(BitConverter.GetBytes((int)obj));//126 ms
                        unsafe
                        {
                            int i = (int)obj;
                            byte* data = (byte*)&i;
                            if (isBigEndian)
                            {
                                tempbuffer[0] = data[3];
                                tempbuffer[1] = data[2];
                                tempbuffer[2] = data[1];
                                tempbuffer[3] = data[0];
                            }
                            else
                            {
                                tempbuffer[0] = data[0];
                                tempbuffer[1] = data[1];
                                tempbuffer[2] = data[2];
                                tempbuffer[3] = data[3];
                            }
                            ms.Write(tempbuffer, 0, 4);
                        }
                    }
                    return;
            }

            int size = Marshal.SizeOf(type_t);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(obj, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            if (isBigEndian)
            {
                w(arr.Reverse());
                return;
            }
            w(arr);
        }
        public byte[] ToArray() => ms.ToArray();
        public void Dispose()
        {
            ms.Dispose();
        }

        void WriteDictionary(IDictionary dict)
        {
            Write(new VarInt(dict.Count));
            IEnumerator key = dict.Keys.GetEnumerator();
            IEnumerator value = dict.Values.GetEnumerator();
            for (int k = 0; k < dict.Count; k++)
            {
                if (!key.MoveNext() || !value.MoveNext())
                    break;
                Write(key.Current, key.Current.GetType());
                Write(value.Current, value.Current.GetType());
            }
        }
        unsafe void WriteBytesLongs(long[] arr)
        {
            if (arr == null)
            {
                ms.WriteByte(0);
                return;
            }
            var len = new VarInt(arr.Length).Bytes;
            ms.Write(len, 0, len.Length);
            if (!isBigEndian)
            {
                byte[] t = new byte[arr.Length * 8];

                fixed (long* pl = &arr[0])
                {
                    byte* start = (byte*)pl;
                    Marshal.Copy((IntPtr)start, t, 0, t.Length);
                    ms.Write(t, 0, t.Length);
                }
            }
            else
            {
                fixed (long* pl = &arr[0])
                {
                    byte* start = (byte*)pl;
                    int l = arr.Length * 8;
                    for (int k = 0; k < l;)
                    {
                        tempbuffer[7] = start[k++];
                        tempbuffer[6] = start[k++];
                        tempbuffer[5] = start[k++];
                        tempbuffer[4] = start[k++];
                        tempbuffer[3] = start[k++];
                        tempbuffer[2] = start[k++];
                        tempbuffer[1] = start[k++];
                        tempbuffer[0] = start[k++];
                        ms.Write(tempbuffer, 0, 8);
                    }
                }

            }
        }
    }
}