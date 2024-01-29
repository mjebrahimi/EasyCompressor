using System;
using System.Runtime.Serialization;

namespace EasyCompressor.Benchmarks.Models;

[DataContract]
public class Person
{
    public static byte[] GetDataBinary()
    {
        var person = Create();
        return Serializer.SerializeMessagePack(person);
    }

    public static Person Create()
    {
        return new()
        {
            Name = "John",
            Age = 25,
            Gender = "Male",
#pragma warning disable S6562 // Always set the "DateTimeKind" when creating new "DateTime" instances
            DateOfBirth = new DateTime(1995, 1, 1),
#pragma warning restore S6562 // Always set the "DateTimeKind" when creating new "DateTime" instances
            PlaceOfBirth = "City, Country",
            Nationality = "Nationality",
            Occupation = "Occupation",
            Education = "Education",
            Residence = "Residence",
            ContactInfo = new()
            {
                PhoneNumber = "1234567890",
                Email = "example@example.com"
            },
            PhysicalDescription = new()
            {
                Height = 170,
                Weight = 60,
                HairColor = "Black",
                EyeColor = "Brown"
            },
            Family = new()
            {
                Parents = ["Parent 1", "Parent 2"],
                Siblings = ["Sibling 1", "Sibling 2"],
                Spouse = "Spouse"
            }
        };
    }

    [DataMember(Order = 1)]
    public string Name { get; set; }
    [DataMember(Order = 2)]
    public int Age { get; set; }
    [DataMember(Order = 3)]
    public string Gender { get; set; }
    [DataMember(Order = 4)]
    public DateTime DateOfBirth { get; set; }
    [DataMember(Order = 5)]
    public string PlaceOfBirth { get; set; }
    [DataMember(Order = 6)]
    public string Nationality { get; set; }
    [DataMember(Order = 7)]
    public string Occupation { get; set; }
    [DataMember(Order = 8)]
    public string Education { get; set; }
    [DataMember(Order = 9)]
    public string Residence { get; set; }
    [DataMember(Order = 10)]
    public ContactInformation ContactInfo { get; set; }
    [DataMember(Order = 11)]
    public PhysicalDescription PhysicalDescription { get; set; }
    [DataMember(Order = 12)]
    public FamilyInfo Family { get; set; }
}

[DataContract]
public class ContactInformation
{
    [DataMember(Order = 1)]
    public string PhoneNumber { get; set; }
    [DataMember(Order = 2)]
    public string Email { get; set; }
}

[DataContract]
public class PhysicalDescription
{
    [DataMember(Order = 1)]
    public double Height { get; set; }
    [DataMember(Order = 2)]
    public double Weight { get; set; }
    [DataMember(Order = 3)]
    public string HairColor { get; set; }
    [DataMember(Order = 4)]
    public string EyeColor { get; set; }
}

[DataContract]
public class FamilyInfo
{
    [DataMember(Order = 1)]
    public string[] Parents { get; set; }
    [DataMember(Order = 2)]
    public string[] Siblings { get; set; }
    [DataMember(Order = 3)]
    public string Spouse { get; set; }
}