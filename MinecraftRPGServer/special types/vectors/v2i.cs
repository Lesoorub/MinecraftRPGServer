using System;
using System.Collections.Generic;

public class v2i
{
    public int x;
    public int y;

    public v2i() { }
    public v2i(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object obj)
    {
        return 
            obj != null && 
            obj is v2i i && 
            i.x == x && 
            i.y == y;
    }

    public static v2i zero =    new v2i(0, 0);
    public static v2i one =     new v2i(1, 1);
    public static v2i right =   new v2i(1, 0);
    public static v2i up =      new v2i(0, 1);
    public static v2i operator -(v2i a) => new v2i(-a.x, -a.y);
    public static v2i operator +(v2i a, v2i b) => new v2i(a.x + b.x, a.y + b.y);
    public static v2i operator -(v2i a, v2i b) => new v2i(a.x - b.x, a.y - b.y);
    public static v2i operator *(v2i a, int b) => new v2i(a.x * b, a.y * b);
    public static v2i operator /(v2i a, int b) => new v2i(a.x / b, a.y / b);
    public static v2i operator *(int b, v2i a) => new v2i(a.x * b, a.y * b);
    public static v2i operator /(int b, v2i a) => new v2i(a.x / b, a.y / b);

    public override int GetHashCode()
    {
        int hashCode = 1502939027;
        hashCode = hashCode * -1521134295 + x.GetHashCode();
        hashCode = hashCode * -1521134295 + y.GetHashCode();
        return hashCode;
    }

    public override string ToString()
    {
        return $"({x}, {y})";
    }

    public static List<v2i> Range(v2i min, v2i max)
    {
        var list = new List<v2i>();
        for (int x = min.x; x < max.x; x++)
            for (int y = min.y; y < max.y; y++)
                list.Add(new v2i(x, y));
        return list;
    }
    public static List<v2i> Range(v2i max)
    {
        var list = new List<v2i>();
        for (int x = 0; x < max.x; x++)
            for (int y = 0; y < max.y; y++)
                list.Add(new v2i(x, y));
        return list;
    }
    public static void ForEach(v2i max, Action<ForEachHandler, v2i> onEach)
    {
        var handler = new ForEachHandler();
        var list = Range(max);
        foreach (var el in list)
        {
            onEach(handler, el);
            if (handler.isBreak)
                break;
        }
    }
    public static void ForEach(v2i max, Action<v2i> onEach)
    {
        var list = Range(max);
        foreach (var el in list)
            onEach(el);
    }
    public static void ForEach(v2i min, v2i max, Action<v2i> onEach)
    {
        var list = Range(min, max);
        foreach (var el in list)
            onEach(el);
    }
    public static void ForEach(v2i min, v2i max, Action<ForEachHandler, v2i> onEach)
    {
        var handler = new ForEachHandler();
        var list = Range(min, max);
        foreach (var el in list)
        {
            onEach(handler, el);
            if (handler.isBreak)
                break;
        }
    }
    public static void ForEach(List<v2i> list, Action<v2i> onEach)
    {
        foreach (var el in list)
            onEach(el);
    }
    public static void ForEach(List<v2i> list, Action<ForEachHandler, v2i> onEach)
    {
        var handler = new ForEachHandler();
        foreach (var el in list)
        {
            onEach(handler, el);
            if (handler.isBreak)
                break;
        }
    }
}
public static class v2iExtentions
{
    public static void ForEach(this List<v2i> list, Action<v2i> onEach) => v2i.ForEach(list, onEach);
}

public class ForEachHandler
{
    public bool isBreak = false;
    public void Break()
    {
        isBreak = true;
    }
}