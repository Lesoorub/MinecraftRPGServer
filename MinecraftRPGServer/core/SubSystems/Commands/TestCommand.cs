using Packets.Play;
using System.Linq;
using System.IO;
using MineServer;
using MinecraftLightEngine;

[ChatCommand]
public class TestCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("test", Execute);
    }
    void Execute(RPGServer server, Player player, string[] args)
    {
        var cpos = player.ChunkPos;
        var sector = player.BlockPos.y >> 4;

        var lengine = new LightEngine();
        var data = lengine.CreateBlockLightData(player.world, cpos.x, (short)sector, cpos.y);

        player.world.GetChunk(cpos).SetBlockLightData(sector, data);
    }
}
[ChatCommand]
public class SaveAllCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("save-all", Execute);
    }
    void Execute(RPGServer server, Player player, string[] args)
    {
        var pair = (server.spawnWorld as SimpleWorld).regions.First();
        var key = pair.Key;
        var mca = pair.Value;
        mca.SaveChunks();
        File.WriteAllBytes($"r.{key.x}.{key.y}.mca", mca.ToByteArray());
        server.logger.WriteLine("Save completed!");
    }
}
