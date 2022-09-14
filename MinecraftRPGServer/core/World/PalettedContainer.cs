using MineServer;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class PalettedContainer
{
    public IContainer container { get; private set; }
    public PaletteType type
    {
        get
        {
            if (container.GetType() == typeof(SinglePalette))
                return PaletteType.Single;

            if (container.GetType() == typeof(DirectPalette))
                return PaletteType.Direct;

            if (container.GetType() == typeof(InDirectPalette))
                return PaletteType.Indirect;

            throw new NotImplementedException();
        }
    }

    byte size;
    byte threshold;
    byte directBitsPerEntry;

    public PalettedContainer(List<short> palette, long[] data, byte size, byte threshold, byte directBitsPerEntry)
    {
        this.size = size;
        this.threshold = threshold;
        this.directBitsPerEntry = directBitsPerEntry;

        if (data == null)//Single
        {
            container = new SinglePalette(size, palette.First());
        }
        else
        {
            if (palette == null)//Direct
            {
                var unpacked = UnpackData(size, directBitsPerEntry, data);
                container = new DirectPalette(unpacked, size, directBitsPerEntry);
            }
            else//Indirect
            {
                var bps = (byte)((data.Length * 64) / (size * size * size));
                var unpacked = UnpackData(size, bps, data);
                container = new InDirectPalette(palette, unpacked, size);
            }
        }
    }

    public PalettedContainer(short fillElement, byte size, byte threshold, byte directBitsPerEntry)
    {
        this.size = size;
        this.threshold = threshold;
        this.directBitsPerEntry = directBitsPerEntry;

        container = new SinglePalette(size, fillElement);
    }

    public void Set(int rx, int ry, int rz, short item)
    {
        Type type = container.GetType();
        if (type == typeof(SinglePalette))
        {
            var single = container as SinglePalette;
            if (item != single.element)
            {
                var indirect = container = new InDirectPalette(single);
                indirect.Set(rx, ry, rz, item);
                return;
            }
        }
        else if (type == typeof(InDirectPalette))
        {
            var indirect = container as InDirectPalette;
            if (indirect.Palette.Any(x => x.value == item) ||
                indirect.Palette.Count + 1 < Math.Pow(2, threshold))
            {
                indirect.Set(rx, ry, rz, item);
                return;
            }
            var direct = container = new DirectPalette(indirect, directBitsPerEntry);
            direct.Set(rx, ry, rz, item);
        }
        else if (type == typeof(DirectPalette))
        {
            var direct = container as DirectPalette;
            direct.Set(rx, ry, rz, item);
            if (direct.GetPalette().Count < Math.Pow(2, threshold))
            {
                container = new InDirectPalette(direct);
            }
        }
    }
    public short Get(int rx, int ry, int rz)
    {
        return container.Get(rx, ry, rz);
    }

    public List<PaletteElement> GetPalette()
    {
        return container.GetPalette();
    }

    public byte[] ToByteArray()
    {
        var builder = new ArrayWriter(true);
        builder.Write(container.BitsPerEntry);
        container.Write(builder);
        return builder.ToArray();
    }
    public static short[] UnpackData(int size, byte BitsPerEntry, long[] longs)
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
    public static long[] PackData(int size, byte BitsPerEntry, short[] data)
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

    public struct PaletteElement
    {
        public short value;
        public short count;

        public PaletteElement(short value, short count)
        {
            this.value = value;
            this.count = count;
        }

        public override string ToString()
        {
            return $"value={value}, count={count}";
        }
    }

    public interface IContainer
    {
        byte BitsPerEntry { get; }
        void Set(int rx, int ry, int rz, short item);
        short Get(int rx, int ry, int rz);
        List<PaletteElement> GetPalette();
        void Write(ArrayWriter writer);
    }

    public class SinglePalette : IContainer
    {
        public short element;
        public byte size;

        public byte BitsPerEntry => 0;

        public SinglePalette(InDirectPalette inDirect_palette)
        {
            element = inDirect_palette.Palette[0].value;
            size = inDirect_palette.size;
        }
        public SinglePalette(byte size, short element)
        {
            this.size = size;
            this.element = element;
        }

        public short Get(int rx, int ry, int rz)
        {
            return element;
        }

        public void Set(int rx, int ry, int rz, short item)
        {
            element = item;
        }

        public void Write(ArrayWriter writer)
        {
            writer.Write(new VarInt(element));
            writer.Write<byte>(0);
        }

        public List<PaletteElement> GetPalette()
        {
            return new List<PaletteElement>() { new PaletteElement(element, (short)(size * size * size)) };
        }
    }
    public class InDirectPalette : IContainer
    {
        public List<PaletteElement> Palette;
        public short[] data;

        public byte size;
        public byte BitsPerEntry => (byte)Math.Ceiling(Math.Log(Palette.Count, 2));

        /// <summary>
        /// O(1)
        /// </summary>
        /// <param name="single_palette"></param>
        /// <param name="size"></param>
        public InDirectPalette(SinglePalette single_palette)
        {
            this.size = single_palette.size;
            data = new short[size * size * size];
            Palette = new List<PaletteElement>() { new PaletteElement(single_palette.element, (short)data.Length) };
        }
        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="direct_palette"></param>
        public InDirectPalette(DirectPalette direct_palette)
        {
            var newpalette = new List<PaletteElement>();
            data = new short[direct_palette.data.Length];
            size = direct_palette.size;
            for (int k = 0; k < data.Length; k++)
            {
                var el = data[k];
                int index = newpalette.FindIndex(x => x.value == el);
                if (index == -1)
                {
                    index = newpalette.Count;
                    newpalette.Add(new PaletteElement(el, 0));
                }
                //Inc count by index
                var t = newpalette[index];
                t.count++;
                newpalette[index] = t;
                //Set data at k
                data[k] = (short)index;
            }
            Palette = newpalette;
        }
        public InDirectPalette(byte size)
        {
            this.size = size;
            Palette = new List<PaletteElement>() { new PaletteElement(0, (short)(size * size * size)) };
            data = new short[size * size * size];
        }
        public InDirectPalette(List<short> palette, short[] data, byte size)
        {
            this.size = size;
            PaletteElement[] paletteElements = palette.Select(x => new PaletteElement(x, 0)).ToArray();
            this.data = data;
            
            for (int k = 0; k < data.Length; k++)
                paletteElements[data[k]].count++;
            
            Palette = paletteElements.ToList();
        }
        public short Get(int rx, int ry, int rz)
        {
            return Palette[data[ry * size * size + rz * size + rx]].value;
        }

        public void Set(int rx, int ry, int rz, short item)
        {
            short index = (short)Palette.FindIndex(x => x.value == item);
            if (index == -1)
            {
                index = (short)Palette.Count;
                Palette.Add(new PaletteElement(item, 0));
            }

            int offset = ry * size * size + rz * size + rx;
            short lastindex = data[offset];

            //deinc count by last index
            var t = Palette[lastindex];
            t.count--;
            Palette[lastindex] = t;

            //inc count by index
            t = Palette[index];
            t.count++;
            Palette[index] = t;

            //set data
            data[offset] = index;

            //Clean up palette
            CleanUp();
            void CleanUp()
            {
                for (short k = 0; k < Palette.Count; k++)
                {
                    if (Palette[k].count != 0) continue;

                    if (Palette.Count == k + 1)
                    {
                        Palette.RemoveAt(k);
                        return;
                    }
                    else
                    {
                        int newindex = k + 1;
                        Palette[k] = Palette[newindex];
                        t = Palette[newindex];
                        t.count = 0;
                        Palette[newindex] = t;

                        for (int i = 0; i < data.Length; i++)
                        {
                            if (data[i] == newindex)
                                data[i] = k;
                        }
                    }
                }
            }

            ////Palette.RemoveAll(x => x.count == 0);
            ////Тест 1 - все указатели в данных должны вести в палитру
            //if (data.Any(x => x >= Palette.Count))
            //{
            //    var index2 = data.ToList().FindIndex(x => x >= Palette.Count);
            //    ;
            //}
            ////Тест 2 - сумма всей палитры должна равняться 4096
            //int sum = Palette.Sum(x => x.count);
            //if (sum != 4096)
            //    ;
            ////Тест 3 - прочесав всю дату можно составить данные кол-ва блоков из палитры
            ////Тест 4 - палитра не содержит элементов с одинаковым состоянием
        }
        public void Write(ArrayWriter writer)
        {
            writer.Write(Palette.Select(x => new VarInt(x.value)).ToArray());

            //Мне лень делать полностью
            byte min = 0;
            if (size == 16)
                min = 4;
            if (size == 4)
                min = 3;
            //

            writer.Write(PackData(size, Math.Max(min, BitsPerEntry), data));
        }

        public List<PaletteElement> GetPalette()
        {
            return Palette;
        }
    }
    public class DirectPalette : IContainer
    {
        public short[] data;

        public byte bitsPerEntry;
        public byte size;
        public DirectPalette(InDirectPalette inDirect_palette, byte bitsPerEntry)
        {
            data = new short[inDirect_palette.data.Length];
            this.bitsPerEntry = bitsPerEntry;
            size = inDirect_palette.size;
            for (int k = 0; k < data.Length; k++)
                data[k] = inDirect_palette.Palette[inDirect_palette.data[k]].value;
        }
        public DirectPalette(byte size, byte bitsPerEntry)
        {
            this.bitsPerEntry = bitsPerEntry;
            this.size = size;

            data = new short[size * size * size];
        }
        public DirectPalette(short[] data, byte size, byte bitsPerEntry)
        {
            this.bitsPerEntry = bitsPerEntry;
            this.size = size;
            this.data = data;
        }

        public byte BitsPerEntry => bitsPerEntry;

        public short Get(int rx, int ry, int rz)
        {
            return data[ry * size * size + rz * size + rx];
        }

        public void Set(int rx, int ry, int rz, short item)
        {
            data[ry * size * size + rz * size + rx] = item;
        }

        public List<PaletteElement> GetPalette()
        {
            List<PaletteElement> palette = new List<PaletteElement>();
            for (int k = 0; k < data.Length; k++)
            {
                var t = data[k];
                int index = palette.FindIndex(x => x.value == t);
                if (index == -1)
                {
                    palette.Add(new PaletteElement(t, 1));
                    continue;
                }
                var a = palette[index];
                a.count++;
                palette[index] = a;
            }
            return palette;
        }

        public void Write(ArrayWriter writer)
        {
            writer.Write(PackData(size, BitsPerEntry, data));
        }
    }
}