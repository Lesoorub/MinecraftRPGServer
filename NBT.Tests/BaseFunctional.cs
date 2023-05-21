using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBT;
using System.Collections.Generic;

namespace NBT.Tests
{
    [TestClass]
    public class HasTag
    {
        [TestMethod]
        public void NBTTag_hasTag1()
        {
            NBTTag nbt = new NBTTag(new TAG_Compound());
            nbt["key"] = new TAG_String("value");
            Assert.IsTrue(nbt.HasTag("key"));
        }
        [TestMethod]
        public void NBTTag_hasTag2()
        {
            NBTTag nbt = new NBTTag(new TAG_Compound());
            nbt["key"] = new TAG_String("value");
            Assert.IsTrue(!nbt.HasTag("key2"));
        }
        [TestMethod]
        public void NBTTag_hasTag3()
        {
            NBTTag nbt = new NBTTag();
            Assert.IsTrue(!nbt.HasTag("key2"));
        }
        [TestMethod]
        public void NBTTag_hasTag4()
        {
            NBTTag nbt = new NBTTag(new TAG_Compound());
            nbt["key"] = new TAG_String("value");
            Assert.IsTrue(nbt.HasPath("key"));
        }
        [TestMethod]
        public void NBTTag_hasTag5()
        {
            NBTTag nbt = new NBTTag(new TAG_Compound()
            {
                data = new List<TAG>()
                {
                    new TAG_Compound("key1")
                    {
                        data = new List<TAG>()
                        {
                            new TAG_String("value", name: "string")
                        }
                    }
                }
            });
            Assert.IsTrue(nbt.HasPath("key1/string"));
        }
    }
}
