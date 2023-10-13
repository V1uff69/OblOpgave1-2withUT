using System.Diagnostics;

namespace Bookshelf
{
    public class Book
    {
        public static int NextId = 0;
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public Book()
        {
        }

        public Book(string title, double price)
        {
            Id = NextId++;
            Title = title;
            Price = price;
        }

        /// <summary>
        /// Checks and validates if Id is less than 0 wich is illigal
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public void ValidateId()
        {
            if (Id < 0)
            {
                throw new ArgumentOutOfRangeException("Id skal være et positivt tal.");
            }
        }

        /// <summary>
        /// Checks and validates if Title meets specified Criteria or is illigal
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public void ValidateTitle()
        {
            if (string.IsNullOrEmpty(Title) || Title.Length < 3)
            {
                throw new ArgumentNullException("Title skal være mindst 3 tegn langt...");
            }
        }

        /// <summary>
        /// Checks if Price meets specified citeria or is illigal
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void ValidatePrice()
        {
            if (Price <= 0 || Price > 1200)
            {
                throw new ArgumentOutOfRangeException("Price skal være mellem 1 og 1200 kr.");
            }
        }

        public void Validate()
        {
            ValidateId();
            ValidateTitle();
            ValidatePrice();
        }

        /// <summary>
        /// //returnere contructoridholdet som en string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Price {Price}.- Kr";
        }
    }
}