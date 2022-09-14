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
        static CSharpCodeProvider c = new CSharpCodeProvider();
        public static bool LoadPlugin(string path)
        {
            var info = new FileInfo(path);
            if (!info.Exists) return false;


            CompilerParameters cp = new CompilerParameters()
            {
                CompilerOptions = "/t:library",
                GenerateInMemory = true,
            };

            var code = File.ReadAllText(path);

            cp.ReferencedAssemblies.AddRange(AppDomain.CurrentDomain
                            .GetAssemblies()
                            .Where(a => !a.IsDynamic)
                            .Select(a => a.Location).ToArray());

            CompilerResults cr = c.CompileAssemblyFromSource(cp, code);
            if (cr.Errors.Count > 0)
            {
                foreach (var err in cr.Errors)
                    Console.WriteLine(string.Format("[{0}] {1}", info.Name, err));
                return false;
            }
            string name = info.Name.Replace(".cs", "");
            plugins.Add(name, new PluginInstance(name, path, cr));
            return true;
        }
        public static void LoadPlugins(string pluginsPath)
        {
            new DirectoryInfo(pluginsPath).Create();
            foreach (var path in Directory.GetFiles(pluginsPath, "*.cs", SearchOption.TopDirectoryOnly))
            {
                if (!LoadPlugin(path))
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
