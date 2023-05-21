using System;
using MineServer;
using Packets.Play;

public class PlayerAPI
{
    Player player;
    NetworkProvider network => player.network;

    public PlayerAPI(Player player)
    {
        this.player = player;
    }

    public void PlaySound(Sound sound, v3f position, float volume = 1, float pitch = 1)
    {
        network.Send(new SoundEffect()
        {
            SoundID = (int)sound.ID,
            x = (int)Math.Floor(position.x * 8),
            y = (int)Math.Floor(position.y * 8),
            z = (int)Math.Floor(position.z * 8),
            SoundCategory = sound.category,
            Volume = volume,
            Pitch = pitch,
        });
    }
    public void SendCooldown(ItemNameID ItemID, int ticks)
    {
        network.Send(new SetCooldown()
        {
            ItemID = (int)ItemID,
            CooldownTicks = ticks
        });
    }
    public void SendEffect(EffectID EffectID, int x, int y, int z, int Data, bool DisableRelativeVolume)
    {
        network.Send(new Effect()
        {
            EffectID = (int)EffectID,
            Location = new Position(x, y, z),
            Data = Data,
            DisableRelativeVolume = DisableRelativeVolume
        });
    }
    public void SendUpdateHealth()
    {
        network.Send(new UpdateHealth()
        {
            Health = player.Health / player.MaxHealth * 20,
            Food = 20,
            FoodSaturation = 0
        });
    }
    public void SendCollectItem(int WhoIED, int ItemEID, int count)
    {
        network.Send(new CollectItem()
        {
            CollectedEntityID = ItemEID,
            CollectorEntityID = WhoIED,
            PickupItemCount = count
        });
    }
    /// <summary>
    /// Обновить метаданные на своем клиенте и клиентах которые видят игрока
    /// </summary>
    public void SendMetadataUpdate()
    {
        var now = Time.Now();
        bool Send(long last, NetworkProvider net)
        {
            var changes = player.meta.GetMetadataChanges(last);
            if (changes.Length > 1)
            {
                net.Send(new Packets.Play.EntityMetadata()
                {
                    EntityID = player.EntityID,
                    Metadata = changes
                });
                return true;
            }
            return false;
        }

        //Отправляю себе свои изменения метадаты
        if (Send(player.PreviousRecievedMetadata, network))
            player.PreviousRecievedMetadata = now;
        //Отправляю всем видимым игрокам свои изменения метадаты
        foreach (var loaded_ent_pair in player.view.players)
            if (Send(loaded_ent_pair.Value.PreviousMetadataTime, loaded_ent_pair.Value.entity.network))
                loaded_ent_pair.Value.PreviousMetadataTime = now;
    }
    public void StopAllSounds()
    {
        network.Send(new StopSound()
        {
            Flags = 0
        });
    }
    public void Echo(Guid sender, ChatMessage_clientbound.PositionType pos, Chat msg) =>
        network.Send(new ChatMessage_clientbound()
        {
            Sender = sender,
            JSONData = msg.ToString(),
            position = pos
        });
    /// <summary>
    /// Sent when any player is struck by an arrow
    /// </summary>
    public void SendArrayHitSound() =>
        SendChangeGameState(ChangeGameState.ReasonType.ArrowHitPlayer, 0);
    public void SendChangeGamemode(GamemodeType newgm) =>
        SendChangeGameState(ChangeGameState.ReasonType.ChangeGamemode, (byte)newgm);
    public void SendChangeGameState(ChangeGameState.ReasonType reason, float value)
    {
        network.Send(new ChangeGameState()
        {
            Reason = reason,
            Value = value
        });
    }
    public void SendInventory()
    {
        network.Send(new WindowItems()
        {
            WindowID = 0,
            slots = player.inventoryWindow.Slots,
            CarriedItem = player.inventory.CarriedItem.item,
            StateID = player.LastStateID
        });
    }
    public void PlayEntitySound(Sound sound, float volume = 1, float pitch = 1)
    {
        network.Send(new EntitySoundEffect()
        {
            EntityID = player.EntityID,
            SoundID = (int)sound.ID,
            SoundCategory = sound.category,
            Volume = volume,
            Pitch = pitch,
        });
    }
    public void SendEnableRespawnScreen(bool isImmediatelyRespawn) =>
        SendChangeGameState(ChangeGameState.ReasonType.EnableRespawnScreen, isImmediatelyRespawn ? 1 : 0);
    public void SendHeldItemChanged()
    {
        network.Send(new HeldItemChange()
        {
            Slot = player.SelectedSlot,
        });
    }
    public void SendPlayerPositionAndLook()
    {
        network.Send(new PlayerPositionAndLook_clientbound()
        {
            X =     player.Position.x,
            Y =     player.Position.y,
            Z =     player.Position.z,
            Yaw =   player.Rotation.x,
            Pitch = player.Rotation.y,
            TeleportID = TeleportConfirm.NextTeleportID,
            DismountVehicle = false
        });
    }
}