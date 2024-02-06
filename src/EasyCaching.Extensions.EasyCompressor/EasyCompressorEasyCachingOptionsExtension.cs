using EasyCaching.Core;
using EasyCaching.Core.Configurations;
using EasyCaching.Core.Serialization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("EasyCompressor.Tests")]

namespace EasyCompressor;

internal class EasyCompressorEasyCachingOptionsExtension(string serializerName = null, string compressorName = null) : IEasyCachingOptionsExtension
{
    private bool single;

    /// <inheritdoc/>
    /// <exception cref="EasyCaching.Core.EasyCachingNotFoundException">Can not find any EasyCachingSerializer that is not assigned to a Compressor. Make sure to call WithCompressor() method after adding a serializer to the EasyCachingOptions, not before.</exception>
    public void AddServices(IServiceCollection services)
    {
        var easyCachingSerializerType = typeof(IEasyCachingSerializer);
        var easyCompressorEasyCachingOptionsExtensionType = typeof(EasyCompressorEasyCachingOptionsExtension);

        var descriptors = services.Where(p =>
            p.ServiceType == easyCachingSerializerType &&
            p.ImplementationFactory?.Target.GetType().ReflectedType != easyCompressorEasyCachingOptionsExtensionType).ToArray();

        if (descriptors.Length == 0)
            throw new EasyCachingNotFoundException("Can not find any EasyCachingSerializer that is not assigned to a Compressor. Make sure to call WithCompressor() method after adding a serializer to the EasyCachingOptions, not before.");

        single = descriptors.Length == 1;

        foreach (var descriptor in descriptors)
        {
            services.Remove(descriptor);

            switch (descriptor.Lifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(provider => DecoratorFactory(descriptor, provider));
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped(provider => DecoratorFactory(descriptor, provider));
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient(provider => DecoratorFactory(descriptor, provider));
                    break;
            }
        }
    }

    private IEasyCachingSerializer DecoratorFactory(ServiceDescriptor descriptor, IServiceProvider provider)
    {
        IEasyCachingSerializer serializer;

        if (descriptor.ImplementationInstance is not null)
            serializer = (IEasyCachingSerializer)descriptor.ImplementationInstance;
        else if (descriptor.ImplementationType is not null)
            serializer = (IEasyCachingSerializer)ActivatorUtilities.GetServiceOrCreateInstance(provider, descriptor.ImplementationType);
        else
            serializer = (IEasyCachingSerializer)descriptor.ImplementationFactory(provider);

        if (serializerName?.Equals(serializer.Name, StringComparison.OrdinalIgnoreCase) is false)
        {
            if (single)
                throw new EasyCachingNotFoundException($"Can not find a matched Serializer instance with name '{serializerName}'.");
            else
                return serializer;
        }

        var compressor = provider.GetRequiredService<ICompressorProvider>().GetCompressor(compressorName);

        return new EasyCachingSerializerDecorator(compressor, serializer);
    }
}