using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace EasyCompressor.Tests.StreamExtensionsTests;

[TestFixture]
public class StreamExtensionsTests
{
    [Test]
    public void WriteMoreThanBufferSize_Then_ReadAll()
    {
        using var stream = new MemoryStream();
        stream.WriteAllBytes(new byte[1000]); //more than internal buffer size
        stream.Position = 0;
        var bytes = stream.ReadAllBytes();
        Assert.That(bytes.Length, Is.EqualTo(1000));
    }

    [Test]
    public void WriteLessThanBufferSize_Then_ReadAll()
    {
        using var stream = new MemoryStream();
        stream.WriteAllBytes(new byte[7]); //less than internal buffer size
        stream.Position = 0;
        var bytes = stream.ReadAllBytes();
        Assert.That(bytes.Length, Is.EqualTo(7));
    }

    [Test]
    public void WriteMoreThanBufferSize_Then_ReadFromTheCurrentPosition1()
    {
        using var stream = new MemoryStream();
        stream.WriteAllBytes(new byte[1000]); //more than internal buffer size
        stream.Position = 7;
        var bytes = stream.ReadAllBytes();
        Assert.That(bytes.Length, Is.EqualTo(993));
    }

    [Test]
    public void WriteMoreThanBufferSize_Then_ReadFromTheCurrentPosition2()
    {
        using var stream = new MemoryStream();
        stream.WriteAllBytes(new byte[1000]); //more than internal buffer size
        stream.Position = 700;
        var bytes = stream.ReadAllBytes();
        Assert.That(bytes.Length, Is.EqualTo(300));
    }

    [Test]
    public void WriteLessThanBufferSize_Then_ReadFromTheCurrentPosition()
    {
        using var stream = new MemoryStream();
        stream.WriteAllBytes(new byte[7]); //less than internal buffer size
        stream.Position = 2;
        var bytes = stream.ReadAllBytes();
        Assert.That(bytes.Length, Is.EqualTo(5));
    }

    [Test]
    public void InitializeMoreThanBufferSize_WithSpecifiedRange_Then_ReadAll()
    {
        using var stream = new MemoryStream(new byte[1000], 200, 600); //With specified range of array
        var bytes = stream.ReadAllBytes();
        Assert.That(bytes.Length, Is.EqualTo(600));
    }

    [Test]
    public void InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadAll1()
    {
        using var stream = new MemoryStream(new byte[100], 20, 30); //With specified range of array
        var bytes = stream.ReadAllBytes();
        Assert.That(bytes.Length, Is.EqualTo(30));
    }

    [Test]
    public void InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadAll2()
    {
        using var stream = new MemoryStream(new byte[7], 2, 4); //With specified range of array
        var bytes = stream.ReadAllBytes();
        Assert.That(bytes.Length, Is.EqualTo(4));
    }

    [Test]
    public void InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadFromTheCurrentPosition1()
    {
        using var stream = new MemoryStream(new byte[100], 20, 30); //With specified range of array
        stream.Position = 12;
        var bytes = stream.ReadAllBytes();
        Assert.That(bytes.Length, Is.EqualTo(18));
    }

    [Test]
    public void InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadFromTheCurrentPosition2()
    {
        using var stream = new MemoryStream(new byte[7], 2, 4); //With specified range of array
        stream.Position = 3;
        var bytes = stream.ReadAllBytes();
        Assert.That(bytes.Length, Is.EqualTo(1));
    }

    [Test]
    public void InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadFromTheCurrentPosition3()
    {
        using var stream = new MemoryStream(new byte[1000], 200, 600); //With specified range of array
        stream.Position = 100;
        var bytes = stream.ReadAllBytes();
        Assert.That(bytes.Length, Is.EqualTo(500));
    }

    [Test]
    public void InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadFromTheCurrentPosition4()
    {
        using var stream = new MemoryStream(new byte[1000], 200, 600); //With specified range of array
        stream.Position = 500;
        var bytes = stream.ReadAllBytes();
        Assert.That(bytes.Length, Is.EqualTo(100));
    }

    [Test]
    public void InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadFromTheCurrentPosition5()
    {
        using var stream = new MemoryStream(new byte[1000], 200, 600); //With specified range of array
        stream.Position = 300;
        var bytes = stream.ReadAllBytes();
        Assert.That(bytes.Length, Is.EqualTo(300));
    }
}

[TestFixture]
public class StreamExtensionsAsyncTests
{
    [Test]
    public async Task WriteMoreThanBufferSize_Then_ReadAll()
    {
        await using var stream = new MemoryStream();
        await stream.WriteAllBytesAsync(new byte[1000]); //more than internal buffer size
        stream.Position = 0;
        var bytes = await stream.ReadAllBytesAsync();
        Assert.That(bytes.Length, Is.EqualTo(1000));
    }

    [Test]
    public async Task WriteLessThanBufferSize_Then_ReadAll()
    {
        await using var stream = new MemoryStream();
        await stream.WriteAllBytesAsync(new byte[7]); //less than internal buffer size
        stream.Position = 0;
        var bytes = await stream.ReadAllBytesAsync();
        Assert.That(bytes.Length, Is.EqualTo(7));
    }

    [Test]
    public async Task WriteMoreThanBufferSize_Then_ReadFromTheCurrentPosition1()
    {
        await using var stream = new MemoryStream();
        await stream.WriteAllBytesAsync(new byte[1000]); //more than internal buffer size
        stream.Position = 7;
        var bytes = await stream.ReadAllBytesAsync();
        Assert.That(bytes.Length, Is.EqualTo(993));
    }

    [Test]
    public async Task WriteMoreThanBufferSize_Then_ReadFromTheCurrentPosition2()
    {
        await using var stream = new MemoryStream();
        await stream.WriteAllBytesAsync(new byte[1000]); //more than internal buffer size
        stream.Position = 700;
        var bytes = await stream.ReadAllBytesAsync();
        Assert.That(bytes.Length, Is.EqualTo(300));
    }

    [Test]
    public async Task WriteLessThanBufferSize_Then_ReadFromTheCurrentPosition()
    {
        await using var stream = new MemoryStream();
        await stream.WriteAllBytesAsync(new byte[7]); //less than internal buffer size
        stream.Position = 2;
        var bytes = await stream.ReadAllBytesAsync();
        Assert.That(bytes.Length, Is.EqualTo(5));
    }

    [Test]
    public async Task InitializeMoreThanBufferSize_WithSpecifiedRange_Then_ReadAll()
    {
        await using var stream = new MemoryStream(new byte[1000], 200, 600); //With specified range of array
        var bytes = await stream.ReadAllBytesAsync();
        Assert.That(bytes.Length, Is.EqualTo(600));
    }

    [Test]
    public async Task InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadAll1()
    {
        await using var stream = new MemoryStream(new byte[100], 20, 30); //With specified range of array
        var bytes = await stream.ReadAllBytesAsync();
        Assert.That(bytes.Length, Is.EqualTo(30));
    }

    [Test]
    public async Task InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadAll2()
    {
        await using var stream = new MemoryStream(new byte[7], 2, 4); //With specified range of array
        var bytes = await stream.ReadAllBytesAsync();
        Assert.That(bytes.Length, Is.EqualTo(4));
    }

    [Test]
    public async Task InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadFromTheCurrentPosition1()
    {
        await using var stream = new MemoryStream(new byte[7], 2, 4); //With specified range of array
        stream.Position = 3;
        var bytes = await stream.ReadAllBytesAsync();
        Assert.That(bytes.Length, Is.EqualTo(1));
    }

    [Test]
    public async Task InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadFromTheCurrentPosition2()
    {
        await using var stream = new MemoryStream(new byte[100], 20, 30); //With specified range of array
        stream.Position = 12;
        var bytes = await stream.ReadAllBytesAsync();
        Assert.That(bytes.Length, Is.EqualTo(18));
    }

    [Test]
    public async Task InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadFromTheCurrentPosition3()
    {
        await using var stream = new MemoryStream(new byte[1000], 200, 600); //With specified range of array
        stream.Position = 100;
        var bytes = await stream.ReadAllBytesAsync();
        Assert.That(bytes.Length, Is.EqualTo(500));
    }

    [Test]
    public async Task InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadFromTheCurrentPosition4()
    {
        await using var stream = new MemoryStream(new byte[1000], 200, 600); //With specified range of array
        stream.Position = 500;
        var bytes = await stream.ReadAllBytesAsync();
        Assert.That(bytes.Length, Is.EqualTo(100));
    }

    [Test]
    public async Task InitializeLessThanBufferSize_WithSpecifiedRange_Then_ReadFromTheCurrentPosition5()
    {
        await using var stream = new MemoryStream(new byte[1000], 200, 600); //With specified range of array
        stream.Position = 300;
        var bytes = await stream.ReadAllBytesAsync();
        Assert.That(bytes.Length, Is.EqualTo(300));
    }
}