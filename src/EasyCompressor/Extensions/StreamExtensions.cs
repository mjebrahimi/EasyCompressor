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
    /// Gets the trimmed buffer of the specified <see cref="MemoryStream"/> (regardless of the current <see cref="MemoryStream.Position"/>).
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <remarks>
    /// Use it only when using a local instance of the <see cref="MemoryStream"/> and you are the owner/creator of it, NOT when it came from somewhere else.
    /// Otherwise it can cause problems
    /// </remarks>
    /// <returns></returns>
    public static byte[] GetTrimmedBuffer(this MemoryStream stream)
    {
        //Not inspired, but worth checking out
        //https://github.com/salarcode/BinaryBuffers

        var length = (int)stream.Length;
        var bytes = stream.GetBuffer();
        if (length < bytes.Length)
            Array.Resize(ref bytes, length);
        return bytes;
    }

    #region ReadAllBytes
    /// <summary>
    /// Reads all [Remained] bytes from current <see cref="Stream.Position"/> to End.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <returns></returns>
    public static byte[] ReadAllBytes(this Stream stream)
    {
        if (stream.CanSeek is false)
        {
            using var output = new MemoryStream();
            stream.CopyTo(output);
            return output.GetTrimmedBuffer();
        }

#if NET5_0_OR_GREATER
        var bytes = GC.AllocateUninitializedArray<byte>((int)(stream.Length - stream.Position));
#else
        var bytes = new byte[(int)(stream.Length - stream.Position)];
#endif

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        /*var bytesRead = */
        stream.Read((Span<byte>)bytes);
#else
        /*var bytesRead = */
        stream.Read(bytes, 0, bytes.Length);
#endif
        //if (bytesRead != bytes.Length)
        //    Array.Resize(ref bytes, bytesRead);
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
        if (stream.CanSeek is false)
        {
#pragma warning disable RCS1261 // Resource can be disposed asynchronously
            using var output = new MemoryStream();
#pragma warning restore RCS1261 // Resource can be disposed asynchronously
            await stream.CopyToAsync(output, cancellationToken).ConfigureAwait(false);
            return output.GetTrimmedBuffer();
        }

#if NET5_0_OR_GREATER
        var bytes = GC.AllocateUninitializedArray<byte>((int)(stream.Length - stream.Position));
#else
        var bytes = new byte[(int)(stream.Length - stream.Position)];
#endif

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        /*var bytesRead = */
        await stream.ReadAsync((Memory<byte>)bytes, cancellationToken);
#else
        /*var bytesRead = */
        await stream.ReadAsync(bytes, 0, bytes.Length, cancellationToken);
#endif
        //if (bytesRead != bytes.Length)
        //    Array.Resize(ref bytes, bytesRead);
        return bytes;
    }
    #endregion

    #region WriteAllBytes
    /// <summary>
    /// Writes all bytes.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="bytes">The bytes.</param>
    public static void WriteAllBytes(this Stream stream, byte[] bytes)
    {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        stream.Write((ReadOnlySpan<byte>)bytes);
#else
        stream.Write(bytes, 0, bytes.Length);
#endif
    }

    /// <summary>
    /// Writes all bytes asynchronously.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="bytes">The bytes.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
#pragma warning disable AsyncFixer01 // Unnecessary async/await usage
    public static async Task WriteAllBytesAsync(this Stream stream, byte[] bytes, CancellationToken cancellationToken = default)
    {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        await stream.WriteAsync((ReadOnlyMemory<byte>)bytes, cancellationToken);
#else
        await stream.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
#endif
    }
#pragma warning restore AsyncFixer01 // Unnecessary async/await usage
    #endregion

    #region CopyToAsync
#if !(NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER)
    /// <summary>
    /// Asynchronously reads the bytes from the current stream and writes them to another stream, using a specified buffer size and cancellation token.
    /// </summary>
    /// <param name="source">The source stream</param>
    /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.</param>
    /// <returns>A task that represents the asynchronous copy operation.</returns>
    public static Task CopyToAsync(this Stream source, Stream destination, CancellationToken cancellationToken = default)
    {
        return source.CopyToAsync(destination, GetCopyBufferSize(source), cancellationToken);
    }

    private static int GetCopyBufferSize(Stream stream)
    {
        // This value was originally picked to be the largest multiple of 4096 that is still smaller than the large object heap threshold (85K).
        // The CopyTo{Async} buffer is short-lived and is likely to be collected at Gen0, and it offers a significant improvement in Copy
        // performance.  Since then, the base implementations of CopyTo{Async} have been updated to use ArrayPool, which will end up rounding
        // this size up to the next power of two (131,072), which will by default be on the large object heap.  However, most of the time
        // the buffer should be pooled, the LOH threshold is now configurable and thus may be different than 85K, and there are measurable
        // benefits to using the larger buffer size.  So, for now, this value remains.
        const int DefaultCopyBufferSize = 81920;

        int bufferSize = DefaultCopyBufferSize;

        if (stream.CanSeek)
        {
            long length = stream.Length;
            long position = stream.Position;
            if (length <= position) // Handles negative overflows
            {
                // There are no bytes left in the stream to copy.
                // However, because CopyTo{Async} is virtual, we need to
                // ensure that any override is still invoked to provide its
                // own validation, so we use the smallest legal buffer size here.
                bufferSize = 1;
            }
            else
            {
                long remaining = length - position;
                if (remaining > 0)
                {
                    // In the case of a positive overflow, stick to the default size
                    bufferSize = (int)Math.Min(bufferSize, remaining);
                }
            }
        }

        return bufferSize;
    }
#endif
    #endregion
}