// Ignore Spelling: Commision Pax

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyCompressor.Benchmarks.Models
{
    [DataContract]
    public class FlightPrice
    {
        [DataMember(Order = 1)]
        public FlightAgeType PaxType { get; set; }

        [IgnoreDataMember]
        public string PaxTypeText
        {
            get
            {
                return PaxType switch
                {
                    FlightAgeType.Adult => "بزرگسال",
                    FlightAgeType.Child => "کودک",
                    FlightAgeType.Infant => "نوزاد",
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one
                    _ => throw new ArgumentOutOfRangeException(),
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one
                };
            }
        }

        [DataMember(Order = 2)]
        public long LeavingPriceWithoutCommision { get; set; }

        [DataMember(Order = 3)]
        public long LeavingPrice { get; set; }

        [DataMember(Order = 4)]
        public long ReturningPriceWithoutCommision { get; set; }

        [DataMember(Order = 5)]
        public long ReturningPrice { get; set; }

        [DataMember(Order = 6)]
        public bool IsPacked { get; set; } = true;

        [DataMember(Order = 7)]
        public decimal MarkupPercent { get; set; }

        [DataMember(Order = 8)]
        public decimal Commission { get; set; }

        [DataMember(Order = 9)]
        public bool CommissionIsPercent { get; set; } = true;

        [IgnoreDataMember]
        public decimal CommissionPercent => CommissionIsPercent ? Commission : 100 * Commission / (LeavingPrice + ReturningPrice);

        [IgnoreDataMember]
        public long CommissionAmount
        {
            get
            {
                if (!TaxIsIncluded)
                    return Convert.ToInt64(CommissionIsPercent ? Commission / 100 * (LeavingPrice + ReturningPrice) : Commission);

#pragma warning disable S3358 // Ternary operators should not be nested
                return Convert.ToInt64(CommissionIsPercent ? Commission / 100 * (LeavingPrice - Tax + (ReturningPrice == 0 ? ReturningPrice : ReturningPrice - Tax)) : Commission);
#pragma warning restore S3358 // Ternary operators should not be nested
            }
        }

        [DataMember(Order = 10)]
        public decimal LeavingCommission { get; set; }

        [DataMember(Order = 11)]
        public decimal ReturningCommission { get; set; }

        [DataMember(Order = 12)]
        public long Markup { get; set; }

        [IgnoreDataMember]
        public long LeavingMarkup => !IsMarkupValue ?
            Convert.ToInt64(MarkupPercent * LeavingPrice) :
            Convert.ToInt64(MarkupPercent);

        [IgnoreDataMember]
        public long ReturningMarkup
        {
            get
            {
                if (IsPacked)
                    return 0;

                return !IsMarkupValue ?
                    Convert.ToInt64(MarkupPercent * ReturningPrice) :
                    Convert.ToInt64(MarkupPercent);
            }
        }

        [IgnoreDataMember]
        public long PackedMarkup
        {
            get
            {
                if (IsPacked)
                    return LeavingMarkup;

                return LeavingMarkup + ReturningMarkup;
            }
        }

        [DataMember(Order = 13)]
        public long ClassPrice { get; set; }

        [DataMember(Order = 14)]
        public long Total { get; set; }

        [IgnoreDataMember]
        public long TotalPrice
        {
            get
            {
                if (IsPacked)
                    return TotalLeavingPrice + (TaxIsIncluded ? 0 : Tax) + OtherPrice;
                return TotalLeavingPrice + TotalReturningPrice + (TaxIsIncluded ? 0 : Tax) + OtherPrice;
            }
        }

        [IgnoreDataMember]
        public string TotalText => Total.ToString("N0");

        [DataMember(Order = 15)]
        public long Fare { get; set; }

        [IgnoreDataMember]
        public long TotalFare
        {
            get
            {
                if (IsPacked)
                    return LeavingPrice + (TaxIsIncluded ? 0 : Tax) + OtherPrice;
                return LeavingPrice + ReturningPrice + (TaxIsIncluded ? 0 : Tax) + OtherPrice;
            }
        }

        [DataMember(Order = 16)]
        public long Tax { get; set; }

        [DataMember(Order = 17)]
        public long LeavingTax { get; set; }

        [DataMember(Order = 18)]
        public long ReturningTax { get; set; }

        [DataMember(Order = 19)]
        public string FarePenaltyAmount { get; set; }

        [DataMember(Order = 20)]
        public string FarePenaltyMessage { get; set; }

        [DataMember(Order = 21)]
        public DateTime? FareLastTicketDate { get; set; }

        [DataMember(Order = 22)]
        public List<FlightFarePricingMessage> FarePricingMessages { get; set; }

        [DataMember(Order = 23)]
        public string RefNumber { get; set; }

        [DataMember(Order = 24)]
        public string RefNumberR { get; set; }

        [DataMember(Order = 25)]
        public int Count { get; set; }

        [IgnoreDataMember]
        public long TotalLeavingPrice => LeavingPrice + LeavingMarkup;

        [IgnoreDataMember]
        public long TotalReturningPrice => ReturningPrice + ReturningMarkup;

        [DataMember(Order = 26)]
        public long OtherPrice { get; set; }

        [DataMember(Order = 27)]
        public bool IsMarkupValue { get; set; }

        [DataMember(Order = 28)]
        public decimal CurrencyRate { get; set; }

        [DataMember(Order = 29)]
        public string CurrencyCode { get; set; } = "IRR";

        [DataMember(Order = 30)]
        public double MainPrice { get; set; }

        [DataMember(Order = 31)]
        public double MainPriceReturning { get; set; }

        [DataMember(Order = 32)]
        public bool TaxIsIncluded { get; set; }

        public override string ToString()
        {
            var returnValue = "";
            returnValue += Count + "X" + PaxType + "-" + Total;

            return returnValue;
        }

        public static string ToStringFlightPriceList(IEnumerable<FlightPrice> flightPrices)
        {
            var returnValue = "";
            foreach (FlightPrice item in flightPrices)
            {
#pragma warning disable S1643 // Strings should not be concatenated using '+' in a loop
                if (returnValue != "")
                    returnValue += "-";

                returnValue += item.ToString();
#pragma warning restore S1643 // Strings should not be concatenated using '+' in a loop
            }

            return returnValue;
        }
    }
}