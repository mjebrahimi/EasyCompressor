using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace EasyCompressor.Benchmarks.Models
{
    [DataContract]
    public class SearchResponse
    {
        public static byte[] GetDataBinary()
        {
            var json = File.ReadAllText(@"Data\SearchResponse\SearchResponse.json");
            var data = Serializer.FromJson<List<SearchResponse>>(json);
            return Serializer.SerializeMessagePack(data);
        }

        [DataMember(Order = 1)]
        public long Id { get; set; }

        [DataMember(Order = 2)]
        public string SessionId { get; set; }

        [DataMember(Order = 3)]
        public FlightProposal Response { get; set; }

        [DataMember(Order = 4)]
        public bool IsFinished { get; set; }

        [DataMember(Order = 5)]
        public int TotalProviderCount { get; set; }

        [DataMember(Order = 6)]
        public string ProviderName { get; set; }

        [DataMember(Order = 7)]
        public DateTime Created { get; set; }

        [DataMember(Order = 8)]
        public string Message { get; set; }
    }
}