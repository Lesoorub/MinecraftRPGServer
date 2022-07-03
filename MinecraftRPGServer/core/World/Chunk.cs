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

    public Chunk(v2i cpos)
    {
        cPos = cpos;
    }
    public Chunk(byte[] raw)
    {
        ChunkParser.Parse(this, new NBTTag(raw));

        UpdateData();
        UpdateLight();
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
        var writer = new ArrayWriter();
        foreach (var section in sections)
            if (section.Key >= -4)
                writer.WriteRaw(section.Value.GetBytes());
        Data = writer.ToArray();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int FromAbsolutePosition(float absT) => (int)absT >> 4;
    public static v2i FromAbsolutePosition(v2f absT) => new v2i(FromAbsolutePosition(absT.x), FromAbsolutePosition(absT.y));
    public static v2i FromAbsolutePosition(v3f absT) => new v2i(FromAbsolutePosition(absT.x), FromAbsolutePosition(absT.z));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetRelativeCoord(int x) => x & 0xF;
}