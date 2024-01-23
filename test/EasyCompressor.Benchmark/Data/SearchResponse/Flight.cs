using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ProtobufVsMsgPack.Models
{
    [DataContract]
    public class Flight
    {
        [DataMember(Order = 1)]
        public string RPH { get; set; }

        [DataMember(Order = 2)]
        public int Id { get; set; }

        [DataMember(Order = 3)]
        public byte Index { get; set; }

        [DataMember(Order = 4)]
        public string Origin { get; set; }

        [DataMember(Order = 5)]
        public string Destination { get; set; }

        [DataMember(Order = 6)]
        public string MarketingCarrier { get; set; }

        [DataMember(Order = 7)]
        public string OperatingCarrier { get; set; }

        [DataMember(Order = 8)]
        public bool ElectronicTicketing { get; set; }

        [DataMember(Order = 9)]
        public string FlightNumber { get; set; }

        [DataMember(Order = 10)]
        public DateTime DepartureDateTime { get; set; }

        [DataMember(Order = 11)]
        public string DepartureTerminal { get; set; }

        [DataMember(Order = 12)]
        public DateTime ArrivalDateTime { get; set; }

        [DataMember(Order = 13)]
        public string ArrivalTerminal { get; set; }

        [DataMember(Order = 14)]
        public string Aircraft { get; set; }

        [DataMember(Order = 15)]
        public string Description { get; set; }

        [DataMember(Order = 16)]
        public string AirlineCode { get; set; }

        [DataMember(Order = 17)]
        public string AirlineName { get; set; }

        [DataMember(Order = 18)]
        public string ArrivalStandardDate { get; set; }

        [DataMember(Order = 19)]
        public string ArrivalDateWithTimeZone { get; set; }

        [DataMember(Order = 20)]
        public string ArrivalTime { get; set; }

        [DataMember(Order = 21)]
        public string DepartureStandardDate { get; set; }

        [DataMember(Order = 22)]
        public string DepartureDateWithTimeZone { get; set; }

        [DataMember(Order = 23)]
        public string DepartureTime { get; set; }

        [DataMember(Order = 24)]
        public string Class { get; set; }

        [DataMember(Order = 25)]
        public string StopDuration { get; set; }

        [DataMember(Order = 26)]
        public int StopDurationTotalMin { get; set; }

        [DataMember(Order = 27)]
        public List<BaggageAllowance> Baggage { get; set; } = new List<BaggageAllowance>();

        [DataMember(Order = 28)]
        public bool UnknownBaggage { get; set; }

        [DataMember(Order = 29)]
        public int DurationTotalMinutes { get; set; }

        [DataMember(Order = 30)]
        public int FreeSeat { get; set; }

        [DataMember(Order = 31)]
        public List<TechnicalStop> TechnicalStop { get; set; } = new List<TechnicalStop>();

        [DataMember(Order = 32)]
        public bool AirportChange { get; set; }

        [IgnoreDataMember]
        public bool IsTrain
        {
            get => Aircraft != null && (Aircraft.ToUpper() == "TRS" || Aircraft.ToUpper() == "TRN");
            set
            {
            }
        }

        [IgnoreDataMember]
        public bool IsBus
        {
            get => Aircraft != null && Aircraft.ToUpper() == "BUS";
            set
            {
            }
        }

        [DataMember(Order = 33)]
        public string CabinClass { get; set; }

        public static string ToStringFlightNumber(List<Flight> flightDetails)
        {
            var mergedFlightNumber = "";

            flightDetails = (flightDetails).GroupBy(x => new
            {
                x.AirlineCode,
                x.FlightNumber
            }).Select(m => m.First()).ToList();

            foreach (Flight item in flightDetails)
            {
                if (!string.IsNullOrEmpty(mergedFlightNumber))
                    mergedFlightNumber += "-";

                mergedFlightNumber += item.FlightNumber;
            }

            return mergedFlightNumber;
        }
    }
}