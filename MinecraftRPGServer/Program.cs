using System;

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
            var server = new MinecraftCore(StartUpSettings.Parse(args));
            server.Start();
            while (server.isStarted)
                server.ExecuteConsoleCommand(Console.ReadLine());
            server.Stop();
        }
    }
}