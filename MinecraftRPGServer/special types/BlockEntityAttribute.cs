using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public class BlockEntityAttribute : Attribute
{
    static BlockEntity[] list;
    public BlockEntityID blockEntityID;
    public BlockEntityAttribute(BlockEntityID blockEntityID)
    {
        this.blockEntityID = blockEntityID;
    }
    public static bool Get(BlockEntityID blockEntityID, out BlockEntity blockEntity)
    {
        if (list == null)
        {
            list = new BlockEntity[Enum.GetValues(typeof(BlockEntityID)).Length];
            foreach (var type in Tools.GetAllTypesWithAttribute<BlockEntityAttribute>())
            {
                var obj = Activator.CreateInstance(type) as BlockEntity;
                if (obj == null) continue;
                var attr = type.GetCustomAttribute<BlockEntityAttribute>();
                list[(int)attr.blockEntityID] = obj;
            }
        }

        blockEntity = list[(int)blockEntityID];
        return blockEntity != null;
    }
}