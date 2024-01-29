namespace EasyCompressor.Benchmarks.Models
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