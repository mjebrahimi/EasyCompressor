using System;
using System.IO;
using SevenZip;
using SevenZip.Compression.LZMA;
namespace EasyCompressor
{
    public class SevenZipCompressor
    {
        private const int dictionary = 1 << 23;
        private const int posStateBits = 2;
        private const int litContextBits = 3;
        private const int litPosBits = 0;
        private const int algorithm = 2;
        private const int numFastBytes = 128;

        private const string mf = "bt4";
        private const bool eos = true;
        private const bool stdInMode = false;

        private static readonly CoderPropID[] propIDs =  {
            CoderPropID.DictionarySize,
            CoderPropID.PosStateBits,
            CoderPropID.LitContextBits,
            CoderPropID.LitPosBits,
            CoderPropID.Algorithm,
            CoderPropID.NumFastBytes,
            CoderPropID.MatchFinder,
            CoderPropID.EndMarker
        };

        private static readonly object[] properties = {
            dictionary,
            posStateBits,
            litContextBits,
            litPosBits,
            algorithm,
            numFastBytes,
            mf,
            eos
        };

        public byte[] Compress(byte[] bytes)
        {
            

            using (var inputStream = new MemoryStream(bytes))
            using (var outputStream = new MemoryStream())
            {
                var encoder = new Encoder();

                encoder.SetCoderProperties(propIDs, properties);
                encoder.WriteCoderProperties(outputStream);
                long fileSize = -1;
                for (int i = 0; i < 8; i++)
                    outputStream.WriteByte((byte)(fileSize >> (8 * i)));

                encoder.Code(inputStream, outputStream, -1, -1, null);
                outputStream.Flush();
                return outputStream.ToArray();
            }
        }

        public byte[] Decompress(byte[] compressedBytes)
        {
            using (var inputStream = new MemoryStream(compressedBytes))
            using (var outputStream = new MemoryStream())
            {
                Decoder decoder = new Decoder();

                byte[] properties = new byte[5];
                if (inputStream.Read(properties, 0, 5) != 5)
                    throw new Exception();
                decoder.SetDecoderProperties(properties);

                long outSize = 0;
                for (int i = 0; i < 8; i++)
                {
                    int v = inputStream.ReadByte();
                    outSize |= ((long)(byte)v) << (8 * i);
                }
                long compressedSize = inputStream.Length - inputStream.Position;

                decoder.Code(inputStream, outputStream, compressedSize, outSize, null);
                outputStream.Flush();
                return outputStream.ToArray();
            }
        }
    }
}
