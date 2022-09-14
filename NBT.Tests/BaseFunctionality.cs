using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBT;
using System.Collections.Generic;
using System.Linq;

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
        [TestMethod]
        public void ReadByteArray()
        {
            byte[] arr = new byte[] { 1, 2, 3 };
            var tag = new TAG_Byte_Array(arr);
            int offset = 0;
            tag = new TAG_Byte_Array(tag.Bytes, ref offset);
            Assert.IsTrue((tag.ToObject(typeof(byte[])) as byte[]).SequenceEqual(arr) && offset == arr.Length + 4);
        }
        [TestMethod]
        public void ReadIntArray()
        {
            int[] arr = new int[] { 1, 2, 3 };
            var tag = new TAG_Int_Array(arr);
            int offset = 0;
            tag = new TAG_Int_Array(tag.Bytes, ref offset);
            Assert.IsTrue((tag.ToObject(typeof(int[])) as int[]).SequenceEqual(arr) && offset == arr.Length * 4 + 4);
        }
        [TestMethod]
        public void ReadLongArray()
        {
            long[] arr = new long[] { 1, 2, 3 };
            var tag = new TAG_Long_Array(arr);
            int offset = 0;
            tag = new TAG_Long_Array(tag.Bytes, ref offset);
            Assert.IsTrue((tag.ToObject(typeof(long[])) as long[]).SequenceEqual(arr) && offset == arr.Length * 8 + 4);
        }
    }
}
