using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    public class Agency
    {
        public string PropertyID { get; }
        public string AgencyName { get; }
        private Dictionary<string, Property> Properties { get; }

        // Constructor
        public Agency(string propertyID, string agencyName)
        {
            if (propertyID.Length < 1 || propertyID.Length > 6)
                throw new ArgumentException("Property ID must be between 1 and 6 characters.");
            if (agencyName.Length < 1 || agencyName.Length > 30)
                throw new ArgumentException("Agency name must be between 1 and 30 characters.");

            PropertyID = propertyID;
            AgencyName = agencyName;
            Properties = new Dictionary<string, Property>();
        }

        // Add a property
        public void AddProperty(string propertyID, Property property)
        {
            if (property == null)
                throw new ArgumentException("Property cannot be null.");
            Properties[propertyID] = property;
        }

        // Remove a property
        public void RemoveProperty(string propertyID)
        {
            Properties.Remove(propertyID);
        }

        // Get a property
        public Property GetProperty(string propertyID)
        {
            return Properties.ContainsKey(propertyID) ? Properties[propertyID] : null;
        }

        // Get total property values
        public double GetTotalPropertyValues()
        {
            return Properties.Values.Sum(p => p.Price);
        }

        // Get properties with pools
        public List<Property> GetPropertiesWithPools()
        {
            return Properties.Values.Where(p => p.SwimmingPool).ToList();
        }

        // Get properties in a price range
        public List<Property> GetPropertiesBetween(double minUsd, double maxUsd)
        {
            return Properties.Values.Where(p => p.Price >= minUsd && p.Price <= maxUsd).ToList();
        }

        // Get properties on a specific street
        public List<Address> GetPropertiesOn(string streetName)
        {
            return Properties.Values
                .Where(p => p.Address.StreetName.Equals(streetName, StringComparison.OrdinalIgnoreCase))
                .Select(p => p.Address)
                .ToList();
        }

        // Get properties with bedrooms in range
        public Dictionary<string, Property> GetPropertiesWithBedrooms(int minBedrooms, int maxBedrooms)
        {
            return Properties
                .Where(p => p.Value.Bedrooms >= minBedrooms && p.Value.Bedrooms <= maxBedrooms)
                .ToDictionary(p => p.Key, p => p.Value);
        }

        // Get properties of a specific type
        public string GetPropertiesOfType(string propertyType)
        {
            var filteredProperties = Properties.Values
                .Where(p => p.Type.Equals(propertyType, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (filteredProperties.Count == 0)
                return $"Type: {propertyType.ToUpper()}\n<none found>";

            string result = $"Type: {propertyType.ToUpper()}";
            int count = 1;
            foreach (var property in filteredProperties)
            {
                result += $"\n{count++}) {property}";
            }
            return result;
        }
    }
}