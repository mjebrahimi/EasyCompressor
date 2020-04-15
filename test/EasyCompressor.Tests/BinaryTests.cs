using NUnit.Framework;
using System;
using System.Linq;

namespace EasyCompressor.Tests.BinaryTests
{
    public class BinaryTests : TestBase
    {
        public BinaryTests(ICompressor compressor)
            : base(compressor)
        {
        }

        [Test]
        public void Compress_NullValue_Should_Throws_ArgumentNullException()
        {
            TestDelegate action = () => Compressor.Compress(null);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void Compress_EmptyValue_Should_Throws_ArgumentException()
        {
            TestDelegate action = () => Compressor.Compress(Array.Empty<byte>());

            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void Decompress_NullValue_Should_Throws_ArgumentNullException()
        {
            TestDelegate action = () => Compressor.Decompress(null);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Test]
        public void Decompress_EmptyValue_Should_Throws_ArgumentException()
        {
            TestDelegate action = () => Compressor.Decompress(Array.Empty<byte>());

            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void Compress_Should_DoesNotThrow_Exception()
        {
            TestDelegate action = () => Compressor.Compress(ObjectBytes);

            Assert.DoesNotThrow(action);
        }

        [Test]
        public void CompressedResult_ShouldNot_NullOrEmpty()
        {
            var compressedBytes = Compressor.Compress(ObjectBytes);

            Assert.IsNotNull(compressedBytes);
            Assert.IsNotEmpty(compressedBytes);
        }

        [Test]
        public void Decompress_Should_DoesNotThrow_Exception()
        {
            var compressedBytes = Compressor.Compress(ObjectBytes);
            TestDelegate action = () => Compressor.Decompress(compressedBytes);

            Assert.DoesNotThrow(action);
        }

        [Test]
        public void DecompressdResult_ShouldNot_NullOrEmpty()
        {
            var compressedBytes = Compressor.Compress(ObjectBytes);
            var decompressedBytes = Compressor.Decompress(compressedBytes);

            Assert.IsNotNull(decompressedBytes);
            Assert.IsNotEmpty(decompressedBytes);
        }

        [Test]
        public void DecompressedResult_Should_SequenceEqual_With_SourceBytes()
        {
            var compressedBytes = Compressor.Compress(ObjectBytes);
            var decompressedBytes = Compressor.Decompress(compressedBytes);

            Assert.IsTrue(decompressedBytes.SequenceEqual(ObjectBytes));
        }

        #region TODO: Must be completed
        //public void EasyCaching_Extensions_EasyCompressor()
        //{
        //    var str = "Of recommend residence education be on difficult repulsive offending. Judge views had mirth table seems great him for her. Alone all happy asked begin fully stand own get. Excuse ye seeing result of we. See scale dried songs old may not. Promotion did disposing you household any instantly. Hills we do under times at first short an. Neat own nor she said see walk. And charm add green you these. Sang busy in this drew ye fine. At greater prepare musical so attacks as on distant. Improving age our her cordially intention. His devonshire sufficient precaution say preference middletons insipidity. Since might water hence the her worse. Concluded it offending dejection do earnestly as me direction. Nature played thirty all him. Received overcame oh sensible so at an. Formed do change merely to county it. Am separate contempt domestic to to oh. On relation my so addition branched. Put hearing cottage she norland letters equally prepare too. Replied exposed savings he no viewing as up. Soon body add him hill. No father living really people estate if. Mistake do produce beloved demesne if am pursuit. An so vulgar to on points wanted. Not rapturous resolving continued household northward gay. He it otherwise supported instantly. Unfeeling agreeable suffering it on smallness newspaper be. So come must time no as. Do on unpleasing possession as of unreserved. Yet joy exquisite put sometimes enjoyment perpetual now. Behind lovers eat having length horses vanity say had its. His followed carriage proposal entrance directly had elegance. Greater for cottage gay parties natural. Remaining he furniture on he discourse suspected perpetual. Power dried her taken place day ought the. Four and our ham west miss. Education shameless who middleton agreement how. We in found world chief is at means weeks smile. Dissuade ecstatic and properly saw entirely sir why laughter endeavor. In on my jointure horrible margaret suitable he followed speedily. Indeed vanity excuse or mr lovers of on. By offer scale an stuff. Blush be sorry no sight. Sang lose of hour then he left find. Stronger unpacked felicity to of mistaken. Fanny at wrong table ye in. Be on easily cannot innate in lasted months on. Differed and and felicity steepest mrs age outweigh. Opinions learning likewise daughter now age outweigh. Raptures stanhill my greatest mistaken or exercise he on although. Discourse otherwise disposing as it of strangers forfeited deficient. Him rendered may attended concerns jennings reserved now. Sympathize did now preference unpleasing mrs few. Mrs for hour game room want are fond dare. For detract charmed add talking age. Shy resolution instrument unreserved man few. She did open find pain some out. If we landlord stanhill mr whatever pleasure supplied concerns so. Exquisite by it admitting cordially september newspaper an. Acceptance middletons am it favourable. It it oh happen lovers afraid. Entire any had depend and figure winter. Change stairs and men likely wisdom new happen piqued six. Now taken him timed sex world get. Enjoyed married an feeling delight pursuit as offered. As admire roused length likely played pretty to no. Means had joy miles her merry solid order. Arrived compass prepare an on as. Reasonable particular on my it in sympathize. Size now easy eat hand how. Unwilling he departure elsewhere dejection at. Heart large seems may purse means few blind. Exquisite newspaper attending on certainty oh suspicion of. He less do quit evil is. Add matter family active mutual put wishes happen. ";
        //    IEasyCachingSerializer serializerWithoutCompressor;
        //    IEasyCachingSerializer serializerWithCompressor;

        //    {
        //        var services = new ServiceCollection();

        //        services.AddEasyCaching(options =>
        //        {
        //            options
        //                .UseInMemory()
        //                .WithMessagePack();
        //        });

        //        var serviceProvider = services.BuildServiceProvider();

        //        serializerWithoutCompressor = serviceProvider.GetRequiredService<IEasyCachingSerializer>();

        //        var bytes = serializerWithoutCompressor.Serialize(str);
        //    }
        //    {
        //        var services = new ServiceCollection();

        //        services.AddGZipCompressor();
        //        services.AddBrotliCompressor("Brotli");
        //        services.AddZstdCompressor("Zstd");

        //        services.AddEasyCaching(options =>
        //        {
        //            options
        //                .UseInMemory()

        //                .WithJson()
        //                .WithCompressor()

        //                //.WithJson()
        //                //.WithMessagePack()
        //                //.WithCompressor("msgpack", "Zstd")
        //                //.WithCompressor()

        //                //.WithMessagePack()
        //                //.WithCompressor("msgpack", "Zstd")
        //                //.WithJson()
        //                //.WithCompressor("json", "Brotli")

        //                //.WithMessagePack()
        //                //.WithJson()
        //                //.WithCompressor("msgpack", "Zstd")
        //                //.WithCompressor("json", "Brotli")

        //                //.WithCompressor("msgpack", "Zstd")
        //                //.WithCompressor("json", "Brotli")
        //                //.WithMessagePack()
        //                //.WithJson()

        //                //.WithMessagePack()
        //                //.WithJson()
        //                //.WithCompressor("json", "Brotli")
        //                ;
        //        });

        //        var serviceProvider = services.BuildServiceProvider();

        //        var serializers = serviceProvider.GetServices<IEasyCachingSerializer>();

        //        serializerWithCompressor = serviceProvider.GetRequiredService<IEasyCachingSerializer>();

        //        var bytes = serializerWithCompressor.Serialize(str);

        //        var actual = serializerWithCompressor.Deserialize<string>(bytes);

        //        if (str != actual)
        //            throw new Exception();
        //    }
        //}
        #endregion
    }
}