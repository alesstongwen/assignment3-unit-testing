using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    public class Property
    {
        public double Price { get; private set; }
        public Address Address { get; }
        public int Bedrooms { get; }
        public bool SwimmingPool { get; }
        public string Type { get; }
        public string PropertyID { get; }

        public Property(double price, Address address, int bedrooms, bool swimmingPool, string type, string propertyID)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price must be greater than 0");
            }
            if (bedrooms < 0)
            {
                throw new ArgumentException("Bedrooms must be greater than 0");
            }
            if (propertyID.Length < 1 || propertyID.Length > 6)
                throw new ArgumentException("Property ID must be between 1 and 6 characters.");
            Price = price;
            Address = address;
            Bedrooms = bedrooms;
            SwimmingPool = swimmingPool;
            Type = type.ToLower();
            PropertyID = propertyID;
        }

        public void SetPrice(double newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Price must be positive.");
            Price = newPrice;
        }

        // Override ToString
        public override string ToString()
        {
            return $"{Type.ToUpper()}: {Address} ({Bedrooms} bedroom{(Bedrooms > 1 ? "s" : "")}{(SwimmingPool ? " plus pool" : "")}): ${Price}.";
        }
    }
}
