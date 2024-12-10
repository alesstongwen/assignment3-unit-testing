using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment3; // Add this using directive to reference the Address class

namespace unitTest
{
    [TestClass]
    public class AddressTest
    {
        [TestMethod]
        public void TestAddressConstructor()
        {
            // arrange 
            string unitNumber = "1a";
            int streetNumber = 777;
            string streetName = "56th avenue";
            string postalCode = "v7n2m8";
            string city = "Surrey";

            // act 
            Address address = new Address("1a", 777, "56th avenue", "v7n2m8", "Surrey");

            // assert
            Assert.AreEqual("1a", address.UnitNumber);
            Assert.AreEqual(777, address.StreetNumber);
            Assert.AreEqual("56th avenue", address.StreetName);
            Assert.AreEqual("v7n2m8", address.PostalCode);
            Assert.AreEqual("Surrey", address.City);
        }
    }
}