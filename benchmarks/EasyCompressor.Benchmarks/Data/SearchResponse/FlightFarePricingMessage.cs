using System.Runtime.Serialization;

namespace EasyCompressor.Benchmarks.Models
{
    [DataContract]
    public class FlightFarePricingMessage
    {
        [DataMember(Order = 1)]
        public FlightFarePricingMessageType Type { get; set; }

        [DataMember(Order = 2)]
        public string Description { get; set; }
    }
}