using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class Tools
{
    public static IEnumerable<Type> GetTypesWithAttribute<T>()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        foreach (Type type in assembly.GetTypes())
        {
            if (type.GetCustomAttributes(typeof(T), true).Length > 0)
            {
                yield return type;
            }
        }
    }
    public static IEnumerable<Type> GetAllTypesWithAttribute<T>()
    {
        var assembly = AppDomain.CurrentDomain.GetAssemblies();
        foreach (Type type in assembly.SelectMany(x => x.GetTypes()))
        {
            if (type.GetCustomAttributes(typeof(T), true).Length > 0)
            {
                yield return type;
            }
        }
    }
}