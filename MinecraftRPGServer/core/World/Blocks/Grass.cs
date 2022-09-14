namespace Blocks
{
    [Block(DefaultBlockState.grass)]
    [Block(DefaultBlockState.fern)]
    [Block(DefaultBlockState.tall_grass)]
    [Block(DefaultBlockState.large_fern)]
    public class Grass : IWorldBlock
    {
        public float hardness => 0;
        public bool hasCollision => false;
    }
}