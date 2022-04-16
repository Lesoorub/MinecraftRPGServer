using System.Collections.Generic;
using System.Linq;
using MineServer;
using Packets.Play;

public abstract class Particle : SerializableToBytesBigEndian
{
    public const float ParticleDrawDistance = 256;
    public VarInt ID = 0;
    public RawByteArray Data = new RawByteArray()
    {
        bytes = new byte[0]
    };

    /// <summary>
    /// Send all players in world (in visible range)
    /// </summary>
    /// <param name="world">World where particles will be spawned</param>
    /// <param name="id">Particle id</param>
    /// <param name="position">Spawn position</param>
    /// <param name="offset">This is added to the position after being multiplied by random.nextGaussian()</param>
    /// <param name="data">The data of each particle</param>
    /// <param name="count">The number of particles to create</param>
    /// <param name="additive">Additive data, check Particles enum description</param>
    public static void Spawn(World world, Particles id, v3f position, v3f offset, float data, int count, params object[] additive)
    {
        var particle = Get(id, additive);
        var packet = new SpawnParticle()
        {
            ParticleID = (int)id,
            LongDistance = false,
            X = position.x,
            Y = position.y,
            Z = position.z,
            OffsetX = offset.x,
            OffsetY = offset.y,
            OffsetZ = offset.z,
            ParticleData = data,
            ParticleCount = count,
            Data = particle.Data,
        };
        float sqrmaxdistance = ParticleDrawDistance * ParticleDrawDistance;
        foreach (var p in Player.GetInWorld(world)
            .Where(x => v3f.SqrDistance(x.Position, position) <= sqrmaxdistance))
            p.network.Send(packet);
    }
    public static Particle Get(Particles particleid, params object[] additive)
    {
        Particle F()
        {
            switch (particleid)
            {
                case Particles.block:
                case Particles.block_marker:
                case Particles.falling_dust:
                    return new Empty()
                    {
                        Data = new VarInt(((BlockState)additive[0]).StateID).Bytes
                    };
                case Particles.dust:
                    return new Dust((float)additive[0], (float)additive[1], (float)additive[2], (float)additive[3]);
                case Particles.dust_color_transition:
                    return new DustColorTransition(
                        (float)additive[0], (float)additive[1], (float)additive[2], 
                        (float)additive[3],
                        (float)additive[4], (float)additive[5], (float)additive[6]);
                case Particles.item:
                    return new Empty()
                    {
                        Data = ((Slot)additive[0]).ToByteArray()
                    };
                case Particles.vibration:
                    return new Vibration((Position)additive[0], (string)additive[1], 
                        (Position)additive[2], (int)additive[3], (int)additive[4]);
            }
            return new Empty();
        }

        var t = F();
        t.ID = new VarInt((int)particleid);
        return t;
    }

    private class Empty : Particle { }
    private class Dust : Particle
    {
        public Dust(float red, float green, float blue, float scale)
        {
            var writer = new ArrayWriter(true);
            writer.Write(red);
            writer.Write(green);
            writer.Write(blue);
            writer.Write(scale);
            Data = writer.ToArray();
        }
    }
    private class DustColorTransition : Particle
    {
        public DustColorTransition(
            float fromRed, float fromGreen, float fromBlue, 
            float scale, 
            float toRed, float toGreen, float toBlue)
        {
            var writer = new ArrayWriter(true);
            writer.Write(fromRed);
            writer.Write(fromGreen);
            writer.Write(fromBlue);
            writer.Write(scale);
            writer.Write(toRed);
            writer.Write(toGreen);
            writer.Write(toBlue);
            Data = writer.ToArray();
        }
    }
    private class Vibration : Particle
    {
        public Vibration(Position origin, string positionType, Position BlockPosition, int EntityID, int Ticks)
        {
            var writer = new ArrayWriter(true);
            writer.Write(origin);
            writer.Write(positionType);
            writer.Write(BlockPosition);
            writer.Write(EntityID);
            writer.Write(Ticks);
            Data = writer.ToArray();
        }
    }
}
public enum Particles : int
{
    ambient_entity_effect = 0,
    angry_villager = 1,
    /// <summary>
    /// Additive: int BlockState //The ID of the block state
    /// </summary>
    block = 2,
    /// <summary>
    /// Additive: int BlockState //The ID of the block state
    /// </summary>
    block_marker = 3,
    bubble = 4,
    cloud = 5,
    crit = 6,
    damage_indicator = 7,
    dragon_breath = 8,
    dripping_lava = 9,
    falling_lava = 10,
    landing_lava = 11,
    dripping_water = 12,
    falling_water = 13,
    /// <summary>
    /// Additive: 
    ///  float red, //Red value, 0-1
    ///  float green, //Green value, 0-1
    ///  float blue, //Blue value, 0-1
    ///  float scale //The scale, will be clamped between 0.01 and 4.
    /// </summary>
    dust = 14,
    /// <summary>
    /// Additive: 
    ///  float fromRed, //Red value, 0-1
    ///  float fromGreen, //Green value, 0-1
    ///  float fromBlue, //Blue value, 0-1
    ///  float scale, //The scale, will be clamped between 0.01 and 4.
    ///  float toRed, //Red value, 0-1
    ///  float toGreen, //Green value, 0-1
    ///  float toBlue //Blue value, 0-1
    /// </summary>
    dust_color_transition = 15,
    effect = 16,
    elder_guardian = 17,
    enchanted_hit = 18,
    enchant = 19,
    end_rod = 20,
    entity_effect = 21,
    explosion_emitter = 22,
    explosion = 23,
    /// <summary>
    /// Additive: int BlockState //The ID of the block state
    /// </summary>
    falling_dust = 24,
    firework = 25,
    fishing = 26,
    flame = 27,
    soul_fire_flame = 28,
    soul = 29,
    flash = 30,
    happy_villager = 31,
    composter = 32,
    heart = 33,
    instant_effect = 34,
    /// <summary>
    /// Additive: Slot Item //The item that will be used.
    /// </summary>
    item = 35,
    /// <summary>
    /// Additive:
    ///  Position origin, //Starting position
    ///  string positionType, //Type of destination
    ///  Position BlockPosition, //Present if PositionType is "minecraft:block"
    ///  int EntityID, //Present if PositionType is "minecraft:entity"
    ///  int Ticks
    /// </summary>
    vibration = 36,
    item_slime = 37,
    item_snowball = 38,
    large_smoke = 39,
    lava = 40,
    mycelium = 41,
    note = 42,
    poof = 43,
    portal = 44,
    rain = 45,
    smoke = 46,
    sneeze = 47,
    spit = 48,
    squid_ink = 49,
    sweep_attack = 50,
    totem_of_undying = 51,
    underwater = 52,
    splash = 53,
    witch = 54,
    bubble_pop = 55,
    current_down = 56,
    bubble_column_up = 57,
    nautilus = 58,
    dolphin = 59,
    campfire_cosy_smoke = 60,
    campfire_signal_smoke = 61,
    dripping_honey = 62,
    falling_honey = 63,
    landing_honey = 64,
    falling_nectar = 65,
    falling_spore_blossom = 66,
    ash = 67,
    crimson_spore = 68,
    warped_spore = 69,
    spore_blossom_air = 70,
    dripping_obsidian_tear = 71,
    falling_obsidian_tear = 72,
    landing_obsidian_tear = 73,
    reverse_portal = 74,
    white_ash = 75,
    small_flame = 76,
    snowflake = 77,
    dripping_dripstone_lava = 78,
    falling_dripstone_lava = 79,
    dripping_dripstone_water = 80,
    falling_dripstone_water = 81,
    glow_squid_ink = 82,
    glow = 83,
    wax_on = 84,
    wax_off = 85,
    electric_spark = 86,
    scrape = 87,
}