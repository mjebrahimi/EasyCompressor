using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using EasyCompressor;
using EasyCompressor.Benchmark;
using ProtobufVsMsgPack.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace EasySerializer.Benchmark;

#if RELEASE
//[ShortRunJob] //Does not achieve accurate results
[SimpleJob(BenchmarkDotNet.Engines.RunStrategy.Throughput)]
#else
[MarkdownExporterAttribute.GitHub]
#endif
//[CategoriesColumn]
[Config(typeof(CustomConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
public abstract class BaseBenchmark<T> where T : BaseCompressor
{
    public abstract string CompressionType { get; }
    public string[] GetCompressionType => [CompressionType];

    public static (byte[] Bytes, string Size)[] GetData()
    {
        var person = PersonGenerator.GeneratePerson();
        var smallData = Serializer.SerializeMessagePack(person);

        var json1 = File.ReadAllText(@"Data\SpotifyAlbum\SpotifyAlbum.json");
        var data1 = Serializer.FromJson<SpotifyAlbumArray>(json1);
        var mediumData = Serializer.SerializeMessagePack(data1);

        var json2 = File.ReadAllText(@"Data\SearchResponse\SearchResponse.json");
        var data2 = Serializer.FromJson<List<SearchResponse>>(json2);
        var largeData = Serializer.SerializeMessagePack(data2);

        return
        [
            (smallData, "Small (190 B)"),
            (mediumData, "Medium (10 KB)"),
            (largeData, "Large (20 KB)")
        ];
    }

    private static readonly (byte[] Bytes, string Size)[] Data = GetData();

    public BaseCompressor CompressorInstance { get; } = ActivatorHelper.CreateInstanceWithDefaultValues<T>();


    [ParamsSource(nameof(GetCompressionType), Priority = -2)]
    public string Type { get; set; }

    public string[] GetTypeNameT { get; } = [typeof(T).Name];

    [ParamsSource(nameof(GetTypeNameT), Priority = -1)]
    public string Compressor { get; set; }

    public IEnumerable<object[]> GetArguments()
    {
        foreach (var (bytes, size) in Data)
        {
            var compressedArg = new CompressedArg(CompressorInstance, bytes, CompressionType);
            var compressionRatio = $"{compressedArg.CompressionRatio:N2} %";
            yield return [size, compressedArg, compressionRatio];
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

public static class ActivatorHelper
{
    public static T CreateInstanceWithDefaultValues<T>()
    {
        return (T)Activator.CreateInstance(typeof(T), BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance | BindingFlags.OptionalParamBinding, null, [Type.Missing], null);
    }
}