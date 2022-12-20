using System.Linq;
using MinecraftData._1_18_2;
using MinecraftData._1_18_2.blocks.minecraft;

public struct BlockState
{
    public short StateID;
    public BlockNameID id { get => GlobalPalette.GetNameID(StateID); }
    public bool solid { get => StateID > 0; }
    public IBlockData iBlockData =>
        GlobalPalette.GetBlockData(StateID);
        //BlockAttribute.blocks.TryGetValue(defaultBlockState, out var iWorldBlock) ? (iWorldBlock, false) : (default, true);
    public bool haveCollision
    {
        get
        {
            var block = iBlockData;
            var collisionShape = block.States.First(x => x.Id == block.DefaultStateID).CollisionShape;
            return collisionShape.HasValue || collisionShape.Value == 0;
        }
    }
    public DefaultBlockState defaultBlockState => GlobalPalette.GetDefaultStateID(StateID);
    public float hardness => BlockAttribute.blocks.TryGetValue(defaultBlockState, out var v) ? v.hardness : -1;

    public BlockState(short StateID)
    {
        this.StateID = StateID;
    }

    public static readonly BlockState air = new BlockState((int)DefaultBlockState.air);

    public static bool operator ==(BlockState a, DefaultBlockState b) => a.StateID == (short)b;
    public static bool operator !=(BlockState a, DefaultBlockState b) => a.StateID != (short)b;

    public override bool Equals(object obj)
    {
        return obj is BlockState state &&
               StateID == state.StateID;
    }

    public override int GetHashCode()
    {
        return -1778456669 + StateID.GetHashCode();
    }
}
