using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace EasyCompressor.Tests.StreamTests;

public class StreamTests(ICompressor compressor) : TestBase(compressor)
{
    //[Test]
    //public void Compress_Large_Data()
    //{
    //    var size2GB = 2_147_483_648;
    //    var filePath = "D:\\large_file.dump";

    //    try
    //    {
    //        CreateDumpFile(filePath, size2GB);

    //        var file = File.OpenRead(filePath);
    //        var output = File.OpenWrite(filePath + ".7z");

    //        var compressor = new LZMACompressor();
    //        compressor.Compress(file, output);
    //    }
    //    finally
    //    {
    //        File.Delete(filePath);
    //    }
    //}

    //[Test]
    //public void Decompress_Large_Data()
    //{
    //    var path = "D:\\large_data";
    //    var compressor = new LZMACompressor();
    //    var file = File.OpenRead(path + "_compressed");
    //    var output = File.OpenWrite(path + "_decompressed");
    //    compressor.Decompress(file, output);
    //}

    [Test]
    public void Compress_NullValue1_Should_Throws_ArgumentNullException()
    {
        void action() => Compressor.Compress(null, new MemoryStream());

        Assert.Throws<ArgumentNullException>(action);
    }

    [Test]
    public void Compress_NullValue2_Should_Throws_ArgumentNullException()
    {
        void action() => Compressor.Compress(new MemoryStream(), null);

        Assert.Throws<ArgumentNullException>(action);
    }

    [Test]
    public void Decompress_NullValue1_Should_Throws_ArgumentNullException()
    {
        void action() => Compressor.Decompress(null, new MemoryStream());

        Assert.Throws<ArgumentNullException>(action);
    }

    [Test]
    public void Decompress_NullValue2_Should_Throws_ArgumentNullException()
    {
        void action() => Compressor.Decompress(new MemoryStream(), null);

        Assert.Throws<ArgumentNullException>(action);
    }

    [Test]
    public void Compress_Should_DoesNotThrow_Exception()
    {
        using var inputStream = new MemoryStream(ObjectBytes);
        using var outputStream = new MemoryStream();

        void action() => Compressor.Compress(inputStream, outputStream);

        Assert.DoesNotThrow(action);
    }

    [Test]
    public void CompressedResult_ShouldNot_NullOrEmpty()
    {
        using var inputStream = new MemoryStream(ObjectBytes);
        using var compressedStream = new MemoryStream();

        Compressor.Compress(inputStream, compressedStream);

        var compressedBytes = compressedStream.GetTrimmedBuffer();

        Assert.That(compressedBytes, Is.Not.Null);
        Assert.That(compressedBytes, Is.Not.Empty);
    }

    [Test]
    public void Decompress_Should_DoesNotThrow_Exception()
    {
        using var inputStream = new MemoryStream(ObjectBytes);
        using var outputStream = new MemoryStream();

        Compressor.Compress(inputStream, outputStream);
        var compressedBytes = outputStream.GetTrimmedBuffer();

        using var inputStream2 = new MemoryStream(compressedBytes);
        using var outputStream2 = new MemoryStream();

        void action() => Compressor.Decompress(inputStream2, outputStream2);

        Assert.DoesNotThrow(action);
    }

    [Test]
    public void DecompressedResult_ShouldNot_NullOrEmpty()
    {
        using var inputStream = new MemoryStream(ObjectBytes);
        using var outputStream = new MemoryStream();

        Compressor.Compress(inputStream, outputStream);
        var compressedBytes = outputStream.GetTrimmedBuffer();

        using var inputStream2 = new MemoryStream(compressedBytes);
        using var outputStream2 = new MemoryStream();

        Compressor.Decompress(inputStream2, outputStream2);
        var decompressedBytes = outputStream2.GetTrimmedBuffer();

        Assert.That(decompressedBytes, Is.Not.Null);
        Assert.That(decompressedBytes, Is.Not.Empty);
    }

    [Test]
    public void DecompressedResult_Should_SequenceEqual_With_SourceBytes()
    {
        using var inputStream = new MemoryStream(ObjectBytes);
        using var outputStream = new MemoryStream();

        Compressor.Compress(inputStream, outputStream);
        var compressedBytes = outputStream.GetTrimmedBuffer();

        using var inputStream2 = new MemoryStream(compressedBytes);
        using var outputStream2 = new MemoryStream();

        Compressor.Decompress(inputStream2, outputStream2);
        var decompressedBytes = outputStream2.GetTrimmedBuffer();

        Assert.That(decompressedBytes.SequenceEqual(ObjectBytes), Is.True);
    }

    [Test]
    public void CompressAndDecompress_ShouldNot_Close_BothStreams()
    {
        using var inputStream = new MemoryStream(ObjectBytes);
        using var outputStream = new MemoryStream();
        Compressor.Compress(inputStream, outputStream);

        Assert.DoesNotThrow(() => inputStream.Position = 0);
        Assert.DoesNotThrow(() => outputStream.Position = 0);

        using var outputStream2 = new MemoryStream();
        Compressor.Decompress(outputStream, outputStream2);

        Assert.DoesNotThrow(() => outputStream.Position = 0);
        Assert.DoesNotThrow(() => outputStream2.Position = 0);
    }

    #region CreateDumpFile
    //private static void CreateDumpFile(string filePath, long fileSize)
    //{
    //    using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
    //    CreateDumpFile(fileStream, fileSize);
    //}

    //private static void CreateDumpFile(FileStream fileStream, long fileSize)
    //{
    //    const int maxArraySize = 2_147_483_591;
    //    if (fileSize <= maxArraySize)
    //    {
    //        byte[] buffer = new byte[fileSize];
    //        fileStream.Write(buffer);
    //    }
    //    else
    //    {
    //        //improve implementation
    //        long currentFileSize = 0;
    //        while (currentFileSize < fileSize)
    //        {
    //            byte[] buffer = new byte[1024];
    //            fileStream.Write(buffer);
    //            currentFileSize += buffer.Length;
    //        }
    //    }
    //    fileStream.FlushAsync();
    //}
    #endregion
}
