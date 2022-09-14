namespace Inventory.Items
{
    [Item(ItemNameID.stone)]
    public class Stone : Item, IItemBlock
    {
        public BlockState PlaceBlock(Player player, v3i pos, Direction face, v3f cursorPos, BlockState placedOn)
        {
            return new BlockState((int)DefaultBlockState.stone);
        }
    }
}