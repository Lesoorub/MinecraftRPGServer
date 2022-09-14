using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftRPGServer.Tests.World
{
    [TestClass]
    public class PaletteContainerTests
    {
        [TestMethod]
        public void PalettedContainer2_Get_Equal_Set()
        {
            var container = new PalettedContainer(0, 16, 4, 15);
            container.Set(1, 2, 3, (short)DefaultBlockState.sandstone);
            Assert.IsTrue(container.Get(1, 2, 3) == (short)DefaultBlockState.sandstone);
        }
        [TestMethod]
        public void PalettedContainer2_EmptyIsSingle()
        {
            var container = new PalettedContainer(0, 16, 2, 15);
            Assert.IsTrue(container.type == PaletteType.Single);
        }
        [TestMethod]
        public void PalettedContainer2_OnceSet()
        {
            var container = new PalettedContainer(0, 16, 2, 15);
            container.Set(1, 2, 3, (short)DefaultBlockState.sandstone);
            Assert.IsTrue(container.type == PaletteType.Indirect);
        }
        [TestMethod]
        public void PalettedContainer2_AutoConvertToDirect()
        {
            byte thr = 4;
            var container = new PalettedContainer(0, 16, thr, 15);
            container.Set(0, 2, 3, 4);//Indirect, palette: 0, 5
            for (int k = 0; k < Math.Pow(2, thr) - 2; k++)
            {
                if (container.type != PaletteType.Indirect)
                    Assert.Fail();
                container.Set(k + 1, 2, 3, (short)(k + 5));
            }
            Assert.IsTrue(container.type == PaletteType.Direct);
        }
        [TestMethod]
        public void PalettedContainer2_ToByteArray_Single()
        {
            short fillElement = 2;
            var container = new PalettedContainer(fillElement, 16, 2, 15);
            Assert.IsTrue(container.ToByteArray().SequenceEqual(new byte[] { 0 }.Combine(new VarInt(fillElement).Bytes).Combine(0)));
        }
    }
}
