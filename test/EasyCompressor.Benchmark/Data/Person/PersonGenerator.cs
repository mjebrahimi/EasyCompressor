using System;

namespace EasyCompressor.Benchmark;

public static class PersonGenerator
{
    public static Person GeneratePerson()
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
}
