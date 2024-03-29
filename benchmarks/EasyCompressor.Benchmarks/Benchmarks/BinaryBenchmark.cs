﻿using BenchmarkDotNet.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EasyCompressor.Benchmarks;

[Display(Name = "Benchmark of Binary Compressors", GroupName = "Benchmark of Binary Compressors")]
public class BinaryBenchmark : BaseBenchmark
{
    public override string CompressionType => "Binary";

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
