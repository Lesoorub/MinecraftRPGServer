using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineServer;
using NBT;

namespace Packets.Play
{
    #region Serverbound
    [BoundToServerPackage]
    public class InteractEntity : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x0D;

        public VarInt EntityID;
        public InteractType Type;
        public RawByteArray additive;

        public enum InteractType : byte
        {
            Interact, Attack, InteractAt
        }
        public class InteractOrAttack : SerializableToBytesBigEndian
        {
            public bool Sneaking;
        }
        public class InteractAt : SerializableToBytesBigEndian
        {
            public float TargetX;
            public float TargetY;
            public float TargetZ;
            public bool Sneaking;
        }
    }
    [BoundToServerPackage]
    public class UseItem : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x2F;

        public VarInt Hand;
    }
    [BoundToServerPackage]
    public class ClientSettings : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x05;

        public string Locale;
        public byte ViewDistance;
        public VarInt ChatMode;
        public bool ChatColors;
        public byte DisplaySkinParts;
        public VarInt MainHand;
        public bool EnableTextFiltering;
        public bool AllowServerListing;
    }

    [BoundToServerPackage]
    public class KeepAlive_serverbound : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x0F;

        public long KeepAliveID;
    }

    [BoundToServerPackage]
    public class TeleportConfirm : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x00;

        public VarInt TeleportID;

        private static int lastTeleportID = 1;
        public static int NextTeleportID { get => lastTeleportID++; }
    }

    [BoundToServerPackage]
    public class PlayerPositionAndRotation_serverbound : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x12;

        public double X;
        public double FeetY;
        public double Z;
        public float Yaw;
        public float Pitch;
        public bool OnGround;
    }

    [BoundToServerPackage]
    public class PlayerRotation : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x13;

        public float Yaw;
        public float Pitch;
        public bool OnGround;
    }

    [BoundToServerPackage]
    public class PlayerPosition : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x11;

        public double X;
        public double FeetY;
        public double Z;
        public bool OnGround;
    }
    [BoundToServerPackage]
    public class ChatMessage_serverbound : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x03;

        public string Message;
    }
    [BoundToServerPackage]
    public class CloseWindow_serverbound : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x09;

        public byte WindowID;
    }
    [BoundToServerPackage]
    public class ClickWindowButton : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x07;

        public byte WindowID;
        /// <summary>
        /// See https://wiki.vg/Protocol#Click_Window_Button
        /// </summary>
        public byte ButtonID;
    }
    [BoundToServerPackage]
    public class ClickWindow : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x08;

        public byte WindowID;
        public VarInt StateID;
        public short Slot;
        public sbyte Button;
        public VarInt Mode;
        public IndexedSlot[] Slots;
        public Slot ClickedItem;

        public class IndexedSlot : SerializableToBytesBigEndian
        {
            public short index;
            public Slot data;
            public override string ToString()
            {
                return data.ToString();
            }
        }
    }
    [BoundToServerPackage]
    public class CreativeInventoryAction : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x28;

        public short Slot;
        public Slot ClickedItem;
    }
    [BoundToServerPackage]
    public class PlayerDigging : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x1A;

        public Status status;
        public Position Location;
        public Direction face;
        public enum Status : byte
        {
            StartedDigging,
            CancelledDigging,
            FinishedDigging,
            DropItemStack,
            DropItem,
            ShootArrowOrFinishEathing,
            SwapItemInHand
        }
    }
    [BoundToServerPackage]
    public class HeldItemChange_serverbound : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x25;

        public short Slot;
    }
    [BoundToServerPackage]
    public class Animation_serverbound : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x2C;

        public VarInt Hand;
    }
    [BoundToServerPackage]
    public class EntityAction : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x1B;

        public VarInt EntityID;
        public ActionType ActionID;
        /// <summary>
        /// Only used by the “start jump with horse” action, in which case it ranges from 0 to 100. In all other cases it is 0.
        /// </summary>
        public VarInt JumpBoost;

        public enum ActionType : byte
        {
            StartSneaking,
            StopSneaking,
            LeaveBed,
            StartSprinting,
            StopSprinting,
            StartJumpWithHorse,
            StopJumpWithHorse,
            /// <summary>
            /// Open horse inventory is only sent when pressing the inventory key (default: E) while on a horse — all other methods of opening a horse's inventory (involving right-clicking or shift-right-clicking it) do not use this packet
            /// </summary>
            OpenHorseInventory,
            StartFlyingWithElytra
        }
    }
    [BoundToServerPackage]
    public class ClientStatus : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x04;

        public ActionIDType ActionID;

        public enum ActionIDType : byte
        {
            PerformRespawn,
            RequestStats
        }
    }
    [BoundToServerPackage]
    public class PlayerBlockPlacement : MSerializableToBytes, IPacket
    {
        public enum HandType : byte
        {
            MainHand, OffHand = 1
        }

        public override int package_id => 0x2E;
        public HandType Hand;
        public Position Location;
        public Direction Face;
        public float CursorPositionX;
        public float CursorPositionY;
        public float CursorPositionZ;
        public bool InsideBlock;
    }
    #endregion

    #region Clientbound
    [BoundToClientPackage]
    public class JoinGame : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x26;

        public int EntityID;
        public bool isHardcore;
        public byte Gamemode;
        public sbyte PreviousGamemode;
        public string[] DimensionsNames;
        public RawByteArray DimensionCodec;
        public RawByteArray Dimension;
        public string DimensionName;
        public long HashedSeed;
        public VarInt MaxPlayers;
        public VarInt ViewDistance;
        public VarInt SimulationDistance;
        public bool ReducedDebugInfo;
        public bool EnableRespawnScreen;
        public bool IsDebug;
        public bool IsFlat;
    }

    [BoundToClientPackage]
    public class HeldItemChange : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x48;

        public byte Slot;
    }

    [BoundToClientPackage]
    public class UpdateViewPosition : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x49;

        public VarInt ChunkX;
        public VarInt ChunkZ;
    }

    [BoundToClientPackage]
    public class PlayerPositionAndLook_clientbound : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x38;

        public double X;
        public double Y;
        public double Z;
        public float Yaw;
        public float Pitch;
        public byte Flags;
        public VarInt TeleportID;
        public bool DismountVehicle;

        public enum FlagsEnum : byte
        {
            X = 0x01, Y = 0x02, Z = 0x04, Y_ROT = 0x08, X_ROT = 0x10
        }
    }

    [BoundToClientPackage]
    public class KeepAlive_clientbound : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x21;

        public long KeepAliveID;
    }

    [BoundToClientPackage]
    public class ChunkDataAndUpdateLight : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x22;

        public int ChunkX;
        public int ChunkZ;
        public NBTTag Heightmaps;
        public byte[] Data;
        public BlockEntity[] BlockEntities;
        public bool TrustEdges;
        public BitSet SkyLightMask;
        public BitSet BlockLightMask;
        public BitSet EmptySkyLightMask;
        public BitSet EmptyBlockLightMask;
        public byte[][] SkyLightArray;
        public byte[][] BlockLightArray;
    }
    [BoundToClientPackage]
    public class UnloadChunk : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x1D;

        public int ChunkX;
        public int ChunkZ;
    }
    [BoundToClientPackage]
    public class SpawnPlayer : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x04;

        public VarInt EntityID;
        public Guid PlayerUUID;
        public double X;
        public double Y;
        public double Z;
        public Angle Yaw;
        public Angle Pitch;
    }
    [BoundToClientPackage]
    public class SpawnLivingEntity : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x02;

        public VarInt EntityID;
        public Guid EntityUUID;
        public VarInt Type;
        public double X;
        public double Y;
        public double Z;
        public Angle Yaw;
        public Angle Pitch;
        public Angle HeadYaw;
        public short VelocityX;
        public short VelocityY;
        public short VelocityZ;
    }
    [BoundToClientPackage]
    public class SpawnExperienceOrb : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x01;

        public VarInt EntityID;
        public double X;
        public double Y;
        public double Z;
        public short Count;
    }
    [BoundToClientPackage]
    public class SpawnEntity : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x00;

        public VarInt EntityID;
        public Guid ObjectUUID;
        public VarInt Type;
        public double X;
        public double Y;
        public double Z;
        public Angle Yaw;
        public Angle Pitch;
        public int Data;
        public short VelocityX;
        public short VelocityY;
        public short VelocityZ;
    }
    [BoundToClientPackage]
    public class EntityAnimation_clientbound : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x06;

        public VarInt EntityID;
        public AnimationType Animation;

        public enum AnimationType : byte
        {
            SwingMainArm = 0,
            TakeDamage,
            LeaveBed,
            SwingOffhand,
            CriticalEffect,
            MagicCriticalEffect
        }
    }
    [BoundToClientPackage]
    public class BlockBreakAnimation : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x08;

        public VarInt EntityID;
        public Position Location;
        /// <summary>
        /// inclusive [0-9]
        /// </summary>
        public byte DestroyStage;
    }
    [BoundToClientPackage]
    public class BlockEntityData : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x0A;

        public Position Location;
        public VarInt Type;
        public NBTTag NBTData;
    }
    [BoundToClientPackage]
    public class BlockAction : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x0B;

        public Position Location;
        public byte ActionID;
        public byte ActionParam;
        /// <summary>
        /// This packet uses a block ID, not a block state.
        /// </summary>
        public VarInt BlockType;
    }
    [BoundToClientPackage]
    public class BlockChange : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x0C;

        public Position Location;
        /// <summary>
        /// The new block state ID for the block as given in the global palette. See that section for more information.
        /// </summary>
        public VarInt BlockID;
    }

    [BoundToClientPackage]
    public class BossBar : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x0D;

        public Guid UUID;
        public SerializableToBytesBigEndian Action;

        public class Add : SerializableToBytesBigEndian
        {
            public VarInt action_id = 0;

            public string Title;
            public float Health;
            public VarInt Color;
            public VarInt Division;
            public global::BossBar.FlagsType Flags;
        }

        public class Remove : SerializableToBytesBigEndian
        {
            public VarInt action_id = 1;
        }

        public class UpdateHealth : SerializableToBytesBigEndian
        {
            public VarInt action_id = 2;

            public float Health;
        }
        public class UpdateTitle : SerializableToBytesBigEndian
        {
            public VarInt action_id = 3;

            public string Title;
        }

        public class UpdateStyle : SerializableToBytesBigEndian
        {
            public VarInt action_id = 4;

            public VarInt Color;
            public VarInt Division;
        }
        public class UpdateFlags : SerializableToBytesBigEndian
        {
            public VarInt action_id = 5;

            public byte Flags;
        }
    }
    [BoundToClientPackage]
    public class Tags : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x67;

        public RawByteArray tags;
    }
    [BoundToClientPackage]
    public class DeclareCommands : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x12;

        public RawByteArray data;
    }
    [BoundToClientPackage]
    public class ChangeGameState : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x1E;

        public ReasonType Reason;
        public float Value;
        public enum ReasonType : byte
        {
            NoRespawnBlockAvailable = 0,
            EndRaining,
            BeginRaining,
            ChangeGamemode,
            WinGame,
            DemoEvent,
            ArrowHitPlayer,
            RainLevelChange,
            ThunderLevelChange,
            PlayPufferfishStingSound,
            PlayElderGuardianMobAppearance,
            EnableRespawnScreen
        }
    }

    [BoundToClientPackage]
    public class ChatMessage_clientbound : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x0F;

        public string JSONData;
        public PositionType position;
        public Guid Sender;

        public enum PositionType : byte
        {
            chat,
            system_message,
            game_info
        }
    }
    [BoundToClientPackage]
    public class PlayerInfo : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x36;

        public VarInt Action;
        public Player[] players;

        public class Player : SerializableToBytesBigEndian
        {
            public Guid uuid;
            public SerializableToBytesBigEndian some;

            public class Add : SerializableToBytesBigEndian
            {
                public static int ActionID => 0;
                public string Name;
                public Property[] Properties;
                public VarInt Gamemode;
                public VarInt Ping;
                public Chat? DisplayName;
                public class Property : SerializableToBytesBigEndian
                {
                    public string Name;
                    public string Value;
                    public OptString Signature;
                }
            }
            public class UpdateGamemode : SerializableToBytesBigEndian
            {
                public static int ActionID = 1;
                public VarInt Gamemode;
            }
            public class UpdateLatency : SerializableToBytesBigEndian
            {
                public static int ActionID = 2;
                public VarInt Ping;
            }
            public class UpdateDisplayName : SerializableToBytesBigEndian
            {
                public static int ActionID = 3;
                public Chat? DisplayName;
            }
            public class RemovePlayer : SerializableToBytesBigEndian
            {
                public static int ActionID = 4;
            }
        }
    }
    [BoundToClientPackage]
    public class EntityPositionAndRotation : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x2A;

        public VarInt EntityID;
        public short DeltaX;
        public short DeltaY;
        public short DeltaZ;
        public Angle Yaw;
        public Angle Pitch;
        public bool OnGround;
    }
    [BoundToClientPackage]
    public class EntityPosition : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x29;

        public VarInt EntityID;
        public short DeltaX;
        public short DeltaY;
        public short DeltaZ;
        public bool OnGround;
    }
    [BoundToClientPackage]
    public class EntityRotation : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x2B;

        public VarInt EntityID;
        public Angle Yaw;
        public Angle Pitch;
        public bool OnGround;
    }
    [BoundToClientPackage]
    public class DestroyEntities : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x3A;

        public VarInt[] Entities;
    }
    [BoundToClientPackage]
    public class PlayerListHeaderAndFooter : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x5F;

        public string Header;
        public string Footer;
    }
    [BoundToClientPackage]
    public class EntityHeadLook : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x3E;

        public VarInt EntityID;
        public Angle HeadYaw;
    }
    [BoundToClientPackage]
    public class EntityTeleport : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x62;

        public VarInt EntityID;
        public double X;
        public double Y;
        public double Z;
        public Angle Yaw;
        public Angle Pitch;
        public bool OnGround;
    }
    [BoundToClientPackage]
    public class EntityVelocity : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x4F;

        public VarInt EntityID;
        public short VelocityX;
        public short VelocityY;
        public short VelocityZ;
    }

    [BoundToClientPackage]
    public class WindowItems : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x14;

        public byte WindowID;
        public VarInt StateID;
        public Slot[] slots;
        public Slot CarriedItem;
    }
    [BoundToClientPackage]
    public class EntityMetadata : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x4D;

        public VarInt EntityID;
        public RawByteArray Metadata;
    }
    [BoundToClientPackage]
    public class EntityEquipment : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x50;

        public VarInt EntityID;
        public RawByteArray equipmentArray;

        public class Equipment : SerializableToBytesBigEndian
        {
            public EquipmentSlot Slot;
            public Slot Item;
        }
        public enum EquipmentSlot : byte
        {
            MainHand = 0, 
            OffHand, 
            Boots, 
            Leggins, 
            Chestplate, 
            Helmet = 5,
            NextPresent = 128
        }
    }
    [BoundToClientPackage]
    public class UpdateHealth : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x52;

        public float Health;
        public VarInt Food;
        public float FoodSaturation;
    }

    [BoundToClientPackage]
    public class ClearTitles : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x10;

        public bool Reset;
    }
    [BoundToClientPackage]
    public class SetTitleSubTitle : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x58;

        public Chat TitleText;
    }
    [BoundToClientPackage]
    public class SetTitleText : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x5A;

        public Chat TitleText;
    }
    [BoundToClientPackage]
    public class SetTitleTimes : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x5B;

        public int FadeIn;
        public int Stay;
        public int FadeOut;
    }
    [BoundToClientPackage]
    public class Respawn : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x3D;

        public NBTTag Dimension;
        public string DimensionName;
        public long HashedSeed;
        public byte Gamemode;
        public byte PreviousGamemode;
        public bool isDebug;
        public bool isFlat;
        public bool CopyMetadata;
    }
    [BoundToClientPackage]
    public class SpawnParticle : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x24;

        public int ParticleID;
        public bool LongDistance;
        public double X;
        public double Y;
        public double Z;
        public float OffsetX;
        public float OffsetY;
        public float OffsetZ;
        public float ParticleData;
        public int ParticleCount;
        public RawByteArray Data;
    }
    [BoundToClientPackage]
    public class CollectItem : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x61;

        public VarInt CollectedEntityID;
        public VarInt CollectorEntityID;
        /// <summary>
        /// Seems to be 1 for XP orbs, otherwise the number of items in the stack.
        /// </summary>
        public VarInt PickupItemCount;
    }
    [BoundToClientPackage]
    public class SoundEffect : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x5D;

        public VarInt SoundID;
        public Categories SoundCategory;
        /// <summary>
        /// Effect X multiplied by 8 (fixed-point number with only 3 bits dedicated to the fractional part).
        /// </summary>
        public int x;
        /// <summary>
        /// Effect Y multiplied by 8 (fixed-point number with only 3 bits dedicated to the fractional part).
        /// </summary>
        public int y;
        /// <summary>
        /// Effect Z multiplied by 8 (fixed-point number with only 3 bits dedicated to the fractional part).
        /// </summary>
        public int z;
        public float Volume;
        public float Pitch;
    }
    [BoundToClientPackage]
    public class NamedSoundEffect : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x19;

        public string SoundName;
        public Categories SoundCategory;
        /// <summary>
        /// Effect X multiplied by 8 (fixed-point number with only 3 bits dedicated to the fractional part).
        /// </summary>
        public int EffectPositionX;
        /// <summary>
        /// Effect Y multiplied by 8 (fixed-point number with only 3 bits dedicated to the fractional part).
        /// </summary>
        public int EffectPositionY;
        /// <summary>
        /// Effect Z multiplied by 8 (fixed-point number with only 3 bits dedicated to the fractional part).
        /// </summary>
        public int EffectPositionZ;
        public float Volume;
        public float Pitch;
    }
    [BoundToClientPackage]
    public class StopSound : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x5E;

        public byte Flags;
        public RawByteArray data;

    }
    [BoundToClientPackage]
    public class EntitySoundEffect : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x5C;

        public VarInt SoundID;
        public Categories SoundCategory;
        public VarInt EntityID;
        public float Volume;
        public float Pitch;

    }
    [BoundToClientPackage]
    public class EntityProperties : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x64;

        public VarInt EntityID;
        public Property[] Properties;
        public class Property : SerializableToBytesBigEndian
        {
            public string Key;
            public double Value;
            public ModiferData[] Modifers;
        }
        public class ModiferData : SerializableToBytesBigEndian
        {
            public Guid UUID;
            public double Amount;
            public ModiferOperation Operation;
        }
        public enum ModiferOperation : byte
        {
            Add_Subtract_amount = 0,
            Add_Subtract_amount_percent_of_the_current_value = 1,
            Multiply_by_amount_percent = 2,
        }
    }
    [BoundToClientPackage]
    public class SetCooldown : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x17;

        public VarInt ItemID;
        public VarInt CooldownTicks;
    }
    [BoundToClientPackage]
    public class OpenWindow : MSerializableToBytes, IPacket
    {
        public override int package_id => 0x2E;

        public VarInt WindowID;
        public VarInt WindowType;
        public Chat WindowTitle;
    }
    #endregion
}