using System.ComponentModel;

namespace ProtobufVsMsgPack.Models
{
    public enum ServiceProvider
    {
        [Description("Amadeus")]
        Amadeus = 0,

        [Description("Zhenic")]
        Zhenic = 2,

        [Description("AtlasGlobal")]
        AtlasGlobal = 3,

        [Description("Mahan")]
        Mahan = 4,

        [Description("Sepehr")]
        Sepehr = 5,

        [Description("Meraj")]
        Meraj = 6,

        [Description("Moghim")]
        Moghim = 8,

        [Description("Gabriel")]
        Gabriel = 9,

        [Description("IranAir")]
        IranAir = 10,

        [Description("Farasoo")]
        Farasoo = 11,

        [Description("Irix")]
        Irix = 12,

        [Description("Chartex")]
        Chartex = 13,

        [Description("Parto")]
        Parto = 14,

        [Description("Iati")]
        Iati = 15,

        [Description("Travelfusion")]
        Travelfusion = 16,

        [Description("QeshmAir")]
        QeshmAir = 17,

        [Description("Artiman")]
        Artiman = 18,

        [Description("NiraI3")]
        NiraI3 = 19,

        [Description("NiraEP")]
        NiraEP = 20,

        [Description("NiraQB")]
        NiraQB = 21,

        [Description("IranAirTour")]
        IranAirTour = 22
    }
}