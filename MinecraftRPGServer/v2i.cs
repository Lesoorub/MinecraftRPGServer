public class v2i
{
    public int x;
    public int y;

    public v2i(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object obj)
    {
        return obj != null && obj is v2i i && i.GetHashCode() == GetHashCode();
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
}
