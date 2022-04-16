using MineServer;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public enum PaletteType : byte
{
    Single, Indirect, Direct
}
public class PalettedContrainer<T>
{
    public byte BitsPerEntry;
    public Palette<T> Palette;
    public short[] data;
    private int size;
    private byte threshold;

    public PaletteType type;

    public PalettedContrainer(List<T> palette, long[] data, int size, byte threshold, byte globalMaxBitsPerEntry)
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
                Palette = new Palette<T>(palette);
                break;
            case PaletteType.Indirect:
                Palette = new Palette<T>(palette);
                this.data = UnpackData(data);
                break;
            case PaletteType.Direct:
                this.data = UnpackData(data);
                break;
        }
    }
    public static PaletteType GetType(List<T> palette, long[] data)
    {
        if (palette == null) return PaletteType.Direct;
        if (data == null) return PaletteType.Single;
        return PaletteType.Indirect;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetData(int rx, int ry, int rz) => data[ry * size * size + rz * size + rx];

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
    public byte[] ToByteArray(Func<T, VarInt> convertPaletteTagToID)
    {
        var writer = new ArrayWriter(true);
        writer.Write(BitsPerEntry);
        if (type != PaletteType.Direct)
            writer.WriteRaw(Palette.ToByteArray(convertPaletteTagToID));
        writer.Write(PackData(data));
        return writer.ToArray();
    }
}
