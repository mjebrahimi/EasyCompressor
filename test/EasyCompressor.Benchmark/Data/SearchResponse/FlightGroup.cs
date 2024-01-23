using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ProtobufVsMsgPack.Models
{
    [DataContract]
    public class FlightGroup
    {
        [DataMember(Order = 1)]
        public Guid InternalId { get; set; }

        [DataMember(Order = 2)]
        public int Order { get; set; }

        [DataMember(Order = 3)]
        public string MarketingAirlineCode { get; set; }

        [DataMember(Order = 4)]
        public string AirlineCode { get; set; }

        private string _airlineName;

        [DataMember(Order = 5)]
        public string AirlineName
        {
            get
            {
                //همه کدهای هواپیمایی ها 2 کاراکتر می باشد
                if (string.IsNullOrEmpty(_airlineName) || _airlineName.Length == 2)
                    return AirlineCode;

                return _airlineName;
            }
            set => _airlineName = value;
        }

        [DataMember(Order = 6)]
        public string Origin { get; set; }

        [DataMember(Order = 7)]
        public string Destination { get; set; }

        [DataMember(Order = 8)]
        public int DurationTotalMinutes { get; set; }

        [DataMember(Order = 9)]
        public string DurationMinText { get; set; }

        [DataMember(Order = 10)]
        public int NumberOfStops { get; set; }

        [DataMember(Order = 11)]
        public DateTime Departure { get; set; }

        [DataMember(Order = 12)]
        public DateTime Arrival { get; set; }

        [DataMember(Order = 13)]
        public string Class { get; set; }

        [DataMember(Order = 14)]
        public string ClassType { get; set; }

        [DataMember(Order = 15)]
        public string ClassTypeName { get; set; }

        [DataMember(Order = 16)]
        public string Status { get; set; }

        [DataMember(Order = 17)]
        public List<Flight> FlightDetails { get; set; }

        [DataMember(Order = 18)]
        public string Index { get; set; }

        [DataMember(Order = 19)]
        public string CabinClass { get; set; }

        [DataMember(Order = 20)]
        public string DepartureStandardDate { get; set; }

        [DataMember(Order = 21)]
        public string DepartureTime { get; set; }

        [DataMember(Order = 22)]
        public string Duration { get; set; }

        [DataMember(Order = 23)]
        public string ArrivalTime { get; set; }

        [DataMember(Order = 24)]
        public string ArrivalStandardDate { get; set; }

        [DataMember(Order = 25)]
        public string NumberOfStopsText { get; set; }

        [DataMember(Order = 26)]
        public int StopsDurationTotalMinutes { get; set; }

        [DataMember(Order = 27)]
        public string UserAgent { get; set; }

        [DataMember(Order = 28)]
        public string UserAgentName { get; set; }

        [DataMember(Order = 29)]
        public bool HasUnknownStop { get; set; }

        [DataMember(Order = 30)]
        public string MarketingAirlineName { get; set; }

        [DataMember(Order = 31)]
        public AncillaryServices AncillaryService { get; set; }
    }
}