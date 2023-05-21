//#define ON_SAVE_TESTING
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Compressions;
using Entities;
using MineServer;
using NBT;
using Rust.Option;
using WorldSystemV2;
public partial class MCA
{

    #region Fields

    #region Private

    ConcurrentDictionary<v2i, Chunk> chunks = new ConcurrentDictionary<v2i, Chunk>(v2iComparer.Instance);
    readonly CompressionScheme GlobalCompressionScheme = CompressionScheme.zlib;
    byte[] location_table_raw;
    byte[] timestamp_table_raw;
    byte[] chunks_raw;

    #endregion

    #endregion

    #region Constructors
    
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

    #endregion

    #region Methods

    #region Public

    public IEnumerable<KeyValuePair<v2i, Chunk>> Chunks => chunks;
    public bool HasChunk(int rx, int rz)
    {
        var t = new v2i(rx, rz);
        if (chunks.ContainsKey(t))
            return true;
        return ChunkSpawned(GetChunkIndex(rx, rz));
    }
    public Option<Chunk> GetChunk(int rx, int rz)
    {
        var t = new v2i(rx, rz);

        if (chunks.TryGetValue(t, out var chunk))
        {
            return Option<Chunk>.Some(chunk);
        }
        else
        {
            return LoadChunk(rx, rz);
        }
    }
    public byte[] ToByteArray()
    {
        return FastByteArrayExtensions.Combine(location_table_raw, timestamp_table_raw, chunks_raw);
    }
    public void SaveChunks()
    {
        if (chunks.All(predicate: pair =>
            GetTimestump(pair.Key.x, pair.Key.y) == pair.Value.LastModifyTimeStamp))
            return;


        var pages = new Dictionary<v2i, (byte[] data, int timestump)>();
        lock (chunks)
        {
            //collect chunks
            v2i.ForEach(new v2i(32, 32), (cpos) =>
            {
                int i = GetChunkIndex(cpos.x, cpos.y);

                int timestump = GetTimestump(i);

                if (chunks.TryGetValue(cpos, out var chunk) && chunk.LastModifyTimeStamp != timestump)
                {
                    pages.Add(cpos,(CompressChunk(chunk), (int)chunk.LastModifyTimeStamp));
                }
                else if (ChunkSpawned(i))
                {
                    pages.Add(cpos,(GetFullPages(i, out _), timestump));
                }
            });
        }

        //compile arrays
        // location_table_raw
        // timestamp_table_raw
        // chunks_raw

        int totalPages = pages.Sum(x => GetChunkPages(x.Value.data.Length));
        location_table_raw = new byte[4096];
        timestamp_table_raw = new byte[4096];
        chunks_raw = new byte[totalPages * 4096];
        int pageIndex = 0;
        foreach (var pair in pages)
        {
            var (page, timestump) = pair.Value;
            byte size = GetChunkPages(page.Length);
            //write chunk data
            Buffer.BlockCopy(
                page,
                0,
                chunks_raw,
                pageIndex * 4096,
                page.Length);
            //write location
            var i = GetChunkIndex(pair.Key.x, pair.Key.y);
            var loc = new Location(pageIndex + 2, size);
            loc.Write(
                location_table_raw,
                i);
            //write timestamp
            Buffer.BlockCopy(
                BitConverter.GetBytes(timestump).Reverse(),
                0,
                timestamp_table_raw,
                i,
                4);
            pageIndex += size;
        }
#if ON_SAVE_TESTING
        //testing
        v2i.ForEach(new v2i(32, 32), (cpos) =>
        {
            int i = GetChunkIndex(cpos.x, cpos.y);
            if (!ChunkSpawned(i)) return;
            if (TryGetChunkData(cpos.x, cpos.y, out var data))
            {
                var c = new Chunk(data);
            }
        });
#endif
    }

    #endregion

    #region Private

    Option<Chunk> LoadChunk(int rx, int rz)
    {
        if (!ChunkSpawned(GetChunkIndex(rx, rz)) ||
            !TryGetChunkData(rx, rz, out var data))
            return CreateChunk(rx, rz);

        return new Option<Chunk>(() =>
        {
            var cpos = new v2i(rx, rz);
            var nbt = new NBTTag(data);
            return new Chunk(cpos, nbt, GetTimestump(rx, rz));
        });
    }
    byte[] CompressChunk(IChunk chunk)
    {
        var bytes = chunk.ExportToBytes();

#if ON_SAVE_TESTING
        try
        {
            var c = new Chunk(bytes);
        }
        catch (Exception ex)
        {
            throw new Exception("При попытке прочитать только что собранный чанк появилось исключение. " + ex);
        }
#endif
        byte[] compressed = bytes;
        switch (GlobalCompressionScheme)
        {
            case CompressionScheme.gzip:
                if (!GZip.TryCompress(bytes, out compressed))
                    throw new Exception("Error while zlib compressed chunk");
                break;
            case CompressionScheme.zlib:
                if (!zlib.TryCompress(bytes, out compressed))
                    throw new Exception("Error while zlib compressed chunk");
                break;
        }

#if ON_SAVE_TESTING
        var result =
#else
        return 
#endif
        FastByteArrayExtensions.Combine(
            BitConverter.GetBytes(compressed.Length + 1).Reverse(),//Big Endian
            new byte[] { (byte)GlobalCompressionScheme },
            compressed);
#if ON_SAVE_TESTING
        int Length = BitConverter.ToInt32(result.BigEndian(0, 4), 0) - 1;
        if (Length < 0 || Length > result.Length)
            throw new Exception("Wrong length of chunk in his pages");
        if (Length != compressed.Length)
            throw new Exception("FastByteArrayExtensions.Combine is wrong");
        if ((CompressionScheme)result[4] != GlobalCompressionScheme)
            throw new Exception("FastByteArrayExtensions.Combine is wrong");
        return result;
#endif

    }
    Option<Chunk> CreateChunk(int rx, int rz)
    {
        return new Option<Chunk>(() =>
        {
            var cpos = new v2i(rx, rz);
            var chunk = new Chunk(cpos);

            if (!chunks.TryAdd(cpos, chunk))
                throw new Exception("Can't add chunk in chunks");
            return chunk;
        });
    }
    byte[] GetFullPages(int index, out int Length)
    {
        Length = 0;
        Location location = new Location(location_table_raw, index);
        if (!location.isValid)
            return null;

        var pages = chunks_raw.Take((location.Offset - /*вычитаются размеры двух первых таблиц*/2) * 4096, location.Size * 4096);
        //Raw struture:
        //length: 4 (bigEndian)
        //compressionType: 1 (CompressionScheme enum)
        //compressedChunkData : (length - 1)
        Length = BitConverter.ToInt32(pages.BigEndian(0, 4), 0) - 1;
        if (Length < 0 || Length > pages.Length)
            throw new Exception("Wrong length of chunk in his pages");
        return pages;
    }
    byte[] GetCompressedChunkData(int index, out CompressionScheme compressionScheme)
    {
        var pages = GetFullPages(index, out var Length);
        compressionScheme = (CompressionScheme)pages[4];
        return pages.Take(5, Length);
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
                return GZip.TryDecompress(compressedData, out data);

            case CompressionScheme.zlib:
                return zlib.TryDecompress(compressedData, out data);

            case CompressionScheme.none:
                data = compressedData;
                return true;

            default:
                throw new Exception("Not supported compression scheme");
        }
    }
    bool ChunkSpawned(int index)
    {
        return new Location(location_table_raw, index).isValid;
    }
    int GetChunkIndex(int rx, int rz)
    {
        const int chunkSizeInBytes = 4;
        const int regionSizeX = 32;
        const int regionSizeY = 32;
        return ((rx % regionSizeX) + (rz % regionSizeY) * regionSizeX) * chunkSizeInBytes;
    }
    byte GetChunkPages(int bytes_length) => (byte)Math.Ceiling((float)bytes_length / 4096);
    int GetTimestump(int index)
    {
        return BitConverter.ToInt32(
                timestamp_table_raw.Take(
                    index,
                    4)
                .Reverse(),
                0);
    }
    int GetTimestump(int rx, int rz)
    {
        return GetTimestump(GetChunkIndex(rx, rz));
    }

    #endregion

    #endregion

    //chunk:
    //[length:be_int4]
    //[compressionType:int1]
    //[compressionChunkData:(length-1)]
    //
    //mca:
    //[{[offset:be_int3][size:int1]}:4096]
    //[timestamp_table:int[4096]]
    //[pages:*]
    enum CompressionScheme : byte
    {
        gzip = 1,
        zlib = 2,
        none = 3
    }
}


namespace SpaceMan
{
    public static class SpaceUtil
    {
        /// <summary>
        /// Ищет пустое место в массиве страниц
        /// </summary>
        /// <param name="locations">Массив данных абсолютных смещений</param>
        /// <param name="data">Массив страниц</param>
        /// <param name="sizeInPages">Искомое пустое место в страницах</param>
        /// <returns>Относительное смещение, либо -1, если места нет</returns>
        public static int GetEmptyPage(byte[] locations, byte[] data, int sizeInPages)
        {
            bool[] pages = new bool[(int)Math.Ceiling(data.Length / 4096f)];
            for (int k = 0; k < 4096; k += 4)
            {
                var loc = new MCA.Location(locations, k);
                if (!loc.isValid)
                    continue;
                int relativeOffset = loc.Offset - 2;
                for (int i = relativeOffset; i < relativeOffset + loc.Size; i++)
                {
                    pages[i] = true;
                }
            }
            int tmp = 0;
            for (int k = 0; k < pages.Length; k++)
            {
                if (!pages[k])
                {
                    tmp++;
                    if (tmp >= sizeInPages)
                    {
                        return k;
                    }
                }
                else
                {
                    tmp = 0;
                }
            }
            return -1;
        }
    }
}