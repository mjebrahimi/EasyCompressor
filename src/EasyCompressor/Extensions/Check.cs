using System;

namespace EasyCompressor.Internal;

/// <summary>
/// Check argument
/// </summary>
public static class Check
{
    /// <summary>
    /// Validates that obj is not null , otherwise throws an ArgumentNullException exception.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj">The object.</param>
    /// <param name="name">The name.</param>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    public static T NotNull<T>(this T obj, string name, string message = null)
    {
        if (obj is null)
            throw new ArgumentNullException($"Argument '{name}' ({typeof(T)} most not null.", message);
        return obj;
    }

    /// <summary>
    /// Validates that the array is not empty, otherwise throws an ArgumentException exception.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj">The object.</param>
    /// <param name="name">The name.</param>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    public static T[] NotEmpty<T>(this T[] obj, string name, string message = null)
    {
        if (obj.Length == 0)
            throw new ArgumentException($"Argument {name} ({typeof(T)}) is empty. " + message, name);
        return obj;
    }

    /// <summary>
    /// Validates that array is not null or empty , otherwise throws an exception.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj">The object.</param>
    /// <param name="name">The name.</param>
    /// <param name="message">The message.</param>
    /// <returns></returns>
    public static T[] NotNullOrEmpty<T>(this T[] obj, string name, string message = null)
    {
        return obj
            .NotNull(name, message)
            .NotEmpty(name, message);
    }
}
