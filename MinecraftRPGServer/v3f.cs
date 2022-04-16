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

    public override bool Equals(object obj)
    {
        return obj != null && obj is v2i i && i.GetHashCode() == GetHashCode();
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
}