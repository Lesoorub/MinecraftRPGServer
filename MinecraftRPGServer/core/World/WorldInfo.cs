using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MineServer;
using NBT;

public class WorldInfo
{
    public v3f SpawnPoint;
    public float SpawnRotation;

    public long Time;
    public long CycleTime = 24000;
    public long Seed;
    public long HashedSeed;
    public int RandomTickSpeed = 3;

    public WorldInfo()
    {
    }
    public void SetSeed(long newseed)
    {
        using (SHA1Managed sha1 = new SHA1Managed())
        {
            Seed = newseed;
            HashedSeed = BitConverter.ToInt64(sha1.ComputeHash(BitConverter.GetBytes(newseed).Take(8)), 0);
        }
    }
    public void SetSeed(string newseed)
    {
        using (SHA1Managed sha1 = new SHA1Managed())
        {
            var seed_bytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(newseed));
            Seed = BitConverter.ToInt64(seed_bytes, 0);
            HashedSeed = BitConverter.ToInt64(sha1.ComputeHash(seed_bytes.Take(8)), 0);
        }
    }
}

public class AnvilWorldInfo : WorldInfo
{
    public AnvilWorldInfo(NBTTag level)
    {
        var data = level["Data"];
        if (level.HasPath("Data/WorldGenSettings/seed"))
            SetSeed((long)data["WorldGenSettings"]["seed"]);
        if (level.HasPath("Data/SpawnX") &&
            level.HasPath("Data/SpawnY") &&
            level.HasPath("Data/SpawnZ"))
            SpawnPoint = new v3f(
                (int)data["SpawnX"],
                (int)data["SpawnY"],
                (int)data["SpawnZ"]);
        if (level.HasPath("Data/SpawnAngle"))
            SpawnRotation = (float)data["SpawnAngle"];
    }
}