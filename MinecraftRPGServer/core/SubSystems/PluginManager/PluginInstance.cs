using System;
using System.IO;
using System.Linq;
using System.CodeDom.Compiler;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MinecraftRPGServer
{
    public class PluginInstance
    {
        public Plugin plugin;

        public Assembly assembly;
        public object instance;
        public Type type;
        public string name;
        public string path;

        public PluginInstance(string name, string path, CompilerResults cr)
        {
            this.name = name;
            this.path = path;
            assembly = cr.CompiledAssembly;
            instance = assembly.CreateInstance(name);
            type = instance.GetType();
            plugin = (Plugin)instance;

            if (type.CustomAttributes.Any(x => x.AttributeType == typeof(PluginConfigAttribute)))
            {
                LoadConfig(type.GetCustomAttribute<PluginConfigAttribute>().configType);
            }
        }

        void LoadConfig(Type confType)
        {
            var confFile = new FileInfo(Path.Combine(path.Replace(name + ".cs", ""), name + ".conf"));
            if (!confFile.Exists)
            {
                plugin.config = (PluginConfig)Activator.CreateInstance(confType);
                plugin.config.configInfo = confFile;
                plugin.config.Save();
            }
            else
            {
                plugin.config = (PluginConfig)JsonConvert.DeserializeObject(File.ReadAllText(confFile.FullName), confType);
            }
            plugin.config.configInfo = confFile;
        }
    }
}
