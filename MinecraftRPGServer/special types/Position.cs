using MineServer;
using System;
using System.Linq;
public struct Position : ISerializable, IDeserializable
{
    public int x, y, z;
    public Position(v3i p) : this(p.x, p.y, p.z)
    {
        if (p.x < -33554432 || p.x > 33554431 ||
            p.y < -2048 || p.y > 2047 ||
            p.z < -33554432 || p.z > 33554431)
            throw new Exception("The coordinates are too large");
    }
    public Position(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static implicit operator v3i(Position a) => new v3i(a.x, a.y, a.z);
    public override string ToString()
    {
        return $"<{x}, {y}, {z}>";
    }

    public byte[] ToByteArray() =>
        BitConverter.GetBytes((((long)x & 0x3FFFFFF) << 38) | (((long)z & 0x3FFFFFF) << 12) | ((long)y & 0xFFF)).Reverse().ToArray();

    public void FromByteArray(byte[] bytes, int offset, out int length)
    {
        long val = BitConverter.ToInt64(bytes.BigEndian(offset, 8), 0);
        x = (int)(val >> 38);
        y = (int)(val & 0xFFF);
        z = (int)(val << 26 >> 38);
        if (x >= 33554432) { x -= 67108864; }
        if (y >= 2048) { y -= 4096; }
        if (z >= 33554432) { z -= 67108864; }
        length = 8;
    }
    public override bool Equals(object obj)
    {
        return obj is Position p && p.x == x && p.y == y && p.z == z;
    }
}
