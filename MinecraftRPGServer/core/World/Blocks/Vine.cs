namespace Blocks
{
    [Block(BlockID.vine)]
    public class Vine : IWorldBlock
    {
        public float hardness => 0;
        public bool hasCollision => false;
    }
}