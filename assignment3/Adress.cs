using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    public class Address
    {
        public string UnitNumber { get; }
        public int StreetNumber { get; }
        public string StreetName { get; }
        public string PostalCode { get; }
        public string City { get; }
        
        public Address(string unitNumber, int streetNumber, string streetName, string postalCode, string city)
        {
            if (unitNumber.Length < 1 || unitNumber.Length > 4)
            {
                throw new ArgumentException("Unit number must be between 1 and 10 characters long");
            }
            if(streetNumber < 0 || streetNumber > 9999)
            {
                throw new ArgumentException("Street number must be between 0 and 9999");
            }
            if(streetName.Length < 1 || streetName.Length > 20)
            {
                throw new ArgumentException("Street name must be between 1 and 20 characters long");
            }
            if(postalCode.Length != 6 || postalCode.Length != 5)
            {
                throw new ArgumentException("Postal code must be 5 or 6 characters.");
            }
            if (city.Length < 1 || city.Length > 30) 
                throw new ArgumentException("City must be between 1 and 30 characters.");
            UnitNumber = unitNumber;
            StreetNumber = streetNumber;
            StreetName = streetName;
            PostalCode = postalCode;
            City = city;
        }
        public override string ToString()
        {
            return UnitNumber != ""
                ? $"unit #{UnitNumber} at {StreetNumber} {StreetName} {PostalCode} in {City}"
                : $"{StreetNumber} {StreetName} {PostalCode} in {City}";
        }
    }
}
