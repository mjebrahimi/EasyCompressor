using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("EasyCompressor.BrotliNET")]
[assembly: InternalsVisibleTo("EasyCompressor.LZ4")]
[assembly: InternalsVisibleTo("EasyCompressor.LZMA")]
[assembly: InternalsVisibleTo("EasyCompressor.Snappy")]
[assembly: InternalsVisibleTo("EasyCompressor.Snappier")]
[assembly: InternalsVisibleTo("EasyCompressor.Zstd")]
[assembly: InternalsVisibleTo("EasyCompressor.ZstdSharp")]
[assembly: InternalsVisibleTo("EasyCompressor.Benchmarks")]
[assembly: InternalsVisibleTo("EasyCompressor.Tests")]
[assembly: InternalsVisibleTo("EasyCaching.Extensions.EasyCompressor")]

namespace EasyCompressor;

/// <summary>
/// Guard and Validation
/// </summary>
internal static class Guard
{
    /// <summary>
    /// Validates that obj is not null , otherwise throws an <see cref="ArgumentNullException"/> exception.
    /// </summary>
    /// <param name="value">The object to validate as non-null.</param>
    /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
    /// <exception cref="ArgumentNullException"></exception>
    internal static void ThrowIfNull<T>(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        [System.Diagnostics.CodeAnalysis.NotNull]
#endif
        T value,
#if NETCOREAPP3_0_OR_GREATER
        [CallerArgumentExpression(nameof(value))]
#endif
        string paramName = null)
    {
        if (value is null)
            throw new ArgumentNullException(paramName, $"Argument {paramName} must be not null.");
    }

    /// <summary>
    /// Validates that the specified <paramref name="enumerable"/> is not null or empty, otherwise throws an exception.
    /// </summary>
    /// <param name="enumerable">The enumerable to validate as non-null and non-empty.</param>
    /// <param name="paramName">The name of the parameter with which <paramref name="enumerable"/> corresponds.</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    internal static void ThrowIfNullOrEmpty<T>(
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
        [System.Diagnostics.CodeAnalysis.NotNull]
#endif
        IEnumerable<T> enumerable,
#if NETCOREAPP3_0_OR_GREATER
        [CallerArgumentExpression(nameof(enumerable))]
#endif
        string paramName = null)
    {
        ThrowIfNull(enumerable, paramName);

        //Performance Tip: using pattern matching on array is faster than TryGetNonEnumeratedCount
        if (enumerable is Array { Length: 0 }
            || (enumerable.TryGetNonEnumeratedCount(out var count) && count == 0)
            || enumerable.Any() is false)
        {
            throw new ArgumentException($"Argument {paramName} must be not empty.", paramName);
        }
    }

#if !NET6_0_OR_GREATER
    /// <summary>
    ///   Attempts to determine the number of elements in a sequence without forcing an enumeration.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <param name="source">A sequence that contains elements to be counted.</param>
    /// <param name="count">
    ///     When this method returns, contains the count of <paramref name="source" /> if successful,
    ///     or zero if the method failed to determine the count.</param>
    /// <returns>
    ///   <see langword="true" /> if the count of <paramref name="source"/> can be determined without enumeration;
    ///   otherwise, <see langword="false" />.
    /// </returns>
    /// <remarks>
    /// <para>
    ///   The method performs a series of type tests, identifying common subtypes whose
    ///   count can be determined without enumerating; this includes <see cref="ICollection{T}"/>,
    ///   <see cref="ICollection{T}"/> as well as internal types used in the LINQ implementation.
    /// </para>
    /// <para>
    ///   The method is typically a constant-time operation, but ultimately this depends on the complexity
    ///   characteristics of the underlying collection implementation.
    /// </para>
    /// </remarks>
    public static bool TryGetNonEnumeratedCount<TSource>(this IEnumerable<TSource> source, out int count)
    {
        ThrowIfNull(source, nameof(source));

        if (source is ICollection<TSource> collectionoft)
        {
            count = collectionoft.Count;
            return true;
        }

        if (source is System.Collections.ICollection collection)
        {
            count = collection.Count;
            return true;
        }

        count = 0;
        return false;
    }
#endif
}