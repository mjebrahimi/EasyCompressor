﻿using System.IO;
using System.Threading;
using System.Threading.Tasks;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S3236")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S4136:Method overloads should be grouped together")]

namespace EasyCompressor;

/// <summary>
/// Base compressor
/// </summary>
public abstract class BaseCompressor : ICompressor
{
    /// <inheritdoc/>
    public string Name { get; protected set; }

    /// <inheritdoc/>
    public abstract CompressionMethod Method { get; }

    /// <summary>
    /// BaseCompress
    /// </summary>
    /// <param name="bytes">The original bytes.</param>
    /// <returns>Returns compressed bytes</returns>
    protected abstract byte[] BaseCompress(byte[] bytes);

    /// <summary>
    /// BaseDecompress
    /// </summary>
    /// <param name="compressedBytes">The compressed bytes.</param>
    /// <returns>Returns uncompressed bytes</returns>
    protected abstract byte[] BaseDecompress(byte[] compressedBytes);

    /// <summary>
    /// BaseCompress
    /// </summary>
    /// <param name="inputStream">The input stream.</param>
    /// <param name="outputStream">The output stream.</param>
    protected abstract void BaseCompress(Stream inputStream, Stream outputStream);

    /// <summary>
    /// BaseDecompress
    /// </summary>
    /// <param name="inputStream">Input stream</param>
    /// <param name="outputStream">Output stream</param>
    protected abstract void BaseDecompress(Stream inputStream, Stream outputStream);

    /// <summary>
    /// BaseCompressAsync
    /// </summary>
    /// <param name="inputStream">Input stream</param>
    /// <param name="outputStream">Output stream</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task</returns>
    protected abstract Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default);

    /// <summary>
    /// BaseDecompressAsync
    /// </summary>
    /// <param name="inputStream">Input stream</param>
    /// <param name="outputStream">Output stream</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task</returns>
    protected abstract Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default);

    /// <inheritdoc/>
    public byte[] Compress(byte[] bytes)
    {
        Guard.ThrowIfNullOrEmpty(bytes, nameof(bytes));

        return BaseCompress(bytes);
    }

    /// <inheritdoc/>
    public byte[] Decompress(byte[] compressedBytes)
    {
        Guard.ThrowIfNullOrEmpty(compressedBytes, nameof(compressedBytes));

        return BaseDecompress(compressedBytes);
    }

    /// <inheritdoc/>
    public void Compress(Stream inputStream, Stream outputStream)
    {
        Guard.ThrowIfNull(inputStream, nameof(inputStream));
        Guard.ThrowIfNull(outputStream, nameof(outputStream));

        BaseCompress(inputStream, outputStream);
    }

    /// <inheritdoc/>
    public void Decompress(Stream inputStream, Stream outputStream)
    {
        Guard.ThrowIfNull(inputStream, nameof(inputStream));
        Guard.ThrowIfNull(outputStream, nameof(outputStream));

        BaseDecompress(inputStream, outputStream);
    }

    /// <inheritdoc/>
    public Task CompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        Guard.ThrowIfNull(inputStream, nameof(inputStream));
        Guard.ThrowIfNull(outputStream, nameof(outputStream));

        return BaseCompressAsync(inputStream, outputStream, cancellationToken);
    }

    /// <inheritdoc/>
    public Task DecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        Guard.ThrowIfNull(inputStream, nameof(inputStream));
        Guard.ThrowIfNull(outputStream, nameof(outputStream));

        return BaseDecompressAsync(inputStream, outputStream, cancellationToken);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Name ?? GetType().Name;
    }
}
