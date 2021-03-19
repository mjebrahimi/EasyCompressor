using NUnit.Framework;
using System.Collections;
using System.IO;

namespace EasyCompressor.Tests
{
    [TestFixtureSource(nameof(GetCompressors))]
    public class TestBase
    {
        protected readonly ICompressor Compressor;
        protected byte[] ObjectBytes;

        public TestBase(ICompressor compressor)
        {
            Compressor = compressor;
        }

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
                yield return new TestFixtureData(new GZipCompressor()).SetArgDisplayNames(" GZip ");
                yield return new TestFixtureData(new DeflateCompressor()).SetArgDisplayNames(" Deflate ");
                yield return new TestFixtureData(new BrotliCompressor()).SetArgDisplayNames(" Brotli ");
                yield return new TestFixtureData(new BrotliNETCompressor()).SetArgDisplayNames(" BrotliNET ");
                yield return new TestFixtureData(new LZ4Compressor()).SetArgDisplayNames(" LZ4 ");
                yield return new TestFixtureData(new LZMACompressor()).SetArgDisplayNames(" LZMA ");
                yield return new TestFixtureData(new SnappyCompressor()).SetArgDisplayNames(" Snappy ");
                yield return new TestFixtureData(new ZstandardCompressor()).SetArgDisplayNames(" Zstandard ");
                yield return new TestFixtureData(new ZstdCompressor()).SetArgDisplayNames(" Zstd ");
            }
        }
    }
}
