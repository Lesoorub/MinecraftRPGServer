using Newtonsoft.Json;
using System.IO;

namespace MinecraftRPGServer.core
{
    public abstract class Config<T> where T : class, new()
    {
        public static T Load(string Path)
        {
            var (conf, error) = ReadConfigs(Path);
            if (error)
            {
                conf = new T();
                try
                {
                    File.WriteAllText(Path, JsonConvert.SerializeObject(conf, Formatting.Indented));
                }
                catch
                {
                    return conf;
                }
            }
            return conf;
        }
        public static (T cfg, bool error) ReadConfigs(string path)
        {
            if (!File.Exists(path)) return (default, true);
            try
            {
                return (JsonConvert.DeserializeObject(File.ReadAllText(path), typeof(T)) as T, false);
            }
            catch
            {
                return (default, true);
            }
        }
    }
}
