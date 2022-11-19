using Microsoft.CSharp;
using System;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftRPGServer
{
    public static class PluginManager
    {
        public static Dictionary<string, PluginInstance> plugins = new Dictionary<string, PluginInstance>();

        public static bool LoadPlugin(RPGServer server, string path)
        {
            var info = new FileInfo(path);
            if (!info.Exists) return false;

            string name = info.Name.Replace(".dll", "");
            try
            {
                plugins.Add(name, new PluginInstance(name, path, System.Reflection.Assembly.LoadFrom(path)));
            }
            catch (Exception ex)
            {
                server.logger.Error($"{name} is not loaded. Exception={ex}");
            }
            finally
            {
                server.logger.Write($"{name} is loaded");
            }
            return true;
        }
        public static void LoadPlugins(RPGServer server, string pluginsPath)
        {
            new DirectoryInfo(pluginsPath).Create();
            foreach (var path in Directory.GetFiles(pluginsPath, "*.dll", SearchOption.TopDirectoryOnly))
            {
                if (!LoadPlugin(server, path))
                    Console.WriteLine($"[{nameof(PluginManager)}] Error on load plugin with path={path}");
            }
        }

        public static void OnPreInit(RPGServer server) 
        {
            foreach (var pl in plugins)
                pl.Value.plugin.OnPreInit(server);
        }
        public static void OnPostInit(RPGServer server)
        {
            foreach (var pl in plugins)
                pl.Value.plugin.OnPostInit(server);
        }

        public static void OnTick(RPGServer server, long tick)
        {
            foreach (var pl in plugins)
                pl.Value.plugin.OnTick(server, tick);
        }


        public static bool OnPlayerLoginIn(Player player, out string reason)
        {
            foreach (var pl in plugins)
                if (!pl.Value.plugin.OnPlayerLoginIn(player, out reason))
                    return false;
            reason = null;
            return true;
        }
        public static void OnPlayerLoginOut(Player player)
        {
            foreach (var pl in plugins)
                pl.Value.plugin.OnPlayerLoginOut(player);
        }
        public static void OnPlayerLoginInCompleted(Player player)
        {
            foreach (var pl in plugins)
                pl.Value.plugin.OnPlayerLoginInCompleted(player);
        }
        public static bool OnPlayerSetBlock(Player player, int x, short y, int z, short blockState)
        {
            foreach (var pl in plugins)
                if (!pl.Value.plugin.OnPlayerSetBlock(player, x, y, z, blockState))
                    return false;
            return true;
        }
    }
}
