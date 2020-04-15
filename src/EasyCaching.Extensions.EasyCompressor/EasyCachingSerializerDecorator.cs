using EasyCaching.Core.Serialization;
using EasyCompressor.Internal;
using System;

namespace EasyCompressor
{
    public class EasyCachingSerializerDecorator : IEasyCachingSerializer
    {
        private readonly ICompressor _compressor;
        private readonly IEasyCachingSerializer _easyCachingSerializer;

        public EasyCachingSerializerDecorator(ICompressor compressor, IEasyCachingSerializer easyCachingSerializer)
        {
            _compressor = compressor.NotNull(nameof(compressor));
            _easyCachingSerializer = easyCachingSerializer.NotNull(nameof(easyCachingSerializer));
        }

        public string Name => _easyCachingSerializer.Name;

        public T Deserialize<T>(byte[] bytes)
        {
            var decompressedBytes = _compressor.Decompress(bytes);

            return _easyCachingSerializer.Deserialize<T>(decompressedBytes);
        }

        public object Deserialize(byte[] bytes, Type type)
        {
            var decompressedBytes = _compressor.Decompress(bytes);

            return _easyCachingSerializer.Deserialize(decompressedBytes, type);
        }

        public object DeserializeObject(ArraySegment<byte> value)
        {
            var decompressedBytes = _compressor.Decompress(value.Array);

            var arraySegment = new ArraySegment<byte>(decompressedBytes);

            return _easyCachingSerializer.DeserializeObject(arraySegment);
        }

        public byte[] Serialize<T>(T value)
        {
            var bytes = _easyCachingSerializer.Serialize(value);

            return _compressor.Compress(bytes);
        }

        public ArraySegment<byte> SerializeObject(object obj)
        {
            var arraySegment = _easyCachingSerializer.SerializeObject(obj);

            var compressedBytes = _compressor.Compress(arraySegment.Array);

            return new ArraySegment<byte>(compressedBytes);
        }
    }
}
