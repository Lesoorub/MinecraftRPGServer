using System;
public class v3d
{
    public double x;
    public double y;
    public double z;

    public v3d(double x, double y, double z)
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
            if (m <= 1e-6) return zero;
            return this / m;
        }
    }
    public override string ToString()
    {
        return $"{{{x.ToString("N1").Replace(",", ".")},{y.ToString("N1").Replace(",", ".")},{z.ToString("N1").Replace(",", ".")}}}";
    }

    public static explicit operator v3d(v3i v) => new v3d(v.x, v.y, v.z);

    public static v3d zero = new v3d(0, 0, 0);
    public static v3d one = new v3d(1, 1, 1);
    public static v3d right = new v3d(1, 0, 0);
    public static v3d up = new v3d(0, 1, 0);
    public static v3d forward = new v3d(0, 0, 1);
    public static v3d operator +(v3d a, v3d b) => new v3d(a.x + b.x, a.y + b.y, a.z + b.z);
    public static v3d operator -(v3d a, v3d b) => new v3d(a.x - b.x, a.y - b.y, a.z - b.z);
    public static v3d operator *(v3d a, double b) => new v3d(a.x * b, a.y * b, a.z * b);
    public static v3d operator /(v3d a, double b) => new v3d(a.x / b, a.y / b, a.z / b);

    public v3i Block { get => new v3i((int)Math.Floor(x), (int)Math.Floor(y), (int)Math.Floor(z)); }
    public static v3d Lerp(v3d a, v3d b, double t) => a * (1 - t) + b * t;
}