public interface IBlock
{
    BlockState PlaceBlock(Player player, v3i pos, Direction face, v3f cursorPos, BlockState placedOn);
}
