﻿using BenchmarkDotNet.Attributes;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace EasyCompressor.Benchmarks;

[Display(Name = "Benchmark of Stream Compressors", GroupName = "Benchmark of Stream Compressors")]
public class StreamBenchmark : BaseBenchmark
{
    public override string CompressionType => "Stream";

#pragma warning disable IDE0060, RCS1163 // Remove unused parameter
    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void Compress(BaseCompressor Compressor, string Data, CompressedArg Compressed, string CompressedSize)
    {
        using var inputStream = new MemoryStream(Compressed.OriginalBytes);
        using var outputStream = new MemoryStream();

        Compressor.Compress(inputStream, outputStream);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void Decompress(BaseCompressor Compressor, string Data, CompressedArg Compressed, string CompressedSize)
    {
        using var inputStream = new MemoryStream(Compressed.CompressedBytes);
        using var outputStream = new MemoryStream();

        Compressor.Decompress(inputStream, outputStream);
    }

    [Benchmark]
    [ArgumentsSource(nameof(GetArguments))]
    public void CompressAndDecompress(BaseCompressor Compressor, string Data, CompressedArg Compressed, string CompressedSize)
    {
        using var inputStream = new MemoryStream(Compressed.OriginalBytes);
        using var outputStream = new MemoryStream();

        Compressor.Compress(inputStream, outputStream);
        var compressedBytes = outputStream.GetTrimmedBuffer();

        using var inputStream2 = new MemoryStream(compressedBytes);
        using var outputStream2 = new MemoryStream();

        Compressor.Decompress(inputStream2, outputStream2);
    }
#pragma warning restore IDE0060, RCS1163 // Remove unused parameter
}