// Ignore Spelling: LZ Pickler

using BenchmarkDotNet.Attributes;
using EasyCompressor.Benchmarks.Models;
using IronCompress;
using System.Collections.Generic;
using System.IO.Compression;

namespace EasyCompressor.Benchmarks;

#if RELEASE
//[ShortRunJob]
[SimpleJob(BenchmarkDotNet.Engines.RunStrategy.Throughput)]
#else
[MarkdownExporterAttribute.GitHub]
#endif
[CategoriesColumn, HideColumns("arg")]
[MemoryDiagnoser(displayGenColumns: false)]
[GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByParams)]
//TODO: Render Html and Image using BenchmarkDotNetVisualizer
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable S101 // Types should be named in PascalCase
public class xLZ4CompressionModesBenchmark
#pragma warning restore S101 // Types should be named in PascalCase
#pragma warning restore IDE1006 // Naming Styles
{
    private static readonly LZ4Compressor legacyCompatibleCompressor = new() { BinaryCompressionMode = LZ4BinaryCompressionMode.LegacyCompatible };
    private static readonly LZ4Compressor streamCompatibleCompressor = new() { BinaryCompressionMode = LZ4BinaryCompressionMode.StreamCompatible };
    private static readonly LZ4Compressor optimizedCompressor = new() { BinaryCompressionMode = LZ4BinaryCompressionMode.Optimized };
    private static readonly Iron ironLZ4Native = new();

    private static readonly (byte[] Bytes, string Size)[] Data = GetData();
    public static (byte[] Bytes, string Size)[] GetData()
    {
        var smallData = Person.GetDataBinary();
        var mediumData = SpotifyAlbumArray.GetDataBinary();
        var largeData = SearchResponse.GetDataBinary();

        return
        [
            (smallData, "Small (190 B)"),
            (mediumData, "Medium (10 KB)"),
            (largeData, "Large (20 KB)")
        ];
    }

    public IEnumerable<object[]> GetArgumentsLegacyCompatible()
    {
        foreach (var (bytes, size) in Data)
        {
            var compressedBytes = legacyCompatibleCompressor.Compress(bytes);
            yield return [new CompressedArg(bytes, compressedBytes), size];
        }
    }

    public IEnumerable<object[]> GetArgumentsStreamCompatible()
    {
        foreach (var (bytes, size) in Data)
        {
            var compressedBytes = streamCompatibleCompressor.Compress(bytes);
            yield return [new CompressedArg(bytes, compressedBytes), size];
        }
    }

    public IEnumerable<object[]> GetArgumentsOptimized()
    {
        foreach (var (bytes, size) in Data)
        {
            var compressedBytes = optimizedCompressor.Compress(bytes);
            yield return [new CompressedArg(bytes, compressedBytes), size];
        }
    }

    public IEnumerable<object[]> GetArgumentsNativeOptimal()
    {
        foreach (var (bytes, size) in Data)
        {
            using IronCompressResult compressed = ironLZ4Native.Compress(Codec.LZ4, bytes, compressionLevel: CompressionLevel.Optimal);
            var compressedBytes = compressed.AsSpan().ToArray();
            yield return [new CompressedArg(bytes, compressedBytes), size];
        }
    }

    public IEnumerable<object[]> GetArgumentsNativeSmallestSize()
    {
        foreach (var (bytes, size) in Data)
        {
            using IronCompressResult compressed = ironLZ4Native.Compress(Codec.LZ4, bytes, compressionLevel: CompressionLevel.SmallestSize);
            var compressedBytes = compressed.AsSpan().ToArray();
            yield return [new CompressedArg(bytes, compressedBytes), size];
        }
    }

    #region LegacyCompatible
    [ArgumentsSource(nameof(GetArgumentsLegacyCompatible))]
    [Benchmark(Description = "Compress"), BenchmarkCategory("LegacyCompatible")]
    public byte[] CompressLegacy(CompressedArg arg, string Size)
    {
        return legacyCompatibleCompressor.Compress(arg.OriginalBytes);
    }

    [ArgumentsSource(nameof(GetArgumentsLegacyCompatible))]
    [Benchmark(Description = "Decompress"), BenchmarkCategory("LegacyCompatible")]
    public byte[] DecompressLegacy(CompressedArg arg, string Size)
    {
        return legacyCompatibleCompressor.Decompress(arg.CompressedBytes);
    }

    [ArgumentsSource(nameof(GetArgumentsLegacyCompatible))]
    [Benchmark(Description = "CompressAndDecompress"), BenchmarkCategory("LegacyCompatible")]
    public byte[] CompressAndDecompressLegacy(CompressedArg arg, string Size)
    {
        var compressedBytes = legacyCompatibleCompressor.Compress(arg.OriginalBytes);
        return legacyCompatibleCompressor.Decompress(compressedBytes);
    }
    #endregion

    #region StreamCompatible
    [ArgumentsSource(nameof(GetArgumentsStreamCompatible))]
    [Benchmark(Description = "Compress"), BenchmarkCategory("StreamCompatible")]
    public byte[] CompressOptimal(CompressedArg arg, string Size)
    {
        return streamCompatibleCompressor.Compress(arg.OriginalBytes);
    }

    [ArgumentsSource(nameof(GetArgumentsStreamCompatible))]
    [Benchmark(Description = "Decompress"), BenchmarkCategory("StreamCompatible")]
    public byte[] DecompressOptimal(CompressedArg arg, string Size)
    {
        return streamCompatibleCompressor.Decompress(arg.CompressedBytes);
    }

    [ArgumentsSource(nameof(GetArgumentsStreamCompatible))]
    [Benchmark(Description = "CompressAndDecompress"), BenchmarkCategory("StreamCompatible")]
    public byte[] CompressAndDecompressOptimal(CompressedArg arg, string Size)
    {
        var compressedBytes = streamCompatibleCompressor.Compress(arg.OriginalBytes);
        return streamCompatibleCompressor.Decompress(compressedBytes);
    }
    #endregion

    #region Optimized
    [ArgumentsSource(nameof(GetArgumentsOptimized))]
    [Benchmark(Description = "Compress"), BenchmarkCategory("Optimized")]
    public byte[] CompressOptimized(CompressedArg arg, string Size)
    {
        return optimizedCompressor.Compress(arg.OriginalBytes);
    }

    [ArgumentsSource(nameof(GetArgumentsOptimized))]
    [Benchmark(Description = "Decompress"), BenchmarkCategory("Optimized")]
    public byte[] DecompressOptimized(CompressedArg arg, string Size)
    {
        return optimizedCompressor.Decompress(arg.CompressedBytes);
    }

    [ArgumentsSource(nameof(GetArgumentsOptimized))]
    [Benchmark(Description = "CompressAndDecompress"), BenchmarkCategory("Optimized")]
    public byte[] CompressAndDecompressOptimized(CompressedArg arg, string Size)
    {
        var compressedBytes = optimizedCompressor.Compress(arg.OriginalBytes);
        return optimizedCompressor.Decompress(compressedBytes);
    }
    #endregion

    #region Native-Optimal (IronCompress)
    [ArgumentsSource(nameof(GetArgumentsNativeOptimal))]
    [Benchmark(Description = "Compress"), BenchmarkCategory("Native-Optimal")]
    public byte[] CompressNativeOptimal(CompressedArg arg, string Size)
    {
        using IronCompressResult compressed = ironLZ4Native.Compress(Codec.LZ4, arg.OriginalBytes, compressionLevel: CompressionLevel.Optimal);
        return compressed.AsSpan().ToArray();
    }

    [ArgumentsSource(nameof(GetArgumentsNativeOptimal))]
    [Benchmark(Description = "Decompress"), BenchmarkCategory("Native-Optimal")]
    public byte[] DecompressNativeOptimal(CompressedArg arg, string Size)
    {
        using IronCompressResult uncompressed = ironLZ4Native.Decompress(Codec.LZ4, arg.CompressedBytes, arg.OriginalBytes.Length);
        return uncompressed.AsSpan().ToArray();
    }

    [ArgumentsSource(nameof(GetArgumentsNativeOptimal))]
    [Benchmark(Description = "CompressAndDecompress"), BenchmarkCategory("Native-Optimal")]
    public byte[] CompressAndDecompressNativeOptimal(CompressedArg arg, string Size)
    {
        using IronCompressResult compressed = ironLZ4Native.Compress(Codec.LZ4, arg.OriginalBytes, compressionLevel: CompressionLevel.Optimal);
        var compressedBytes = compressed.AsSpan().ToArray();

        using IronCompressResult uncompressed = ironLZ4Native.Decompress(Codec.LZ4, compressedBytes, arg.OriginalBytes.Length);
        return uncompressed.AsSpan().ToArray();
    }
    #endregion

    #region Native-SmallestSize (IronCompress)
    [ArgumentsSource(nameof(GetArgumentsNativeSmallestSize))]
    [Benchmark(Description = "Compress"), BenchmarkCategory("Native-SmallestSize")]
    public byte[] CompressNativeSmallestSize(CompressedArg arg, string Size)
    {
        using IronCompressResult compressed = ironLZ4Native.Compress(Codec.LZ4, arg.OriginalBytes, compressionLevel: CompressionLevel.SmallestSize);
        return compressed.AsSpan().ToArray();
    }

    [ArgumentsSource(nameof(GetArgumentsNativeSmallestSize))]
    [Benchmark(Description = "Decompress"), BenchmarkCategory("Native-SmallestSize")]
    public byte[] DecompressNativeSmallestSize(CompressedArg arg, string Size)
    {
        using IronCompressResult uncompressed = ironLZ4Native.Decompress(Codec.LZ4, arg.CompressedBytes, arg.OriginalBytes.Length);
        return uncompressed.AsSpan().ToArray();
    }

    [ArgumentsSource(nameof(GetArgumentsNativeSmallestSize))]
    [Benchmark(Description = "CompressAndDecompress"), BenchmarkCategory("Native-SmallestSize")]
    public byte[] CompressAndDecompressNativeSmallestSize(CompressedArg arg, string Size)
    {
        using IronCompressResult compressed = ironLZ4Native.Compress(Codec.LZ4, arg.OriginalBytes, compressionLevel: CompressionLevel.SmallestSize);
        var compressedBytes = compressed.AsSpan().ToArray();

        using IronCompressResult uncompressed = ironLZ4Native.Decompress(Codec.LZ4, compressedBytes, arg.OriginalBytes.Length);
        return uncompressed.AsSpan().ToArray();
    }
    #endregion

    #region Stream Sync and Async
    //    #region Stream Sync
    //    [ArgumentsSource(nameof(GetArgumentsStreamCompatible))]
    //    [Benchmark(Description = "Compress"), BenchmarkCategory("StreamSync")]
    //    public byte[] CompressStream(CompressedArg arg, string Size)
    //    {
    //        using var input = new MemoryStream(arg.OriginalBytes);
    //        using var output = new MemoryStream();
    //        optimalCompressor.Compress(input, output);
    //        return output.GetTrimmedBuffer();
    //    }

    //    [ArgumentsSource(nameof(GetArgumentsStreamCompatible))]
    //    [Benchmark(Description = "Decompress"), BenchmarkCategory("StreamSync")]
    //    public byte[] DecompressStream(CompressedArg arg, string Size)
    //    {
    //        using var input = new MemoryStream(arg.CompressedBytes);
    //        using var output = new MemoryStream();
    //        optimalCompressor.Decompress(input, output);
    //        return output.GetTrimmedBuffer();
    //    }

    //    [ArgumentsSource(nameof(GetArgumentsStreamCompatible))]
    //    [Benchmark(Description = "CompressAndDecompress"), BenchmarkCategory("StreamSync")]
    //    public byte[] CompressAndDecompressStream(CompressedArg arg, string Size)
    //    {
    //        using var input = new MemoryStream(arg.OriginalBytes);
    //        using var output = new MemoryStream();
    //        optimalCompressor.Compress(input, output);
    //        var compressed = output.GetTrimmedBuffer();

    //        using var input2 = new MemoryStream(compressed);
    //        using var output2 = new MemoryStream();
    //        optimalCompressor.Decompress(input2, output2);
    //        return output2.GetTrimmedBuffer();
    //    }
    //    #endregion

    //    #region Stream Async
    //#pragma warning disable RCS1261 // Resource can be disposed asynchronously
    //    [ArgumentsSource(nameof(GetArgumentsStreamCompatible))]
    //    [Benchmark(Description = "Compress"), BenchmarkCategory("StreamAsync")]
    //    public async Task<byte[]> CompressStreamAsync(CompressedArg arg, string Size)
    //    {
    //        using var input = new MemoryStream(arg.OriginalBytes);
    //        using var output = new MemoryStream();
    //        await optimalCompressor.CompressAsync(input, output);
    //        return output.GetTrimmedBuffer();
    //    }

    //    [ArgumentsSource(nameof(GetArgumentsStreamCompatible))]
    //    [Benchmark(Description = "Decompress"), BenchmarkCategory("StreamAsync")]
    //    public async Task<byte[]> DecompressStreamAsync(CompressedArg arg, string Size)
    //    {
    //        using var input = new MemoryStream(arg.CompressedBytes);
    //        using var output = new MemoryStream();
    //        await optimalCompressor.DecompressAsync(input, output);
    //        return output.GetTrimmedBuffer();
    //    }

    //    [ArgumentsSource(nameof(GetArgumentsStreamCompatible))]
    //    [Benchmark(Description = "CompressAndDecompress"), BenchmarkCategory("StreamAsync")]
    //    public async Task<byte[]> CompressAndDecompressStreamAsync(CompressedArg arg, string Size)
    //    {
    //        using var input = new MemoryStream(arg.OriginalBytes);
    //        using var output = new MemoryStream();
    //        await optimalCompressor.CompressAsync(input, output);
    //        var compressed = output.GetTrimmedBuffer();

    //        using var input2 = new MemoryStream(compressed);
    //        using var output2 = new MemoryStream();
    //        await optimalCompressor.DecompressAsync(input2, output2);
    //        return output2.GetTrimmedBuffer();
    //    }
    //#pragma warning restore RCS1261 // Resource can be disposed asynchronously
    //    #endregion
    #endregion

    public class CompressedArg
    {
        public CompressedArg(byte[] originalBytes, byte[] compressedBytes)
        {
            OriginalBytes = originalBytes;
            CompressedBytes = compressedBytes;
        }

        public byte[] OriginalBytes { get; }
        public byte[] CompressedBytes { get; }
    }
}