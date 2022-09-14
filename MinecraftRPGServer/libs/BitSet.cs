using System;
using System.Collections.Generic;
using System.Linq;
using MineServer;
using NBT;

public class BitSet : ISerializable, IDeserializable
{
    const int SizeLongInBits = 64;
    public long[] data = new long[1];
    public BitSet() { }
    public BitSet(long[] arr)
    {
        FromLongArray(arr);
    }
    public void FromLongArray(long[] arr)
    {
        data = arr;
    }
    public void Set(int index, bool value)
    {
        int lindex = index / SizeLongInBits;
        if (lindex >= data.Length)
        {
            var t = new long[lindex];
            Array.Copy(data, t, data.Length);
            data = t;
        }
        if (value)
            data[lindex] |= 1L << (index % SizeLongInBits);
        else
            data[lindex] &= ~(1L << (index % SizeLongInBits));
    }
    public int GetOnesCount()
    {
        int t = 0;
        for (int k = 0; k < data.Length; k++)
        {
            var l = data[k];
            for (int i = 0; i < SizeLongInBits; i++)
                t += (int)((l >> i) & 1);
        }
        return t;
    }
    public long[] ToLongsArray()
    {
        return data;
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