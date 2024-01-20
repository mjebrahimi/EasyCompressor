using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EasyCompressor;

/// <summary>
/// Stream Extensions
/// </summary>
public static class StreamExtensions
{
    /// <summary>
    /// Gets the trimmed buffer of the specified <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <remarks>
    /// Use it only if you are the owner/creator of the <see cref="MemoryStream"/> instance, NOT when it came from somewhere else.
    /// Otherwise it can cause problems
    /// </remarks>
    /// <returns></returns>
    public static byte[] GetTrimmedBuffer(this MemoryStream stream)
    {
        var bytes = stream.GetBuffer();
        Array.Resize(ref bytes, (int)stream.Length);
        return bytes;
    }

    #region ReadAllBytes
    /// <summary>
    /// Reads all bytes.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns></returns>
    public static byte[] ReadAllBytes(this Stream stream)
    {
        if (stream is MemoryStream memory)
            return memory.ToArray();

#if NET5_0_OR_GREATER
        var bytes = GC.AllocateUninitializedArray<byte>((int)stream.Length);
#else
        var bytes = new byte[(int)stream.Length];
#endif

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
        stream.Read(bytes.AsSpan());
#else
        stream.Read(bytes, 0, bytes.Length);
#endif
        return bytes;
    }

    /// <summary>
    /// Reads all bytes asynchronously.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    public static async Task<byte[]> ReadAllBytesAsync(this Stream stream, CancellationToken cancellationToken = default)
    {
        if (stream is MemoryStream memory)
            return memory.ToArray();

#if NET5_0_OR_GREATER
        var bytes = GC.AllocateUninitializedArray<byte>((int)stream.Length);
#else
        var bytes = new byte[(int)stream.Length];
#endif

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
        await stream.ReadAsync(bytes.AsMemory(), cancellationToken);
#else
        await stream.ReadAsync(bytes, 0, bytes.Length, cancellationToken);
#endif
        return bytes;
    }
    #endregion

    #region WriteAllBytes
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
#pragma warning disable S4136 // Method overloads should be grouped together
    /// <summary>
    /// Writes all bytes.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="bytes">The bytes.</param>
    public static void WriteAllBytes(this Stream stream, ReadOnlySpan<byte> bytes)
    {
        if (stream is MemoryStream memory)
            memory.Write(bytes);
        else
            stream.Write(bytes);
    }

    /// <summary>
    /// Writes all bytes asynchronously.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="bytes">The bytes.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    public static ValueTask WriteAllBytesAsync(this Stream stream, ReadOnlyMemory<byte> bytes, CancellationToken cancellationToken = default)
    {
        if (stream is MemoryStream memory)
            return memory.WriteAsync(bytes, cancellationToken);
        else
            return stream.WriteAsync(bytes, cancellationToken);
    }
#pragma warning restore S4136 // Method overloads should be grouped together
#endif

    /// <summary>
    /// Writes all bytes.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="bytes">The bytes.</param>
    public static void WriteAllBytes(this Stream stream, byte[] bytes)
    {
        if (stream is MemoryStream memory)
            memory.Write(bytes, 0, bytes.Length);
        else
            stream.Write(bytes, 0, bytes.Length);
    }

    /// <summary>
    /// Writes all bytes asynchronous.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="bytes">The bytes.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    public static Task WriteAllBytesAsync(this Stream stream, byte[] bytes, CancellationToken cancellationToken = default)
    {
        if (stream is MemoryStream memory)
            return memory.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
        else
            return stream.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
    }
    #endregion
}