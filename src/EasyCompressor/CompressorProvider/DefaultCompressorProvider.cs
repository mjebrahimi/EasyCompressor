using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyCompressor;

/// <summary>
/// Default compressor provider
/// </summary>
/// <seealso cref="ICompressorProvider" />
public class DefaultCompressorProvider : ICompressorProvider
{
    private readonly List<ICompressor> _compressors;

    /// <summary>
    /// Initializes a new instance of <see cref="DefaultCompressorProvider"/>
    /// </summary>
    /// <param name="compressors">compressors</param>
    public DefaultCompressorProvider(IEnumerable<ICompressor> compressors)
    {
        Guard.ThrowIfNullOrEmpty(compressors, nameof(compressors));
        _compressors = compressors.ToList();
    }

    /// <inheritdoc/>
    public ICompressor GetCompressor(string name)
    {
        var foundCompressors = _compressors.FindAll(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
        return foundCompressors.Count switch
        {
            //0 when name is not null => throw new ArgumentException($"Can not find a matched compressor with name '{name ?? "null"}'.", nameof(name)),
            //0 when name is null && _compressors.Count == 1 => _compressors[0], //return the only one if name is null. //gets the only one if <paramref name="name"/> is <see langword="null"/>
            0 => throw new ArgumentException($"Can not find a matched compressor with name '{name ?? "null"}'.", nameof(name)),
            1 => foundCompressors[0],
            > 1 => throw new ArgumentException($"There is more than one compressor with this name '{name ?? "null"}'.", nameof(name)),
            _ => throw new NotImplementedException(), //Having default case is a micro-optimization
        };
    }
}
