public interface IItemBlock
{
    BlockState PlaceBlock(Player player, v3i pos, Direction face, v3f cursorPos, BlockState placedOn);
}
