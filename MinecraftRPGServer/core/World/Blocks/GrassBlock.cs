namespace Blocks
{
    [Block(BlockID.grass_block)]
    public class GrassBlock : IWorldBlock
    {
        public float hardness => 0.6f;
        public bool hasCollision => true;
    }
}