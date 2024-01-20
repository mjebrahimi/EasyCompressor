using EasyCaching.Core;
using EasyCaching.Core.Configurations;
using EasyCaching.Core.Serialization;
using EasyCaching.Serialization.MessagePack;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyCompressor.Tests.EasyCachingCompressor;

    [TestFixture]
    public class EasyCachingCompressorTests
    {
        [SetUp]
        public void ClearStaticDictionary()
        {
            var type = Type.GetType("EasyCompressor.EasyCompressorEasyCachingOptionsExtension, EasyCaching.Extensions.EasyCompressor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
            var dictonary = (Dictionary<string, string>)type.GetField("_dictonary", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
            dictonary.Clear();
            dictonary.Add("binary", null);
        }

        [Test]
        public void BinaryFormatter_WithCompressor_NonNamed_Should_Decorate()
        {
            var services = new ServiceCollection();
            services.AddZstdCompressor();
            services.AddEasyCaching(options =>
            {
                options.UseRedis(config =>
                {
                    config.DBConfig.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6379));
                })
                .WithCompressor();
            });
            var cachingProvider = services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();

            Assert.IsInstanceOf<EasyCachingSerializerDecorator>(cachingProvider.GetFieldValue("_serializer"));

            Assert.IsInstanceOf<DefaultBinaryFormatterSerializer>(cachingProvider.GetFieldValue("_serializer").GetFieldValue("_easyCachingSerializer"));

            Assert.IsInstanceOf<ZstdCompressor>(cachingProvider.GetFieldValue("_serializer").GetFieldValue("_compressor"));

            Assert.AreEqual("binary", cachingProvider.GetFieldValue("_serializer").GetFieldValue<IEasyCachingSerializer>("_easyCachingSerializer").Name);

            Assert.AreEqual(null, cachingProvider.GetFieldValue("_serializer").GetFieldValue<ICompressor>("_compressor").Name);
        }

        [Test]
        public void MessagePack_WithCompressor_NonNamed_Should_Decorate()
        {
            var services = new ServiceCollection();
            services.AddZstdCompressor();
            services.AddEasyCaching(options =>
            {
                options.UseRedis(config =>
                {
                    config.DBConfig.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6379));
                    config.SerializerName = "msgpack";
                })
                .WithMessagePack()
                .WithCompressor();
            });
            var cachingProvider = services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();

            Assert.IsInstanceOf<EasyCachingSerializerDecorator>(cachingProvider.GetFieldValue("_serializer"));

            Assert.IsInstanceOf<DefaultMessagePackSerializer>(cachingProvider.GetFieldValue("_serializer").GetFieldValue("_easyCachingSerializer"));

            Assert.IsInstanceOf<ZstdCompressor>(cachingProvider.GetFieldValue("_serializer").GetFieldValue("_compressor"));

            Assert.AreEqual("msgpack", cachingProvider.GetFieldValue("_serializer").GetFieldValue<IEasyCachingSerializer>("_easyCachingSerializer").Name);

            Assert.AreEqual(null, cachingProvider.GetFieldValue("_serializer").GetFieldValue<ICompressor>("_compressor").Name);
        }

        [Test]
        public void MessagePack_WithCompressor_CorrectNamed_Should_Decorate()
        {
            var services = new ServiceCollection();
            services.AddZstdCompressor("Zstd");
            services.AddEasyCaching(options =>
            {
                options.UseRedis(config =>
                {
                    config.DBConfig.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6379));
                    config.SerializerName = "MessagePack";
                })
                .WithMessagePack("MessagePack")
                .WithCompressor("MessagePack", "Zstd");
            });
            var cachingProvider = services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();

            Assert.IsInstanceOf<EasyCachingSerializerDecorator>(cachingProvider.GetFieldValue("_serializer"));

            Assert.IsInstanceOf<DefaultMessagePackSerializer>(cachingProvider.GetFieldValue("_serializer").GetFieldValue("_easyCachingSerializer"));

            Assert.IsInstanceOf<ZstdCompressor>(cachingProvider.GetFieldValue("_serializer").GetFieldValue("_compressor"));

            Assert.AreEqual("MessagePack", cachingProvider.GetFieldValue("_serializer").GetFieldValue<IEasyCachingSerializer>("_easyCachingSerializer").Name);

            Assert.AreEqual("Zstd", cachingProvider.GetFieldValue("_serializer").GetFieldValue<ICompressor>("_compressor").Name);
        }

        [Test]
        public void MessagePack_WithCompressor_IncorrectNamed1_Should_ThrowException()
        {
            var services = new ServiceCollection();
            services.AddZstdCompressor("zstd");
            services.AddEasyCaching(options =>
            {
                options.UseRedis(config =>
                {
                    config.DBConfig.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6379));
                    config.SerializerName = "msgpack";
                })
                .WithMessagePack("msgpack")
                .WithCompressor();
            });

        void action() => services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();
            Assert.Catch(action);
        }

        [Test]
        public void MessagePack_WithCompressor_IncorrectNamed2_Should_ThrowException()
        {
            var services = new ServiceCollection();
            services.AddZstdCompressor("zstd");
            services.AddEasyCaching(options =>
            {
                options.UseRedis(config =>
                {
                    config.DBConfig.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6379));
                    config.SerializerName = "msgpack";
                })
                .WithMessagePack("msgpack")
                .WithCompressor("msgpack", "xzy");
            });

        void action() => services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();
            Assert.Catch(action);
        }

        [Test]
        public void MessagePack_WithCompressor_IncorrectNamed3_Should_ThrowException()
        {
            var services = new ServiceCollection();
            services.AddZstdCompressor("zstd");
            services.AddEasyCaching(options =>
            {
                options.UseRedis(config =>
                {
                    config.DBConfig.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6379));
                    config.SerializerName = "msgpack";
                })
                .WithMessagePack("msgpack")
                .WithCompressor("xyz", "zstd");
            });

        void action() => services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();
            Assert.Catch(action);
        }

        [Test]
        public void NoSerializer_WithCompressor_Should_ThrowException()
        {
            var services = new ServiceCollection();

            TestDelegate action = () => services.AddEasyCaching(options =>
            {
                options.UseInMemory()
                    .WithCompressor();
            });

            TestDelegate action2 = () => services.AddEasyCaching(options =>
            {
                options.UseInMemory()
                    .WithCompressor()
                    .WithMessagePack();
            });

            Assert.Throws<InvalidOperationException>(action, "This operation must be called after serializer added.");
            Assert.Throws<InvalidOperationException>(action2, "This operation must be called after serializer added.");
        }
    }

    public static class ReflectionExtensions
    {
        public static object GetFieldValue(this object obj, string name)
        {
            // Set the flags so that private and public fields from instances will be found
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var field = obj.GetType().GetField(name, bindingFlags);
            return field?.GetValue(obj);
        }

        public static T GetFieldValue<T>(this object obj, string name)
        {
            // Set the flags so that private and public fields from instances will be found
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var field = obj.GetType().GetField(name, bindingFlags);
            return (T)field?.GetValue(obj);
        }
    }
