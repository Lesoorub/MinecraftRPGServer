using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class v2f
{
    public float x;
    public float y;

    public v2f(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    public static v2f zero = new v2f(0, 0);
    public static v2f one = new v2f(1, 1);
    public static v2f right = new v2f(1, 0);
    public static v2f up = new v2f(0, 1);
    public static v2f operator +(v2f a, v2f b) => new v2f(a.x + b.x, a.y + b.y);
    public static v2f operator -(v2f a, v2f b) => new v2f(a.x - b.x, a.y - b.y);
    public static v2f operator *(v2f a, float b) => new v2f(a.x * b, a.y * b);
    public static v2f operator /(v2f a, float b) => new v2f(a.x / b, a.y / b);

    public override bool Equals(object obj)
    {
        return obj is v2f i && i.x == x && i.y == y;
    }

    public override int GetHashCode()
    {
        int hashCode = 1502939027;
        hashCode = hashCode * -1521134295 + x.GetHashCode();
        hashCode = hashCode * -1521134295 + y.GetHashCode();
        return hashCode;
    }
}