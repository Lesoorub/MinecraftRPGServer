namespace Blocks
{
    [Block(DefaultBlockState.dandelion)]
    [Block(DefaultBlockState.poppy)]
    [Block(DefaultBlockState.blue_orchid)]
    [Block(DefaultBlockState.allium)]
    [Block(DefaultBlockState.azure_bluet)]
    [Block(DefaultBlockState.red_tulip)]
    [Block(DefaultBlockState.orange_tulip)]
    [Block(DefaultBlockState.white_tulip)]
    [Block(DefaultBlockState.pink_tulip)]
    [Block(DefaultBlockState.oxeye_daisy)]
    [Block(DefaultBlockState.cornflower)]
    [Block(DefaultBlockState.lily_of_the_valley)]
    [Block(DefaultBlockState.wither_rose)]
    public class Flower : IWorldBlock
    {
        public float hardness => 0;
        public bool hasCollision => false;
    }
}