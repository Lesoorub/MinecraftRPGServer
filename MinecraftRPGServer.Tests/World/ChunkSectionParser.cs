using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static PalettedContainer;
using Utf8Json;

namespace MinecraftRPGServer.Tests.World
{
    [TestClass]
    public class ChunkSectionParserTests
    {
        [TestMethod]
        public void StateIDSpeed()
        {
            var args = Utf8Json.JsonSerializer.Deserialize<List<Arg>>(Properties.Resources.args);
            short result = 0;
            foreach (var arg in args)
            {
                if ((result = ChunkSectionParser.StateIDFromTAG(arg.name, arg.props)) != arg.result)
                    throw new System.Exception($"{arg.name} => {result} != {arg.result}");
                    
            }
            for (int k = 0; k < 100; k++)
            {
                foreach (var arg in args)
                    ChunkSectionParser.StateIDFromTAG(arg.name, arg.props);
            }
            Assert.IsTrue(true);
        }
        public struct Arg
        {
            public string name;
            public Dictionary<string, string> props;
            public short result;
        }
    }
}