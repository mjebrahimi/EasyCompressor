using System.Runtime.Serialization;

namespace EasyCompressor.Benchmarks.Models
{
    [DataContract]
    public class BaggageAllowance
    {
        [DataMember(Order = 1)]
        public FlightAgeType AgeType { get; set; }

        [DataMember(Order = 2)]
        public int BaggageAllowanceAmount { get; set; }

        [DataMember(Order = 3)]
        public string BaggageUnit { get; set; } = "K";

        private int _baggagePieceAmount = 23;

        [DataMember(Order = 4)]
        public int BaggagePieceAmount
        {
            get
            {
                if (BaggageUnit?.ToLower() == "p" || BaggageUnit?.ToLower() == "pc" || BaggageUnit?.ToLower() == "piece")
                    return _baggagePieceAmount;
                return 0;
            }
            set => _baggagePieceAmount = value;
        }

        [DataMember(Order = 5)]
        public bool UnknownBaggageInfo { get; set; }

        [IgnoreDataMember]
        public string BaggageTextDisplay
        {
            get
            {
                if (UnknownBaggageInfo)
                    return "تماس با پشتیبان";

                if (BaggageAllowanceAmount == 0)
                    return "بدون بار";

                if (string.Equals(BaggageUnit, "k", System.StringComparison.OrdinalIgnoreCase) || string.Equals(BaggageUnit, "kg", System.StringComparison.OrdinalIgnoreCase))
                    return $"{BaggageAllowanceAmount} کیلوگرم";

                if (BaggageUnit?.ToLower() == "p" || BaggageUnit?.ToLower() == "pc" || BaggageUnit?.ToLower() == "piece")
                    return $"{BaggageAllowanceAmount} بسته (هر بسته {BaggagePieceAmount} کیلوگرم)";

                return "تماس با پشتیبان";
            }
        }
    }
}