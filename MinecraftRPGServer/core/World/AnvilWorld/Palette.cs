using System;
using System.Collections.Generic;
using MineServer;

public class Palette<T>
{
    public List<T> data;

    public Palette(List<T> palette)
    {
        data = palette;
    }

    public byte[] ToByteArray(Func<T, VarInt> convert)
    {
        var data = new VarInt[this.data.Count];
        for (int k = 0; k < data.Length; k++)
            data[k] = convert(this.data[k]);

        var writer = new ArrayWriter(true);
        if (data.Length == 1)
            writer.Write(data[0]);
        else
            writer.Write(data);
        return writer.ToArray();
    }
}