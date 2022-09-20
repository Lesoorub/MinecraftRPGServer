using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using MineServer;
public class MCA
{
    ConcurrentDictionary<v2i, Chunk> chunks = new ConcurrentDictionary<v2i, Chunk>(v2iComparer.Instance);
    public byte[] location_table_raw;
    public byte[] timestamp_table_raw;
    public byte[] chunks_raw;
    readonly CompressionScheme GlobalCompressionScheme = CompressionScheme.zlib;
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
            if (c == null)
                throw new Exception("Can't load chunk");
            return c;
        }
        return chunks[t];
    }
    public Chunk LoadChunk(int rx, int rz)
    {
        if (!ChunkSpawned(GetChunkIndex(rx, rz)))
            return CreateChunk(rx, rz);
        if (!TryGetChunkData(rx, rz, out var data)) 
            return CreateChunk(rx, rz);
        try
        {
            var chunk = new Chunk(data);
            var cpos = new v2i(rx, rz);
            if (!chunks.TryAdd(cpos, chunk))
                return chunks[cpos];
            return chunk;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return null;
        }
    }
    public void SaveChunks()
    {
        byte[] Format(byte[] data, CompressionScheme compressionScheme)
        {
            return BitConverter.GetBytes(data.Length + 1)
                .Reverse()
                .Combine((byte)compressionScheme)
                .Combine(data);
        }

        lock (chunks)
        {
            List<byte[]> raw = new List<byte[]>();

            int page = 0;
            v2i.ForEach(new v2i(32, 32), (cpos) =>
            {
                int i = GetChunkIndex(cpos.x, cpos.y);
                byte[] compressed_chunk = null;
                if (chunks.ContainsKey(cpos))
                {
                    var compressed = CompressLoadedChunk(cpos, out _);
                    if (compressed != null)
                        compressed_chunk = Format(compressed, GlobalCompressionScheme);
                }
                else
                {
                    if (ChunkSpawned(i))
                        compressed_chunk = Format(GetCompressedChunkData(i, out var scheme), scheme);
                }
                if (compressed_chunk == null)
                {
                    Buffer.BlockCopy(BitConverter.GetBytes(0), 0, location_table_raw, i, 4);
                    return;
                }

                Buffer.BlockCopy(BitConverter.GetBytes(page + 2).Take(3).Reverse(), 0, location_table_raw, i, 3);
                byte size = (byte)GetChunkPages(compressed_chunk.Length);
                location_table_raw[i + 3] = size;
                page += size;

                raw.Add(compressed_chunk);

            });
            timestamp_table_raw = new byte[4096];

            int offset = 0;
            chunks_raw = new byte[page * 4096];
            foreach (var r in raw)
            {
                Buffer.BlockCopy(r, 0, chunks_raw, offset, r.Length);
                offset += GetChunkPages(r.Length) * 4096;
            }
        }
    }
    public byte[] ToByteArray()
    {
        return FastByteArrayExtensions.Combine(location_table_raw, timestamp_table_raw, chunks_raw);
    }

    Chunk CreateChunk(int rx, int rz)
    {
        var cpos = new v2i(rx, rz);
        var chunk = new Chunk(cpos);
        if (!chunks.TryAdd(cpos, chunk))
            throw new Exception("Can't add chunk in chunks");
        return chunk;
    }
    enum CompressionScheme : byte
    {
        gzip = 1,
        zlib = 2,
        none = 3
    }
    byte[] GetCompressedChunkData(int index, out CompressionScheme compressionScheme)
    {
        compressionScheme = 0;
        int offset = BitConverter.ToInt32(location_table_raw.BigEndian(index, 3).Combine(0), 0);
        int size = location_table_raw[index + 3];
        if (offset == 0 && size == 0)
            return null;
        var raw = chunks_raw.Take((offset - 2) * 4096, size * 4096);
        //Raw struture:
        //length: 4 (bigEndian)
        //compressionType: 1 (CompressionScheme enum)
        //compressedChunkData : (length - 1)
        int Length = BitConverter.ToInt32(raw.BigEndian(0, 4), 0) - 1;
        compressionScheme = (CompressionScheme)raw[4];
        return raw.Take(5, Length);
    }
    bool TryGetChunkData(int rx, int rz, out byte[] data)
    {
        data = null;
        int index = GetChunkIndex(rx, rz);
        if (index < 0)
            throw new Exception("Попытка чтений данных вне файла");
        var compressedData = GetCompressedChunkData(index, out var compressionScheme);
        switch (compressionScheme)
        {
            case CompressionScheme.gzip:
                return Compressions.GZip.TryDecompress(compressedData, out data);

            case CompressionScheme.zlib:
                return Compressions.zlib.TryDecompress(compressedData, out data);

            case CompressionScheme.none:
                data = compressedData;
                return true;

            default:
                throw new Exception("Not supported compression scheme");
        }
    }
    bool ChunkSpawned(int index)
    {
        int offset = BitConverter.ToInt32(location_table_raw.BigEndian(index, 3).Combine(0), 0);
        int size = location_table_raw[index + 3];
        if (offset == 0 && size == 0)
            return false;
        return true;
    }
    int GetChunkIndex(int rx, int rz) => ((rx % 32) + (rz % 32) * 32) * 4;
    int GetChunkPages(int bytes_length) => (int)Math.Ceiling((float)bytes_length / 4096);
    byte[] CompressLoadedChunk(v2i cpos, out int pages)
    {
        byte[] bytes = ChunkParser.Serialize(chunks[cpos]).Bytes;
        switch (GlobalCompressionScheme)
        {
            case CompressionScheme.gzip:
                if (!Compressions.GZip.TryCompress(bytes, out bytes))
                {
                    pages = 0;
                    return null;
                }
                break;
            case CompressionScheme.zlib:
                if (!Compressions.zlib.TryCompress(bytes, out bytes))
                {
                    pages = 0;
                    return null;
                }
                break;
        }
        pages = GetChunkPages(bytes.Length);
        return bytes;
    }

}