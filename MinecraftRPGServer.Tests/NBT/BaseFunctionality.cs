using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MinecraftRPGServer.Tests.NBT
{
    [TestClass]
    public class BaseFunctionality
    {
        [TestMethod]
        public void Create1()
        {
            NBTTag tag = new NBTTag();
            Assert.IsNotNull(tag);
        }
        [TestMethod]
        public void AddressableInt()
        {
            const int cost = 1;

            TAG tag = new NBTTag().root;
            tag[nameof(cost)] = cost;

            Assert.IsTrue(
                (int)tag[nameof(cost)] == cost);
        }
        [TestMethod]
        public void AddressableString_normal()
        {
            const string name = "andrey";

            TAG tag = new NBTTag().root;
            tag[nameof(name)] = name;

            Assert.IsTrue(
                (string)tag[nameof(name)] == name);
        }
        [TestMethod]
        public void AddressableString_null()
        {
            const string name = null;

            TAG tag = new NBTTag().root;
            tag[nameof(name)] = name;

            Assert.IsTrue(
                (string)tag[nameof(name)] == name);
        }

        [TestMethod]
        public void AccessToNotExistsTag()
        {
            TAG tag = new NBTTag().root;
            Assert.IsNull(tag["name"]);
        }

        [TestMethod]
        public void RewriteTagString()
        {
            TAG tag = new NBTTag().root;
            tag["name"] = "1";
            tag["name"] = "2";
            Assert.IsTrue(((string)tag["name"]).Equals("2"));
        }
        [TestMethod]
        public void RewriteTagInt()
        {
            TAG tag = new NBTTag().root;
            tag["name"] = 1;
            tag["name"] = "2";
            Assert.IsTrue(((string)tag["name"]).Equals("2"));
        }
        [TestMethod]
        public void AccessWithNullKey()
        {
            TAG tag = new NBTTag().root;
            Assert.IsNull(tag[null]);
        }
        [TestMethod]
        public void SetWithNullKey()
        {
            TAG tag = new NBTTag().root;
            tag[null] = 1;
            Assert.IsTrue(tag[null] == null);
        }
    }
}
