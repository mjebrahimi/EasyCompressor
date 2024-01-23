namespace ProtobufVsMsgPack.Models
{
    public enum FlightFarePricingMessageType
    {
        Unknown,

        CodedFreeText,

        LiteralText,

        CodedAndLiteralText,

        AppendedMessage,

        LastDateToTicket,

        PenaltiesMessage,

        Surcharges,

        SystemChecks,

        WarningMessage,
    }
}