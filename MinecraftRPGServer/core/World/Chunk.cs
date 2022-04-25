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
    public ChunkSection[] sections;
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
        var block_entities = nbt["block_entities"] as TAG_List;
        
        if (block_entities != null && block_entities.data.Count > 0)
        {
            byte f(int x) => (byte)(x & 0xF);
            BlockEntities = new BlockEntity[block_entities.data.Count];

            int index = 0;
            foreach (var ent in block_entities.data)
            {
                BlockEntities[index++] = new BlockEntity()
                {
                    blockX = f(ent["x"] as TAG_Int),
                    blockZ = f(ent["z"] as TAG_Int),
                    Y = (short)(ent["y"] as TAG_Int),
                    Type = BlockEntity.Types[ent["id"] as TAG_String],
                    Data = (ent as TAG_Compound).RemoveTags(new string[] { "x", "y", "z", "id" })
                };
            }
        }

        var Sections = (nbt["sections"] as TAG_List).data;

        sbyte miny = Sections.Min(x => (x["Y"] as TAG_Byte).data);
        sections = new ChunkSection[Sections.Count];
        for (int k = 0; k < Sections.Count; k++)
        {
            var section = new ChunkSection(Sections[k]);
            sections[section.Y - miny] = section;
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
        List<byte[]> skylight = new List<byte[]>(sections.Length);
        List<byte[]> blocklight = new List<byte[]>(sections.Length);
        for (int k = 0; k < sections.Length; k++)
        {
            var section = sections[k];

            if (section == null) continue;

            if (section.SkyLight != null)
                skylight.Add(section.SkyLight);
            if (section.BlockLight != null)
                blocklight.Add(section.BlockLight);

            int index = k + 1;

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
            writer.WriteRaw(section.Bytes);
        Data = writer.ToArray();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FromAbsolutePosition(float absT) => (int)absT >> 4;
    public static v2i FromAbsolutePosition(v2f absT) => new v2i(FromAbsolutePosition(absT.x), FromAbsolutePosition(absT.y));
    public static v2i FromAbsolutePosition(v3f absT) => new v2i(FromAbsolutePosition(absT.x), FromAbsolutePosition(absT.z));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetRelativeCoord(int x) => x & 0xF;
}