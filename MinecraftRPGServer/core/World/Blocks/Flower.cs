namespace Blocks
{
    [Block(BlockID.dandelion)]
    [Block(BlockID.poppy)]
    [Block(BlockID.blue_orchid)]
    [Block(BlockID.allium)]
    [Block(BlockID.azure_bluet)]
    [Block(BlockID.red_tulip)]
    [Block(BlockID.orange_tulip)]
    [Block(BlockID.white_tulip)]
    [Block(BlockID.pink_tulip)]
    [Block(BlockID.oxeye_daisy)]
    [Block(BlockID.cornflower)]
    [Block(BlockID.lily_of_the_valley)]
    [Block(BlockID.wither_rose)]
    public class Flower : IWorldBlock
    {
        public float hardness => 0;
        public bool hasCollision => false;
    }
}