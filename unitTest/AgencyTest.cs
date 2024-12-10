using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment3;

namespace unitTest
{
    [TestClass]
    public class AgencyTest
    {
        [TestMethod]
        public void TestAgencyConstructor_ValidInputs()
        {
            // Arrange
            string propertyID = "A123";
            string agencyName = "BCIT Ltd";

            // Act
            var agency = new Agency(propertyID, agencyName);

            // Assert
            Assert.AreEqual(propertyID, agency.PropertyID);
            Assert.AreEqual(agencyName, agency.AgencyName);
        }

        [TestMethod]
        public void TestAgencyConstructor_InvalidInputs_ThrowsException()
        {
            // Arrange
            string invalidPropertyID = "ABCDEFG"; // Too long
            string validAgencyName = "BCIT Ltd";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new Agency(invalidPropertyID, validAgencyName));

            Assert.ThrowsException<ArgumentException>(() =>
                new Agency("A123", "")); // Empty agency name
        }

        [TestMethod]
        public void TestAddProperty_ValidProperty()
        {
            // Arrange
            var agency = new Agency("A123", "BCIT Ltd");
            var address = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            var property = new Property(500000, address, 3, true, "residence", "P001");

            // Act
            agency.AddProperty(property.PropertyID, property);

            // Assert
            Assert.AreEqual(property, agency.GetProperty(property.PropertyID));
        }

        [TestMethod]
        public void TestAddProperty_NullProperty_ThrowsException()
        {
            // Arrange
            var agency = new Agency("A123", "BCIT Ltd");

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                agency.AddProperty("P001", null));
        }

        [TestMethod]
        public void TestRemoveProperty()
        {
            // Arrange
            var agency = new Agency("A123", "BCIT Ltd");
            var address = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            var property = new Property(500000, address, 3, true, "residence", "P001");
            agency.AddProperty(property.PropertyID, property);

            // Act
            agency.RemoveProperty(property.PropertyID);

            // Assert
            Assert.IsNull(agency.GetProperty(property.PropertyID));
        }

        [TestMethod]
        public void TestGetTotalPropertyValues()
        {
            // Arrange
            var agency = new Agency("A123", "BCIT Ltd");
            var address1 = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            var address2 = new Address("2B", 456, "Broadway", "67890", "Burnaby");
            var property1 = new Property(500000, address1, 3, true, "residence", "P001");
            var property2 = new Property(750000, address2, 4, false, "residence", "P002");

            agency.AddProperty(property1.PropertyID, property1);
            agency.AddProperty(property2.PropertyID, property2);

            // Act
            double totalValue = agency.GetTotalPropertyValues();

            // Assert
            Assert.AreEqual(1250000, totalValue);
        }

        [TestMethod]
        public void TestGetPropertiesWithPools()
        {
            // Arrange
            var agency = new Agency("A123", "BCIT Ltd");
            var address1 = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            var address2 = new Address("2B", 456, "Broadway", "67890", "Burnaby");
            var property1 = new Property(500000, address1, 3, true, "residence", "P001"); // With pool
            var property2 = new Property(750000, address2, 4, false, "residence", "P002"); // No pool

            agency.AddProperty(property1.PropertyID, property1);
            agency.AddProperty(property2.PropertyID, property2);

            // Act
            var propertiesWithPools = agency.GetPropertiesWithPools();

            // Assert
            Assert.AreEqual(1, propertiesWithPools.Count);
            Assert.AreEqual(property1, propertiesWithPools[0]);
        }

        [TestMethod]
        public void TestGetPropertiesBetween()
        {
            // Arrange
            var agency = new Agency("A123", "BCIT Ltd");
            var address1 = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            var address2 = new Address("2B", 456, "Broadway", "67890", "Burnaby");
            var property1 = new Property(500000, address1, 3, true, "residence", "P001");
            var property2 = new Property(750000, address2, 4, false, "residence", "P002");

            agency.AddProperty(property1.PropertyID, property1);
            agency.AddProperty(property2.PropertyID, property2);

            // Act
            var properties = agency.GetPropertiesBetween(400000, 600000);

            // Assert
            Assert.AreEqual(1, properties.Count);
            Assert.AreEqual(property1, properties[0]);
        }

        [TestMethod]
        public void TestGetPropertiesWithBedrooms()
        {
            // Arrange
            var agency = new Agency("A123", "BCIT Ltd");
            var address1 = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            var address2 = new Address("2B", 456, "Broadway", "67890", "Burnaby");
            var property1 = new Property(500000, address1, 3, true, "residence", "P001");
            var property2 = new Property(750000, address2, 4, false, "residence", "P002");

            agency.AddProperty(property1.PropertyID, property1);
            agency.AddProperty(property2.PropertyID, property2);

            // Act
            var propertiesWithBedrooms = agency.GetPropertiesWithBedrooms(2, 3);

            // Assert
            Assert.AreEqual(1, propertiesWithBedrooms.Count);
            Assert.AreEqual(property1, propertiesWithBedrooms["P001"]);
        }

        [TestMethod]
        public void TestGetPropertiesOfType()
        {
            // Arrange
            var agency = new Agency("A123", "BCIT Ltd");
            var address1 = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            var property1 = new Property(500000, address1, 3, true, "residence", "P001");

            agency.AddProperty(property1.PropertyID, property1);

            // Act
            string result = agency.GetPropertiesOfType("residence");

            // Assert
            string expected = "Type: RESIDENCE\n1) RESIDENCE: unit #1A at 123 Main Street 12345 in Vancouver (3 bedrooms plus pool): $500000.";
            Assert.AreEqual(expected, result);
        }
    }
}
