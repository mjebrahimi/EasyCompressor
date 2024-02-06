using EasyCaching.Core;
using EasyCaching.Core.Configurations;
using EasyCaching.Core.Serialization;
using EasyCaching.Disk;
using EasyCaching.Serialization.Json;
using EasyCaching.Serialization.MessagePack;
using EasyCaching.Serialization.Protobuf;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EasyCompressor.Tests.EasyCachingCompressor;

[TestFixture]
public class EasyCachingCompressorTests
{
    [Test]
    public void NameLess_Compressor_Should_Work()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor();

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack")
                .WithMessagePack("msgpack")
                .WithCompressor();
        });

        var cachingProvider = services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();

        CheckAssertions<DefaultMessagePackSerializer, GZipCompressor>(cachingProvider as DefaultDiskCachingProvider, "msgpack", null);
    }

    [Test]
    public void Named_Compressor_Should_Work()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("gzip");

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack")
                .WithMessagePack("msgpack")
                .WithCompressor("gzip");
        });

        var cachingProviders = services.BuildServiceProvider().GetRequiredService<IEnumerable<IEasyCachingProvider>>().ToArray();

        CheckAssertions<DefaultMessagePackSerializer, GZipCompressor>(cachingProviders[0] as DefaultDiskCachingProvider, "msgpack", "gzip");
    }

    [Test]
    public void Named_Compressor_WithCompressor_Named_Serializer_Should_Work()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("gzip");

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack")
                .WithMessagePack("msgpack")
                .WithCompressor("msgpack", "gzip");
        });
        var cachingProvider = services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();

        CheckAssertions<DefaultMessagePackSerializer, GZipCompressor>(cachingProvider as DefaultDiskCachingProvider, "msgpack", "gzip");
    }

    [Test]
    public void NameLess_Compressor_ForAllPrevious_Serializers_Should_Work()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor();

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack", "disk1")
                .WithMessagePack("msgpack");

            options
                .UseDisk("protobuf", "disk2")
                .WithProtobuf("protobuf")
                .WithCompressor();
        });

        var cachingProviders = services.BuildServiceProvider().GetRequiredService<IEnumerable<IEasyCachingProvider>>().ToArray();

        CheckAssertions<DefaultMessagePackSerializer, GZipCompressor>(cachingProviders[0] as DefaultDiskCachingProvider, "msgpack", null);
        CheckAssertions<DefaultProtobufSerializer, GZipCompressor>(cachingProviders[1] as DefaultDiskCachingProvider, "protobuf", null);
    }

    [Test]
    public void Named_Compressor_ForAllPrevious_Serializers_Should_Work()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("gzip1");
        services.AddGZipCompressor("gzip2");
        services.AddGZipCompressor("gzip3");

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack", "disk1")
                .WithMessagePack("msgpack");

            options
                .UseDisk("protobuf", "disk2")
                .WithProtobuf("protobuf")
                .WithCompressor("gzip2");
        });

        var cachingProviders = services.BuildServiceProvider().GetRequiredService<IEnumerable<IEasyCachingProvider>>().ToArray();

        CheckAssertions<DefaultMessagePackSerializer, GZipCompressor>(cachingProviders[0] as DefaultDiskCachingProvider, "msgpack", "gzip2");
        CheckAssertions<DefaultProtobufSerializer, GZipCompressor>(cachingProviders[1] as DefaultDiskCachingProvider, "protobuf", "gzip2");
    }

    [Test]
    public void Named_Compressor_ForOnly_Named_Serializer_Should_Work()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("gzip1");
        services.AddGZipCompressor("gzip2");
        services.AddGZipCompressor("gzip3");

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack1", "disk1")
                .WithMessagePack("msgpack1");

            options
                .UseDisk("msgpack2", "disk2")
                .WithMessagePack("msgpack2")
                .WithCompressor("msgpack2", "gzip2");
        });

        var cachingProviders = services.BuildServiceProvider().GetRequiredService<IEnumerable<IEasyCachingProvider>>().ToArray();

        var msgpack1 = (cachingProviders[0] as DefaultDiskCachingProvider).Get_serializer();
        Assert.That(msgpack1, Is.InstanceOf<DefaultMessagePackSerializer>());
        Assert.That(msgpack1.Name, Is.EqualTo("msgpack1"));

        CheckAssertions<DefaultMessagePackSerializer, GZipCompressor>(cachingProviders[1] as DefaultDiskCachingProvider, "msgpack2", "gzip2");
    }

    [Test]
    public void Named_Compressor_ForEach_Named_Serializer_Should_Work()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("gzip");
        services.AddDeflateCompressor("deflate");
        services.AddBrotliCompressor("brotli");

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack", "disk1")
                .WithMessagePack("msgpack")
                .WithCompressor("gzip");

            options
                .UseDisk("protobuf", "disk2")
                .WithProtobuf("protobuf")
                .WithCompressor("deflate");

            options
                .UseDisk("json", "disk3")
                .WithJson("json")
                .WithCompressor("brotli");
        });

        var cachingProviders = services.BuildServiceProvider().GetRequiredService<IEnumerable<IEasyCachingProvider>>().ToArray();

        CheckAssertions<DefaultMessagePackSerializer, GZipCompressor>(cachingProviders[0] as DefaultDiskCachingProvider, "msgpack", "gzip");
        CheckAssertions<DefaultProtobufSerializer, DeflateCompressor>(cachingProviders[1] as DefaultDiskCachingProvider, "protobuf", "deflate");
        CheckAssertions<DefaultJsonSerializer, BrotliCompressor>(cachingProviders[2] as DefaultDiskCachingProvider, "json", "brotli");
    }

    [Test]
    public void Named_Compressor_ForEach_Named_Serializer_Should_Work2()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("gzip");
        services.AddDeflateCompressor("deflate");
        services.AddBrotliCompressor("brotli");

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack", "disk1")
                .WithMessagePack("msgpack")
                .WithCompressor("msgpack", "gzip");

            options
                .UseDisk("protobuf", "disk2")
                .WithProtobuf("protobuf")
                .WithCompressor("protobuf", "deflate");

            options
                .UseDisk("json", "disk3")
                .WithJson("json")
                .WithCompressor("json", "brotli");
        });

        var cachingProviders = services.BuildServiceProvider().GetRequiredService<IEnumerable<IEasyCachingProvider>>().ToArray();

        CheckAssertions<DefaultMessagePackSerializer, GZipCompressor>(cachingProviders[0] as DefaultDiskCachingProvider, "msgpack", "gzip");
        CheckAssertions<DefaultProtobufSerializer, DeflateCompressor>(cachingProviders[1] as DefaultDiskCachingProvider, "protobuf", "deflate");
        CheckAssertions<DefaultJsonSerializer, BrotliCompressor>(cachingProviders[2] as DefaultDiskCachingProvider, "json", "brotli");
    }

    [Test]
    public void Duplicate_NameLess_Compressor_Should_ThrowException()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor();
        services.AddGZipCompressor();

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack1", "disk1")
                .WithMessagePack("msgpack1")
                .WithCompressor();
        });

        void action() => services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();

        Assert.That(action, Throws.TypeOf<ArgumentException>().And.Message.EqualTo("There is more than one compressor with this name 'null'. (Parameter 'name')"));
    }

    [Test]
    public void Duplicate_Named_Compressor_Should_ThrowException()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("duplicate");
        services.AddGZipCompressor("duplicate");

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack1", "disk1")
                .WithMessagePack("msgpack1")
                .WithCompressor("duplicate");
        });

        void action() => services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();

        Assert.That(action, Throws.TypeOf<ArgumentException>().And.Message.EqualTo("There is more than one compressor with this name 'duplicate'. (Parameter 'name')"));
    }

    [Test]
    public void CanNotFind_Nameless_Compressor_Should_ThrowException1()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("gzip");

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack")
                .WithMessagePack("msgpack")
                .WithCompressor();
        });

        void action() => services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();

        Assert.That(action, Throws.TypeOf<ArgumentException>().And.Message.EqualTo("Can not find a matched compressor with name 'null'. (Parameter 'name')"));
    }

    [Test]
    public void CanNotFind_Nameless_Compressor_Should_ThrowException2()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("gzip1");
        services.AddGZipCompressor("gzip2");

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack")
                .WithMessagePack("msgpack")
                .WithCompressor();
        });

        void action() => services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();

        Assert.That(action, Throws.TypeOf<ArgumentException>().And.Message.EqualTo("Can not find a matched compressor with name 'null'. (Parameter 'name')"));
    }

    [Test]
    public void CanNotFind_Nameless_Compressor_Should_ThrowException3()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("gzip1");
        services.AddGZipCompressor("gzip2");

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack")
                .WithMessagePack("msgpack");

            options
                .UseDisk("msgpack")
                .WithMessagePack("msgpack")
                .WithCompressor();
        });

        void action() => services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();

        Assert.That(action, Throws.TypeOf<ArgumentException>().And.Message.EqualTo("Can not find a matched compressor with name 'null'. (Parameter 'name')"));
    }

    [Test]
    public void CanNotFind_InvalidNameCompressor_ThrowException()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("gzip");

        services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack")
                .WithMessagePack("msgpack")
                .WithCompressor("msgpack", "xzy");
        });

        void action() => services.BuildServiceProvider().GetRequiredService<IEasyCachingProvider>();

        Assert.That(action, Throws.TypeOf<ArgumentException>().And.Message.EqualTo("Can not find a matched compressor with name 'xzy'. (Parameter 'name')"));
    }

    [Test]
    public void CanNotFind_Serializer_Should_ThrowException()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("gzip");

        void action() => services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack")
                .WithMessagePack("msgpack")
                .WithCompressor("xyz", "gzip");
        });

        Assert.That(action, Throws.TypeOf<EasyCachingNotFoundException>().And.Message.EqualTo("Can not find a matched Serializer instance with name 'xyz'."));
    }

    [Test]
    public void CanNotFind_Serializer_Should_ThrowException2()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("gzip");

        void action() => services.AddEasyCaching(options =>
        {
            options
                .UseDisk("msgpack1")
                .WithMessagePack("msgpack1");

            options
                .UseDisk("protobuf")
                .WithProtobuf("protobuf")
                .WithCompressor("xyz", "gzip");
        });

        Assert.That(action, Throws.TypeOf<EasyCachingNotFoundException>().And.Message.EqualTo("Can not find a matched Serializer instance with name 'xyz'."));
    }

    [Test]
    public void NoCompressor_NoSerializer_Should_ThrowException()
    {
        var services = new ServiceCollection();

        void action1() => services.AddEasyCaching(options =>
        {
            options
                .UseInMemory()
                .WithCompressor();
        });

        void action2() => services.AddEasyCaching(options =>
        {
            options
                .UseInMemory()
                .WithCompressor()
                .WithMessagePack();
        });

        Assert.That(action1, Throws.TypeOf<EasyCachingNotFoundException>().And.Message.EqualTo("Can not find any EasyCachingSerializer that is not assigned to a Compressor. Make sure to call WithCompressor() method after adding a serializer to the EasyCachingOptions, not before."));
        Assert.That(action2, Throws.TypeOf<EasyCachingNotFoundException>().And.Message.EqualTo("Can not find any EasyCachingSerializer that is not assigned to a Compressor. Make sure to call WithCompressor() method after adding a serializer to the EasyCachingOptions, not before."));
    }

    [Test]
    public void NameLess_Compressor_NoSerializer_Should_ThrowException()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor();

        void action1() => services.AddEasyCaching(options =>
        {
            options
                .UseInMemory()
                .WithCompressor();
        });

        void action2() => services.AddEasyCaching(options =>
        {
            options.UseInMemory()
                .WithCompressor()
                .WithMessagePack();
        });

        Assert.That(action1, Throws.TypeOf<EasyCachingNotFoundException>().And.Message.EqualTo("Can not find any EasyCachingSerializer that is not assigned to a Compressor. Make sure to call WithCompressor() method after adding a serializer to the EasyCachingOptions, not before."));
        Assert.That(action2, Throws.TypeOf<EasyCachingNotFoundException>().And.Message.EqualTo("Can not find any EasyCachingSerializer that is not assigned to a Compressor. Make sure to call WithCompressor() method after adding a serializer to the EasyCachingOptions, not before."));
    }

    [Test]
    public void Named_Compressor_NoSerializer_WithCompressor_Should_ThrowException()
    {
        var services = new ServiceCollection();

        services.AddGZipCompressor("gzip");

        void action1() => services.AddEasyCaching(options =>
        {
            options
                .UseInMemory()
                .WithCompressor();
        });

        void action2() => services.AddEasyCaching(options =>
        {
            options.UseInMemory()
                .WithCompressor()
                .WithMessagePack();
        });

        Assert.That(action1, Throws.TypeOf<EasyCachingNotFoundException>().And.Message.EqualTo("Can not find any EasyCachingSerializer that is not assigned to a Compressor. Make sure to call WithCompressor() method after adding a serializer to the EasyCachingOptions, not before."));
        Assert.That(action2, Throws.TypeOf<EasyCachingNotFoundException>().And.Message.EqualTo("Can not find any EasyCachingSerializer that is not assigned to a Compressor. Make sure to call WithCompressor() method after adding a serializer to the EasyCachingOptions, not before."));
    }

    private static void CheckAssertions<TSerializer, TCompressor>(DefaultDiskCachingProvider cachingProvider, string serializerName, string compressorName)
        where TSerializer : IEasyCachingSerializer
        where TCompressor : ICompressor
    {
        var _serializer = cachingProvider.Get_serializer() as EasyCachingSerializerDecorator;
        Assert.That(_serializer, Is.InstanceOf<EasyCachingSerializerDecorator>());

        var _compressor = _serializer.Get_compressor();
        var _easyCachingSerializer = _serializer.Get_easyCachingSerializer();

        Assert.That(_easyCachingSerializer, Is.InstanceOf<TSerializer>());
        Assert.That(_easyCachingSerializer.Name, Is.SameAs(serializerName));

        Assert.That(_compressor, Is.InstanceOf<TCompressor>());
        Assert.That(_compressor.Name, Is.SameAs(compressorName));
    }

    //[SetUp]
    //public void ClearStaticDictionary()
    //{
    //    //var type = Type.GetType("EasyCompressor.EasyCompressorEasyCachingOptionsExtension, EasyCaching.Extensions.EasyCompressor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
    //    //var type = typeof(EasyCompressorEasyCachingOptionsExtension);
    //    //var dictionary = (Dictionary<string, string>)type.GetField("_dictionary", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
    //    var dictionary = ReflectionHelper.Get_dictionary(new());
    //    dictionary.Clear();
    //    dictionary.Add("binary", null);
    //}
}

internal static class Ext
{
    internal static EasyCachingOptions UseDisk(this EasyCachingOptions options, string serializerName, string diskName = "DefaultDisk")
    {
        return options
            .UseDisk(option =>
            {
                option.DBConfig.BasePath = "/";
                option.SerializerName = serializerName;
            }, diskName);
    }
}

internal static class ReflectionHelper
{
    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_serializer")]
    internal extern static ref IEasyCachingSerializer Get_serializer(this DefaultDiskCachingProvider @this);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_easyCachingSerializer")]
    internal extern static ref IEasyCachingSerializer Get_easyCachingSerializer(this EasyCachingSerializerDecorator @this);

    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_compressor")]
    internal extern static ref ICompressor Get_compressor(this EasyCachingSerializerDecorator @this);

    internal static object GetFieldValue(this object obj, string name)
    {
        // Set the flags so that private and public fields from instances will be found
        const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        var field = obj.GetType().GetField(name, bindingFlags);
        return field?.GetValue(obj);
    }

    internal static T GetFieldValue<T>(this object obj, string name)
    {
        // Set the flags so that private and public fields from instances will be found
        const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        var field = obj.GetType().GetField(name, bindingFlags);
        return (T)field?.GetValue(obj);
    }
}