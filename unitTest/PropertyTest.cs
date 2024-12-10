using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment3;

namespace unitTest
{
    [TestClass]
    public class PropertyTest
    {
        [TestMethod]
        public void TestPropertyConstructor_ValidInputs()
        {
            // Arrange
            Address address = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            double price = 500000;
            int bedrooms = 3;
            bool swimmingPool = true;
            string type = "residence";
            string propertyID = "abc123";

            // Act
            var property = new Property(price, address, bedrooms, swimmingPool, type, propertyID);

            // Assert
            Assert.AreEqual(price, property.Price);
            Assert.AreEqual(address, property.Address);
            Assert.AreEqual(bedrooms, property.Bedrooms);
            Assert.AreEqual(swimmingPool, property.SwimmingPool);
            Assert.AreEqual("residence", property.Type);
            Assert.AreEqual(propertyID, property.PropertyID);
        }

        [TestMethod]
        public void TestPropertyConstructor_InvalidPrice_ThrowsException()
        {
            // Arrange
            Address address = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            double invalidPrice = -1;
            int bedrooms = 3;
            bool swimmingPool = true;
            string type = "residence";
            string propertyID = "abc123";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new Property(invalidPrice, address, bedrooms, swimmingPool, type, propertyID));
        }

        [TestMethod]
        public void TestPropertyConstructor_InvalidBedrooms_ThrowsException()
        {
            // Arrange
            Address address = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            double price = 500000;
            int invalidBedrooms = -1;
            bool swimmingPool = true;
            string type = "residence";
            string propertyID = "abc123";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new Property(price, address, invalidBedrooms, swimmingPool, type, propertyID));
        }

        [TestMethod]
        public void TestPropertyConstructor_InvalidPropertyID_ThrowsException()
        {
            // Arrange
            Address address = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            double price = 500000;
            int bedrooms = 3;
            bool swimmingPool = true;
            string type = "residence";
            string invalidPropertyID = "abcdefg"; // Too long (7 characters)

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new Property(price, address, bedrooms, swimmingPool, type, invalidPropertyID));
        }

        [TestMethod]
        public void TestSetPrice_ValidPrice()
        {
            // Arrange
            Address address = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            var property = new Property(500000, address, 3, true, "residence", "abc123");
            double newPrice = 600000;

            // Act
            property.SetPrice(newPrice);

            // Assert
            Assert.AreEqual(newPrice, property.Price);
        }

        [TestMethod]
        public void TestSetPrice_InvalidPrice_ThrowsException()
        {
            // Arrange
            Address address = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            var property = new Property(500000, address, 3, true, "residence", "abc123");
            double invalidPrice = -1;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                property.SetPrice(invalidPrice));
        }

        [TestMethod]
        public void TestToString_ValidOutput()
        {
            // Arrange
            Address address = new Address("1A", 123, "Main Street", "12345", "Vancouver");
            var property = new Property(500000, address, 3, true, "residence", "abc123");

            // Act
            string result = property.ToString();

            // Assert
            string expected = "RESIDENCE: unit #1A at 123 Main Street 12345 in Vancouver (3 bedrooms plus pool): $500000.";
            Assert.AreEqual(expected, result);
        }
    }
}
