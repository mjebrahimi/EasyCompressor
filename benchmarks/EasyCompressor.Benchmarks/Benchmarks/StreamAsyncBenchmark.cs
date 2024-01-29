using BenchmarkDotNet.Attributes;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace EasyCompressor.Benchmarks;

#pragma warning disable RCS1261 // Resource can be disposed asynchronously
[Display(Name = "Benchmark of StreamAsync Compressors", GroupName = "Benchmark of StreamAsync Compressors")]
public class StreamAsyncBenchmark : BaseBenchmark
{
    public override string CompressionType => "StreamAsync";

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public async Task Compress(BaseCompressor Compressor, string Data, CompressedArg Compressed, string CompressionRatio)
    {
        using var inputStream = new MemoryStream(Compressed.OriginalBytes);
        using var outputStream = new MemoryStream();

        await Compressor.CompressAsync(inputStream, outputStream);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public async Task Decompress(BaseCompressor Compressor, string Data, CompressedArg Compressed, string CompressionRatio)
    {
        using var inputStream = new MemoryStream(Compressed.CompressedBytes);
        using var outputStream = new MemoryStream();

        await Compressor.DecompressAsync(inputStream, outputStream);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public async Task CompressAndDecompress(BaseCompressor Compressor, string Data, CompressedArg Compressed, string CompressionRatio)
    {
        using var inputStream = new MemoryStream(Compressed.OriginalBytes);
        using var outputStream = new MemoryStream();

        await Compressor.CompressAsync(inputStream, outputStream).ConfigureAwait(false);
        var compressedBytes = outputStream.ToArray();

        using var inputStream2 = new MemoryStream(compressedBytes);
        using var outputStream2 = new MemoryStream();

        await Compressor.DecompressAsync(inputStream2, outputStream2).ConfigureAwait(false);
    }
}
#pragma warning restore RCS1261 // Resource can be disposed asynchronously
