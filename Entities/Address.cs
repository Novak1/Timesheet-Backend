using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace VegaIT.Timesheet.Core.Entities
{
    public class Address : ValueObject
    {
        //DDD- domain driven design- nacin na koji dizajniras softver(enterprise software)
        //ValueObject- klasa koja je tip nekog fild-a u entitetu.
        private Address(string street, string city, string zipCode, string country)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
            Country = country;
        }

        public string Street { get; }

        public string City { get; }

        public string ZipCode { get; }

        public string Country { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return ZipCode;
            yield return Country;
        }

        public static Result<Address> Create(string street, string city, string zipCode, string country )
        {
            if (string.IsNullOrWhiteSpace(street)) return Result.Failure<Address>("Street cannot be empty");
            if (string.IsNullOrWhiteSpace(city)) return Result.Failure<Address>("City cannot be empty");
            if (string.IsNullOrWhiteSpace(zipCode)) return Result.Failure<Address>("Zip code cannot be empty");
            if (string.IsNullOrWhiteSpace(country)) return Result.Failure<Address>("Country cannot be empty");

            return Result.Success(new Address(street, city, zipCode, country));
        }
    }
}