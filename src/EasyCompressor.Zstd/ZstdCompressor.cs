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
    /// Compression level
    /// </summary>
    protected readonly int Level;

    /// <inheritdoc/>
    public override CompressionMethod Method => CompressionMethod.Zstd;

    /// <summary>
    /// Initializes a new instance
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="level">Compression level (Defaults to <c>3</c>)</param>
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

        outputStream.WriteAllBytes(compressedBytes);

        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override void BaseDecompress(Stream inputStream, Stream outputStream)
    {
        var compressedBytes = inputStream.ReadAllBytes();
        var bytes = BaseDecompress(compressedBytes);

        outputStream.WriteAllBytes(bytes);

        outputStream.Flush(); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        var bytes = await inputStream.ReadAllBytesAsync(cancellationToken).ConfigureAwait(false);
        var compressedBytes = BaseCompress(bytes);

        await outputStream.WriteAllBytesAsync(compressedBytes, cancellationToken).ConfigureAwait(false);

        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }

    /// <inheritdoc/>
    protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
    {
        var compressedBytes = await inputStream.ReadAllBytesAsync(cancellationToken).ConfigureAwait(false);
        var bytes = BaseDecompress(compressedBytes);

        await outputStream.WriteAllBytesAsync(bytes, cancellationToken).ConfigureAwait(false);

        await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false); //It's needed because of FileStream internal buffering
    }
}
