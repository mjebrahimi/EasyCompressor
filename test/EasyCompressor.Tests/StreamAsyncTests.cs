using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCompressor.Tests.StreamAsyncTest
{
    public class StreamAsyncTests : TestBase
    {
        public StreamAsyncTests(ICompressor compressor)
            : base(compressor)
        {
        }

        [Test]
        public void Compress_NullValue1_Should_Throws_ArgumentNullException()
        {
            AsyncTestDelegate action = () => Compressor.CompressAsync(null, new MemoryStream());

            Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Test]
        public void Compress_NullValue2_Should_Throws_ArgumentNullException()
        {
            AsyncTestDelegate action = () => Compressor.CompressAsync(new MemoryStream(), null);

            Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Test]
        public void Decompress_NullValue1_Should_Throws_ArgumentNullException()
        {
            AsyncTestDelegate action = () => Compressor.DecompressAsync(null, new MemoryStream());

            Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Test]
        public void Decompress_NullValue2_Should_Throws_ArgumentNullException()
        {
            AsyncTestDelegate action = () => Compressor.DecompressAsync(new MemoryStream(), null);

            Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Test]
        public void Compress_Should_DoesNotThrow_Exception()
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();

            AsyncTestDelegate action = () => Compressor.CompressAsync(inputStream, outputStream);

            Assert.DoesNotThrowAsync(action);
        }

        [Test]
        public async Task CompressedResult_ShouldNot_NullOrEmpty()
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var compressedStream = new MemoryStream();

            await Compressor.CompressAsync(inputStream, compressedStream);

            var compressedBytes = compressedStream.ToArray();

            Assert.IsNotNull(compressedBytes);
            Assert.IsNotEmpty(compressedBytes);
        }

        [Test]
        public async Task Decompress_Should_DoesNotThrow_Exception()
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();

            await Compressor.CompressAsync(inputStream, outputStream);
            var compressedBytes = outputStream.ToArray();

            using var inputStream2 = new MemoryStream(compressedBytes);
            using var outputStream2 = new MemoryStream();

            AsyncTestDelegate action = () => Compressor.DecompressAsync(inputStream2, outputStream2);

            Assert.DoesNotThrowAsync(action);
        }

        [Test]
        public async Task DecompressdResult_ShouldNot_NullOrEmpty()
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();

            await Compressor.CompressAsync(inputStream, outputStream);
            var compressedBytes = outputStream.ToArray();

            using var inputStream2 = new MemoryStream(compressedBytes);
            using var outputStream2 = new MemoryStream();

            await Compressor.DecompressAsync(inputStream2, outputStream2);
            var decompressedBytes = outputStream2.ToArray();

            Assert.IsNotNull(decompressedBytes);
            Assert.IsNotEmpty(decompressedBytes);
        }

        [Test]
        public async Task DecompressedResult_Should_SequenceEqual_With_SourceBytes()
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();

            await Compressor.CompressAsync(inputStream, outputStream);
            var compressedBytes = outputStream.ToArray();

            using var inputStream2 = new MemoryStream(compressedBytes);
            using var outputStream2 = new MemoryStream();

            await Compressor.DecompressAsync(inputStream2, outputStream2);
            var decompressedBytes = outputStream2.ToArray();

            Assert.True(decompressedBytes.SequenceEqual(ObjectBytes));
        }

        [Test]
        public async Task LeaveOpen_ShouldNot_Close_OutputStream()
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();
            await Compressor.CompressAsync(inputStream, outputStream, true);

            Assert.DoesNotThrow(() => inputStream.Position = 0);
            Assert.DoesNotThrow(() => outputStream.Position = 0);

            using var outputStream2 = new MemoryStream();
            await Compressor.DecompressAsync(outputStream, outputStream2, true);

            Assert.DoesNotThrow(() => outputStream.Position = 0);
            Assert.DoesNotThrow(() => outputStream2.Position = 0);
        }

        [Test]
        public async Task NoLeaveOpen_Should_Close_OutputStream()
        {
            using var inputStream = new MemoryStream(ObjectBytes);
            using var outputStream = new MemoryStream();
            await Compressor.CompressAsync(inputStream, outputStream);

            Assert.DoesNotThrow(() => inputStream.Position = 0);
            Assert.Throws<ObjectDisposedException>(() => outputStream.Position = 0);

            using var inputStream2 = new MemoryStream(outputStream.ToArray());
            using var outputStream2 = new MemoryStream();
            await Compressor.DecompressAsync(inputStream2, outputStream2);

            Assert.DoesNotThrow(() => outputStream2.Position = 0);
            Assert.Throws<ObjectDisposedException>(() => inputStream2.Position = 0);
        }
    }
}
