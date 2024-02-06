// Ignore Spelling: Uknown

using System;
using System.Runtime.Serialization;

namespace EasyCompressor.Benchmarks.Models
{
    [DataContract]
    public class TechnicalStop
    {
        [DataMember(Order = 1)]
        public string ArrivalDate { get; set; }

        [DataMember(Order = 2)]
        public string DepartureDate { get; set; }

        [DataMember(Order = 3)]
        public string ArrivalTime { get; set; }

        [DataMember(Order = 4)]
        public string DepartureTime { get; set; }

        [DataMember(Order = 5)]
        public string Location { get; set; }

        [DataMember(Order = 6)]
        public bool UknownData { get; set; }

        [IgnoreDataMember]
        public int DurationTotalMinute
        {
            get
            {
                try
                {
#pragma warning disable S6580 // Use a format provider when parsing date and time
                    var d = DateTime.Parse(DepartureDate + " " + DepartureTime);
                    var a = DateTime.Parse(ArrivalDate + " " + ArrivalTime);
#pragma warning restore S6580 // Use a format provider when parsing date and time
                    return (int)a.Subtract(d).TotalMinutes;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}