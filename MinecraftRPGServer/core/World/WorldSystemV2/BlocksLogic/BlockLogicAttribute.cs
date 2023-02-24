using System;
using System.Collections.Generic;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public class BlockLogicAttribute : Attribute
{
    static Dictionary<BlockNameID, IBlockTickable> dict;

    public BlockNameID nameID;
    public static Dictionary<BlockNameID, IBlockTickable> Dict
    {
        get
        {
            if (dict == null)
                SpawnInstances();
            return dict;
        }
    }
    public BlockLogicAttribute(BlockNameID nameID)
    {
        this.nameID = nameID;
    }
    public static void SpawnInstances()
    {
        dict = new Dictionary<BlockNameID, IBlockTickable>();
        foreach (var type in Tools.GetAllTypesWithAttribute<BlockLogicAttribute>())
        {
            var obj = Activator.CreateInstance(type) as IBlockTickable;
            foreach (var attr in type.GetCustomAttributes<BlockLogicAttribute>())
            {
                dict.Add(attr.nameID, obj);
            }
        }
    }
}
