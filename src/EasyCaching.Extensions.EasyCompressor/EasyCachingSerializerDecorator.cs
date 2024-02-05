using EasyCaching.Core.Serialization;
using System;

namespace EasyCompressor;

/// <summary>
/// EasyCaching serializer decorator
/// </summary>
/// <remarks>
/// Initializes a new instance
/// </remarks>
/// <param name="compressor">Compressor</param>
/// <param name="easyCachingSerializer">EasyCaching serializer</param>
public class EasyCachingSerializerDecorator(ICompressor compressor, IEasyCachingSerializer easyCachingSerializer) : IEasyCachingSerializer
{
    private readonly ICompressor _compressor = compressor.NotNull(nameof(compressor));
    private readonly IEasyCachingSerializer _easyCachingSerializer = easyCachingSerializer.NotNull(nameof(easyCachingSerializer));

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
