using EasyCaching.Core.Configurations;
using EasyCaching.Core.Serialization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyCompressor
{
    internal class EasyCompressorEasyCachingOptionsExtension : IEasyCachingOptionsExtension
    {
        private static Dictionary<string, string> _dictonary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public EasyCompressorEasyCachingOptionsExtension()
        {
        }

        public EasyCompressorEasyCachingOptionsExtension(string serializerName, string compressorName)
        {
            //serializerName.NotNullOrWhiteSpace(nameof(serializerName));
            _dictonary.Add(serializerName, compressorName);
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
                services.Remove(descriptor);

                services.AddSingleton<IEasyCachingSerializer>(serviceProvider =>
                {
                    var serializer = (IEasyCachingSerializer)descriptor.ImplementationFactory(serviceProvider);

                    if (_dictonary.TryGetValue(serializer.Name, out var compressorName) == false)
                    {
                        //return serializer;
                    }

                    var compressor = serviceProvider.GetRequiredService<ICompressorProvider>().GetCompressor(compressorName);

                    return new EasyCachingSerializerDecorator(compressor, serializer);
                });
            }
        }
    }
}
