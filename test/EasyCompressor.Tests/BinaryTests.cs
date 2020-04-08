using NUnit.Framework;
using System;
using System.Linq;

namespace EasyCompressor.Tests.BinaryTests
{
    public class BinaryTests : TestBase
    {
        public BinaryTests(ICompressor compressor)
            : base(compressor)
        {
        }

        [Test]
        public void Compress_NullValue_Should_Throws_ArgumentNullException()
        {
            TestDelegate action = () => Compressor.Compress(null);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void Compress_EmptyValue_Should_Throws_ArgumentException()
        {
            TestDelegate action = () => Compressor.Compress(Array.Empty<byte>());

            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void Decompress_NullValue_Should_Throws_ArgumentNullException()
        {
            TestDelegate action = () => Compressor.Decompress(null);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void Decompress_EmptyValue_Should_Throws_ArgumentException()
        {
            TestDelegate action = () => Compressor.Decompress(Array.Empty<byte>());

            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void Compress_Should_DoesNotThrow_Exception()
        {
            TestDelegate action = () => Compressor.Compress(ObjectBytes);

            Assert.DoesNotThrow(action);
        }

        [Test]
        public void CompressedResult_ShouldNot_NullOrEmpty()
        {
            var compressedBytes = Compressor.Compress(ObjectBytes);

            Assert.IsNotNull(compressedBytes);
            Assert.IsNotEmpty(compressedBytes);
        }

        [Test]
        public void Decompress_Should_DoesNotThrow_Exception()
        {
            var compressedBytes = Compressor.Compress(ObjectBytes);
            TestDelegate action = () => Compressor.Decompress(compressedBytes);

            Assert.DoesNotThrow(action);
        }

        [Test]
        public void DecompressdResult_ShouldNot_NullOrEmpty()
        {
            var compressedBytes = Compressor.Compress(ObjectBytes);
            var decompressedBytes = Compressor.Decompress(compressedBytes);

            Assert.IsNotNull(decompressedBytes);
            Assert.IsNotEmpty(decompressedBytes);
        }

        [Test]
        public void DecompressedResult_Should_SequenceEqual_With_SourceBytes()
        {
            var compressedBytes = Compressor.Compress(ObjectBytes);
            var decompressedBytes = Compressor.Decompress(compressedBytes);

            Assert.IsTrue(decompressedBytes.SequenceEqual(ObjectBytes));
        }
    }
}