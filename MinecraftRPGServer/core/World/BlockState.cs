using System.Collections.Generic;
using System.Linq;
using MinecraftData._1_18_2.blocks.minecraft;

public struct BlockState : IBlockData
{
    public short StateID;
    public BlockNameID id { get => GlobalPalette.GetNameID(StateID); }
    private IBlockData iBlockData =>
        GlobalPalette.GetBlockData(StateID);
    public bool haveCollision
    {
        get
        {
            var collisionShape = iBlockData.DefaultState.CollisionShape;
            return collisionShape.HasValue || collisionShape.Value == 0;
        }
    }
    public DefaultBlockState defaultBlockState => GlobalPalette.GetDefaultStateID(StateID);

    public short DefaultStateID => iBlockData.DefaultStateID;

    public state DefaultState => iBlockData.DefaultState;
    public state CurrentState
    {
        get
        {
            var sId = StateID;
            return States.First(t => t.Id == sId);
        }
    }

    public float Hardness => iBlockData.Hardness;

    public float ExplosionResistance => iBlockData.ExplosionResistance;

    public bool IsTransparent => iBlockData.IsTransparent;

    public MinecraftMaterial Material => iBlockData.Material;

    public byte SoundGroup => iBlockData.SoundGroup;

    public short DroppedItem => iBlockData.DroppedItem;

    public Dictionary<string, List<string>> Properties => iBlockData.Properties;

    public state[] States => iBlockData.States;
    public bool isAir => StateID == 0;
    public bool isSolid
    {
        get
        {
            var curState = CurrentState;
            return curState.CollisionShape.HasValue && curState.CollisionShape.Value == 0;
        }
    }
    public BlockState(short StateID)
    {
        this.StateID = StateID;
    }

    public static readonly BlockState air = new BlockState((int)DefaultBlockState.air);

    public static bool operator ==(BlockState a, DefaultBlockState b) => a.StateID == (short)b;
    public static bool operator !=(BlockState a, DefaultBlockState b) => a.StateID != (short)b;

    public override bool Equals(object obj)
    {
        return obj is BlockState state &&
               StateID == state.StateID;
    }

    public override int GetHashCode()
    {
        return -1778456669 + StateID.GetHashCode();
    }
}
