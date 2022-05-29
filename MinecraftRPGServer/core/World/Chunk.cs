using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MineServer;
using Packets.Play;

public class Chunk
{
    public NBTTag Heightmaps = new NBTTag();
    public v2i cPos;
    public SortedDictionary<int, ChunkSection> sections = new SortedDictionary<int, ChunkSection>();
    public BlockEntity[] BlockEntities = new BlockEntity[0];
    public byte[] Data;

    public BitSet SkyMask = new BitSet();
    public BitSet BlockMask = new BitSet();
    public BitSet EmptySkyMask = new BitSet();
    public BitSet EmptyBlockMask = new BitSet();

    public byte[][] SkyLightArrays;
    public byte[][] BlockLightArrays;

    public ChunkDataAndUpdateLight BacketPacket;

    public Chunk(v2i cpos)
    {
        cPos = cpos;
    }
    public Chunk(byte[] raw)
    {
        var nbt = new NBTTag(raw);
        Heightmaps = nbt["Heightmaps"];
        cPos = new v2i(nbt["xPos"] as TAG_Int, nbt["zPos"] as TAG_Int);
        TAG_List block_entities = nbt["block_entities"] as TAG_List;
        
        if (block_entities != null && block_entities.data.Count > 0)
        {
            BlockEntities = new BlockEntity[block_entities.data.Count];

            int index = 0;
            foreach (var ent in block_entities.data)
            {
                if (BlockEntity.GetByNameID(ent["id"] as TAG_String, out var type))
                {
                    BlockEntities[index++] = new BlockEntity()
                    {
                        blockX = (byte)(ent["x"] as TAG_Int & 0xF),
                        blockZ = (byte)(ent["z"] as TAG_Int & 0xF),
                        Y = (short)(ent["y"] as TAG_Int),
                        Type = type,
                        Data = (ent as TAG_Compound).RemoveTags(new string[] { "x", "y", "z", "id" })
                    };
                }
            }
        }

        var Sections = (nbt["sections"] as TAG_List).data;

        for (int k = 0; k < Sections.Count; k++)
        {
            var section = new ChunkSection(Sections[k]);
            sections.Add(section.Y, section);
        }

        UpdateData();
        UpdateLight();

        BacketPacket = new ChunkDataAndUpdateLight()
        {
            ChunkX = cPos.x,
            ChunkZ = cPos.y,
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

            int index = sectionPair.Key + 1;

            SkyMask.Set(index, section.SkyLight != null);
            EmptySkyMask.Set(index, section.SkyLight == null);
            BlockMask.Set(index, section.BlockLight != null);
            EmptyBlockMask.Set(index, section.BlockLight == null);
        }
        SkyLightArrays = skylight.ToArray();
        BlockLightArrays = blocklight.ToArray();
    }
    public void UpdateData()
    {
        var writer = new ArrayWriter();
        foreach (var section in sections)
            if (section.Key >= -4)
                writer.WriteRaw(section.Value.Bytes);
        Data = writer.ToArray();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FromAbsolutePosition(float absT) => (int)absT >> 4;
    public static v2i FromAbsolutePosition(v2f absT) => new v2i(FromAbsolutePosition(absT.x), FromAbsolutePosition(absT.y));
    public static v2i FromAbsolutePosition(v3f absT) => new v2i(FromAbsolutePosition(absT.x), FromAbsolutePosition(absT.z));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetRelativeCoord(int x) => x & 0xF;
}