public struct BlockState
{
    public int StateID;
    public string id { get => default; }
    public bool solid { get => StateID > 0; }
    public bool hasShadow { get => solid; }
    public bool haveCollision 
    { 
        get => 
            BlockAttribute.blocks.TryGetValue(blockid, out var iWorldBlock) 
            ? iWorldBlock.hasCollision :
            StateID != 0; 
    }
    public BlockID blockid => GlobalPalette.GetBlockID(StateID);
    public float hardness => BlockAttribute.blocks.TryGetValue(blockid, out var v) ? v.hardness : -1;
    public BlockState(int StateID)
    {
        this.StateID = StateID;
    }
    public static readonly BlockState air = new BlockState((int)DefaultBlockState.air);
}
