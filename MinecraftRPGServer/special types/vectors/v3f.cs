using System;
using MinecraftData._1_18_2.items.minecraft;
using Newtonsoft.Json;
public class v3f
{
    public float x;
    public float y;
    public float z;

    public v3f(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public v3f Clone() => new v3f(x, y, z);
    public override bool Equals(object obj)
    {
        return obj != null && obj is v3f i && i.GetHashCode() == GetHashCode();
    }

    public override int GetHashCode()
    {
        int hashCode = 1502939027;
        hashCode = hashCode * -1521134295 + x.GetHashCode();
        hashCode = hashCode * -1521134295 + y.GetHashCode();
        hashCode = hashCode * -1521134295 + z.GetHashCode();
        return hashCode;
    }

    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }

    //Operators
    public static v3f operator /(v3f a, float b) => new v3f(a.x / b, a.y / b, a.z / b);
    public static v3f operator /(v3f a, int b) => new v3f(a.x / b, a.y / b, a.z / b);

    public static v3f operator *(v3f a, float b) => new v3f(a.x * b, a.y * b, a.z * b);
    public static v3f operator *(float a, v3f b) => b * a;
    public static v3f operator *(v3f a, int b) => new v3f(a.x * b, a.y * b, a.z * b);
    public static v3f operator *(int a, v3f b) => b * a;

    public static v3f operator +(v3f a, v3f b) => new v3f(a.x + b.x, a.y + b.y, a.z + b.z);

    public static v3f operator -(v3f a, v3f b) => new v3f(a.x - b.x, a.y - b.y, a.z - b.z);

    //Casts
    public static explicit operator v3f (v3i t) => new v3f(t.x, t.y, t.z);
    [JsonIgnore]
    public v3i FloorToInt => new v3i((int)Math.Floor(x), (int)Math.Floor(y), (int)Math.Floor(z));
    [JsonIgnore]
    public v3i CeilingToInt => new v3i((int)Math.Ceiling(x), (int)Math.Ceiling(y), (int)Math.Ceiling(z));
    [JsonIgnore]
    public v3i RoundToInt => new v3i((int)Math.Round(x), (int)Math.Round(y), (int)Math.Round(z));
    [JsonIgnore]
    public float SqrMagnitude => x * x + y * y + z * z;
    [JsonIgnore]
    public float Magnitude => (float)Math.Sqrt(SqrMagnitude);
    [JsonIgnore]
    public v3f Normalized => this / Magnitude;
    [JsonIgnore]
    public v2i Chunk => new v2i((int)x >> 4, (int)z >> 4);

    //Consts
    private const double Rad2Deg = (2 * Math.PI) / 360f;
    private const double Deg2Rad = 360f / (2 * Math.PI);

    //Shorts
    //Можно оптимизировать если возвращать один и тот же вектор не создавая его повторно каждый раз.
    public static v3f zero    => new v3f( 0,  0,  0);
    public static v3f one     => new v3f( 1,  1,  1);
    public static v3f halfone => new v3f(.5f,.5f,.5f);
    public static v3f right   => new v3f( 1,  0,  0);
    public static v3f left    => new v3f(-1,  0,  0);
    public static v3f up      => new v3f( 0,  1,  0);
    public static v3f down    => new v3f( 0, -1,  0);
    public static v3f forward => new v3f( 0,  0,  1);
    public static v3f back    => new v3f( 0,  0, -1);

    //Static methods
    public static v3f FromRotationInvertX(v2f rotation) => new v3f(
        (float)-(Math.Sin(rotation.x * Rad2Deg) * Math.Cos(rotation.y * Rad2Deg)),
        (float)-Math.Sin(rotation.y * Rad2Deg),
        (float)(Math.Cos(rotation.x * Rad2Deg) * Math.Cos(rotation.y * Rad2Deg)));
    public static v3f FromRotation(v2f rotation) => new v3f(
        (float)(Math.Sin(rotation.x * Rad2Deg) * Math.Cos(rotation.y * Rad2Deg)),
        (float)-Math.Sin(rotation.y * Rad2Deg),
        (float)(Math.Cos(rotation.x * Rad2Deg) * Math.Cos(rotation.y * Rad2Deg)));
    public static v3f Project(v3f vector, v3f onto)
    {
        float numerator = Dot(vector, onto);
        float denominator = Dot(onto, onto);
        if (denominator == 0)
            return onto;
        return onto * (numerator / denominator);
    }
    public static float Dot(v3f a, v3f b) => 
        a.x * b.x + a.y * b.y + a.z * b.z;
    public static float Distance(v3f a, v3f b) => (a - b).Magnitude;
    public static float SqrDistance(v3f a, v3f b) => (a - b).SqrMagnitude;
}