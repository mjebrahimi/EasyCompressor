﻿using System.Runtime.Serialization;

namespace ProtobufVsMsgPack.Models
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