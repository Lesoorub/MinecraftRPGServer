using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using Newtonsoft.Json;

namespace ResoursePackCreator
{
    class Program
    {
        static string SpritesFolder = "Sprites";
        static string TempFolder = "Temp";
        static string ResourcePackPath = "Pack.zip";

        static string TempModelsDir = Path.Combine(TempFolder, "assets", "minecraft", "models", "item");
        static string TempItemDir = Path.Combine(TempFolder, "assets", "minecraft", "textures", "item");
        static StringBuilder enumbuilder = new StringBuilder();
        static void Main(string[] args)
        {
            string copyto = null;
            if (args.Length > 0)
            {
                for (int k = 0; k < args.Length; k++)
                {
                    switch (args[k])
                    {
                        case "-in:path":
                            SpritesFolder = args[++k];
                            break;
                        case "-TempFolder":
                            TempFolder = args[++k];
                            break;
                        case "-copyto:path":
                            copyto = args[++k];
                            break;
                        case "-out:name":
                            ResourcePackPath = args[++k];
                            if (string.IsNullOrEmpty(ResourcePackPath.Trim()))
                                ResourcePackPath = "Pack.zip";
                            if (ResourcePackPath.EndsWith("."))
                                ResourcePackPath += "zip";
                            if (ResourcePackPath.StartsWith("."))
                                ResourcePackPath = "Pack" + ResourcePackPath;
                            if (Path.GetFileNameWithoutExtension(ResourcePackPath) == ResourcePackPath)
                                ResourcePackPath += ".zip";
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine(
                    $"Allowed arguments: {Environment.NewLine}" +
                    $" -copyto:path        - default: /{Environment.NewLine}" +
                    $" -in:path            - default: {SpritesFolder}{Environment.NewLine}" +
                    $" -TempFolder         - default: {TempFolder}{Environment.NewLine}" +
                    $" -out:name           - default: {ResourcePackPath}{Environment.NewLine}");
            }

            if (Directory.Exists(TempFolder))
                Directory.Delete(TempFolder, true);

            Directory.CreateDirectory(TempFolder);

            SetPackData("pack.png", "Custom description");
            enumbuilder.AppendLine("public enum CustomModelData : int");
            enumbuilder.AppendLine("{");
            CompileFiles();
            CreateZipFile();
            enumbuilder.AppendLine("}");
            if (!string.IsNullOrEmpty(copyto))
                File.Copy(ResourcePackPath, Path.Combine(copyto, ResourcePackPath), true);

            if (Directory.Exists(TempFolder))
                Directory.Delete(TempFolder, true);
            File.WriteAllText("CustomModelData.cs", enumbuilder.ToString());
        }

        static void SetPackData(string imagePath, string packDescription)
        {
            Console.WriteLine("Create pack info");
            var imageinfo = new FileInfo(imagePath);
            if (imageinfo.Extension != ".png")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fatal error. Texture pack image is not valid. Extension is not .png");
                Console.ResetColor();
                return;
            }
            File.WriteAllText(Path.Combine(TempFolder, "pack.mcmeta"),
                JsonConvert.SerializeObject(new McMeta(packDescription), Formatting.Indented));
            File.Copy(imagePath, Path.Combine(TempFolder, "pack.png"));
        }
        static void CompileFiles()
        {
            new DirectoryInfo(TempModelsDir).Create();
            new DirectoryInfo(TempItemDir).Create();

            foreach(var dirpath in Directory.GetDirectories(SpritesFolder))
            {
                var directoryInfo = new DirectoryInfo(dirpath);
                string itemName = Path.GetFileNameWithoutExtension(directoryInfo.Name);

                List<(string model, int id)> t = new List<(string model, int id)>();
                foreach (var imgPath in Directory.GetFiles(dirpath))
                {
                    var image = Path.GetFileNameWithoutExtension(imgPath);
                    int id = CreateMD5(imgPath);

                    if (image.Contains(" "))
                        image = image.Replace(" ", "_").ToLower();

                    enumbuilder.AppendLine($"{image} = {id},");
                    Console.WriteLine("Create " + Path.Combine(TempModelsDir, image + ".json") + " with id=" + id);
                    File.WriteAllText(Path.Combine(TempModelsDir, image + ".json"),
                        JsonConvert.SerializeObject(new ItemModel(image), Formatting.Indented, new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        }));

                    File.Copy(imgPath, Path.Combine(TempItemDir, Path.GetFileName(imgPath).Replace(" ", "_").ToLower()));

                    t.Add((Path.Combine("item", image).Replace("\\", "/"), id));
                }

                Console.WriteLine("Create " + Path.Combine(TempModelsDir, itemName + ".json"));
                //write item
                File.WriteAllText(Path.Combine(TempModelsDir, itemName + ".json"),
                    JsonConvert.SerializeObject(new ItemModel(itemName, t.ToArray()), Formatting.Indented, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    }));
            }
        }
        static void CreateZipFile()
        {
            if (File.Exists(ResourcePackPath))
                File.Delete(ResourcePackPath);
            ZipFile.CreateFromDirectory(TempFolder, ResourcePackPath);
        }
        public static int CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Math.Abs(hashBytes[0] << 24 | hashBytes[1] << 16 | hashBytes[2] << 8 | hashBytes[3]);

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }
    }
    public class McMeta
    {
        public McMeta(string description)
        {
            pack = new _pack()
            {
                description = description
            };
        }
        public _pack pack;
        public class _pack
        {
            public int pack_format = 8; // 1.16.5
            public string description = "Standart description";
        }
    }
    public class ItemModel
    {
        public string parent = "item/generated";
        public _textures textures;
        public _override[] overrides = null;
        public ItemModel(string sprite)
        {
            textures = new _textures(Path.Combine("item", sprite).Replace("\\", "/"));
        }
        public ItemModel(string sprite, (string modelItem, int id)[] ids)
        {
            textures = new _textures(Path.Combine("item", sprite).Replace("\\", "/"));
            overrides = new _override[ids.Length];
            for (int k = 0; k < ids.Length; k++)
                overrides[k] = new _override() 
                { 
                    model = ids[k].modelItem,
                    predicate = new _override._predicate() 
                    { 
                        custom_model_data = ids[k].id
                    } 
                };
        }
        public class _textures
        {
            public string layer0;

            public _textures(string layer0)
            {
                this.layer0 = layer0;
            }
        }
        public class _override
        {
            public string model;
            public _predicate predicate;

            public class _predicate
            {
                public int custom_model_data = 1000000;
            }
        }
    }
}
