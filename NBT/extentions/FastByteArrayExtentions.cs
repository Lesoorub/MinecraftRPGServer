using System;
using System.Linq;
using System.Text;

//Documentation https://wiki.vg/NBT
namespace NBT
{
    internal static class FastByteArrayExtentions
    {
        public static byte[] Combine(this byte[] a, byte[] b)
        {
            byte[] n = new byte[a.Length + b.Length];
            Buffer.BlockCopy(a, 0, n, 0, a.Length);
            Buffer.BlockCopy(b, 0, n, a.Length, b.Length);
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
        public static byte[] Take(this byte[] from, int count)
        {
            byte[] t = new byte[count];
            Buffer.BlockCopy(from, 0, t, 0, count);
            return t;
        }
        public static byte[] Reverse(this byte[] from)
        {
            Array.Reverse(from, 0, from.Length);
            return from;
        }
        public static byte[] BigEndian(this byte[] raw, int offset, int len)
        {
            byte[] buffer = new byte[len];
            Buffer.BlockCopy(raw, offset, buffer, 0, len);
            Array.Reverse(buffer);
            return buffer;
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