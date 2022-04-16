using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class RandomPlus
{
    private readonly static Random rnd = new Random();

    public static int Range(int min, int max) => rnd.Next(min, max);
    public static float Range(float min, float max) => (float)(rnd.NextDouble() * (max - min) + min);
    public static long Range(long min, long max) => (long)(rnd.NextDouble() * (max - min) + min);
    public static long GetLong()
    {
        byte[] bytes = new byte[8];
        rnd.NextBytes(bytes);
        return BitConverter.ToInt64(bytes, 0);
    }
}