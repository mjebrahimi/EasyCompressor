using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SevenZip.Compression.LZMA;

namespace EasyCompressor
{
    /// <summary>
    /// LZMA compressor
    /// </summary>
    public class LZMACompressor : BaseCompressor
    {
        #region Stream https://gist.github.com/ststeiger/cb9750664952f775a341
        //private static readonly CoderPropID[] propIDs =
        //{
        //    CoderPropID.DictionarySize,
        //    CoderPropID.PosStateBits,
        //    CoderPropID.LitContextBits,
        //    CoderPropID.LitPosBits,
        //    CoderPropID.Algorithm,
        //    CoderPropID.NumFastBytes,
        //    CoderPropID.MatchFinder,
        //    CoderPropID.EndMarker
        //};

        //// these are the default properties, keeping it simple for now:
        //private static readonly object[] properties =
        //{
        //    1 << 23,
        //    2,
        //    3,
        //    0,
        //    2,
        //    128,
        //    "bt4",
        //    false
        //};

        //public override byte[] Compress(byte[] inputBytes)
        //{
        //    byte[] retVal = null;
        //    SevenZip.Compression.LZMA.Encoder encoder = new SevenZip.Compression.LZMA.Encoder();
        //    encoder.SetCoderProperties(propIDs, properties);

        //    using (System.IO.MemoryStream strmInStream = new System.IO.MemoryStream(inputBytes))
        //    {
        //        using (System.IO.MemoryStream strmOutStream = new System.IO.MemoryStream())
        //        {
        //            encoder.WriteCoderProperties(strmOutStream);
        //            long fileSize = strmInStream.Length;
        //            for (int i = 0; i < 8; i++)
        //                strmOutStream.WriteByte((byte)(fileSize >> (8 * i)));

        //            encoder.Code(strmInStream, strmOutStream, -1, -1, null);
        //            retVal = strmOutStream.ToArray();
        //        } // End Using outStream

        //    } // End Using inStream 

        //    return retVal;
        //} // End Function Compress

        //public override byte[] Decompress(byte[] inputBytes)
        //{
        //    byte[] retVal = null;

        //    SevenZip.Compression.LZMA.Decoder decoder = new SevenZip.Compression.LZMA.Decoder();

        //    using (System.IO.MemoryStream strmInStream = new System.IO.MemoryStream(inputBytes))
        //    {
        //        strmInStream.Seek(0, 0);

        //        using (System.IO.MemoryStream strmOutStream = new System.IO.MemoryStream())
        //        {
        //            byte[] properties2 = new byte[5];
        //            if (strmInStream.Read(properties2, 0, 5) != 5)
        //                throw (new System.Exception("input .lzma is too short"));

        //            long outSize = 0;
        //            for (int i = 0; i < 8; i++)
        //            {
        //                int v = strmInStream.ReadByte();
        //                if (v < 0)
        //                    throw (new System.Exception("Can't Read 1"));
        //                outSize |= ((long)(byte)v) << (8 * i);
        //            } // Next i 

        //            decoder.SetDecoderProperties(properties2);

        //            long compressedSize = strmInStream.Length - strmInStream.Position;
        //            decoder.Code(strmInStream, strmOutStream, compressedSize, outSize, null);

        //            retVal = strmOutStream.ToArray();
        //        } // End Using newOutStream 

        //    } // End Using newInStream 

        //    return retVal;
        //} // End Function Decompress 
        #endregion

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="name">Name</param>
        public LZMACompressor(string name = null)
        {
            Name = name;
        }

        /// <inheritdoc/>
        protected override byte[] BaseCompress(byte[] bytes)
        {
            using (MemoryStream inputStream = new MemoryStream(bytes))
            using (MemoryStream outputStream = new MemoryStream())
            {
                var encoder = new Encoder();

                // Write the encoder properties
                encoder.WriteCoderProperties(outputStream);

                // Write the decompressed file size.
                outputStream.Write(BitConverter.GetBytes(inputStream.Length), 0, 8);

                // Encode
                encoder.Code(inputStream, outputStream, inputStream.Length, -1, null);
                outputStream.Flush();

                return outputStream.ToArray();
            }
        }

        /// <inheritdoc/>
        protected override byte[] BaseDecompress(byte[] compressedBytes)
        {
            using (MemoryStream inputStream = new MemoryStream(compressedBytes))
            using (MemoryStream outputStream = new MemoryStream())
            {
                var decoder = new Decoder();

                // Read the decoder properties
                var properties = new byte[5];
                inputStream.Read(properties, 0, 5);
                decoder.SetDecoderProperties(properties);

                // Read in the decompress file size.
                var fileLengthBytes = new byte[8];
                inputStream.Read(fileLengthBytes, 0, 8);
                var fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

                // Decode
                decoder.Code(inputStream, outputStream, inputStream.Length, fileLength, null);
                outputStream.Flush();

                return outputStream.ToArray();
            }
        }

        /// <inheritdoc/>
        protected override void BaseCompress(Stream inputStream, Stream outputStream)
        {
            using (MemoryStream inputMemory = new MemoryStream())
            {
                inputStream.CopyTo(inputMemory);
                inputStream.Flush();
                inputMemory.Flush();
                inputMemory.Position = 0;

                var encoder = new Encoder();

                // Write the encoder properties
                encoder.WriteCoderProperties(outputStream);

                // Write the decompressed file size.
                outputStream.Write(BitConverter.GetBytes(inputMemory.Length), 0, 8);

                // Encode
                encoder.Code(inputMemory, outputStream, inputMemory.Length, -1, null);
                outputStream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override void BaseDecompress(Stream inputStream, Stream outputStream)
        {
            using (MemoryStream inputMemory = new MemoryStream())
            {
                inputStream.CopyTo(inputMemory);
                inputStream.Flush();
                inputMemory.Flush();
                inputMemory.Position = 0;

                var decoder = new Decoder();

                // Read the decoder properties
                var properties = new byte[5];
                inputMemory.Read(properties, 0, 5);
                decoder.SetDecoderProperties(properties);

                // Read in the decompress file size.
                var fileLengthBytes = new byte[8];
                inputMemory.Read(fileLengthBytes, 0, 8);
                var fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

                // Decode
                decoder.Code(inputMemory, outputStream, inputMemory.Length, fileLength, null);
                outputStream.Flush();
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseCompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (MemoryStream inputMemory = new MemoryStream())
            {
                await inputStream.CopyToAsync(inputMemory, DefaultBufferSize, cancellationToken).ConfigureAwait(false);
                await inputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
                await inputMemory.FlushAsync(cancellationToken).ConfigureAwait(false);
                inputMemory.Position = 0;

                var encoder = new Encoder();

                // Write the encoder properties
                encoder.WriteCoderProperties(outputStream);

                // Write the decompressed file size.
                await outputStream.WriteAsync(BitConverter.GetBytes(inputMemory.Length), 0, 8, cancellationToken).ConfigureAwait(false);

                // Encode
                encoder.Code(inputMemory, outputStream, inputMemory.Length, -1, null);
                await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        /// <inheritdoc/>
        protected override async Task BaseDecompressAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken = default)
        {
            using (MemoryStream inputMemory = new MemoryStream())
            {
                await inputStream.CopyToAsync(inputMemory, DefaultBufferSize, cancellationToken).ConfigureAwait(false);
                await inputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
                await inputMemory.FlushAsync(cancellationToken).ConfigureAwait(false);
                inputMemory.Position = 0;

                var decoder = new Decoder();

                // Read the decoder properties
                var properties = new byte[5];
                await inputMemory.ReadAsync(properties, 0, 5, cancellationToken).ConfigureAwait(false);
                decoder.SetDecoderProperties(properties);

                // Read in the decompress file size.
                var fileLengthBytes = new byte[8];
                await inputMemory.ReadAsync(fileLengthBytes, 0, 8, cancellationToken).ConfigureAwait(false);
                var fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

                // Decode
                decoder.Code(inputMemory, outputStream, inputMemory.Length, fileLength, null);
                await outputStream.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
