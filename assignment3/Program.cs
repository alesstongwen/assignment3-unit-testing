using System.Net;

namespace assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an address
            Address address1 = new Address("1a", 777, "56th avenue", "v7n2m8", "Surrey");

            // Create a property
            Property property1 = new Property(499000, address1, 3, true, "residence", "abc123");

            // Create an agency and add the property
            Agency agency = new Agency("abc123", "BCIT Ltd");
            agency.AddProperty("abc123", property1);

            // Print property details
            Console.WriteLine(property1);

            // Get total value of properties
            Console.WriteLine($"Total property value: ${agency.GetTotalPropertyValues()}");

            // Get properties of a specific type
            Console.WriteLine(agency.GetPropertiesOfType("residence"));
        }
    }
}