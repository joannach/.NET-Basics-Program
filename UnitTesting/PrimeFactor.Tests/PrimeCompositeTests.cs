namespace PrimeFactor.Tests
{
    public class Tests
    {
        private PrimeComposite primeComposite;
        private readonly string expectedOutput = "1 2 prime 4 composite 6 composite 8 composite 10 composite " +
                "prime 12 composite 14 composite 16 composite 18 composite prime 20 composite " +
                "22 composite prime 24 composite 26 composite 28 composite prime 30 composite " +
                "32 composite 34 composite 36 composite prime 38 composite 40 composite " +
                "prime 42 composite 44 composite 46 composite prime 48 composite 50 composite " +
                "52 composite 54 composite prime 56 composite 58 composite 60 composite prime " +
                "62 composite prime 64 composite 66 composite 68 composite prime 70 composite " +
                "72 composite 74 composite 76 composite prime 78 composite 80 composite " +
                "prime 82 composite 84 composite 86 composite prime 88 composite 90 composite " +
                "92 composite 94 composite prime 96 composite 98 composite 100 composite";

        [SetUp]
        public void Setup()
        {
            primeComposite = new PrimeComposite();
        }

        [Test]
        public void PrintNumbersInRange_PrintsNumbersCorrectly()
        {
            // Arrange
            int start = 1;
            int end = 100;

            // Act
            string actualOutput = primeComposite.GetPrimeCompositeNumbers(start, end);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(3, false)]
        [TestCase(4, true)]
        [TestCase(5, false)]
        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(8, true)]
        [TestCase(9, true)]
        [TestCase(10, true)]
        public void IsComposite_ReturnsCorrectResult(int number, bool expectedResult)
        {
            // Act
            bool actualResult = primeComposite.IsComposite(number);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(5, true)]
        [TestCase(6, false)]
        [TestCase(7, true)]
        [TestCase(8, false)]
        [TestCase(9, false)]
        [TestCase(10, false)]
        public void IsPrime_ReturnsCorrectResult(int number, bool expectedResult)
        {
            // Act
            bool actualResult = primeComposite.IsPrime(number);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}