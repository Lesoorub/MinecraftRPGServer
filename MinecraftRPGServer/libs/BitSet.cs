using System;
using System.Collections.Generic;
using System.Linq;
using MineServer;
public class BitSet : ISerializable, IDeserializable
{
    public Dictionary<int, bool> data = new Dictionary<int, bool>();

    public BitSet() { }
    public BitSet(long[] arr)
    {
        FromLongArray(arr);
    }
    public void FromLongArray(long[] arr)
    {
        data.Clear();
        for (int k = 0; k < arr.Length; k++)
        {
            var l = arr[k];
            for (int i = 0; i < 64; i++)
            {
                var b = ((l >> i) & 1) == 1;
                if (b)
                    data[k * 64 + i] = b;
            }    
        }
    }
    public void Set(int index, bool value)
    {
        if (index < 0)
            throw new Exception("index should been > 0");
        if (!data.ContainsKey(index))
            data.Add(index, value);
        else
            data[index] = value;
    }
    public int GetOnesCount() => data.Sum(x => x.Value ? 1 : 0);
    public long[] ToLongsArray()
    {
        if (data.Count == 0)
            return new long[0];
        int GetSector(int index) => index >> 6;
        long[] arr = new long[GetSector(data.Max(x => x.Key)) + 1];
        foreach (var d in data)
            arr[GetSector(d.Key)] |= (long)(d.Value ? 1 : 0) << (d.Key % 64);
        return arr;
    }

    public byte[] ToByteArray()
    {
        var writer = new ArrayWriter(true);
        writer.Write(ToLongsArray());
        return writer.ToArray();
    }

    public void FromByteArray(byte[] bytes, int offset, out int length)
    {
        var reader = new ArrayReader(bytes, offset, true);
        var arr = reader.Read<long[]>();
        FromLongArray(arr);
        length = reader.offset - offset;
    }

    public override string ToString()
    {
        return ToLongsArray().Select(x => BitConverter.GetBytes(x)).SelectMany(x => x).ToArray().Reverse().ToDump();
    }
}