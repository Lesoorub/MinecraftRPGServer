using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MinecraftData._1_18_2.CodeGenerators
{
    public static class Tools
    {
        public static Dictionary<string, T> ReadBigJson<T>(string path)
        {
            if (!File.Exists(path)) throw new Exception("Not found file");
            var data = new Dictionary<string, T>();

            using (var streamReader = new StreamReader(path))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                jsonReader.SupportMultipleContent = true;
                var serializer = new JsonSerializer();
                while (jsonReader.Read())
                {
                    if (jsonReader.TokenType == JsonToken.StartObject)
                    {
                        var meta = (JObject)serializer.Deserialize(jsonReader);
                        var props = meta.Properties();
                        foreach (var property in props)
                            data.Add(property.Name, property.Value.ToObject<T>());
                    }
                }
            }
            return data;
        }
    }
}