using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftData;
using static PalettedContainer;

namespace MinecraftRPGServer.Tests.World
{
    [TestClass]
    public class InDirectPaletteTests
    {
        [TestMethod]
        public void InDirectPalette_EmptyFilledAir()
        {
            var palette = new InDirectPalette(16);
            Assert.IsTrue(palette.Palette.First().value == (short)DefaultBlockState.air);
        }
        [TestMethod]
        public void InDirectPalette_SetBlock_Value()
        {
            var palette = new InDirectPalette(16);
            palette.Set(1, 2, 3, (short)DefaultBlockState.sandstone);
            Assert.IsTrue(palette.Palette[1].value == (short)DefaultBlockState.sandstone);
        }
        [TestMethod]
        public void InDirectPalette_SetBlock_count()
        {
            var palette = new InDirectPalette(16);
            palette.Set(1, 2, 3, (short)DefaultBlockState.sandstone);
            palette.Set(1, 2, 4, (short)DefaultBlockState.sandstone);
            Assert.IsTrue(palette.Palette[1].count == 2);
        }
        [TestMethod]
        public void InDirectPalette_SetBlock_replace()
        {
            var palette = new InDirectPalette(16);
            palette.Set(1, 2, 3, (short)DefaultBlockState.sandstone);
            palette.Set(1, 2, 3, (short)DefaultBlockState.air);
            Assert.IsTrue(palette.Palette.Count == 1);
        }
        [TestMethod]
        public void InDirectPalette_SetBlock_notreplace()
        {
            var palette = new InDirectPalette(16);
            palette.Set(1, 2, 3, (short)DefaultBlockState.sandstone);
            palette.Set(1, 2, 4, (short)DefaultBlockState.sandstone);
            palette.Set(1, 2, 3, (short)DefaultBlockState.air);
            Assert.IsTrue(palette.Palette.Count == 2);
        }
        [TestMethod]
        public void InDirectPalette_SetBlock_Air_Count()
        {
            var palette = new InDirectPalette(16);
            palette.Set(1, 2, 3, (short)DefaultBlockState.sandstone);
            Assert.IsTrue(palette.Palette[0].count == 16 * 16 * 16 - 1);
        }
        [TestMethod]
        public void InDirectPalette_SetBlock_Air_Count2()
        {
            var palette = new InDirectPalette(16);
            palette.Set(1, 2, 3, (short)DefaultBlockState.sandstone);
            palette.Set(1, 2, 3, (short)DefaultBlockState.sandstone);
            Assert.IsTrue(palette.Palette[0].count == 16 * 16 * 16 - 1);
        }
        [TestMethod]
        public void InDirectPalette_GetBlock()
        {
            var palette = new InDirectPalette(16);
            palette.Set(1, 2, 3, (short)DefaultBlockState.sandstone);
            Assert.IsTrue(palette.Get(1, 2, 3) == (short)DefaultBlockState.sandstone);
        }
        [TestMethod]
        public void InDirectPalette_ConvertFromSingle_value()
        {
            var single = new SinglePalette(16, (short)DefaultBlockState.snow);
            var palette = new InDirectPalette(single);
            Assert.IsTrue(palette.Palette[0].value == (short)DefaultBlockState.snow);
        }
        [TestMethod]
        public void InDirectPalette_ConvertFromSingle_count()
        {
            var single = new SinglePalette(16, (short)DefaultBlockState.snow);
            var palette = new InDirectPalette(single);
            Assert.IsTrue(palette.Palette[0].count == 16 * 16 * 16);
        }
        [TestMethod]
        public void InDirectPalette_Palette_Count()
        {
            var palette = new InDirectPalette(16);
            Assert.IsTrue(palette.Palette.Count == 1);
        }
        [TestMethod]
        public void InDirectPalette_BitsPerEntry()
        {
            var palette = new InDirectPalette(16);
            palette.Set(1, 2, 3, (short)DefaultBlockState.snow);
            Assert.IsTrue(palette.BitsPerEntry == 1);
        }
        [TestMethod]
        public void InDirectPalette_BitsPerEntry2()
        {
            var palette = new InDirectPalette(16);
            palette.Set(1, 2, 3, (short)DefaultBlockState.snow);
            palette.Set(1, 2, 4, (short)DefaultBlockState.netherite_block);
            Assert.IsTrue(palette.BitsPerEntry == 2);
        }
    }
}
