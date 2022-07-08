using MineServer;
using Packets.Play;

[PacketListener(0x2E, State.Play)]
public class OnPlayerBlockPlacement : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var placePacket = packet as PlayerBlockPlacement;
        var player = client as Player;
        if (placePacket == null || player == null) return;

        var pos = placePacket.Location + DirToV3f(placePacket.Face);
        if (player.rpgserver.config.AllowBreakBlocks)
        {
            var placedOn = player.world.GetBlock(placePacket.Location);
            if (placedOn.StateID == 0) 
                return;
            BlockState state;
            IItemBlock item = null;
            switch (placePacket.Hand)
            {
                case PlayerBlockPlacement.HandType.MainHand:
                    item = player.MainHand as IItemBlock;
                    break;
                case PlayerBlockPlacement.HandType.OffHand:
                    item = player.OffHand as IItemBlock;
                    break;
            }
            if (item != null)
            {
                state = item.PlaceBlock(
                    player,
                    pos,
                    placePacket.Face,
                    new v3f(
                        placePacket.CursorPositionX,
                        placePacket.CursorPositionY,
                        placePacket.CursorPositionZ),
                    placedOn);
                if (state.StateID != 0)
                {
                    player.world.SetBlock(player, pos.x, pos.y, pos.z, state);
                }
            }
        }
        player.network.Send(new BlockChange()
        {
            BlockID = new VarInt(player.world.GetBlock(pos).StateID),
            Location = new Position(pos),
        });
    }
    private v3i DirToV3f(Direction face)
    {
        switch (face)
        {
            case Direction.East: return v3i.right;
            case Direction.West: return v3i.left;
            case Direction.South: return v3i.forward;
            case Direction.North: return v3i.back;
            case Direction.Top: return v3i.up;
            case Direction.Bottom: return v3i.down;
        }
        return v3i.zero;
    }
}