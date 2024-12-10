using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment3;

namespace unitTest
{
    [TestClass]
    public class AddressTest
    {
        [TestMethod]
        public void TestAddressConstructor_ValidInputs()
        {
            // Arrange
            string unitNumber = "1A";
            int streetNumber = 123;
            string streetName = "Main Street";
            string postalCode = "12345";
            string city = "Vancouver";

            // Act
            var address = new Address(unitNumber, streetNumber, streetName, postalCode, city);

            // Assert
            Assert.AreEqual("unit #1A at 123 Main Street 12345 in Vancouver", address.ToString());
        }

        [TestMethod]
        public void TestAddressConstructor_InvalidUnitNumber_ThrowsException()
        {
            // Arrange
            string unitNumber = "12345"; // Invalid length (>4)
            int streetNumber = 123;
            string streetName = "Main Street";
            string postalCode = "12345";
            string city = "Vancouver";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new Address(unitNumber, streetNumber, streetName, postalCode, city));
        }

        [TestMethod]
        public void TestAddressConstructor_InvalidStreetNumber_ThrowsException()
        {
            // Arrange
            string unitNumber = "1A";
            int streetNumber = 100000; // Invalid (too large)
            string streetName = "Main Street";
            string postalCode = "12345";
            string city = "Vancouver";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new Address(unitNumber, streetNumber, streetName, postalCode, city));
        }

        [TestMethod]
        public void TestAddressConstructor_InvalidPostalCode_ThrowsException()
        {
            // Arrange
            string unitNumber = "1A";
            int streetNumber = 123;
            string streetName = "Main Street";
            string invalidPostalCode1 = "1234";    // Invalid length (4)
            string invalidPostalCode2 = "1234567"; // Invalid length (7)
            string city = "Vancouver";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new Address(unitNumber, streetNumber, streetName, invalidPostalCode1, city));

            Assert.ThrowsException<ArgumentException>(() =>
                new Address(unitNumber, streetNumber, streetName, invalidPostalCode2, city));
        }

        [TestMethod]
        public void TestAddressConstructor_InvalidCity_ThrowsException()
        {
            // Arrange
            string unitNumber = "1A";
            int streetNumber = 123;
            string streetName = "Main Street";
            string postalCode = "12345";
            string invalidCity = ""; // Invalid (empty)

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new Address(unitNumber, streetNumber, streetName, postalCode, invalidCity));
        }
    }
}
