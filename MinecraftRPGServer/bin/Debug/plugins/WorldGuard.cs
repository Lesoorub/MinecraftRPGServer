using Newtonsoft.Json;
using System;

[PluginConfig(typeof(WorldGuardConfig))]
public class WorldGuard : Plugin
{
    public override void OnPlayerLoginInCompleted(Player player)
    {
        player.EchoSystemMessage("WorldGuard enabled");
    }
    public override bool OnPlayerSetBlock(Player player, int x, short y, int z, short blockState)
    {
        return (config as WorldGuardConfig).allowEdit;
    }
}
public class WorldGuardConfig : PluginConfig
{
    public bool allowEdit = false;
}
[ChatCommand]
public class WGCommand : IChatCommand
{
    public void Register()
    {
        Commands.Register(new Node()
        {
            Name = "wg",
            Flags = Node.FlagsEnum.literal | Node.FlagsEnum.IsExecutable
        },
        Execute);
    }
    void Execute(RPGServer server, Player player, string[] args)
    {
        player.EchoIntoChatFromServer("wg!");
    }
}