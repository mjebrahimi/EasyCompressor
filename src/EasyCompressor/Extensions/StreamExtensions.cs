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

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
        /*var bytesRead = */
        stream.Read(bytes.AsSpan());
#else
        /*var bytesRead = */stream.Read(bytes, 0, bytes.Length);
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
            using var output = new MemoryStream();
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
            await stream.CopyToAsync(output, cancellationToken).ConfigureAwait(false);
#else
            await stream.CopyToAsync(output, 81920, cancellationToken).ConfigureAwait(false); // DefaultBufferSize: 81920
#endif
            return output.GetTrimmedBuffer();
        }

#if NET5_0_OR_GREATER
        var bytes = GC.AllocateUninitializedArray<byte>((int)(stream.Length - stream.Position));
#else
        var bytes = new byte[(int)(stream.Length - stream.Position)];
#endif

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
        /*var bytesRead = */
        await stream.ReadAsync(bytes.AsMemory(), cancellationToken);
#else
        /*var bytesRead = */await stream.ReadAsync(bytes, 0, bytes.Length, cancellationToken);
#endif
        //if (bytesRead != bytes.Length)
        //    Array.Resize(ref bytes, bytesRead);
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


#region Functionality Tests
////====================================== Bellow than internal buffer size ======================================
//{
//    var arr = Enumerable.Range(1, 6).Select(p => (byte)p).ToArray();
//    using var stream = new MemoryStream();
//    stream.WriteAllBytes(arr);
//    stream.Position = 2;
//    var bytes = stream.ReadAllBytes_UsingBinaryReader();
//}
//{
//    var arr = Enumerable.Range(1, 6).Select(p => (byte)p).ToArray();
//    using var stream = new MemoryStream();
//    stream.WriteAllBytes(arr);
//    stream.Position = 2;
//    var bytes = stream.ReadAllBytes_UsingCopyToMemoryStream();
//}
//{
//    var arr = Enumerable.Range(1, 6).Select(p => (byte)p).ToArray();
//    using var stream = new MemoryStream();
//    stream.WriteAllBytes(arr);
//    stream.Position = 2;
//    var bytes = stream.ReadAllBytes();
//}
////=================================== With specified range of array =========================================
//{
//    var arr = Enumerable.Range(1, 100).Select(p => (byte)p).ToArray();
//    using var stream = new MemoryStream(arr, 20, 30);
//    stream.Position = 15;
//    var bytes = stream.ReadAllBytes_UsingBinaryReader();
//}
//{
//    var arr = Enumerable.Range(1, 100).Select(p => (byte)p).ToArray();
//    using var stream = new MemoryStream(arr, 20, 30);
//    stream.Position = 15;
//    var bytes = stream.ReadAllBytes_UsingCopyToMemoryStream();
//}
//{
//    var arr = Enumerable.Range(1, 100).Select(p => (byte)p).ToArray();
//    using var stream = new MemoryStream(arr, 20, 30);
//    stream.Position = 15;
//    var bytes = stream.ReadAllBytes();
//}
#endregion