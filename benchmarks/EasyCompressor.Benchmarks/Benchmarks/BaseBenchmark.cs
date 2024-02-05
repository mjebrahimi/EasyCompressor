using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using EasyCompressor.Benchmarks.Models;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace EasyCompressor.Benchmarks;

#if RELEASE
[ShortRunJob]
//[SimpleJob(BenchmarkDotNet.Engines.RunStrategy.Throughput)]
#else
[MarkdownExporterAttribute.GitHub]
#endif
//[CategoriesColumn]
[HideColumns("Compressed")]
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
            (smallData, "Small (2 KB)"),
            (mediumData, "Medium (10 KB)"),
            (largeData, "Large (20 KB)")
        ];
    }

    private static readonly BaseCompressor[] Compressors =
    [
        #region Compression Level/Ratio Benchmarks
        //new GZipCompressor(level: CompressionLevel.NoCompression),
        //new GZipCompressor(level: CompressionLevel.Fastest),
        //new GZipCompressor(level: CompressionLevel.Optimal),
        //new GZipCompressor(level: CompressionLevel.SmallestSize),

        //new DeflateCompressor(level: CompressionLevel.NoCompression),
        //new DeflateCompressor(level: CompressionLevel.Fastest),
        //new DeflateCompressor(level: CompressionLevel.Optimal),
        //new DeflateCompressor(level: CompressionLevel.SmallestSize),

        //new ZLibCompressor(level: CompressionLevel.NoCompression),
        //new ZLibCompressor(level: CompressionLevel.Fastest),
        //new ZLibCompressor(level: CompressionLevel.Optimal),
        //new ZLibCompressor(level: CompressionLevel.SmallestSize),

        //new BrotliCompressor(level: CompressionLevel.NoCompression),
        //new BrotliCompressor(level: CompressionLevel.Fastest),
        //new BrotliCompressor(level: CompressionLevel.Optimal),
        //new BrotliCompressor(level: CompressionLevel.SmallestSize),

        //new BrotliNETCompressor(null, quality: 0),
        //new BrotliNETCompressor(null, quality: 1),
        //new BrotliNETCompressor(null, quality: 2),
        //new BrotliNETCompressor(null, quality: 3),
        //new BrotliNETCompressor(null, quality: 4),
        //new BrotliNETCompressor(null, quality: 5),
        //new BrotliNETCompressor(null, quality: 6),
        //new BrotliNETCompressor(null, quality: 7),
        //new BrotliNETCompressor(null, quality: 8),
        //new BrotliNETCompressor(null, quality: 9),
        //new BrotliNETCompressor(null, quality: 10),
        //new BrotliNETCompressor(null, quality: 11),

        //new LZ4Compressor(level: K4os.Compression.LZ4.LZ4Level.L00_FAST, binaryCompressionMode: LZ4BinaryCompressionMode.Optimized),
        //new LZ4Compressor(level: K4os.Compression.LZ4.LZ4Level.L03_HC, binaryCompressionMode: LZ4BinaryCompressionMode.Optimized),
        //new LZ4Compressor(level: K4os.Compression.LZ4.LZ4Level.L04_HC, binaryCompressionMode: LZ4BinaryCompressionMode.Optimized),
        //new LZ4Compressor(level: K4os.Compression.LZ4.LZ4Level.L05_HC, binaryCompressionMode: LZ4BinaryCompressionMode.Optimized),
        //new LZ4Compressor(level: K4os.Compression.LZ4.LZ4Level.L06_HC, binaryCompressionMode: LZ4BinaryCompressionMode.Optimized),
        //new LZ4Compressor(level: K4os.Compression.LZ4.LZ4Level.L07_HC, binaryCompressionMode: LZ4BinaryCompressionMode.Optimized),
        //new LZ4Compressor(level: K4os.Compression.LZ4.LZ4Level.L08_HC, binaryCompressionMode: LZ4BinaryCompressionMode.Optimized),
        //new LZ4Compressor(level: K4os.Compression.LZ4.LZ4Level.L09_HC, binaryCompressionMode: LZ4BinaryCompressionMode.Optimized),
        //new LZ4Compressor(level: K4os.Compression.LZ4.LZ4Level.L10_OPT, binaryCompressionMode: LZ4BinaryCompressionMode.Optimized),
        //new LZ4Compressor(level: K4os.Compression.LZ4.LZ4Level.L11_OPT, binaryCompressionMode: LZ4BinaryCompressionMode.Optimized),
        //new LZ4Compressor(level: K4os.Compression.LZ4.LZ4Level.L12_MAX, binaryCompressionMode: LZ4BinaryCompressionMode.Optimized),

        //new LZMACompressor(speed: LZMASpeed.Fastest, dictionarySize: DictionarySize.VerySmall),
        //new LZMACompressor(speed: LZMASpeed.Fastest, dictionarySize: DictionarySize.Small),
        //new LZMACompressor(speed: LZMASpeed.Fastest, dictionarySize: DictionarySize.Medium),
        //new LZMACompressor(speed: LZMASpeed.Fastest, dictionarySize: DictionarySize.Large),
        //new LZMACompressor(speed: LZMASpeed.Fastest, dictionarySize: DictionarySize.Larger),
        //new LZMACompressor(speed: LZMASpeed.Fastest, dictionarySize: DictionarySize.VeryLarge),
        //new LZMACompressor(speed: LZMASpeed.Fastest),
        //new LZMACompressor(speed: LZMASpeed.VeryFast),
        //new LZMACompressor(speed: LZMASpeed.Fast),
        //new LZMACompressor(speed: LZMASpeed.Medium),
        //new LZMACompressor(speed: LZMASpeed.Slow),
        //new LZMACompressor(speed: LZMASpeed.VerySlow),

        //new ZstdCompressor(level: -131072), -- No Compression
        //new ZstdCompressor(level: -22),
        //new ZstdCompressor(level: -21),
        //new ZstdCompressor(level: -20),
        //new ZstdCompressor(level: -19),
        //new ZstdCompressor(level: -18),
        //new ZstdCompressor(level: -17),
        //new ZstdCompressor(level: -16),
        //new ZstdCompressor(level: -15),
        //new ZstdCompressor(level: -14),
        //new ZstdCompressor(level: -13),
        //new ZstdCompressor(level: -12),
        //new ZstdCompressor(level: -11),
        //new ZstdCompressor(level: -10),
        //new ZstdCompressor(level: -9),
        //new ZstdCompressor(level: -8),
        //new ZstdCompressor(level: -7),
        //new ZstdCompressor(level: -6),
        //new ZstdCompressor(level: -5),
        //new ZstdCompressor(level: -4),
        //new ZstdCompressor(level: -3),
        //new ZstdCompressor(level: -2),
        //new ZstdCompressor(level: -1),
        //new ZstdCompressor(level: 1),
        //new ZstdCompressor(level: 2),
        //new ZstdCompressor(level: 0), -- Equals to 3 (default)
        //new ZstdCompressor(level: 3),
        //new ZstdCompressor(level: 4),
        //new ZstdCompressor(level: 5),
        //new ZstdCompressor(level: 6),
        //new ZstdCompressor(level: 7),
        //new ZstdCompressor(level: 8),
        //new ZstdCompressor(level: 9),
        //new ZstdCompressor(level: 10),
        //new ZstdCompressor(level: 11),
        //new ZstdCompressor(level: 12),
        //new ZstdCompressor(level: 13),
        //new ZstdCompressor(level: 14),
        //new ZstdCompressor(level: 15),
        //new ZstdCompressor(level: 16),
        //new ZstdCompressor(level: 17),
        //new ZstdCompressor(level: 18),
        //new ZstdCompressor(level: 19),
        //new ZstdCompressor(level: 20),
        //new ZstdCompressor(level: 21),
        //new ZstdCompressor(level: 22),


        //new ZstdSharpCompressor(level: -131072), -- No Compression
        //new ZstdSharpCompressor(level: -22),
        //new ZstdSharpCompressor(level: -21),
        //new ZstdSharpCompressor(level: -20),
        //new ZstdSharpCompressor(level: -19),
        //new ZstdSharpCompressor(level: -18),
        //new ZstdSharpCompressor(level: -17),
        //new ZstdSharpCompressor(level: -16),
        //new ZstdSharpCompressor(level: -15),
        //new ZstdSharpCompressor(level: -14),
        //new ZstdSharpCompressor(level: -13),
        //new ZstdSharpCompressor(level: -12),
        //new ZstdSharpCompressor(level: -11),
        //new ZstdSharpCompressor(level: -10),
        //new ZstdSharpCompressor(level: -9),
        //new ZstdSharpCompressor(level: -8),
        //new ZstdSharpCompressor(level: -7),
        //new ZstdSharpCompressor(level: -6),
        //new ZstdSharpCompressor(level: -5),
        //new ZstdSharpCompressor(level: -4),
        //new ZstdSharpCompressor(level: -3),
        //new ZstdSharpCompressor(level: -2),
        //new ZstdSharpCompressor(level: -1),
        //new ZstdSharpCompressor(level: 1),
        //new ZstdSharpCompressor(level: 2),
        //new ZstdSharpCompressor(level: 0), -- Equals to 3 (default)
        //new ZstdSharpCompressor(level: 3),
        //new ZstdSharpCompressor(level: 4),
        //new ZstdSharpCompressor(level: 5),
        //new ZstdSharpCompressor(level: 6),
        //new ZstdSharpCompressor(level: 7),
        //new ZstdSharpCompressor(level: 8),
        //new ZstdSharpCompressor(level: 9),
        //new ZstdSharpCompressor(level: 10),
        //new ZstdSharpCompressor(level: 11),
        //new ZstdSharpCompressor(level: 12),
        //new ZstdSharpCompressor(level: 13),
        //new ZstdSharpCompressor(level: 14),
        //new ZstdSharpCompressor(level: 15),
        //new ZstdSharpCompressor(level: 16),
        //new ZstdSharpCompressor(level: 17),
        //new ZstdSharpCompressor(level: 18),
        //new ZstdSharpCompressor(level: 19),
        //new ZstdSharpCompressor(level: 20),
        //new ZstdSharpCompressor(level: 21),
        //new ZstdSharpCompressor(level: 22),
        #endregion

#pragma warning disable CS0618 // Type or member is obsolete
        new GZipCompressor(name: "GZipCompressor"),
        new DeflateCompressor(name: "DeflateCompressor"),
        new ZLibCompressor(name: "ZLibCompressor"),
        new BrotliCompressor(name: "BrotliCompressor"),
        new BrotliNETCompressor(name: "BrotliNETCompressor (deprecated)"),
        new LZ4Compressor(name: "LZ4Compressor"),
        //new LZ4Compressor(name: "LZ4Compressor-LegacyCompatible", binaryCompressionMode: LZ4BinaryCompressionMode.LegacyCompatible),
        //new LZ4Compressor(name: "LZ4Compressor-StreamCompatible", binaryCompressionMode: LZ4BinaryCompressionMode.StreamCompatible),
        //new LZ4Compressor(name: "LZ4Compressor-Optimized", binaryCompressionMode: LZ4BinaryCompressionMode.Optimized),
        new LZMACompressor(name: "LZMACompressor"),
        new SnappyCompressor(name: "SnappyCompressor (deprecated)"),
        new SnappierCompressor(name: "SnappierCompressor"),
        new ZstdCompressor(name: "ZstdCompressor (deprecated)"),
        new ZstdSharpCompressor(name: "ZstdSharpCompressor"),
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
                var compressionRatio = $"{compressedArg.CompressedBytes.Length:N0} bytes ({compressedArg.CompressionRatio:N2} %)";
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
    }
}

class CustomConfig : ManualConfig
{
    public CustomConfig()
    {
        Orderer = new CustomOerderer();
        SummaryStyle = DefaultConfig.Instance.SummaryStyle.WithMaxParameterColumnWidth(100);
    }
    private class CustomOerderer : IOrderer
    {
        public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase, IEnumerable<BenchmarkLogicalGroupRule> order = null)
            => benchmarksCase;

        public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCases, Summary summary)
            => from benchmarkCase in benchmarksCases
               orderby
                   benchmarkCase.Parameters["Data"].ToString(),
                   GetCompressorName(benchmarkCase.Parameters["Compressor"].ToString()),
                   benchmarkCase.Descriptor.WorkloadMethodDisplayInfo,
                   string.Join('_', benchmarkCase.Descriptor.Categories),
                   summary[benchmarkCase]?.ResultStatistics?.Mean ?? 0
               select benchmarkCase;

        public string GetHighlightGroupKey(BenchmarkCase benchmarkCase)
            => string.Join('_',
                GetCompressorName(benchmarkCase.Parameters["Compressor"].ToString()),
                string.Join('_', benchmarkCase.Descriptor.Categories));

        public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase)
            => string.Join('_',
                benchmarkCase.Parameters["Data"].ToString(),
                GetCompressorName(benchmarkCase.Parameters["Compressor"].ToString()),
                string.Join('_', benchmarkCase.Descriptor.Categories));

        public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups, IEnumerable<BenchmarkLogicalGroupRule> order = null)
            => logicalGroups.OrderBy(it => it.Key);

        public bool SeparateLogicalGroups => true;
    }

    #region Compression Level/Ratio Orderer
    //private class CustomOerderer : IOrderer
    //{
    //    public IEnumerable<BenchmarkCase> GetExecutionOrder(ImmutableArray<BenchmarkCase> benchmarksCase, IEnumerable<BenchmarkLogicalGroupRule> order = null)
    //        => benchmarksCase;

    //    public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCases, Summary summary)
    //        => from benchmarkCase in benchmarksCases
    //           orderby
    //               benchmarkCase.Parameters["Data"].ToString(),
    //               GetCompressorName(benchmarkCase.Parameters["Compressor"].ToString()),
    //               benchmarkCase.Descriptor.WorkloadMethodDisplayInfo,
    //               benchmarkCase.Parameters["CompressionRatio"].ToString().ExtractNumber() descending,
    //               benchmarkCase.Parameters["Compressor"].ToString() descending,
    //               string.Join('_', benchmarkCase.Descriptor.Categories),
    //               summary[benchmarkCase]?.ResultStatistics?.Mean ?? 0
    //           select benchmarkCase;

    //    public string GetHighlightGroupKey(BenchmarkCase benchmarkCase)
    //        => string.Join('_',
    //            GetCompressorName(benchmarkCase.Parameters["Compressor"].ToString()),
    //            benchmarkCase.Descriptor.WorkloadMethodDisplayInfo,
    //            string.Join('_', benchmarkCase.Descriptor.Categories));

    //    public string GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase)
    //        => string.Join('_',
    //            benchmarkCase.Parameters["Data"].ToString(),
    //            GetCompressorName(benchmarkCase.Parameters["Compressor"].ToString()),
    //            benchmarkCase.Descriptor.WorkloadMethodDisplayInfo,
    //            string.Join('_', benchmarkCase.Descriptor.Categories));

    //    public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups, IEnumerable<BenchmarkLogicalGroupRule> order = null)
    //        => logicalGroups.OrderBy(it => it.Key);

    //    public bool SeparateLogicalGroups => true;
    //}
    #endregion

    private static string GetCompressorName(string compressor)
    {
        var index = compressor.IndexOf('-');
        return index >= 0 ? compressor.Substring(0, index) : compressor;
    }
}

/*
TODO:
fix sorting issue - LZMACompressor - BrotliNETCompressor - LZ4Compressor, ...
test zstd with 21 and brotli with 0

NOTE:
========================================== BrotliCompressor ==========================================
BrotliCompressor(NoCompression)	Instead, use Fastest
BrotliCompressor(Fastest)       	Fast-GCInefficient **BEST**✔️
BrotliCompressor(Optimal)       	Slow-GCEfficient
BrotliCompressor(SmallestSize	)   Slowest
Decompress 			No difference
Use BrotliCompressor for medium or large objects (>= 10,000)
DO NOT use BrotliCompressor for small object (<= 190)

========================================== BrotliNETCompressor ==========================================
BrotliNETCompressor(0)		Instead, use 1
BrotliNETCompressor(1)		Fast-GCInefficient **BEST**✔️
BrotliNETCompressor(2..4)	Optimal
BrotliNETCompressor(5..11)	Getting Worse
Decompress 			No difference
Use BrotliNETCompressor for medium or large objects (>= 10,000)
DO NOT use BrotliNETCompressor for small object (<= 190)

========================================== DeflateCompressor ==========================================
DeflateCompressor(NoCompression)	Fastest with NO compress and GCInefficient (does not worth)
DeflateCompressor(Fastest)      	Moderate Speed (**BEST**)✔️
DeflateCompressor(Optimal)      	Slow (does not worth)
DeflateCompressor(SmallestSize) 	Slowest (does not worth)
DeflateCompressor is OK event for small objects

========================================== GZipCompressor/ZLibCompressor ==========================================
GZipCompressor same as DeflateCompressor - DeflateCompressor is better for small objects (due to lack of extra header bytes)✔️
ZLibCompressor same as DeflateCompressor - DeflateCompressor is a bit better for small objects (due to lack of extra header bytes)✔️
BrotliCompressor is faster but not GC efficient than GZip/ZLib/Deflate with Fastest option

========================================== LZ4Compressor ==========================================
LZ4Compressor(L00_FAST,Optimized)       Fastest - **BEST**✔️
LZ4Compressor(L03..L09,Optimized)       Slow
LZ4Compressor(L10..L12,Optimized)       Very Slow

========================================== LZMACompressor ==========================================
LZMACompressor(UltraFast-Smallest_64KB)     Faster and More GC Efficient (**BEST**)✔️
LZMACompressor(UltraFast-VeryLarge)         Slower and Less GC Efficient
LZMACompressor(Fastest)                     **BEST** option✔️
LZMACompressor(VerySlow)                    Worst
NOT good for small objects (due to low compression Ratio because of extra header bytes and also bad performance/allocation)
In general LZMACompressor is the Slowest and worst in memory allocation
BUT the stongest in compression (highest Ratio: 12.63)
Not much difference between compression level/speed

========================================== ZstdCompressor ==========================================
ZstdCompressor(-1000..-~)	Fastest with NO compress and GCInefficient (does not worth)
ZstdCompressor(-22)			Fast with low compression Ratio (37.86)
ZstdCompressor(-1..-~)		Getting Faster but less GC efficient in Linear way for both Compress/Decompress
ZstdCompressor(-1)		    **BEST** moderated between Ratio/Speed/Allocation (ratio: 17.52)✔️
ZstdCompressor(0(Bad),2,3,4	Instead, use 1 (0 is equal to 3 in zstd)
ZstdCompressor(1)			A bit low compression Ratio than average (15.87 - avg: 17~18)
ZstdCompressor(5~21)			Getting slow without sensible difference
ZstdCompressor(16~19)		Slow but top 2nd in compression Ratio (13.96)
ZstdCompressor(22)			Slowest, Instead use ZstdCompressor-19
ZstdCompressor levels also effect in Decompress
Decompress ZstdCompressor-0..22	is Slow but ZstdCompressor--22..-~ is Fast
DO NOT use lvl less than -2 for small objects (NO compression at all)

========================================== ZstdSharpCompressor ==========================================
ZstdSharpCompressor is the same as ZstdCompressor
*/