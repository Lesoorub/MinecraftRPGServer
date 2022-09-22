using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.IO;

namespace MineServer
{
    public static class FastByteArrayExtensions
    {
        public static byte[] Copy(this byte[] t)
        {
            byte[] n = new byte[t.Length];
            Buffer.BlockCopy(t, 0, n, 0, t.Length);
            return n;
        }
        public static byte[] Combine(this byte[] a, byte b)
        {
            byte[] n = new byte[a.Length + 1];
            Buffer.BlockCopy(a, 0, n, 0, a.Length);
            n[a.Length] = b;
            return n;
        }
        public static byte[] Combine(this byte[] a, byte[] b, int len)
        {
            byte[] n = new byte[a.Length + len];
            Buffer.BlockCopy(a, 0, n, 0, a.Length);
            Buffer.BlockCopy(b, 0, n, a.Length, len);
            return n;
        }
        public static byte[] Combine(this byte[] a, byte[] b)
        {
            byte[] n = new byte[a.Length + b.Length];
            Buffer.BlockCopy(a, 0, n, 0, a.Length);
            Buffer.BlockCopy(b, 0, n, a.Length, b.Length);
            return n;
        }
        public static T[] Combine<T>(this T[] a, params object[] objs)
        {
            T[][] t = new T[objs.Length][];
            int index = 0;
            foreach (var b in objs)
            {
                if (b is T[] array)
                    t[index++] = array;
                else if (b is T o)
                    t[index++] = new T[] { o };
                else
                {
                    throw new Exception("Неизветный тип, тут был брейкпоинт, и я уже не помню зачем, но он вроде не разу не сработал");
                }
            }
            index = a.Length;
            T[] n = new T[t.Sum(x => x != null ? x.Length : 0) + index];
            Array.Copy(a, 0, n, 0, index);
            foreach (var arr in t)
            {
                var l = arr.Length;
                Array.Copy(arr, 0, n, index, l);
                index += l;
            }
            return n;
        }
        public static byte[] Combine(this byte[] a, params byte[][] objs)
        {
            byte[][] t = new byte[objs.Length][];
            int index = 0;
            foreach (var b in objs)
                t[index++] = b;
            index = a.Length;
            byte[] n = new byte[t.Sum(x => x.Length) + index];
            Buffer.BlockCopy(a, 0, n, 0, index);
            foreach (var arr in t)
            {
                var l = arr.Length;
                Buffer.BlockCopy(arr, 0, n, index, l);
                index += l;
            }
            return n;
        }
        public static byte[] Combine(byte[][] objs)
        {
            byte[] bytes = new byte[objs.Sum(a => a.Length)];
            int offset = 0;

            foreach (byte[] array in objs)
            {
                Buffer.BlockCopy(array, 0, bytes, offset, array.Length);
                offset += array.Length;
            }

            return bytes;
        }
        public static T[] Take<T>(this T[] from, int skip, int count)
        {
            T[] t = new T[count];
            Array.Copy(from, skip, t, 0, count);
            return t;
        }
        public static T[] Take<T>(this T[] from, int count)
        {
            T[] t = new T[count];
            Array.Copy(from, 0, t, 0, count);
            return t;
        }
        public static T[] Skip<T>(this T[] from, int count)
        {
            T[] n = new T[from.Length - count];
            Array.Copy(from, count, n, 0, n.Length);
            return n;
        }
        public static byte[] Take(this byte[] from, int skip, int count)
        {
            byte[] t = new byte[count];
            Buffer.BlockCopy(from, skip, t, 0, count);
            return t;
        }
        public static byte[] Take(this byte[] from, int count)
        {
            byte[] t = new byte[count];
            Buffer.BlockCopy(from, 0, t, 0, count);
            return t;
        }
        public static byte[] Skip(this byte[] from, int count)
        {
            byte[] n = new byte[from.Length - count];
            Buffer.BlockCopy(from, count, n, 0, n.Length);
            return n;
        }
        public static byte[] Reverse(this byte[] from)
        {
            Array.Reverse(from, 0, from.Length);
            return from;
        }
        public static byte[] FromDump(this string hex)
        {
            return Enumerable.Range(0, hex.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                     .ToArray();
        }
        public static string ToDump(this byte[] buffer)
        {
            StringBuilder hex = new StringBuilder(buffer.Length * 2);
            foreach (byte b in buffer)
                hex.AppendFormat("{0:x2} ", b);
            return hex.ToString().TrimEnd();
        }
        public static bool ReadBytesToEndSync(this NetworkStream stream, out byte[] data)
        {
            byte[] buffer = new byte[1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int numBytesRead;

                do
                {
                    numBytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (numBytesRead == 0)
                    {
                        data = null;
                        return false;
                    }
                    ms.Write(buffer, 0, numBytesRead);
                }
                while (numBytesRead == buffer.Length);
                data = ms.ToArray();
                return true;
            }
        }
        public static byte[] BigEndian(this byte[] raw, int offset, int len)
        {
            byte[] buffer = new byte[len];
            Buffer.BlockCopy(raw, offset, buffer, 0, len);
            Array.Reverse(buffer);
            return buffer;
        }
        public static byte[] GetSha1(this string str)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
                return sha1.ComputeHash(Encoding.UTF8.GetBytes(str));
        }
        public static byte[] GetSha1(this byte[] arr)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
                return sha1.ComputeHash(arr);
        }
        public static string GetHexString(this byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2} ", b);
            return hex.ToString().TrimEnd();
        }
    }
}