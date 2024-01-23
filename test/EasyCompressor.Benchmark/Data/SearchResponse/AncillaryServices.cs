using System.Runtime.Serialization;

namespace ProtobufVsMsgPack.Models
{
    [DataContract]
    public class AncillaryServices
    {
        [DataMember(Order = 1)]
        public bool FreeTransfer { get; set; }

        [DataMember(Order = 2)]
        public bool LowCost { get; set; }

        [DataMember(Order = 3)]
        public bool Insurance { get; set; }

        [DataMember(Order = 4)]
        public bool Sponsored { get; set; }

        [DataMember(Order = 5)]
        public bool FreeCancelation { get; set; }

        [DataMember(Order = 6)]
        public int Priority { get; set; }

        [IgnoreDataMember]
        public bool Enable
        {
            get
            {
                if (FreeTransfer || LowCost || Insurance || Sponsored || FreeCancelation)
                    return true;
                return false;
            }
        }
    }
}