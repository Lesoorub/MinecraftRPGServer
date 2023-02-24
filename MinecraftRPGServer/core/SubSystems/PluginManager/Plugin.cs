using System;
using System.IO;
using Newtonsoft.Json;
public class Plugin
{
    public PluginConfig config;
    public virtual void OnPreInit(RPGServer server) { }
    public virtual void OnPostInit(RPGServer server) { }

    public virtual void OnTick(RPGServer server, long tick) { }


    public virtual bool OnPlayerLoginIn(Player player, out string reason) { reason = null; return true; }
    public virtual void OnPlayerLoginOut(Player player) { }
    public virtual void OnPlayerLoginInCompleted(Player player) { }
    public virtual bool OnPlayerSetBlock(Player player, int x, short y, int z, short blockState) => true;
}
public class PluginConfig
{
    [JsonIgnore]
    public FileInfo configInfo;
    public void Save()
    {
        File.WriteAllText(configInfo.FullName, JsonConvert.SerializeObject(this, Formatting.Indented));
    }
}
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class PluginConfigAttribute : Attribute
{
    public Type configType;
    public PluginConfigAttribute(Type configType)
    {
        this.configType = configType;
    }
}