using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using MineServer;

namespace MineSocket.NET.Tests
{
    [TestClass]
    public class ArrayWriterTests
    {
        //int
        [TestMethod]
        public void WriteInt_L()
        {
            var writer = new ArrayWriter();
            writer.Write<int>(123);
            Assert.IsTrue(writer.ToArray().SequenceEqual(new byte[] { 0x7b, 0, 0, 0 }));
        }
        [TestMethod]
        public void WriteInt_B()
        {
            var writer = new ArrayWriter(true);
            writer.Write<int>(123);
            Assert.IsTrue(writer.ToArray().SequenceEqual(new byte[] { 0, 0, 0, 0x7b }));
        }
        [TestMethod]
        public void Write1000000Int_L()
        {
            var writer = new ArrayWriter();
            for (int k = 0; k < 1000000; k++)
                writer.Write(123, typeof(int));
            var bytes = writer.ToArray();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void Write1000000Int_B()
        {
            var writer = new ArrayWriter(true);
            for (int k = 0; k < 1000000; k++)
                writer.Write(123, typeof(int));
            var bytes = writer.ToArray();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void WriteIntArray_L()
        {
            var writer = new ArrayWriter();
            int[] arr = new int[] { 1, 2, 5, 164, 123246234, 1231, 675 };
            writer.Write(arr);
            var bytes = writer.ToArray();
            Assert.IsTrue(bytes.SequenceEqual(FastByteArrayExtensions.Combine(new byte[][]
            {
                new VarInt(arr.Length).Bytes,
                arr.SelectMany(x => BitConverter.GetBytes(x)).ToArray()
            })));
        }
        [TestMethod]
        public void WriteIntArray_B()
        {
            var writer = new ArrayWriter(true);
            int[] arr = new int[] { 1, 2, 5, 164, 123246234, 1231, 675 };
            writer.Write(arr);
            var bytes = writer.ToArray();
            Assert.IsTrue(bytes.SequenceEqual(FastByteArrayExtensions.Combine(new byte[][]
            {
                new VarInt(arr.Length).Bytes,
                arr.SelectMany(x => BitConverter.GetBytes(x).Reverse()).ToArray()
            })));
        }
        //varint
        [TestMethod]
        public void WriteVarIntArray()
        {
            var writer = new ArrayWriter(true);
            var arr = new VarInt[] { 1, 2, 5, 164, 123246234, 1231, 675 };
            writer.Write(arr);
            var bytes = writer.ToArray();
            Assert.IsTrue(bytes.SequenceEqual(VarInt.ArrayOfVarIntsToByteArray(arr)));
        }
        [TestMethod]
        public void Write100000VarIntArray()
        {
            var writer = new ArrayWriter(true);
            VarInt[] arr = new VarInt[] {
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
            };
            for (int k = 0; k < 100000; k++)
            {
                writer.Write(arr);
            }
            var bytes = writer.ToArray();
            Assert.IsTrue(true);
        }
        //long[]
        [TestMethod]
        public void WriteLongArray_B()
        {
            var writer = new ArrayWriter(true);
            var arr = new long[] { 1, 2, 5, 164, 123246234, 1231, 675 };
            writer.Write(arr);
            var bytes = writer.ToArray();
            Assert.IsTrue(bytes.SequenceEqual(FastByteArrayExtensions.Combine(new byte[][]
            {
                new VarInt(arr.Length).Bytes,
                arr.SelectMany(x => BitConverter.GetBytes(x).Reverse()).ToArray()
            })));
        }
        [TestMethod]
        public void WriteLongArray_L()
        {
            var writer = new ArrayWriter();
            var arr = new long[] { 1, 2, 5, 164, 123246234, 1231, 675 };
            writer.Write(arr);
            var bytes = writer.ToArray();
            Assert.IsTrue(bytes.SequenceEqual(FastByteArrayExtensions.Combine(new byte[][]
            {
                new VarInt(arr.Length).Bytes,
                arr.SelectMany(x => BitConverter.GetBytes(x)).ToArray()
            })));
        }
        [TestMethod]
        public void Write10000LongArray_B()
        {
            var writer = new ArrayWriter(true);
            var arr = new long[] {
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
            };
            for (int k = 0; k < 10000; k++)
            {
                writer.Write(arr);
            }
            var bytes = writer.ToArray();
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void Write10000LongArray_L()
        {
            var writer = new ArrayWriter();
            var arr = new long[] {
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
                1, 2, 5, 164, 123246234, 1231, 675,
            };
            for (int k = 0; k < 10000; k++)
            {
                writer.Write(arr);
            }
            var bytes = writer.ToArray();
            Assert.IsTrue(true);
        }
    }
}
