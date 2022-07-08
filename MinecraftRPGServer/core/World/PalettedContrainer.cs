using MineServer;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
public class PalettedContrainer
{
    public byte BitsPerEntry;
    public Palette<short> Palette;
    public short[] data;
    private int size;
    private byte threshold;

    public PaletteType type;

    public PalettedContrainer(List<short> Palette, short[] data, int size)
    {
        this.Palette = new Palette<short>(Palette);
        this.data = data;
        this.size = size;
        BitsPerEntry = (byte)Math.Ceiling(Math.Log(Palette.Count, 2));

        if (Palette == null)
            type = PaletteType.Direct;
        else if (data == null)
            type = PaletteType.Single;
        else
            type = PaletteType.Indirect;
    }

    public PalettedContrainer(List<short> palette, long[] data, int size, byte threshold, byte globalMaxBitsPerEntry)
    {
        this.size = size;
        this.threshold = threshold;

        if (palette == null && data == null)
            throw new Exception("Wrong nbt. Nbt not contains available data");

        type = GetType(palette, data);

        switch (type)
        {
            case PaletteType.Indirect:
            case PaletteType.Direct:
                BitsPerEntry = (byte)((data.Length * 64) / (size * size * size));
                type = PaletteType.Indirect;
                if (BitsPerEntry > threshold)
                {
                    BitsPerEntry = globalMaxBitsPerEntry;
                    type = PaletteType.Direct;
                }
                break;
        }
        switch (type)
        {
            case PaletteType.Single:
                Palette = new Palette<short>(palette);
                break;
            case PaletteType.Indirect:
                Palette = new Palette<short>(palette);
                this.data = UnpackData(data);
                break;
            case PaletteType.Direct:
                this.data = UnpackData(data);
                break;
        }
    }
    public static PaletteType GetType(List<short> palette, long[] data)
    {
        if (palette == null) return PaletteType.Direct;
        if (data == null) return PaletteType.Single;
        return PaletteType.Indirect;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public short GetData(int rx, int ry, int rz) => data[ry * size * size + rz * size + rx];

    public void Add(int rx, int ry, int rz, short item)
    {
        if (Palette == null)
            Palette = new Palette<short>(new List<short>());
        //Поиск индекса значения в палитре
        short index = (short)Palette.data.IndexOf(item);
        if (index == -1)
        {
            //Добавить индекс значения в палитру
            Palette.data.Add(item);
            if (Palette.data.Count >= threshold)
            {
                int fullsize = size * size * size;
                for (int k = 0; k < fullsize; k++)
                {
                    data[k] = Palette.data[data[k]];
                }
                data[ry * size * size + rz * size + rx] = item;
                return;
            }
            index = (short)(Palette.data.Count - 1);
        }
        //Записать в данные индекс
        if (data == null)
        {
            data = new short[size * size * size];
            type = PaletteType.Indirect;
        }
        data[ry * size * size + rz * size + rx] = index;
    }
    public short[] UnpackData(long[] longs)
    {
        short[] blocks = new short[size * size * size];

        int lpv = 64 / BitsPerEntry;
        int index = 0;
        long mask = ((long)1 << BitsPerEntry) - 1;
        for (int k = 0; k < longs.Length; k++)
        {
            long l = longs[k];
            for (int i = 0; i < lpv && index < blocks.Length; i++)
            {
                blocks[index++] = (short)(l & mask);
                l >>= BitsPerEntry;
            }
        }
        return blocks;
    }
    public long[] PackData(short[] data)
    {
        if (BitsPerEntry == 0)
            return new long[0];

        int vpl = 64 / BitsPerEntry;
        long[] longs = new long[(int)Math.Ceiling((double)(size * size * size) / vpl)];
        int BitsInEntry = 64 / BitsPerEntry * BitsPerEntry;
        int index = 0;
        int bb = 0;
        for (int z = 0; z < size; z++)
            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                {
                    longs[bb / BitsInEntry] |= ((long)data[index]) << (bb % BitsInEntry);
                    index++;
                    bb += BitsPerEntry;
                }

        return longs;
    }
    public byte[] ToByteArray(Func<short, VarInt> convertPaletteTagToID)
    {
        var writer = new ArrayWriter(true);
        writer.Write(BitsPerEntry);
        if (type != PaletteType.Direct)
            writer.WriteRaw(Palette.ToByteArray(convertPaletteTagToID));
        writer.Write(PackData(data));
        return writer.ToArray();
    }
}
