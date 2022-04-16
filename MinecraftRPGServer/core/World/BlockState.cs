public struct BlockState
{
    public int StateID;
    public string id { get => default; }
    public bool solid { get => StateID > 0; }
    public bool hasShadow { get => solid; }
    public bool haveCollision { get => StateID != 0; }
    public BlockState(int StateID)
    {
        this.StateID = StateID;
    }
    public readonly static BlockState air = new BlockState(0);
}
