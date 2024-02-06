#if !NET8_0_OR_GREATER
using System;

namespace EasyCompressor;

/// <summary>
/// ArgumentOutOfRangeException
/// </summary>
#pragma warning disable S2166 // Classes named like "Exception" should extend "Exception" or a subclass
internal static class ArgumentOutOfRangeException
#pragma warning restore S2166 // Classes named like "Exception" should extend "Exception" or a subclass
{
    /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is less than <paramref name="other"/>.</summary>
    /// <param name="value">The argument to validate as greater than or equal than <paramref name="other"/>.</param>
    /// <param name="other">The value to compare with <paramref name="value"/>.</param>
    /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
    public static void ThrowIfLessThan<T>(T value, T other, string paramName = null)
        where T : IComparable<T>
    {
        if (value.CompareTo(other) < 0)
            ThrowLess(value, other, paramName);
    }

    /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is greater than <paramref name="other"/>.</summary>
    /// <param name="value">The argument to validate as less or equal than <paramref name="other"/>.</param>
    /// <param name="other">The value to compare with <paramref name="value"/>.</param>
    /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
    public static void ThrowIfGreaterThan<T>(T value, T other, string paramName = null)
        where T : IComparable<T>
    {
        if (value.CompareTo(other) > 0)
            ThrowGreater(value, other, paramName);
    }

    /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is less than or equal <paramref name="other"/>.</summary>
    /// <param name="value">The argument to validate as greater than <paramref name="other"/>.</param>
    /// <param name="other">The value to compare with <paramref name="value"/>.</param>
    /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
    public static void ThrowIfLessThanOrEqual<T>(T value, T other, string paramName = null)
        where T : IComparable<T>
    {
        if (value.CompareTo(other) <= 0)
            ThrowLessEqual(value, other, paramName);
    }

    /// <summary>Throws an <see cref="ArgumentOutOfRangeException"/> if <paramref name="value"/> is greater than or equal <paramref name="other"/>.</summary>
    /// <param name="value">The argument to validate as less than <paramref name="other"/>.</param>
    /// <param name="other">The value to compare with <paramref name="value"/>.</param>
    /// <param name="paramName">The name of the parameter with which <paramref name="value"/> corresponds.</param>
    public static void ThrowIfGreaterThanOrEqual<T>(T value, T other, string paramName = null)
        where T : IComparable<T>
    {
        if (value.CompareTo(other) >= 0)
            ThrowGreaterEqual(value, other, paramName);
    }

    private static void ThrowLess<T>(T value, T other, string paramName) =>
        throw new System.ArgumentOutOfRangeException(paramName, value, $"Parameter '{paramName}' (value: {value}) must be greater than or equal to {other}");

    private static void ThrowGreater<T>(T value, T other, string paramName) =>
        throw new System.ArgumentOutOfRangeException(paramName, value, $"Parameter '{paramName}' (value: {value}) must be less than or equal to {other}");

    private static void ThrowLessEqual<T>(T value, T other, string paramName) =>
        throw new System.ArgumentOutOfRangeException(paramName, value, $"Parameter '{paramName}' (value: {value}) must be greater than {other}");

    private static void ThrowGreaterEqual<T>(T value, T other, string paramName) =>
        throw new System.ArgumentOutOfRangeException(paramName, value, $"Parameter '{paramName}' (value: {value}) must be less than {other}");
}
#endif
