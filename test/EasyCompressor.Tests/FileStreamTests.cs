using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace EasyCompressor.Tests.FileStreamTests;

public class FileStreamTests(ICompressor compressor) : TestBase(compressor)
{
    private const string Path_Original = @"D:\original.txt";
    private const string Path_Compressed = @"D:\compressed.txt";
    private const string Path_Decompressed = @"D:\decompressed.txt";

    [SetUp]
    [TearDown]
    public void Setup()
    {
        if (Path.Exists(Path_Original)) File.Delete(Path_Original);
        if (Path.Exists(Path_Compressed)) File.Delete(Path_Compressed);
        if (Path.Exists(Path_Decompressed)) File.Delete(Path_Decompressed);
    }

    [Test]
    public void MemoryStreamAsInput_FileStreamAsOutput()
    {
        //Compress Bytes
        using var originalStream = new MemoryStream(ObjectBytes);
        using var compressedStream = new FileStream(Path_Compressed, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
        compressor.Compress(originalStream, compressedStream);

        //Read Compressed Bytes
        using var compressedStream2 = new FileStream(Path_Compressed, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        var compressedBytes = compressedStream2.ReadAllBytes();

        //Decompressed Bytes
        using var compressedStream3 = new MemoryStream(compressedBytes);
        using var decompressedStream = new FileStream(Path_Decompressed, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
        compressor.Decompress(compressedStream3, decompressedStream);

        //Read Decompressed Bytes
        using var decompressedStream2 = new FileStream(Path_Decompressed, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        var decompressedBytes = decompressedStream2.ReadAllBytes();

        //Compare Decompressed Data with Original Data
        Assert.That(ObjectBytes, Is.EquivalentTo(decompressedBytes));
        //Assert.That(ObjectBytes.SequenceEqual(decompressedBytes), Is.True);
    }

    [Test]
    public void FileStreamAsInput_MemoryStreamAsOutput()
    {
        //Write Original Bytes
        using var originalStream1 = new FileStream(Path_Original, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
        originalStream1.WriteAllBytes(ObjectBytes);
        originalStream1.Position = 0;

        //Compress Bytes
        using var compressedStream1 = new MemoryStream();
        compressor.Compress(originalStream1, compressedStream1);

        //Read Compressed Bytes
        compressedStream1.Position = 0;
        var compressedBytes = compressedStream1.ReadAllBytes();

        //Write Compressed Bytes
        using var compressedStream2 = new FileStream(Path_Compressed, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
        compressedStream2.WriteAllBytes(compressedBytes);
        compressedStream2.Position = 0;

        //Decompressed Bytes
        using var decompressedStream = new MemoryStream();
        compressor.Decompress(compressedStream2, decompressedStream);

        //Read Decompressed Bytes
        decompressedStream.Position = 0;
        var decompressedBytes = decompressedStream.ReadAllBytes();

        //Compare Decompressed Data with Original Data
        Assert.That(ObjectBytes, Is.EquivalentTo(decompressedBytes));
        //Assert.That(ObjectBytes.SequenceEqual(decompressedBytes), Is.True);
    }
}

public class FileStreamAsyncTests(ICompressor compressor) : TestBase(compressor)
{
    private const string Path_Original = @"D:\original.txt";
    private const string Path_Compressed = @"D:\compressed.txt";
    private const string Path_Decompressed = @"D:\decompressed.txt";

    [SetUp]
    [TearDown]
    public void Setup()
    {
        if (Path.Exists(Path_Original)) File.Delete(Path_Original);
        if (Path.Exists(Path_Compressed)) File.Delete(Path_Compressed);
        if (Path.Exists(Path_Decompressed)) File.Delete(Path_Decompressed);
    }

    [Test]
    public async Task MemoryStreamAsInput_FileStreamAsOutput_Async()
    {
        //Compress Bytes
        await using var originalStream = new MemoryStream(ObjectBytes);
        await using var compressedStream = new FileStream(Path_Compressed, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
        await compressor.CompressAsync(originalStream, compressedStream);

        //Read Compressed Bytes
        await using var compressedStream2 = new FileStream(Path_Compressed, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        var compressedBytes = await compressedStream2.ReadAllBytesAsync();

        //Decompressed Bytes
        await using var compressedStream3 = new MemoryStream(compressedBytes);
        await using var decompressedStream = new FileStream(Path_Decompressed, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
        await compressor.DecompressAsync(compressedStream3, decompressedStream);

        //Read Decompressed Bytes
        await using var decompressedStream2 = new FileStream(Path_Decompressed, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        var decompressedBytes = await decompressedStream2.ReadAllBytesAsync();

        //Compare Decompressed Data with Original Data
        Assert.That(ObjectBytes, Is.EquivalentTo(decompressedBytes));
        //Assert.That(ObjectBytes.SequenceEqual(decompressedBytes), Is.True);
    }

    [Test]
    public async Task FileStreamAsInput_MemoryStreamAsOutput_Async()
    {
        //Write Original Bytes
        await using var originalStream1 = new FileStream(Path_Original, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
        await originalStream1.WriteAllBytesAsync(ObjectBytes);
        originalStream1.Position = 0;

        //Compress Bytes
        await using var compressedStream1 = new MemoryStream();
        await compressor.CompressAsync(originalStream1, compressedStream1);

        //Read Compressed Bytes
        compressedStream1.Position = 0;
        var compressedBytes = await compressedStream1.ReadAllBytesAsync();

        //Write Compressed Bytes
        await using var compressedStream2 = new FileStream(Path_Compressed, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
        await compressedStream2.WriteAllBytesAsync(compressedBytes);
        compressedStream2.Position = 0;

        //Decompressed Bytes
        await using var decompressedStream = new MemoryStream();
        await compressor.DecompressAsync(compressedStream2, decompressedStream);

        //Read Decompressed Bytes
        decompressedStream.Position = 0;
        var decompressedBytes = await decompressedStream.ReadAllBytesAsync();

        //Compare Decompressed Data with Original Data
        Assert.That(ObjectBytes, Is.EquivalentTo(decompressedBytes));
        //Assert.That(ObjectBytes.SequenceEqual(decompressedBytes), Is.True);
    }
}