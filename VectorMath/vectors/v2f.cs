using Newtonsoft.Json;
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
    //Casts
    public static explicit operator v2f(v2i t) => new v2f(t.x, t.y);
    [JsonIgnore]
    public v2i FloorToInt => new v2i((int)Math.Floor(x), (int)Math.Floor(y));
    [JsonIgnore]
    public v2i CeilingToInt => new v2i((int)Math.Ceiling(x), (int)Math.Ceiling(y));
    [JsonIgnore]
    public v2i RoundToInt => new v2i((int)Math.Round(x), (int)Math.Round(y));
    [JsonIgnore]
    public float SqrMagnitude => x * x + y * y;
    [JsonIgnore]
    public float Magnitude => (float)Math.Sqrt(SqrMagnitude);
    [JsonIgnore]
    public v2f Normalized => this / Magnitude;
    [JsonIgnore]
    public v2i Chunk => new v2i((int)x >> 4, (int)y >> 4);

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

    public v2f Clone() => new v2f(x, y);
    public override int GetHashCode()
    {
        int hashCode = 1502939027;
        hashCode = hashCode * -1521134295 + x.GetHashCode();
        hashCode = hashCode * -1521134295 + y.GetHashCode();
        return hashCode;
    }
    public static v2f FromAngle(float radianAngle)
    {
        var t = (2 * Math.PI * radianAngle) / 360;
        return new v2f((float)Math.Cos(t), (float)Math.Sin(t));
    }
    public static v2f Project(v2f vector, v2f onto)
    {
        float numerator = Dot(vector, onto);
        float denominator = Dot(onto, onto);
        if (denominator == 0)
            return onto;
        return onto * (numerator / denominator);
    }
    public static float Dot(v2f a, v2f b) =>
        a.x * b.x + a.y * b.y;
    public static float Distance(v2f a, v2f b) => (a - b).Magnitude;
    public static float SqrDistance(v2f a, v2f b) => (a - b).SqrMagnitude;
}