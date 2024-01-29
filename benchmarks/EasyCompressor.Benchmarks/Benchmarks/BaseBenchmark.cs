using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using EasyCompressor.Benchmarks.Models;
using System.Collections.Generic;
using System.IO;

namespace EasyCompressor.Benchmarks;

#if RELEASE
//[ShortRunJob]
[SimpleJob(BenchmarkDotNet.Engines.RunStrategy.Throughput)]
#else
[MarkdownExporterAttribute.GitHub]
#endif
//[CategoriesColumn]
[Config(typeof(CustomConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
public abstract class BaseBenchmark
{
    public abstract string CompressionType { get; }

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

    private static readonly BaseCompressor[] Compressors =
    [
#pragma warning disable CS0618 // Type or member is obsolete
        new GZipCompressor(),
        new DeflateCompressor(),
        new BrotliCompressor(),
        new BrotliNETCompressor(),
        new LZ4Compressor() { BinaryCompressionMode = LZ4BinaryCompressionMode.LegacyCompatible },
        new LZ4Compressor() { BinaryCompressionMode = LZ4BinaryCompressionMode.StreamCompatible },
        new LZ4Compressor() { BinaryCompressionMode = LZ4BinaryCompressionMode.Optimized },
        new LZMACompressor(),
        new SnappyCompressor(),
        new SnappierCompressor(),
        new ZstdCompressor(),
        new ZstdSharpCompressor(),
#pragma warning restore CS0618 // Type or member is obsolete
    ];

    public string[] GetCompressionType => [CompressionType];
    [ParamsSource(nameof(GetCompressionType), Priority = -2)]
    public string Type { get; set; }

    public IEnumerable<object[]> GetArguments()
    {
        foreach (var compressor in Compressors)
        {
            foreach (var (bytes, size) in Data)
            {
                var compressedArg = new CompressedArg(compressor, bytes, CompressionType);
                var compressionRatio = $"{compressedArg.CompressionRatio:N2} %";
                yield return [compressor, size, compressedArg, compressionRatio];
            }
        }
    }

    public class CompressedArg
    {
        public CompressedArg(ICompressor compressor, byte[] originalBytes, string compressionType)
        {
            OriginalBytes = originalBytes;

            if ((compressionType == "Stream" || compressionType == "StreamAsync") && compressor is LZ4Compressor lz4Compressor)
            {
                using var input = new MemoryStream(originalBytes);
                using var output = new MemoryStream();

                lz4Compressor.Compress(input, output);

                CompressedBytes = output.GetTrimmedBuffer();
            }
            else
            {
                CompressedBytes = compressor.Compress(originalBytes);
            }

            CompressionRatio = CompressedBytes.Length * 100 / (decimal)originalBytes.Length;
        }

        public byte[] OriginalBytes { get; }
        public byte[] CompressedBytes { get; }
        public decimal CompressionRatio { get; set; }

        public override string ToString()
        {
            return $"{CompressedBytes.Length:N0} bytes";
        }
    }
}

class CustomConfig : ManualConfig
{
    public CustomConfig()
    {
        SummaryStyle = DefaultConfig.Instance.SummaryStyle.WithMaxParameterColumnWidth(30);
    }
}