﻿using NUnit.Framework;
using System.Collections;
using System.IO;

namespace EasyCompressor.Tests;

[TestFixtureSource(nameof(GetCompressors))]
public class TestBase(ICompressor compressor)
{
    protected readonly ICompressor Compressor = compressor;
    protected byte[] ObjectBytes;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var json = File.ReadAllText("Data\\spotifyAlbum.json");
        var spotify = Serializer.FromJson<SpotifyAlbum>(json);
        ObjectBytes = Serializer.SerializeMessagePack(spotify);
    }

    public static IEnumerable GetCompressors
    {
        get
        {
#pragma warning disable CS0618 // Type or member is obsolete
            yield return new TestFixtureData(new GZipCompressor()).SetArgDisplayNames(" GZip ");
            yield return new TestFixtureData(new DeflateCompressor()).SetArgDisplayNames(" Deflate ");
            yield return new TestFixtureData(new BrotliCompressor()).SetArgDisplayNames(" Brotli ");
            yield return new TestFixtureData(new BrotliNETCompressor()).SetArgDisplayNames(" BrotliNET ");
            yield return new TestFixtureData(new LZ4Compressor() { BinaryCompressionMode = LZ4BinaryCompressionMode.LegacyCompatible }).SetArgDisplayNames(" LZ4-LegacyCompatible ");
            yield return new TestFixtureData(new LZ4Compressor() { BinaryCompressionMode = LZ4BinaryCompressionMode.StreamCompatible }).SetArgDisplayNames(" LZ4-StreamCompatible ");
            yield return new TestFixtureData(new LZ4Compressor() { BinaryCompressionMode = LZ4BinaryCompressionMode.Optimized }).SetArgDisplayNames(" LZ4-Optimized ");
            yield return new TestFixtureData(new LZMACompressor()).SetArgDisplayNames(" LZMA ");
            yield return new TestFixtureData(new SnappyCompressor()).SetArgDisplayNames(" Snappy ");
            yield return new TestFixtureData(new ZstdCompressor()).SetArgDisplayNames(" Zstd ");
            yield return new TestFixtureData(new SnappierCompressor()).SetArgDisplayNames(" Snappier ");
            yield return new TestFixtureData(new ZstdSharpCompressor()).SetArgDisplayNames(" ZstdSharp ");
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
