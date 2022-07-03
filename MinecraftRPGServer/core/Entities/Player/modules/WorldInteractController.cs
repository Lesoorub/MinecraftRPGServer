using System.Collections.Generic;
using Packets.Play;
using System;
using System.Runtime.CompilerServices;
using Inventory;

public class WorldInteractController : IModule
{
    Player player;
    public List<v2i> loadedChunks = new List<v2i>();
    public Position? BlockBreakingPosition;
    /// <summary>
    /// Time in milliseconds
    /// </summary>
    public long BlockBreakingEndTime = 0;
    public void Init(Player player)
    {
        this.player = player;
        player.OnChunkChanged += Player_OnChunkChanged;
    }

    private void Player_OnChunkChanged(v2i lastchunk, v2i newchunk)
    {
        SendUpdateViewPosition();
        SendWorld();
    }
    public void Tick()
    {
    }
    public void SendWorld()
    {
        lock (loadedChunks)
        {
            int r = player.settings.ViewDistance + 1;
            var cpos = player.ChunkPos;

            for (int k = 0; k < r; k++)
                for (int x = -k; x <= k; x++)
                    for (int z = -k; z <= k; z++)
                    {
                        if (Math.Abs(x) != k && Math.Abs(z) != k) continue;
                        var rpos = new v2i(x + cpos.x, z + cpos.y);
                        if (loadedChunks.Contains(rpos))
                            continue;
                        loadedChunks.Add(rpos);
                        var chunk = player.world.GetChunk(rpos);
                        if (chunk == null)
                            continue;
                        //Нам придется каждый раз либо создавать новый пакет,
                        //либо использовать кешированный для каждого поддерживаемого протокола
                        player.network.Send(new ChunkDataAndUpdateLight()
                        {
                            ChunkX = chunk.cPos.x,
                            ChunkZ = chunk.cPos.y,
                            Heightmaps = chunk.Heightmaps,
                            Data = chunk.Data,
                            BlockEntities = chunk.BlockEntities,
                            TrustEdges = true,
                            SkyLightMask = chunk.SkyMask,
                            BlockLightMask = chunk.BlockMask,
                            EmptySkyLightMask = chunk.EmptySkyMask,
                            EmptyBlockLightMask = chunk.EmptyBlockMask,
                            SkyLightArray = chunk.SkyLightArrays,
                            BlockLightArray = chunk.BlockLightArrays
                        });
                    }
            //Unload chunks
            foreach (var pos in loadedChunks)
            {
                if (Math.Abs(pos.x - cpos.x) > r ||
                    Math.Abs(pos.y - cpos.y) > r)
                    SendUnloadChunk(pos);
            }
            loadedChunks.RemoveAll(pos =>
                Math.Abs(pos.x - cpos.x) > r ||
                Math.Abs(pos.y - cpos.y) > r);
        }
    }
    public void SendUpdateViewPosition()
    {
        var cpos = player.ChunkPos;
        player.network.Send(new UpdateViewPosition()
        {
            ChunkX = cpos.x,
            ChunkZ = cpos.y,
        });
    }
    public void UnloadChunks()
    {
        lock (loadedChunks)
        {
            foreach (var pos in loadedChunks)
                SendUnloadChunk(pos);
            loadedChunks.Clear();
        }
    }
    public void SendUnloadChunk(v2i pos)
    {
        player.network.Send(new UnloadChunk()
        {
            ChunkX = pos.x,
            ChunkZ = pos.y,
        });
    }
    public void StartBreakBlock(Position position)
    {
        if (BlockBreakingPosition.HasValue && position.Equals(BlockBreakingPosition.Value))
            return;
        BlockBreakingPosition = position;
        float breakTime = GetBreakingTime();
        if (breakTime < 0) return;
        BlockBreakingEndTime = Time.Now() + (long)breakTime;
    }
    public bool canBreak(Position position) => position.Equals(BlockBreakingPosition) && Time.Now() >= BlockBreakingEndTime;
    public void EndlBreakBlock()
    {
        BlockBreakingPosition = null;
        BlockBreakingEndTime = 0;
    }
    public float GetBreakingTime()
    {
        //input
        var breakingblockstate = player.world.GetBlock(BlockBreakingPosition);
        var breakingBlock = breakingblockstate.blockid;
        ItemID tool = player.MainHand != null ? player.MainHand.ItemID : ItemID.air;

        //tool impact
        float toolMultiplier = ToolMath.getToolSpeed(tool);
        float blockHardness = breakingblockstate.hardness;
        if (blockHardness < 0) return -1;
        bool canHarvest = ToolMath.canHarvest(tool, breakingBlock);
        bool isBestTool = ToolMath.isSpecificTool(ToolMath.ToolType.none, breakingBlock);
        //tool enchantments
        float efficiencyLevel = 0;
        bool toolEfficiency = efficiencyLevel != 0;

        //player impact
        bool inWater = false;
        bool onGround = player.OnGround;
        //armor enchanments
        bool hasAquaAffinity = false;
        //effects
        float hasteLevel = 0;
        bool hasteEffect = hasteLevel != 0;
        float miningFatigueLevel = 0;
        bool miningFatigue = miningFatigueLevel != 0;

        //calculation
        float speedMultiplier = 1;
        float damage;//Сколько урона получит инструмент
        if (isBestTool)
        {
            speedMultiplier = toolMultiplier;
            if (!canHarvest)
                speedMultiplier = 1;
            else if (toolEfficiency)
                speedMultiplier += (float)Math.Pow(efficiencyLevel, 2) + 1;
        }
        if (hasteEffect)
          speedMultiplier *= 0.2f * hasteLevel + 1;
        if (miningFatigue)
          speedMultiplier *= (float)Math.Pow(0.3, Math.Min(miningFatigueLevel, 4));
        if (inWater && !hasAquaAffinity)
          speedMultiplier /= 5f;
        if (!onGround)
          speedMultiplier /= 5f;
        damage = speedMultiplier / blockHardness;
        if (canHarvest)
          damage /= 30f;
        else
          damage /= 100f;
        if (damage > 1)
          return 0;
        float ticks = (float)Math.Ceiling(1f / damage);
        Console.WriteLine($"ticks=" + ticks);
        return ticks / 20f;
    }
}