using System;
using System.Collections.Generic;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public class BlockLogicAttribute : Attribute
{
    static BaseBlockLogic[] baseBlockLogics;

    public BlockNameID nameID;
    public BlockLogicAttribute(BlockNameID nameID)
    {
        this.nameID = nameID;
    }
    public static void SpawnInstances()
    {
        baseBlockLogics = new BaseBlockLogic[Enum.GetValues(typeof(BlockNameID)).Length];
        foreach (var type in Tools.GetAllTypesWithAttribute<BlockLogicAttribute>())
        {
            var obj = Activator.CreateInstance(type) as BaseBlockLogic;
            foreach (var attr in type.GetCustomAttributes<BlockLogicAttribute>())
            {
                baseBlockLogics[(int)attr.nameID] = obj;
            }
        }
    }

    public static bool TryGetLogic(BlockNameID nameID, out BaseBlockLogic logic)
    {
        if (baseBlockLogics == null)
            SpawnInstances();
        logic = baseBlockLogics[(int)nameID];
        return logic != null;
    }
}
