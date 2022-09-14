using System;
using System.Collections.Generic;
using System.Text;

public class _3DArray<T>
{
    T[,,] arr;
    public string[] _ToString
    {
        get
        {
            List<string> list = new List<string>();
            for (int k = 0; k < arr.GetLength(2); k++)
                list.Add(Slice(k)._ToString);
            return list.ToArray();
        }
    }
    public string _ToStringSummury
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            var l = _ToString;
            int index = 0;
            foreach (var t in l)
                sb.AppendLine("z = " + (index++) + Environment.NewLine + t + Environment.NewLine);
            return sb.ToString();
        }
    }
    public T[] Palette
    {
        get
        {
            List<T> palette = new List<T>();
            foreach (var t in arr)
                if (!palette.Contains(t))
                    palette.Add(t);
            return palette.ToArray();
        }
    }
    public string[] StringPalette
    {
        get
        {
            List<string> palette = new List<string>();
            foreach (var t in arr)
            {
                var s = t.ToString();
                if (!palette.Contains(s))
                    palette.Add(s);
            }
            return palette.ToArray();
        }
    }
    public _3DArray(T[,,] arr)
    {
        this.arr = arr;
    }

    public _2DArray<T> Slice(int z)
    {
        T[,] t = new T[arr.GetLength(0), arr.GetLength(1)];
        for (int y = 0; y < arr.GetLength(1); y++)
            for (int x = 0; x < arr.GetLength(0); x++)
                t[x, y] = arr[x, y, z];
        return new _2DArray<T>(t);
    }

    public static implicit operator T[,,](_3DArray<T> t) => t.arr;
}
public static class _3DArrayExtensions
{
    public static _3DArray<T> ToDebugArray<T>(this T[,,] arr) => new _3DArray<T>(arr);
}