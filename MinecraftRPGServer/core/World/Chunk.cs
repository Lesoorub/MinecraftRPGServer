using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NBT;
using Packets.Play;
using WorldSystemV2;

public class Chunk : IChunk
{
    public NBTTag Heightmaps = new NBTTag();
    public v2i cPos;
    public SortedDictionary<int, ChunkSection> sections = new SortedDictionary<int, ChunkSection>();
    public BlockEntity[] BlockEntities = new BlockEntity[0];
    byte[] data;
    public long LastModifyTimeStamp;
    public byte[] Data
    {
        get
        {
            if (isChanged)
            {
                UpdateData();
                UpdateLight();
            }
            return data;
        }
    }

    public int X => cPos.x;

    public int Z => cPos.y;

    ChunkDataAndUpdateLight _packet;//for cache packet
    long _packet_LastModifyTimeStamp;//for cache packet
    public ChunkDataAndUpdateLight packet 
    { 
        get
        {
            if (_packet == null || _packet_LastModifyTimeStamp != LastModifyTimeStamp)
            {
                _packet_LastModifyTimeStamp = LastModifyTimeStamp;
                _packet = new ChunkDataAndUpdateLight()
                {
                    ChunkX = X,
                    ChunkZ = Z,
                    Heightmaps = Heightmaps,
                    Data = Data,
                    BlockEntities = BlockEntities,
                    TrustEdges = true,
                    SkyLightMask = SkyMask,
                    BlockLightMask = BlockMask,
                    EmptySkyLightMask = EmptySkyMask,
                    EmptyBlockLightMask = EmptyBlockMask,
                    SkyLightArray = SkyLightArrays,
                    BlockLightArray = BlockLightArrays
                };
            }
            return _packet;
        } 
    }

    public BitSet SkyMask  { get; } = new BitSet();
    public BitSet BlockMask { get; } = new BitSet();
    public BitSet EmptySkyMask { get; } = new BitSet();
    public BitSet EmptyBlockMask { get; } = new BitSet();

    public byte[][] SkyLightArrays { get; protected set; }
    public byte[][] BlockLightArrays { get; protected set; }

    private bool isChanged = false;

    public Chunk(v2i cpos)
    {
        cPos = cpos;
        UpdateData();
        UpdateLight();
    }
    public Chunk(byte[] raw, int Timestump)
    {
        if (raw == null)
            throw new Exception("Невозможно загрузить чанк из массива равного null");
        ChunkParser.Parse(this, new NBTTag(raw));

        UpdateData();
        UpdateLight();

        LastModifyTimeStamp = Timestump;
    }
    public void UpdateLight()
    {
        List<byte[]> skylight = new List<byte[]>(sections.Count);
        List<byte[]> blocklight = new List<byte[]>(sections.Count);
        foreach (var sectionPair in sections)
        {
            var section = sectionPair.Value;

            if (section == null) continue;

            if (section.SkyLight != null)
                skylight.Add(section.SkyLight);
            if (section.BlockLight != null)
                blocklight.Add(section.BlockLight);

            int index = sectionPair.Key + 5;

            SkyMask.Set(index, section.SkyLight != null);
            EmptySkyMask.Set(index, section.SkyLight == null);
            BlockMask.Set(index, section.BlockLight != null);
            EmptyBlockMask.Set(index, section.BlockLight == null);
        }

#if DEBUG
        bool isNormal(long t) => t < 33554431 && t >= 0;

        if (!isNormal(SkyMask.data[0]))
        {
            Console.WriteLine("Anomaly SkyMask data");
        }
        if (!isNormal(EmptySkyMask.data[0]))
        {
            Console.WriteLine("Anomaly EmptySkyMask data");
        }
        if (!isNormal(BlockMask.data[0]))
        {
            Console.WriteLine("Anomaly BlockMask data");
        }
        if (!isNormal(EmptyBlockMask.data[0]))
        {
            Console.WriteLine("Anomaly EmptyBlockMask data");
        }
#endif

        SkyLightArrays = skylight.ToArray();
        BlockLightArrays = blocklight.ToArray();
    }
    public void UpdateData()
    {
        var builder = new ArrayOfBytesBuilder();
        {
            foreach (var section in sections)
                if (section.Key >= -4)
                {
                    builder.Append(section.Value.GetBytes());
                }
            data = builder.ToArray();
        }
        isChanged = false;
    }

    public byte[] GetSkyLightData(int section)
    {
        return sections[section].SkyLight;
    }
    public byte[] GetBlockLightData(int section)
    {
        return sections[section].BlockLight;
    }
    public void SetSkyLightData(int section, byte[] data)
    {
        sections[section].SkyLight = data;
    }
    public void SetBlockLightData(int section, byte[] data)
    {
        sections[section].BlockLight = data;
    }

    public bool SetBlock(byte rx, short y, byte rz, short blockState)
    {
        if (y > 319 || y < -64) return false;
        var section = sections[y >> 4];
        if (section == null)
            sections.Add(y >> 4, section = new ChunkSection());
        section.SetBlock(rx, y % 16, rz, blockState);
        IsChanged();
        return true;
    }
    public void IsChanged()
    {
        this.isChanged = true;
        LastModifyTimeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FromAbsolutePosition(float absT) => (int)absT >> 4;
    public static v2i FromAbsolutePosition(v2f absT) => new v2i(FromAbsolutePosition(absT.x), FromAbsolutePosition(absT.y));
    public static v2i FromAbsolutePosition(v3f absT) => new v2i(FromAbsolutePosition(absT.x), FromAbsolutePosition(absT.z));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetRelativeCoord(int x) => x & 0xF;

    public BlockState GetBlock(byte rx, short y, byte rz)
    {
        if (y > 319 || y < -64) return BlockState.air;
        var section = sections[y >> 4];
        if (section == null) return BlockState.air;
        return section.GetBlock(rx, y, rz);
    }

    public bool SetBlock(byte rx, short y, byte rz, BlockState newState)
    {
        return SetBlock((byte)rx, (short)y, (byte)rz, newState.StateID);
    }

    public byte[] ExportToBytes()
    {
        return ChunkParser.Serialize(this).Bytes;
    }
}