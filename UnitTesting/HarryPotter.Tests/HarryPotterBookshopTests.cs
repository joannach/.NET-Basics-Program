namespace HarryPotter.Tests
{
    [TestFixture]
    public class HarryPotterBookshopTests
    {
        public HarryPotterBookshop harryPotterBookshop;

        [SetUp]
        public void Setup()
        {
            harryPotterBookshop = new HarryPotterBookshop();
        }

        [Test]
        public void CalculatePrice_EmptyBasket_ReturnsZero()
        {
            // Arrange
            var basket = new int[5];

            // Act
            var price = harryPotterBookshop.CalculatePrice(basket);

            // Assert
            Assert.AreEqual(0, price);
        }

        [Test]
        public void CalculatePrice_SingleBook_ReturnsPriceWithoutDiscount()
        {
            // Arrange
            var basket = new int[5] { 1, 0, 0, 0, 0 };

            // Act
            var price = harryPotterBookshop.CalculatePrice(basket);

            // Assert
            Assert.AreEqual(8, price);
        }

        [Test]
        public void CalculatePrice_TwoDifferentBooks_ReturnsPriceWith5PercentDiscount()
        {
            // Arrange
            var basket = new int[5] { 1, 1, 0, 0, 0 };

            // Act
            var price = harryPotterBookshop.CalculatePrice(basket);

            // Assert
            Assert.AreEqual(2 * 8 * 0.95, price);
        }

        [Test]
        public void CalculatePrice_ThreeDifferentBooks_ReturnsPriceWith10PercentDiscount()
        {
            // Arrange
            var basket = new int[5] { 1, 1, 1, 0, 0 };

            // Act
            var price = harryPotterBookshop.CalculatePrice(basket);

            // Assert
            Assert.AreEqual(3 * 8 * 0.9, price);
        }

        [Test]
        public void CalculatePrice_FourDifferentBooks_ReturnsPriceWith20PercentDiscount()
        {
            // Arrange
            var basket = new int[5] { 1, 1, 1, 1, 0 };

            // Act
            var price = harryPotterBookshop.CalculatePrice(basket);

            // Assert
            Assert.AreEqual(4 * 8 * 0.8, price);
        }

        [Test]
        public void CalculatePrice_AllBooks_ReturnsPriceWith25PercentDiscount()
        {
            // Arrange
            var basket = new int[5] { 1, 1, 1, 1, 1 };

            // Act
            var price = harryPotterBookshop.CalculatePrice(basket);

            // Assert
            Assert.AreEqual(5 * 8 * 0.75, price);
        }

        [Test]
        public void CalculatePrice_MultipleBooks_ReturnsCorrectPrice()
        {
            // Arrange
            var basket = new int[5] { 2, 2, 2, 1, 1 };

            // Act
            var price = harryPotterBookshop.CalculatePrice(basket);

            // Assert
            Assert.AreEqual(51.60, price);
        }
    }
}