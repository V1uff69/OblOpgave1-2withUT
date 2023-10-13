using Bookshelf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Bookshelf_UnitTest
{
    /// <summary>
    /// Unit tests for the Book class.
    /// </summary>
    [TestClass]
    public class UnitTestBook
    {
        private Book book = new Book("Anne og Arne", 420);
        private Book bookNegativeId = new Book("Negative Id", 123);
        private Book bookTitleNull = new Book(null, 69);
        private Book bookTitleTooShort = new Book("Me", 88);
        private Book bookPriceTooHigh = new Book("This price is too high", 1201);
        private Book bookPriceNegative = new Book("This price is negative", -1);

        /// <summary>
        /// Tests the ToString method of the Book class.
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            //act
            string str = book.ToString();

            //assert
            Assert.AreEqual(str, "Id: 0, Title: Anne og Arne, Price 420.- Kr");
        }

        /// <summary>
        /// Tests the ValidateId method with a negative ID.
        /// </summary>
        [TestMethod]

        public void TestNegativeId()
        {
            bookNegativeId.Id = -1;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookNegativeId.Validate());
        }

        /// <summary>
        /// Tests the ValidateTitle method with a null title.
        /// </summary>
        [TestMethod]
        public void TestTitleNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => bookTitleNull.Validate());
        }

        /// <summary>
        /// Tests the ValidateTitle method with a title that is too short.
        /// </summary>
        [TestMethod]
        public void TestTitleTooShort()
        {
            Assert.ThrowsException<ArgumentNullException>(() => bookTitleTooShort.Validate());
        }

        /// <summary>
        /// Tests the ValidatePrice method with a price that is too high.
        /// </summary>
        [TestMethod]
        public void TestPriceTooHigh()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceTooHigh.Validate());
        }

        /// <summary>
        /// Test the ValidatePrice method with a price that is negative
        /// </summary>
        public void TestPriceTooLow()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceNegative.Validate());
        }

        /// <summary>
        /// Tests the ValidatePrice method with a negative price and various other price values.
        /// </summary>
        [TestMethod()]
        [DataRow(-500)]
        [DataRow(0)]
        [DataRow(25)]
        [DataRow(1500)]
        [DataRow(1200)]
        public void TestPrice(double Price)
        {
            book.Price = Price;
            if (Price <= 0 || Price > 1200)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => book.ValidatePrice());
            }
            else
                book.ValidatePrice();
        }

    }
}
