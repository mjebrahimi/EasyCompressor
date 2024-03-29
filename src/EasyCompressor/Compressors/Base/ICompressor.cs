﻿using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor;

/// <summary>
/// ICompressor
/// </summary>
public interface ICompressor
{
    /// <summary>
    /// Compressor name
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Compression method
    /// </summary>
    CompressionMethod Method { get; }

    /// <summary>
    /// Compress bytes
    /// </summary>
    /// <param name="bytes">Bytes</param>
    /// <returns>Returns compressed bytes</returns>
    byte[] Compress(byte[] bytes);

    /// <summary>
    /// Decompress bytes
    /// </summary>
    /// <param name="compressedBytes">Compressed bytes</param>
    /// <returns>Returns uncompressed bytes</returns>
    byte[] Decompress(byte[] compressedBytes);

    /// <summary>
    /// Compress input stream into output stream
    /// </summary>
    /// <param name="inputStream">Input stream</param>
    /// <param name="outputStream">Output stream</param>
    void Compress(Stream inputStream, Stream outputStream);

    /// <summary>
    /// Decompress input stream into output stream
    /// </summary>
    /// <param name="inputStream">Input stream</param>
    /// <param name="outputStream">Output stream</param>
    void Decompress(Stream inputStream, Stream outputStream);

    /// <summary>
    /// Compress input stream into output stream
    /// </summary>
    /// <param name="inputStream">Input stream</param>
    /// <param name="outputStream">Output stream</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task CompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default);

    /// <summary>
    /// Decompress input stream into output stream
    /// </summary>
    /// <param name="inputStream">Input stream</param>
    /// <param name="outputStream">Output stream</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task DecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default);
}

///// <summary>
///// IBinaryCompressor
///// </summary>
//public interface IBinaryCompressor
//{
//    /// <summary>
//    /// Compressor name
//    /// </summary>
//    string Name { get; }

//    /// <summary>
//    /// Compression method
//    /// </summary>
//    CompressionMethod Method { get; }

//    /// <summary>
//    /// Compress bytes
//    /// </summary>
//    /// <param name="bytes">Bytes</param>
//    /// <returns>Returns compressed bytes</returns>
//    byte[] Compress(byte[] bytes);

//    /// <summary>
//    /// Decompress bytes
//    /// </summary>
//    /// <param name="compressedBytes">Compressed bytes</param>
//    /// <returns>Returns uncompressed bytes</returns>
//    byte[] Decompress(byte[] compressedBytes);
//}

///// <summary>
///// IStreamCompressor
///// </summary>
//public interface IStreamCompressor
//{
//    /// <summary>
//    /// Compressor name
//    /// </summary>
//    string Name { get; }

//    /// <summary>
//    /// Compression method
//    /// </summary>
//    CompressionMethod Method { get; }

//    /// <summary>
//    /// Compress input stream to output stream
//    /// </summary>
//    /// <param name="inputStream">Input stream</param>
//    /// <param name="outputStream">Output stream</param>
//    void Compress(Stream inputStream, Stream outputStream);

//    /// <summary>
//    /// Decompress input stream to output stream
//    /// </summary>
//    /// <param name="inputStream">Input stream</param>
//    /// <param name="outputStream">Output stream</param>
//    void Decompress(Stream inputStream, Stream outputStream);

//    /// <summary>
//    /// Compress input stream to output stream
//    /// </summary>
//    /// <param name="inputStream">Input stream</param>
//    /// <param name="outputStream">Output stream</param>
//    /// <param name="cancellationToken">Cancellation token</param>
//    Task CompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default);

//    /// <summary>
//    /// Decompress input stream to output stream
//    /// </summary>
//    /// <param name="inputStream">Input stream</param>
//    /// <param name="outputStream">Output stream</param>
//    /// <param name="cancellationToken">Cancellation token</param>
//    Task DecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default);
//}