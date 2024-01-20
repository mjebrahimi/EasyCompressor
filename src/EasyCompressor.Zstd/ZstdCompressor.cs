// Ignore Spelling: Zstd

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ZstdNet;

namespace EasyCompressor;

/// <summary>
/// Zstd compressor
/// </summary>
public class ZstdCompressor : BaseCompressor
{
    #region Load libzstd v1.4.4 DLL (No longer needed according to ZstdNet v1.4.5 update)
    //static ZstdCompressor()
    //{
    //    //Workaround to fix "System.DllNotFoundException: Unable to load DLL 'libzstd' or one of its dependencies: The specified module could not be found."
    //
    //    if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    //        return;
    //
    //    var bit = Environment.Is64BitProcess ? "x64" : "x86";
    //    var folder = Path.Combine(Path.GetTempPath(), "zstd-v1.4.4", bit);
    //    Directory.CreateDirectory(folder);
    //
    //    var fileName = Path.Combine(folder, "libzstd.dll");
    //    if (!File.Exists(fileName))
    //    {
    //        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"libzstd.{bit}.dll"))
    //        using (var file = File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
    //            stream.CopyTo(file);
    //    }
    //
    //    var type = typeof(Compressor).Assembly.GetType("ZstdNet.ExternMethods");
    //    var method = type.GetMethod("SetDllDirectory", BindingFlags.NonPublic | BindingFlags.Static);
    //    method.Invoke(null, new[] { folder });
    //}
    #endregion

    /// <summary>
    /// Level
    /// </summary>
    protected readonly int Level;

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.Zstd;

    /// <summary>
    /// Initializes a new instance
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="level">Level</param>
    public ZstdCompressor(string name = null, int level = 3)
    {
        Name = name;
        Level = level;
    }

    /// <inheritdoc/>
    protected override byte[] BaseCompress(byte[] bytes)
    {
        byte[] compressedBytes;
        using (var options = new CompressionOptions(Level))
        using (var compressor = new Compressor(options))
        {
            compressedBytes = compressor.Wrap((ReadOnlySpan<byte>)bytes);
        }
        return compressedBytes;
    }

    /// <inheritdoc/>
    protected override byte[] BaseDecompress(byte[] compressedBytes)
    {
        byte[] decompressedBytes;
        using (var decompressor = new Decompressor())
        {
            decompressedBytes = decompressor.Unwrap((ReadOnlySpan<byte>)compressedBytes);
        }
        return decompressedBytes;
    }

    /// <inheritdoc/>
    protected override void BaseCompress(Stream inputStream, Stream outputStream)
    {
        var bytes = inputStream.ReadAllBytes();
        var compressedBytes = BaseCompress(bytes);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
        outputStream.WriteAllBytes((ReadOnlySpan<byte>)compressedBytes);
#else
        outputStream.WriteAllBytes(compressedBytes);
#endif
        outputStream.Flush();
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        var compressedBytes = inputStream.ReadAllBytes();
        var bytes = BaseDecompress(compressedBytes);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
        outputStream.WriteAllBytes((ReadOnlySpan<byte>)bytes);
#else
        outputStream.WriteAllBytes(bytes);
#endif
        outputStream.Flush();
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        var bytes = await inputStream.ReadAllBytesAsync(cancellationToken).ConfigureAwait(false);
        var compressedBytes = BaseCompress(bytes);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
        await outputStream.WriteAllBytesAsync((ReadOnlyMemory<byte>)compressedBytes, cancellationToken).ConfigureAwait(false);
#else
        await outputStream.WriteAllBytesAsync(compressedBytes, cancellationToken).ConfigureAwait(false);
#endif
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        var compressedBytes = await inputStream.ReadAllBytesAsync(cancellationToken).ConfigureAwait(false);
        var bytes = BaseDecompress(compressedBytes);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
        await outputStream.WriteAllBytesAsync((ReadOnlyMemory<byte>)bytes, cancellationToken).ConfigureAwait(false);
#else
        await outputStream.WriteAllBytesAsync(bytes, cancellationToken).ConfigureAwait(false);
#endif
        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
    }
}
