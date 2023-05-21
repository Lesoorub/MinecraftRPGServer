using System.Collections.Generic;
using Org.BouncyCastle.Utilities;
using Packets.Play;

namespace WorldSystemV2
{
    public interface IChunk
    {
        int X { get; }
        int Z { get; }

        BitSet SkyMask { get; }
        BitSet BlockMask { get; }
        BitSet EmptySkyMask { get; }
        BitSet EmptyBlockMask { get; }


        byte[][] SkyLightArrays { get; }
        byte[][] BlockLightArrays { get; }

        byte[] Data { get; }
        ChunkDataAndUpdateLight packet { get; }
        void Tick(IWorld World);
        BlockState GetBlock(byte rx, short y, byte rz);
        bool SetBlock(byte rx, short y, byte rz, BlockState newState);
        void SetMultiBlocks(IStructureSection structureSection);
        byte[] ExportToBytes();
    }
    public interface IBlocksStructure
    {
        string Name { get; }
        IEnumerable<IStructureSection> Sections { get; }
        BlockState GetBlock(int x, short y, int z);
        void SetBlock(int x, short y, int z, BlockState state);
    }
    public interface IStructureSection
    {
        long ChunkSectionPosition { get; }
        long[] Blocks { get; }

        BlockState GetBlock(byte rx, byte y, byte rz);
        void SetBlock(byte rx, byte y, byte rz, BlockState state);
    }
}
