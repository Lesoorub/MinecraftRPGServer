using System.Linq;
using System.IO;

[ChatCommand]
public class SaveAllCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register("save-all", Execute);
    }
    void Execute(RPGServer server, Player player, string[] args)
    {
        var pair = (server.spawnWorld as AnvilWorld).regions.First();
        var key = pair.Key;
        var mca = pair.Value;
        mca.SaveChunks();
        File.WriteAllBytes($"r.{key.x}.{key.y}.mca", mca.ToByteArray());
        server.logger.Write("Save completed!");
    }
}
