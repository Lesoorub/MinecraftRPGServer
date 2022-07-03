using MineServer;
public class ChunkSection
{
    public sbyte Y;
    public PalettedContrainer biomes;
    public PalettedContrainer block_states;

    public byte[] SkyLight;
    public byte[] BlockLight;

    public short BlockCount;
    public byte BitsPerBlock;

    public bool isChanged = false;

    public short GetNumberOfBlocks()
    {
        short BlockCount = 0;
        if (block_states == null)
            return BlockCount;
        int airindex = block_states.Palette.data.FindIndex(x => x == 0);
        if (block_states.type == PaletteType.Single)
        {
            BlockCount = (short)(airindex == -1 ? 4096 : 0);
            return BlockCount;
        }
        var dat = block_states.data;
        for (int k = 0; k < dat.Length; k++)
        {
            if (dat[k] != airindex)
                BlockCount++;
        }
        return BlockCount;
    }
    public byte[] GetBytes() 
    {
        var writer = new ArrayWriter();
        writer.Write(BlockCount);
        writer.WriteRaw(block_states.ToByteArray((tag) => tag));
        writer.WriteRaw(biomes.ToByteArray((tag) => 0));
        return writer.ToArray();
    }
    public BlockState GetBlock(int rx, int ry, int rz)
    {
        if (block_states.data != null)
            return new BlockState(
                block_states.Palette.data[
                    block_states.GetData(rx, ry, rz)
                    ]);
        else return BlockState.air;
    }
    public void SetBlock(int rx, int ry, int rz, short StateID)
    {
        block_states.Add(rx, ry, rz, StateID);
        isChanged = true;
    }

    public override string ToString()
    {
        return $"Y={Y}, BlockCount={BlockCount}, SkyLight?={SkyLight != null}, BlockLight?={BlockLight != null}";
    }
}
