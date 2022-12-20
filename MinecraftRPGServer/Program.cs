using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineServer;
using System.Runtime.InteropServices;

namespace MinecraftRPGServer
{
    internal class Program
    {
        /// <summary>
        /// Example to import function from C++
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        //[DllImport(
        //    @"NBT\x64\Debug\NBT.dll", 
        //    CallingConvention = CallingConvention.StdCall)]
        //public static extern int Sum(int a, int b);
        static void Main(string[] args)
        {
            MinecraftData._1_18_2.CodeGenerators.BlocksGenerator.ConvertRawDataBlockFormatToBlockFormat(
                inJsonPath: @"D:\minecraft\blocks.json",
                outputJsonPath: @"D:\minecraft\blocksData.json");
            MinecraftData._1_18_2.CodeGenerators.BlocksGenerator.GenerateCode(
                jsonInPath: @"D:\minecraft\blocksData.json",
                outputCodeDir: @"D:\minecraft\blocks");
            return;

            var server = new RPGServer(StartUpSettings.Parse(args));
            server.Start();
            while (server.isStarted)
                server.ExecuteConsoleCommand(Console.ReadLine());
            server.Stop();
        }
    }
}