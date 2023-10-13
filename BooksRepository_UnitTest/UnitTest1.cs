using Bookshelf;

namespace BooksRepository_UnitTest
{

    [TestClass]
    public class BooksRepositoryxTests
    {
        /// <summary>
        /// testing Get method with range of price and sorting by title.
        /// </summary>
        [TestMethod]
        public void Get_WithPriceRange_SortByTitle()
        {
            // Arrange
            var repository = new BooksRepository();

            // Act
            List<Book> result = repository.Get(50, 500, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count); // Expected number of books in the price range [50, 500]
            Assert.AreEqual("Disney: Peter Plys", result[0].Title); // Assuming sorting by title
            Assert.AreEqual("The Snowman", result[3].Title);
        }

        /// <summary>
        /// testing with a pricerange max and sorting by price
        /// </summary>
        [TestMethod]
        public void Get_WithMaxPrice_SortByPrice()
        {
            // Arrange
            var repository = new BooksRepository();

            // Act
            List<Book> result = repository.Get(0, 200, false);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count); // Expected number of books with a price less than or equal to 200
            Assert.AreEqual("Flip", result[0].Title); // Assuming sorting by price
            Assert.AreEqual("Disney: Peter Plys", result[2].Title);
        }

        /// <summary>
        /// testing with no pricefilter and sorting by Title.
        /// </summary>
        [TestMethod]
        public void Get_WithNoPriceFilter_SortByTitle()
        {
            // Arrange
            var repository = new BooksRepository();

            // Act
            List<Book> result = repository.Get(null, null, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count); // Expected number of books with no price filter
            Assert.AreEqual("Disney: Peter Plys", result[0].Title); // Assuming sorting by title
        }

        /// <summary>
        /// Deletes object from list matching Id.
        /// </summary>
        /// <param name="id">set to 1 by datarow</param>
        [TestMethod()]
        [DataRow(1)]
        public void DeleteById(int id)
        {
            //Arrange
            var repository = new BooksRepository();

            //Act
            Book result = repository.Delete(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Disney: Peter Plys", result.Title);
        }
    }
}