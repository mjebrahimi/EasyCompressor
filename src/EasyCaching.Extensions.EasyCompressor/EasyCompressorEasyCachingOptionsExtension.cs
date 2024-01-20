using EasyCaching.Core.Configurations;
using EasyCaching.Core.Serialization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyCompressor;

internal class EasyCompressorEasyCachingOptionsExtension : IEasyCachingOptionsExtension
{
    private static readonly Dictionary<string, string> _dictonary = new(StringComparer.OrdinalIgnoreCase) { { "binary", null } };

    public EasyCompressorEasyCachingOptionsExtension()
    {
    }

    public EasyCompressorEasyCachingOptionsExtension(string serializerName, string compressorName)
    {
        //Workaround for default BinaryFormatter serializer
        _dictonary["binary"] = compressorName;
        _dictonary[serializerName] = compressorName;
    }

    public void AddServices(IServiceCollection services)
    {
        var descriptors = services.Where(p =>
            p.ServiceType == typeof(IEasyCachingSerializer) &&
            p.ImplementationFactory?.Target.GetType().ReflectedType != typeof(EasyCompressorEasyCachingOptionsExtension)).ToList();

        if (descriptors.Count == 0)
            throw new InvalidOperationException("This operation must be called after serializer added.");

        foreach (var descriptor in descriptors)
        {
            //descriptor.ImplementationType == typeof(DefaultBinaryFormatterSerializer)

            services.Remove(descriptor);

            switch (descriptor.Lifetime)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton<IEasyCachingSerializer>(provider => DecoratorFactory(descriptor, provider));
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped<IEasyCachingSerializer>(provider => DecoratorFactory(descriptor, provider));
                    break;
                case ServiceLifetime.Transient:
                    services.AddTransient<IEasyCachingSerializer>(provider => DecoratorFactory(descriptor, provider));
                    break;
            }
        }
    }

    private static EasyCachingSerializerDecorator DecoratorFactory(ServiceDescriptor descriptor, IServiceProvider provider)
    {
        IEasyCachingSerializer serializer;

        if (descriptor.ImplementationInstance != null)
        {
            serializer = (IEasyCachingSerializer)descriptor.ImplementationInstance;
        }
        else if (descriptor.ImplementationType != null)
        {
            serializer = (IEasyCachingSerializer)ActivatorUtilities.GetServiceOrCreateInstance(provider, descriptor.ImplementationType);
        }
        else //has Factory
        {
            serializer = (IEasyCachingSerializer)descriptor.ImplementationFactory(provider);
        }

        _dictonary.TryGetValue(serializer.Name, out var compressorName);
        var compressor = provider.GetRequiredService<ICompressorProvider>().GetCompressor(compressorName);

        return new EasyCachingSerializerDecorator(compressor, serializer);
    }
}