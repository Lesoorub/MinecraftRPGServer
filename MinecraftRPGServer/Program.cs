using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineServer;

namespace MinecraftRPGServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NBT_Tests.Test("nbt tests");
            //Console.ReadLine();
            //return;

            var server = new RPGServer(25565);
            server.Start();
            while (server.isStarted)
                server.ExecuteConsoleCommand(Console.ReadLine());
            server.Stop();
        }
    }
}
