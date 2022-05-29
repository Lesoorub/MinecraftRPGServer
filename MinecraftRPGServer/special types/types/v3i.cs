using System;

public class v3i
{
    public int x;
    public int y;
    public int z;

    public v3i(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public double sqrMagnitude { get => x * x + y * y + z * z; }
    public double magnitude { get => Math.Sqrt(sqrMagnitude); }
    public v3d normalize
    {
        get
        {
            var m = magnitude;
            if (m <= 1e-6) return v3d.zero;
            return (v3d)this / m;
        }
    }

    public static v3i zero = new v3i(0, 0, 0);
    public static v3i one = new v3i(1, 1, 1);
    public static v3i right = new v3i(1, 0, 0);
    public static v3i left = new v3i(-1, 0, 0);
    public static v3i up = new v3i(0, 1, 0);
    public static v3i down = new v3i(0, -1, 0);
    public static v3i forward = new v3i(0, 0, 1);
    public static v3i back = new v3i(0, 0, -1);
    public static v3i operator -(v3i a) => new v3i(-a.x, -a.y, -a.z);
    public static v3i operator +(v3i a, v3i b) => new v3i(a.x + b.x, a.y + b.y, a.z + b.z);
    public static v3i operator -(v3i a, v3i b) => new v3i(a.x - b.x, a.y - b.y, a.z - b.z);
    public static v3i operator *(v3i a, int b) => new v3i(a.x * b, a.y * b, a.z * b);
    public static v3i operator /(v3i a, int b) => new v3i(a.x / b, a.y / b, a.z / b);

    public override string ToString()
    {
        return $"[{x}, {y}, {z}]";
    }
    public override bool Equals(object obj)
    {
        return obj is v3i i &&
               x == i.x &&
               y == i.y &&
               z == i.z;
    }

    public override int GetHashCode()
    {
        int hashCode = -297796415;
        hashCode = hashCode * -1521134295 + y.GetHashCode();
        hashCode = hashCode * -1521134295 + z.GetHashCode();
        return hashCode;
    }

    public static explicit operator v3i(v3d v) => new v3i((int)v.x, (int)v.y, (int)v.z);
    public static explicit operator v3i(v3f v) => new v3i((int)v.x, (int)v.y, (int)v.z);
}