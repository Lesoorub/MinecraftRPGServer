namespace Blocks
{
    [Block(DefaultBlockState.glowstone)]
    public class GlowStone : IWorldBlock
    {
        public float hardness => 0.3f;
        public bool hasCollision => true;
    }
}