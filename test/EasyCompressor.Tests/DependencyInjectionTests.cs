using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;

namespace EasyCompressor.Tests.DependencyInjectionTests;

    [TestFixtureSource(nameof(GetTestItems))]
    public class DependencyInjectionTests
    {
        protected readonly IServiceCollection ServiceCollection;
        protected readonly IServiceProvider ServiceProvider;
        protected readonly Type ImplementationType;

        public DependencyInjectionTests(Action<IServiceCollection, string> addService, Type type)
        {
            ServiceCollection = new ServiceCollection();

            //TODO: add compressor with null as name and test ICompressorProvider
            //TODO: write test for EasyCaching.Extensions.EasyCompressor
            addService(ServiceCollection, "duplicate-name");
            addService(ServiceCollection, "duplicate-name");
            addService(ServiceCollection, "my-compressor");

            ServiceProvider = ServiceCollection.BuildServiceProvider();

            ImplementationType = type;
        }

        [Test]
        public void Service_Count_ShouldBe_Foure()
        {
            Assert.AreEqual(ServiceCollection.Count, 4);
        }

        [Test]
        public void ICompressorProvider_Count_ShouldBe_One()
        {
            var count = ServiceCollection.Count(p => p.ServiceType == typeof(ICompressorProvider));
            Assert.AreEqual(count, 1);
        }

        [Test]
        public void ICompressor_Count_ShouldBe_Tree()
        {
            var count = ServiceCollection.Count(p => p.ServiceType == typeof(ICompressor));
            Assert.AreEqual(count, 3);
        }

        [Test]
        public void ICompressor_Should_Registred_As_Singleton()
        {
            var list = ServiceCollection.Where(p => p.ServiceType == typeof(ICompressor)).ToList();

            foreach (var serviceDescriptor in list)
            {
                Assert.IsNotNull(serviceDescriptor);
                Assert.AreEqual(serviceDescriptor.Lifetime, ServiceLifetime.Singleton);
            }
        }

        [Test]
        public void ICompressorProvider_Should_Registred_As_Singleton()
        {
            var serviceDescriptor = ServiceCollection.SingleOrDefault(p => p.ServiceType == typeof(ICompressorProvider));

            Assert.IsNotNull(serviceDescriptor);
            Assert.AreEqual(serviceDescriptor.Lifetime, ServiceLifetime.Singleton);
        }

        [Test]
        public void ICompressor_Should_Resolve_Correctly()
        {
            var compressor = ServiceProvider.GetService<ICompressor>();

            Assert.IsNotNull(compressor);
            Assert.AreEqual(compressor.GetType(), ImplementationType);
        }

        [Test]
        public void ICompressorProvider_Should_Resolve_Correctly()
        {
            var compressorProvider = ServiceProvider.GetService<ICompressorProvider>();

            Assert.IsNotNull(compressorProvider);
        }

        [Test]
        public void Resolved_ICompressor_And_GetCompressor_ShouldBe_AsSame()
        {
            var compressor1 = ServiceProvider.GetService<ICompressor>();

            var compressorProvider = ServiceProvider.GetService<ICompressorProvider>();

            var compressor2 = compressorProvider.GetCompressor("my-compressor");

            Assert.IsNotNull(compressor2);
            Assert.AreSame(compressor1, compressor2);
        }

        [Test]
        public void GetCompressor_NotExistName_Should_Throws_ArgumentException()
        {
            var compressorProvider = ServiceProvider.GetService<ICompressorProvider>();

        void action() => compressorProvider.GetCompressor("not-exist-name");

            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        public void GetCompressor_With_DuplicateName_Should_Throws_ArgumentException()
        {
            var compressorProvider = ServiceProvider.GetService<ICompressorProvider>();

        void action() => compressorProvider.GetCompressor("duplicate-name");

            Assert.Throws<ArgumentException>(action);
        }

        public static IEnumerable GetTestItems
        {
            get
            {
                yield return new TestFixtureData(new Action<IServiceCollection, string>((services, name) => services.AddGZipCompressor(name)), typeof(GZipCompressor)).SetArgDisplayNames(" GZip ");
                yield return new TestFixtureData(new Action<IServiceCollection, string>((services, name) => services.AddDeflateCompressor(name)), typeof(DeflateCompressor)).SetArgDisplayNames(" Deflate ");
                yield return new TestFixtureData(new Action<IServiceCollection, string>((services, name) => services.AddBrotliCompressor(name)), typeof(BrotliCompressor)).SetArgDisplayNames(" Brotli ");
                yield return new TestFixtureData(new Action<IServiceCollection, string>((services, name) => services.AddBrotliNETCompressor(name)), typeof(BrotliNETCompressor)).SetArgDisplayNames(" BrotliNET ");
                yield return new TestFixtureData(new Action<IServiceCollection, string>((services, name) => services.AddLZ4Compressor(name)), typeof(LZ4Compressor)).SetArgDisplayNames(" LZ4 ");
                yield return new TestFixtureData(new Action<IServiceCollection, string>((services, name) => services.AddLZMACompressor(name)), typeof(LZMACompressor)).SetArgDisplayNames(" LZMA ");
                yield return new TestFixtureData(new Action<IServiceCollection, string>((services, name) => services.AddSnappyCompressor(name)), typeof(SnappyCompressor)).SetArgDisplayNames(" Snappy ");
                yield return new TestFixtureData(new Action<IServiceCollection, string>((services, name) => services.AddZstandardCompressor(name)), typeof(ZstandardCompressor)).SetArgDisplayNames(" Zstandard ");
                yield return new TestFixtureData(new Action<IServiceCollection, string>((services, name) => services.AddZstdCompressor(name)), typeof(ZstdCompressor)).SetArgDisplayNames(" Zstd ");
            }
        }
    }
