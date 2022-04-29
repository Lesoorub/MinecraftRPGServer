using System.Collections.Generic;

class v2iComparer : IEqualityComparer<v2i>
{
    public static v2iComparer Instance = new v2iComparer();
    public bool Equals(v2i x, v2i y) => x != null && y != null && x.x == y.x && x.y == y.y;
    public int GetHashCode(v2i obj) => obj.GetHashCode();
}
