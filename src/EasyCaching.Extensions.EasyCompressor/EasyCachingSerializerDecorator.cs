﻿using EasyCaching.Core.Serialization;
using System;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S3236")]

namespace EasyCompressor;

/// <summary>
/// EasyCaching serializer decorator
/// </summary>
public class EasyCachingSerializerDecorator : IEasyCachingSerializer
{
    private readonly ICompressor _compressor;
    private readonly IEasyCachingSerializer _easyCachingSerializer;

    /// <summary>
    /// Initializes a new instance of the <see cref="EasyCachingSerializerDecorator"/> class.
    /// </summary>
    /// <param name="compressor">The compressor.</param>
    /// <param name="easyCachingSerializer">The easy caching serializer.</param>
    public EasyCachingSerializerDecorator(ICompressor compressor, IEasyCachingSerializer easyCachingSerializer)
    {
        Guard.ThrowIfNull(compressor, nameof(compressor));
        Guard.ThrowIfNull(easyCachingSerializer, nameof(easyCachingSerializer));

        _compressor = compressor;
        _easyCachingSerializer = easyCachingSerializer;
    }

    /// <inheritdoc/>
    public string Name => _easyCachingSerializer.Name;

    /// <inheritdoc/>
    public T Deserialize<T>(byte[] bytes)
    {
        var decompressedBytes = _compressor.Decompress(bytes);

        return _easyCachingSerializer.Deserialize<T>(decompressedBytes);
    }

    /// <inheritdoc/>
    public object Deserialize(byte[] bytes, Type type)
    {
        var decompressedBytes = _compressor.Decompress(bytes);

        return _easyCachingSerializer.Deserialize(decompressedBytes, type);
    }

    /// <inheritdoc/>
    public object DeserializeObject(ArraySegment<byte> value)
    {
        var decompressedBytes = _compressor.Decompress(value.Array);

        var arraySegment = new ArraySegment<byte>(decompressedBytes);

        return _easyCachingSerializer.DeserializeObject(arraySegment);
    }

    /// <inheritdoc/>
    public byte[] Serialize<T>(T value)
    {
        var bytes = _easyCachingSerializer.Serialize(value);

        return _compressor.Compress(bytes);
    }

    /// <inheritdoc/>
    public ArraySegment<byte> SerializeObject(object obj)
    {
        var arraySegment = _easyCachingSerializer.SerializeObject(obj);

        var compressedBytes = _compressor.Compress(arraySegment.Array);

        return new ArraySegment<byte>(compressedBytes);
    }
}
