using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NBT;
using Packets.Play;
using WorldSystemV2;

public class Chunk : IChunk
{
    #region Fields
    
    public IWorld World { get; set; }
    public NBTTag Heightmaps = new NBTTag();
    public v2i cPos;
    public SortedDictionary<int, ChunkSection> sections = new SortedDictionary<int, ChunkSection>();
    public BlockEntityData[] BlockEntities = new BlockEntityData[0];
    /// <summary>
    /// Данные о секциях
    /// </summary>
    byte[] data;
    public long LastModifyTimeStamp;
    public const bool TrustEdges = true;
    ChunkDataAndUpdateLight _packet;//for cache packet
    long _packet_LastModifyTimeStamp;//for cache packet

    #endregion

    #region Valid check
    public bool IsValid =>  
        IsValid_Heightmaps 
        && IsValid_cPos 
        && IsValid_sections
        && IsValid_BlockEntities
        && IsValid_LastModifyTimeStamp;
    public bool IsValid_Heightmaps => Heightmaps != null;
    public bool IsValid_cPos => cPos != null;
    public bool IsValid_sections => sections != null && 
        sections.All(x => x.Value.IsValid);
    public bool IsValid_BlockEntities => BlockEntities != null;
    public bool IsValid_LastModifyTimeStamp => LastModifyTimeStamp != 0;
    #endregion

    #region Properties

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
                    TrustEdges = TrustEdges,
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

    #endregion

    public Chunk(v2i cpos)
    {
        this.cPos = cpos;
        UpdateData();
        UpdateLight();
    }
    public Chunk(v2i cpos, NBTTag nbt, int Timestump)
    {
        this.cPos = cpos;
        this.LastModifyTimeStamp = Timestump;
        ChunkParser.Parse(this, nbt);
        UpdateData();
        UpdateLight();
    }

    static Random rnd = new Random();
    public void Tick(IWorld World)
    {
        foreach (var entityData in BlockEntities)
        {
            if (!BlockEntityAttribute.Get((BlockEntityID)entityData.Type.value, out var blockEntity))
                continue;
            blockEntity.SetState(World, X * 16 + entityData.blockX, entityData.Y, Z * 16 + entityData.blockZ, entityData);
            blockEntity.Tick();
        }
        for (int k = 0; k < World.Info.RandomTickSpeed; k++)
        {
            byte rx = (byte)rnd.Next(0, 16);
            short y = (short)rnd.Next(global::World.MinBlockHeight, global::World.MaxBlockHeight + 1);
            byte rz = (byte)rnd.Next(0, 16);

            var block = GetBlock(rx, y, rz);

            if (BlockLogicAttribute.TryGetLogic(block.id, out var logic))
            {
                logic.SetState(World, X * 16 + rx, y, Z * 16 + rz, block);
                logic.OnRandomTick();
            }
        }
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
        if (y > global::World.MaxBlockHeight || y < global::World.MinBlockHeight) return false;
        var sectionY = MinecraftCoordinatesSystem.PosToChunk1D(y);
        var section = sections[sectionY];
        if (section == null)
            sections.Add(sectionY, section = new ChunkSection());
        section.SetBlock(rx, GetRelativeCoord(y), rz, blockState);
        IsChanged();
        return true;
    }
    public bool SetBlock(byte rx, short y, byte rz, BlockState newState)
    {
        return SetBlock((byte)rx, (short)y, (byte)rz, newState.StateID);
    }
    public void IsChanged()
    {
        this.isChanged = true;
        LastModifyTimeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetRelativeCoord(int x) => x & 0xF;
    public BlockState GetBlock(byte rx, short y, byte rz)
    {
        if (y > global::World.MaxBlockHeight || y < global::World.MinBlockHeight) return BlockState.air;
        var section = sections[MinecraftCoordinatesSystem.PosToChunk1D(y)];
        if (section == null) return BlockState.air;
        return section.GetBlock(rx, y, rz);
    }
    public byte[] ExportToBytes()
    {
        return ChunkParser.Serialize(this).Bytes;
    }

    public void SetMultiBlocks(IStructureSection structureSection)
    {
        throw new NotImplementedException();
    }
}