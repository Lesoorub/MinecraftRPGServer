namespace Blocks
{
    [Block(BlockID.dead_bush)]
    public class DeadBush : IWorldBlock
    {
        public float hardness => 0;
        public bool hasCollision => false;
    }
}