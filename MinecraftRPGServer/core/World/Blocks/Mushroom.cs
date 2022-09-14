namespace Blocks
{
    [Block(DefaultBlockState.brown_mushroom)]
    [Block(DefaultBlockState.red_mushroom)]
    [Block(DefaultBlockState.crimson_fungus)]
    [Block(DefaultBlockState.warped_fungus)]
    public class Mushroom : IWorldBlock
    {
        public float hardness => 0;
        public bool hasCollision => false;
    }
}