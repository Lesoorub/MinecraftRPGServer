namespace Blocks
{
    [Block(DefaultBlockState.vine)]
    public class Vine : IWorldBlock
    {
        public float hardness => 0;
        public bool hasCollision => false; 
    }
}