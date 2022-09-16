using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBT;
using System.Collections.Generic;
using System.Linq;
using static NBT.Tests.Properties.Resources;

namespace MinecraftRPGServer.Tests.NBT
{
    [TestClass]
    public class Parse
    {
        [TestMethod]
        public void ParseAnonimousObject()
        {
            var nbt = NBTTag.Parse(new
            {
                i8 = (byte)255,
                i16 = (short)25621,
                i32 = 123,
                i64 = 1235L,
                f32 = 0.1f,
                f64 = 0.1d,
                str = "string",
                anotherObject = new
                {
                    anotherObject_i8 = (byte)112,
                    anotherObject_i16 = (short)5121,
                    anotherObject_i32 = 45623,
                    anotherObject_i64 = 1534645L,
                    anotherObject_f32 = 2.5f,
                    anotherObject_f64 = 1.2d,
                    anotherObject_str = "anotherObject_string",
                },
                i32_arr = new int[] { 1, 2, 3, 4 },
                i8_arr = new byte[] { 2, 4, 8, 16, 32 },
                i64_arr = new long[] { 123, 453, 547, 1231 },
                False = false,
            });

            Assert.IsTrue((byte)nbt["i8"] == 255);
        }
        [TestMethod]
        public void ParseByte()
        {
            var nbt = NBTTag.Parse(new
            {
                i8 = (byte)123,
            });

            Assert.IsTrue((byte)nbt["i8"] == 123);
        }
        [TestMethod]
        public void ParseShort()
        {
            var nbt = NBTTag.Parse(new
            {
                i16 = (short)25121,
            });

            Assert.IsTrue((short)nbt["i16"] == 25121);
        }
        [TestMethod]
        public void ParseInt()
        {
            var nbt = NBTTag.Parse(new
            {
                i32 = (int)665577,
            });

            Assert.IsTrue((int)nbt["i32"] == 665577);
        }
        [TestMethod]
        public void ParseLong()
        {
            var nbt = NBTTag.Parse(new
            {
                i64 = (long)5000000000L,
            });

            Assert.IsTrue((long)nbt["i64"] == 5000000000L);
        }
        [TestMethod]
        public void ParseFloat()
        {
            var nbt = NBTTag.Parse(new
            {
                f32 = (float)0.1f,
            });

            Assert.IsTrue((float)nbt["f32"] == 0.1f);
        }
        [TestMethod]
        public void ParseDouble()
        {
            var nbt = NBTTag.Parse(new
            {
                f64 = (double)0.1d,
            });

            Assert.IsTrue((double)nbt["f64"] == 0.1d);
        }
        [TestMethod]
        public void ParseBoolTrue()
        {
            var nbt = NBTTag.Parse(new
            {
                boolean = true,
            });

            Assert.IsTrue((bool)nbt["boolean"]);
        }
        [TestMethod]
        public void ParseBoolFalse()
        {
            var nbt = NBTTag.Parse(new
            {
                boolean = false,
            });

            Assert.IsTrue(!(bool)nbt["boolean"]);
        }
        [TestMethod]
        public void ParseByteArray()
        {
            var nbt = NBTTag.Parse(new
            {
                i8_arr = new byte[] { 1, 2, 3, 4 },
            });

            Assert.IsTrue(((byte[])nbt["i8_arr"]).SequenceEqual(new byte[] { 1, 2, 3, 4 }));
        }
        [TestMethod]
        public void ParseIntArray()
        {
            var nbt = NBTTag.Parse(new
            {
                i32_arr = new int[] { 1, 2, 3, 4 },
            });

            Assert.IsTrue(((int[])nbt["i32_arr"]).SequenceEqual(new int[] { 1, 2, 3, 4 }));
        }
        [TestMethod]
        public void ParseLongArray()
        {
            var nbt = NBTTag.Parse(new
            {
                i64_arr = new long[] { 1, 2, 3, 4 },
            });

            Assert.IsTrue(((long[])nbt["i64_arr"]).SequenceEqual(new long[] { 1, 2, 3, 4 }));
        }
        [TestMethod]
        public void ParseString()
        {
            var nbt = NBTTag.Parse(new
            {
                str = "string",
            });

            Assert.IsTrue(((string)nbt["str"]).Equals("string"));
        }
        [TestMethod]
        public void ParseList()
        {
            var arr = new string[] { "a", "b", "c" };
            var nbt = NBTTag.Parse(new
            {
                str_array = arr,
            });
            Assert.IsTrue(nbt["str_array"] is TAG_List list && list.data.Select(x => (string)x).SequenceEqual(arr));
        }
        [TestMethod]
        public void ParseObject()
        {
            var nbt = NBTTag.Parse(new
            {
                obj = new
                {
                    i32 = 123
                }
            });

            Assert.IsTrue(nbt["obj"] is TAG_Compound comp && (int)comp["i32"] == 123);
        }

        [TestMethod]
        public void ParseClass()
        {
            var obj = new SomeData()
            {
                cost = 24,
                name = "username",
                position = new v2i(1, 2) 
            };
            var nbt = NBTTag.Parse(obj);

            Assert.IsTrue(
                (int)nbt["cost"] == obj.cost && 
                ((string)nbt["name"]).Equals(obj.name) && 
                ((int)nbt["position"]["x"]) == 1 &&
                ((int)nbt["position"]["y"]) == 2);
        }
        public class SomeData
        {
            public int cost;
            public string name;
            public v2i position;
        }
        [TestMethod]
        public void ToObjectSomeData()
        {
            var nbt = NBTTag.Parse(new
            {
                cost = 24,
                name = "username",
                position = new v2i(1, 2)
            });
            var obj = nbt.ToObject<SomeData>();
            Assert.IsTrue(obj.cost == 24 && obj.name.Equals("username") && obj.position != null && obj.position.x == 1 && obj.position.y == 2);
        }
        [TestMethod]
        public void ToObjectList()
        {
            var nbt = NBTTag.Parse(new string[] { "a", "b", "c" });
            var obj = nbt.ToObject<List<string>>();
            Assert.IsTrue(obj[0] == "a" && obj[1] == "b" && obj[2] == "c");
        }
        [TestMethod]
        public void TagToObjectList()
        {
            var nbt = NBTTag.Parse(new { string_array = new string[] { "a", "b", "c" } });
            var obj = nbt["string_array"].ToObject<List<string>>();
            Assert.IsTrue(obj[0] == "a" && obj[1] == "b" && obj[2] == "c");
        }
        [TestMethod]
        public void NotRecursiveParse()
        {
            var nbt = new NBTTag(level2, true);

            int offset = 0;
            var parsed = NBTTag.ParseNotRecursive(nbt.Bytes, ref offset);

            Assert.IsTrue(parsed.Bytes.SequenceEqual(nbt.Bytes));
        }
    }
}
