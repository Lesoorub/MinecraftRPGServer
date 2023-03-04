using Packets.Play;

namespace WorldSystemV2
{
    public interface IChunk
    {
        IWorld World { get; set; }
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
        void Tick();
        BlockState GetBlock(byte rx, short y, byte rz);
        bool SetBlock(byte rx, short y, byte rz, BlockState newState);

        byte[] ExportToBytes();
    }
}
