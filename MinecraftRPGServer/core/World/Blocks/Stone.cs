namespace Blocks
{
    [Block(BlockID.stone)]
    public class Stone : IWorldBlock
    {
        public float hardness => 1.5f;
        public bool hasCollision => true;
    }
}