using System;
using System.Collections.Generic;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class BlockAttribute : Attribute
{
    public DefaultBlockState BlockID;
    public static readonly Dictionary<DefaultBlockState, IWorldBlock> blocks = new Dictionary<DefaultBlockState, IWorldBlock>();
    public BlockAttribute(DefaultBlockState BlockID)
    {
        this.BlockID = BlockID;
    }
    public static void Init()
    {
        blocks.Clear();
        foreach(var type in Tools.GetTypesWithAttribute<BlockAttribute>())
        {
            var attrs = type.GetCustomAttributes<BlockAttribute>();
            var obj = (IWorldBlock)Activator.CreateInstance(type);
            foreach (var attr in attrs)
                blocks.Add(attr.BlockID, obj);
        }
    }
}
