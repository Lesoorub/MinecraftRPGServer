using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBT.Tests.Properties;

namespace NBT.Tests
{
    [TestClass]
    public class DynamicObjectTests
    {
        [TestMethod]
        public void BasicWorking()
        {
            var nbt = new NBTTag(new { test = 1 });
            dynamic d = nbt.ToDynamic();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void HasValue()
        {
            var nbt = new NBTTag(new { test = (byte)1 });
            dynamic d = nbt.ToDynamic();
            try
            {
                var x = d.test;
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
            //Assert.IsTrue(d.test == 1 && d.test.GetType() == typeof(byte));
        }
        [TestMethod]
        public void GetByte()
        {
            var nbt = new NBTTag(new { test = (byte)1 });
            dynamic d = nbt.ToDynamic();
            Assert.IsTrue(d.test == (byte)1 &&
                ((object)d.test).GetType() == typeof(sbyte));
        }
        [TestMethod]
        public void GetString()
        {
            var nbt = new NBTTag(new { test = "datatata" });
            dynamic d = nbt.ToDynamic();
            Assert.IsTrue(d.test == "datatata" &&
                ((object)d.test).GetType() == typeof(string));
        }
        [TestMethod]
        public void GetByteArray()
        {
            var nbt = new NBTTag(new { test = new byte[] { 1, 2, 3 } });
            dynamic d = nbt.ToDynamic();
            byte[] bytes = d.test;
            Assert.IsTrue(
                d.test[0] == 1 &&
                d.test[1] == 2 &&
                d.test[2] == 3 &&
                ((object)d.test).GetType() == typeof(byte[]));
        }
        [TestMethod]
        public void ParseTestData_ab4c6e09_9dc0_348e_ba88_9f0cef0e8100()
        {
            var nbt = new NBTTag(Resources.ab4c6e09_9dc0_348e_ba88_9f0cef0e8100);
            dynamic d = nbt.ToDynamic();
            Assert.IsTrue(d.recipeBook.recipes[0].Equals("minecraft:andesite_slab_from_andesite_stonecutting"));
            Assert.IsTrue(d.Inventory[0].Count == 1);
            Assert.IsTrue(d.Inventory[0].id == "minecraft:chest");
            Assert.IsTrue(d.Inventory[0].Slot == 0);
            Assert.IsTrue(d.Inventory[1].Count == 1);
            Assert.IsTrue(d.Inventory[1].id == "minecraft:hopper");
            Assert.IsTrue(d.Inventory[1].Slot == 1);
            Assert.IsTrue(d.EnderItems != null);
        }
        [TestMethod]
        public void GetList()
        {
            var nbt = new NBTTag(new { list = new string[] { "a", "b" } });
            dynamic d = nbt.ToDynamic();
            Assert.IsTrue(
                ((object)d.list[0]).Equals("a") &&
                ((object)d.list[1]).Equals("b"));
        }
        [TestMethod]
        public void GetCompound()
        {
            var nbt = new NBTTag(new 
            {
                comp = new
                {
                    test = 1
                }
            });
            dynamic d = nbt.ToDynamic();
            Assert.IsTrue(d.comp.test == 1);
        }
    }
}
