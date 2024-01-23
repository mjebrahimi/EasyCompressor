using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ProtobufVsMsgPack.Models
{
    [DataContract]
    public class FlightProposal
    {
        [DataMember(Order = 1)]
        public string MarketingAirlineCode { get; set; }

        [DataMember(Order = 2)]
        public bool CanReserve { get; set; } = true;

        [DataMember(Order = 3)]
        public string IdentityType { get; set; } = "Passport";

        [DataMember(Order = 4)]
        public string FlightProposalId { get; set; }

        [DataMember(Order = 5)]
        public string ClassPrice { get; set; }

        // Total is final price that we are showing to user in website
        [DataMember(Order = 6)]
        public long Total { get; set; }

        [DataMember(Order = 7)]
        public long TotalFare { get; set; }

        [DataMember(Order = 8)]
        public long TotalTax { get; set; }

        [DataMember(Order = 9)]
        public List<FlightPrice> Prices { get; set; }

        [DataMember(Order = 10)]
        public List<FlightGroup> FlightGroups { get; set; } = new List<FlightGroup>();

        [DataMember(Order = 11)]
        public bool IsMultiDestination { get; set; }

        [IgnoreDataMember]
        public FlightGroup LeavingFlightGroup
        {
            get => FlightGroups?.FirstOrDefault();
            set
            {
                if (FlightGroups == null)
                    FlightGroups = new List<FlightGroup>();
                if (FlightGroups.Count == 0)
                    FlightGroups.Add(value);
            }
        }

        [IgnoreDataMember]
        public FlightGroup ReturningFlightGroup
        {
            get
            {
                if (!IsMultiDestination && FlightGroups.Count == 2)
                    return FlightGroups[1];
                return null;
            }
            set
            {
                if (FlightGroups == null)
                    FlightGroups = new List<FlightGroup>();
                if (FlightGroups.Count == 1 && value != null)
                    FlightGroups.Add(value);
            }
        }

        [IgnoreDataMember]
        public int TotalDurationMinutes => LeavingFlightGroup.DurationTotalMinutes +
                                           (ReturningFlightGroup?.DurationTotalMinutes ?? 0);

        [DataMember(Order = 12)]
        public string TotalText { get; set; }

        [DataMember(Order = 13)]
        public string FlightId { get; set; }

        [DataMember(Order = 14)]
        public string ClassPriceText { get; set; }

        [DataMember(Order = 15)]
        public string SystemKey { get; set; }

        [DataMember(Order = 16)]
        public bool IsCharter { get; set; }

        [DataMember(Order = 17)]
        public string Description { get; set; }

        [DataMember(Order = 18)]
        public int Seat { get; set; }

        #region Extended Property

        [DataMember(Order = 19)]
        public ServiceProvider ProviderMetadata { get; set; }

        [DataMember(Order = 20)]
        public string ProviderProposalId { get; set; }

        //وقتی در زمان پر کردن اطلاعات، جای خالی پرواز انتخاب شده پر شده باشد، 1 می شود

        [DataMember(Order = 21)]
        public bool UnavailableSeat { get; set; }

        private bool _isRefundable = true;

        [DataMember(Order = 22)]
        public bool IsRefundable
        {
            get => AncillaryService != null && AncillaryService.FreeCancelation || _isRefundable;
            set => _isRefundable = value;
        }

        #endregion Extended Property

        [DataMember(Order = 23)]
        public bool IsPoint { get; set; }

        [DataMember(Order = 24)]
        public AncillaryServices AncillaryService { get; set; }

        public static string ToUniqueKey(FlightProposal proposal)
        {
            var str = new StringBuilder();
            foreach (Flight flight in proposal.FlightGroups.SelectMany(flightGroup => flightGroup.FlightDetails))
            {
                str.Append(flight.DepartureDateTime.Date.ToString("yyyyMMdd"));
                str.Append(flight.AirlineCode);
                str.Append(flight.FlightNumber);
            }

            str.Append(proposal.IsCharter);

            return str.ToString();
        }

        public override string ToString()
        {
            var returnValue = "";
            returnValue += Flight.ToStringFlightNumber(LeavingFlightGroup.FlightDetails);

            if (ReturningFlightGroup != null)
                returnValue += "-" + Flight.ToStringFlightNumber(ReturningFlightGroup.FlightDetails);

            returnValue += "-" + FlightPrice.ToStringFlightPriceList(Prices);
            return returnValue;
        }
    }
}