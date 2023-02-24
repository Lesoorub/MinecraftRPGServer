using CommandLine;

namespace MinecraftRPGServer
{
    public class StartUpSettings
    {
        [Option('p', "port", Required = false, HelpText = "Set port.")]
        public ushort port { get; set; } = 25565;

        [Option("noreadconfigs", Required = false, HelpText = "Core will be ignore any config file.")]
        public bool NoReadConfigs { get; set; } = false;

        public static StartUpSettings Parse(string[] args)
        {
            return Parser.Default.ParseArguments<StartUpSettings>(args).Value;
        }
    }
}