namespace Inventory.Items
{
    [Item(ItemID.stone)]
    public class Stone : Item, IBlock
    {
        public BlockState PlaceBlock(Player player, v3i pos, Direction face, v3f cursorPos, BlockState placedOn)
        {
            return new BlockState(1);
        }
    }
}