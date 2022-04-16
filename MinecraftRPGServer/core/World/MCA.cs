using System;
using System.Collections.Generic;
using System.Linq;
using MineServer;

public class MCA
{
    Dictionary<v2i, Chunk> chunks = new Dictionary<v2i, Chunk>();
    public byte[] location_table_raw;
    public byte[] timestamp_table_raw;
    public byte[] chunks_raw;
    public MCA()
    {
        location_table_raw = new byte[4096];
        timestamp_table_raw = new byte[4096];
    }
    public MCA(byte[] raw)
    {
        location_table_raw = raw.Take(4096);
        timestamp_table_raw = raw.Take(4096, 4096);
        chunks_raw = raw.Skip(4096 * 2);
    }
    public Chunk GetChunk(int rx, int rz)
    {
        var t = new v2i(rx, rz);
        if (!chunks.ContainsKey(t))
        {
            var c = LoadChunk(rx, rz);
            chunks[t] = c;
            return c;
        }
        return chunks[t];
    }
    public Chunk LoadChunk(int rx, int rz)
    {
        int index = ((rx % 32) + (rz % 32) * 32) * 4;
        if (index < 0)
#if DEBUG
            throw new Exception("Попытка чтений данных вне файла");
#else
            return null;
#endif
        int offset = BitConverter.ToInt32(location_table_raw.BigEndian(index, 3).Combine(0), 0);
        int size = location_table_raw[index + 3];
        if (offset == 0 && size == 0)
            return null;
        byte[] raw = chunks_raw.Take((offset - 2) * 4096, size * 4096);
        //chunk header
        int Length = BitConverter.ToInt32(raw.BigEndian(0, 4), 0) - 1;
        byte compressionScheme = raw[4];
        //chunk data
        if (compressionScheme == 1)
            return new Chunk(GZip.Decompress(raw.Take(5, Length)));
        else if (compressionScheme == 2)
            return new Chunk(zlib.Decompress2(raw.Take(5, Length)));
        else if (compressionScheme == 3)
            return new Chunk(raw.Take(5, Length));
        return null;// throw new Exception("Not supported compression scheme");
    }
}