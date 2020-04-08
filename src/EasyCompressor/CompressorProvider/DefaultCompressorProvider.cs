using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyCompressor
{
    /// <summary>
    /// Default compressor provider
    /// </summary>
    public class DefaultCompressorProvider : ICompressorProvider
    {
        private readonly IEnumerable<ICompressor> _compressors;

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        /// <param name="compressors">compressors</param>
        public DefaultCompressorProvider(IEnumerable<ICompressor> compressors)
        {
            _compressors = compressors.NotNull(nameof(compressors));
        }

        /// <inheritdoc/>
        public ICompressor GetCompressor(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var count = _compressors.Count(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (count > 1)
                throw new ArgumentException($"There is more than one compressor with this name : '{name}'", name);

            var compressor = _compressors.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (compressor == null)
                throw new ArgumentException($"Can not find a match compressor with name : '{name}'", name);

            return compressor;
        }
    }
}
