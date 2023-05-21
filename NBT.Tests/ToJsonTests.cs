using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBT.Tests.Properties;

namespace NBT.Tests
{
    [TestClass]
    public class ToJsonTests
    {
        [TestMethod]
        public void BasicWorking()
        {
            var nbt = new NBTTag(new { test = 1 });
            var json = nbt.ToJson();
            Assert.IsTrue(json.Length > 0);
        }

        [TestMethod]
        public void IntVariable()
        {
            var nbt = new NBTTag(new { test = 1 });
            Assert.IsTrue(nbt.ToJson().Equals("{\"test\":1}"));
        }
        [TestMethod]
        public void StringVariable()
        {
            var nbt = new NBTTag(new { test = "123b" });
            Assert.IsTrue(nbt.ToJson().Equals("{\"test\":\"123b\"}"));
        }
        [TestMethod]
        public void Example_ab4c6e09_9dc0_348e_ba88_9f0cef0e8100()
        {
            var nbt = new NBTTag(Resources.ab4c6e09_9dc0_348e_ba88_9f0cef0e8100);
            var json = nbt.ToJson();
            Assert.IsTrue(Newtonsoft.Json.JsonConvert.DeserializeObject(json) != null);
        }
    }
}
