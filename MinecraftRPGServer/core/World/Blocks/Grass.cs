namespace Blocks
{
    [Block(BlockID.grass)]
    [Block(BlockID.fern)]
    [Block(BlockID.tall_grass)]
    [Block(BlockID.large_fern)]
    public class Grass : IWorldBlock
    {
        public float hardness => 0;
        public bool hasCollision => false;
    }
}