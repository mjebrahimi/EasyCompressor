using BenchmarkDotNet.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EasyCompressor.Benchmarks;

[Display(Name = "Benchmark of Compressors for Highest Compression (Smallest Size)", GroupName = "Highest Compression (Smallest Size)")]
public class HighestCompressionBenchmark : BaseBenchmark
{
    public override string CompressionType => "Binary";

    public HighestCompressionBenchmark()
    {
        Compressors =
        [
            new BrotliCompressor(System.IO.Compression.CompressionLevel.SmallestSize),
            new LZMACompressor(LZMACompressionLevel.Ultra, DictionarySize.VeryLarge_64MB),
            new ZstdSharpCompressor(ZstdCompressionLevel.SmallestSize),
        ];
    }

#pragma warning disable IDE0060, RCS1163 // Remove unused parameter
    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public byte[] Compress(BaseCompressor Compressor, string Data, CompressedArg Compressed, string CompressedSize)
    {
        return Compressor.Compress(Compressed.OriginalBytes);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public byte[] Decompress(BaseCompressor Compressor, string Data, CompressedArg Compressed, string CompressedSize)
    {
        return Compressor.Decompress(Compressed.CompressedBytes);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public byte[] CompressAndDecompress(BaseCompressor Compressor, string Data, CompressedArg Compressed, string CompressedSize)
    {
        var compressedBytes = Compressor.Compress(Compressed.OriginalBytes);
        return Compressor.Decompress(compressedBytes);
    }
#pragma warning restore IDE0060, RCS1163 // Remove unused parameter
}
