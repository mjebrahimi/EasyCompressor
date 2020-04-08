using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace EasyCompressor.Tests.StreamTests
{
    public class StreamTests : TestBase
    {
        public StreamTests(ICompressor compressor)
            : base(compressor)
        {
        }

        [Test]
        public void Compress_NullValue1_Should_Throws_ArgumentNullException()
        {
            TestDelegate action = () => Compressor.Compress(null, new MemoryStream());

            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void Compress_NullValue2_Should_Throws_ArgumentNullException()
        {
            TestDelegate action = () => Compressor.Compress(new MemoryStream(), null);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void Decompress_NullValue1_Should_Throws_ArgumentNullException()
        {
            TestDelegate action = () => Compressor.Decompress(null, new MemoryStream());

            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void Decompress_NullValue2_Should_Throws_ArgumentNullException()
        {
            TestDelegate action = () => Compressor.Compress(new MemoryStream(), null);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void Compress_Should_DoesNotThrow_Exception()
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();

            TestDelegate action = () => Compressor.Compress(inputStream, outputStream);

            Assert.DoesNotThrow(action);
        }

        [Test]
        public void CompressedResult_ShouldNot_NullOrEmpty()
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var compressedStream = new MemoryStream();

            Compressor.Compress(inputStream, compressedStream);

            var compressedBytes = compressedStream.ToArray();

            Assert.IsNotNull(compressedBytes);
            Assert.IsNotEmpty(compressedBytes);
        }

        [Test]
        public void Decompress_Should_DoesNotThrow_Exception()
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();

            Compressor.Compress(inputStream, outputStream);
            var compressedBytes = outputStream.ToArray();

            using var inputStream2 = new MemoryStream(compressedBytes);
            using var outputStream2 = new MemoryStream();

            TestDelegate action = () => Compressor.Decompress(inputStream2, outputStream2);

            Assert.DoesNotThrow(action);
        }

        [Test]
        public void DecompressdResult_ShouldNot_NullOrEmpty()
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();

            Compressor.Compress(inputStream, outputStream);
            var compressedBytes = outputStream.ToArray();

            using var inputStream2 = new MemoryStream(compressedBytes);
            using var outputStream2 = new MemoryStream();

            Compressor.Decompress(inputStream2, outputStream2);
            var decompressedBytes = outputStream2.ToArray();

            Assert.IsNotNull(decompressedBytes);
            Assert.IsNotEmpty(decompressedBytes);
        }

        [Test]
        public void DecompressedResult_Should_SequenceEqual_With_SourceBytes()
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();

            Compressor.Compress(inputStream, outputStream);
            var compressedBytes = outputStream.ToArray();

            using var inputStream2 = new MemoryStream(compressedBytes);
            using var outputStream2 = new MemoryStream();

            Compressor.Decompress(inputStream2, outputStream2);
            var decompressedBytes = outputStream2.ToArray();

            Assert.True(decompressedBytes.SequenceEqual(ObjectBytes));
        }
    }
}
