using System;
using System.Collections.Generic;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class BlockAttribute : Attribute
{
    public BlockID BlockID;
    public static readonly Dictionary<BlockID, IWorldBlock> blocks = new Dictionary<BlockID, IWorldBlock>();
    public BlockAttribute(BlockID BlockID)
    {
        this.BlockID = BlockID;
    }
    public static void Init()
    {
        blocks.Clear();
        foreach(var type in RPGServer.GetTypesWithAttribute<BlockAttribute>())
        {
            var attrs = type.GetCustomAttributes<BlockAttribute>();
            var obj = (IWorldBlock)Activator.CreateInstance(type);
            foreach (var attr in attrs)
                blocks.Add(attr.BlockID, obj);
        }
    }
}
