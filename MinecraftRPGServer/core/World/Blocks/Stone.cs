namespace Blocks
{
    [Block(DefaultBlockState.stone)]
    public class Stone : IWorldBlock
    {
        public float hardness => 1.5f;
        public bool hasCollision => true;
    }
}