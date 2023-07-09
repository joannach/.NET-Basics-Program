using System.ComponentModel.DataAnnotations;

namespace HarryPotter
{
    public class HarryPotterBookshop
    {
        private float BookPrice = 8;
        private static readonly double[] Discounts = { 0, 0, 0.95, 0.90, 0.80, 0.75 };

        public double CalculatePrice(int[] basket)
        {
            if (basket.Length == 0 || basket.Length > 5)
                return 0;

            var allBooks = basket.Sum();
            var differentBooksCount = basket.Where(b => b > 0).Count();

            return CalculateFinalPrice(allBooks, differentBooksCount);
        }

        private double CalculateFinalPrice(int allBooks, int differentBooksCount)
        {
            var booksWithoutDiscount = allBooks - differentBooksCount;

            if (differentBooksCount == 1)
                booksWithoutDiscount = 1;

            return (booksWithoutDiscount * BookPrice)
                   + differentBooksCount * BookPrice * Discounts[differentBooksCount];
        }
    }
}
