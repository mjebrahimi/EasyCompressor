using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCompressor.Tests.StreamAsyncTest;

public class StreamAsyncTests(ICompressor compressor) : TestBase(compressor)
{
    [Test]
    public void Compress_NullValue1_Should_Throws_ArgumentNullException()
    {
        Task action() => Compressor.CompressAsync(null, new MemoryStream());

        Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Test]
    public void Compress_NullValue2_Should_Throws_ArgumentNullException()
    {
        Task action() => Compressor.CompressAsync(new MemoryStream(), null);

        Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Test]
    public void Decompress_NullValue1_Should_Throws_ArgumentNullException()
    {
        Task action() => Compressor.DecompressAsync(null, new MemoryStream());

        Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Test]
    public void Decompress_NullValue2_Should_Throws_ArgumentNullException()
    {
        Task action() => Compressor.DecompressAsync(new MemoryStream(), null);

        Assert.ThrowsAsync<ArgumentNullException>(action);
    }

    [Test]
    public void Compress_Should_DoesNotThrow_Exception()
    {
        using var inputStream = new MemoryStream(ObjectBytes);
        using var outputStream = new MemoryStream();

        Task action() => Compressor.CompressAsync(inputStream, outputStream);

        Assert.DoesNotThrowAsync(action);
    }

    [Test]
    public async Task CompressedResult_ShouldNot_NullOrEmpty()
    {
        await using var inputStream = new MemoryStream(ObjectBytes);
        await using var compressedStream = new MemoryStream();

        await Compressor.CompressAsync(inputStream, compressedStream).ConfigureAwait(false);

        var compressedBytes = compressedStream.GetTrimmedBuffer();

        Assert.That(compressedBytes, Is.Not.Null);
        Assert.That(compressedBytes, Is.Not.Empty);
    }

    [Test]
    public async Task Decompress_Should_DoesNotThrow_Exception()
    {
        await using var inputStream = new MemoryStream(ObjectBytes);
        await using var outputStream = new MemoryStream();

        await Compressor.CompressAsync(inputStream, outputStream).ConfigureAwait(false);
        var compressedBytes = outputStream.GetTrimmedBuffer();

        await using var inputStream2 = new MemoryStream(compressedBytes);
        await using var outputStream2 = new MemoryStream();

        Task action() => Compressor.DecompressAsync(inputStream2, outputStream2);

        Assert.DoesNotThrowAsync(action);
    }

    [Test]
    public async Task DecompressedResult_ShouldNot_NullOrEmpty()
    {
        await using var inputStream = new MemoryStream(ObjectBytes);
        await using var outputStream = new MemoryStream();

        await Compressor.CompressAsync(inputStream, outputStream).ConfigureAwait(false);
        var compressedBytes = outputStream.GetTrimmedBuffer();

        await using var inputStream2 = new MemoryStream(compressedBytes);
        await using var outputStream2 = new MemoryStream();

        await Compressor.DecompressAsync(inputStream2, outputStream2).ConfigureAwait(false);
        var decompressedBytes = outputStream2.GetTrimmedBuffer();

        Assert.That(decompressedBytes, Is.Not.Null);
        Assert.That(decompressedBytes, Is.Not.Empty);
    }

    [Test]
    public async Task DecompressedResult_Should_SequenceEqual_With_SourceBytes()
    {
        await using var inputStream = new MemoryStream(ObjectBytes);
        await using var outputStream = new MemoryStream();

        await Compressor.CompressAsync(inputStream, outputStream).ConfigureAwait(false);
        var compressedBytes = outputStream.GetTrimmedBuffer();

        await using var inputStream2 = new MemoryStream(compressedBytes);
        await using var outputStream2 = new MemoryStream();

        await Compressor.DecompressAsync(inputStream2, outputStream2).ConfigureAwait(false);
        var decompressedBytes = outputStream2.GetTrimmedBuffer();

        Assert.That(decompressedBytes.SequenceEqual(ObjectBytes), Is.True);
    }

    [Test]
    public async Task CompressAndDecompress_ShouldNot_Close_BothStreams()
    {
        await using var inputStream = new MemoryStream(ObjectBytes);
        await using var outputStream = new MemoryStream();
        await Compressor.CompressAsync(inputStream, outputStream).ConfigureAwait(false);

        Assert.DoesNotThrow(() => inputStream.Position = 0);
        Assert.DoesNotThrow(() => outputStream.Position = 0);

        await using var outputStream2 = new MemoryStream();
        await Compressor.DecompressAsync(outputStream, outputStream2).ConfigureAwait(false);

        Assert.DoesNotThrow(() => outputStream.Position = 0);
        Assert.DoesNotThrow(() => outputStream2.Position = 0);
    }
}
