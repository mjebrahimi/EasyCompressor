// Ignore Spelling: Lz Protobuf

using MessagePack;
using Newtonsoft.Json;
using System.IO;

namespace EasyCompressor.Benchmarks.Models;

public static class Serializer
{
    public static byte[] SerializeMessagePack<T>(T value)
    {
        return MessagePackSerializer.Serialize(value);
    }

    public static T DeserializeMessagePack<T>(byte[] bytes)
    {
        return MessagePackSerializer.Deserialize<T>(bytes);
    }

    public static byte[] SerializeMessagePackLz4<T>(T value)
    {
        var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);
        return MessagePackSerializer.Serialize(value, lz4Options);
    }

    public static T DeserializeMessagePackLz4<T>(byte[] bytes)
    {
        var lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);
        return MessagePackSerializer.Deserialize<T>(bytes, lz4Options);
    }

    public static byte[] SerializeProtobuf<T>(T value)
    {
        using var stream = new MemoryStream();
        ProtoBuf.Serializer.Serialize<T>(stream, value);
        return stream.GetTrimmedBuffer();
    }

    public static T DeserializeProtobuf<T>(byte[] bytes)
    {
        using var stream = new MemoryStream(bytes);
        return ProtoBuf.Serializer.Deserialize<T>(stream);
    }

    public static T FromJson<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json, Converter.Settings);
    }

    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new()
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None
        };
    }
}