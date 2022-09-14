using System;
using System.Linq;
using MineServer;
using Packets.Play;
using MinecraftData._1_18_2.items.minecraft;

[PacketListener(0x2E, State.Play)]
public class OnPlayerBlockPlacement : PacketListener
{
    public override void OnPacketRecieved(IClient client, IPacket packet)
    {
        var placePacket = packet as PlayerBlockPlacement;
        var player = client as Player;
        if (placePacket == null || player == null) return;

        v3i pos = placePacket.Location;

        var placedOn = player.world.GetBlock(placePacket.Location);

        if (!Tags_1_18_2.blocks.replaceable_plants_names.Contains(placedOn.id.ToString()))
        {
            pos += DirToV3f(placePacket.Face);
        }

        //if (placePacket.CursorPositionX == 1 || placePacket.CursorPositionX == 0 ||
        //    placePacket.CursorPositionY == 1 || placePacket.CursorPositionY == 0 ||
        //    placePacket.CursorPositionZ == 1 || placePacket.CursorPositionZ == 0)
        if (!player.rpgserver.config.AllowBreakBlocks)
        {
            player.network.Send(new BlockChange()
            {
                BlockID = new VarInt(player.world.GetBlock(pos).StateID),
                Location = new Position(pos),
            });
            return;
        }


        if (placedOn.StateID == (short)DefaultBlockState.air)//Запрет ставить блок на воздух
            return;

        ICanPlaceBlock item = null;

        //Определяем какой предмет в руке
        switch (placePacket.Hand)
        {
            case PlayerBlockPlacement.HandType.MainHand:
                item = player.MainHand?.itemData as ICanPlaceBlock;
                break;
            case PlayerBlockPlacement.HandType.OffHand:
                item = player.OffHand?.itemData as ICanPlaceBlock;
                break;
        }

        if (item == null)//Если предмета в руке нет - игнор
        {
            return;
        }    

        BlockState state = new BlockState(GlobalPalette.GetBlockData(item.block).DefaultStateID);
        if (state.StateID != 0 && !player.world.SetBlock(player, pos.x, (short)pos.y, pos.z, state))
        {
            player.network.Send(new BlockChange()
            {
                BlockID = new VarInt(player.world.GetBlock(pos).StateID),
                Location = new Position(pos),
            });
            return;
        }
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