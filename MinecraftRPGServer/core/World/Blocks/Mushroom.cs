namespace Blocks
{
    [Block(BlockID.brown_mushroom)]
    [Block(BlockID.red_mushroom)]
    [Block(BlockID.crimson_fungus)]
    [Block(BlockID.warped_fungus)]
    public class Mushroom : IWorldBlock
    {
        public float hardness => 0;
        public bool hasCollision => false;
    }
}