using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using static NBT.Tests.Properties.Resources;
using NBT;
using MineServer;

namespace MinecraftRPGServer.Tests.NBT
{
    [TestClass]
    public class RealData
    {
        [TestMethod]
        public void NBTTag_Level2()
        {
            TestNBT(level2);
        }
        [TestMethod]
        public void NBTTag_servers()
        {
            TestNBT(servers);
        }
        [TestMethod]
        public void NBTTag_map()
        {
            TestNBT(map_5);
        }
        [TestMethod]
        public void NBTTag_userdata()
        {
            TestNBT(ab4c6e09_9dc0_348e_ba88_9f0cef0e8100);
        }

        [TestMethod]
        public void NBTTag_streamreading()
        {
            var firstNBT = GZip.Decompress(ab4c6e09_9dc0_348e_ba88_9f0cef0e8100);
            var secondNBT = GZip.Decompress(map_5);
            var data = firstNBT.Combine(secondNBT);

            NBTTag nbt = new NBTTag();
            nbt.FromByteArray(data, offset: 0, out var len);
            Assert.AreEqual(len, firstNBT.Length);
        }

        private void TestNBT(byte[] bytes)
        {
            //Try decompress
            try
            {
                bytes = GZip.Decompress(bytes);
            }
            catch { }
            NBTTag nbt = new NBTTag(bytes, false);
            Assert.IsTrue(bytes.SequenceEqual(nbt.Bytes));
        }
        [TestMethod]
        public void MCATest()
        {
            var mca = new MCA(r__1__1);
            v2i.ForEach(new v2i(32, 32), (cpos) =>
            {
                mca.GetChunk(cpos.x, cpos.y);
            });
            Assert.IsTrue(true);
        }
    }
}
