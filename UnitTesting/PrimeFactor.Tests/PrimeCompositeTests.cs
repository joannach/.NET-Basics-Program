namespace PrimeFactor.Tests
{
    public class Tests
    {
        private PrimeComposite primeComposite;
        private readonly string expectedOutput = "1 2 prime 4 prime 6 prime 8 composite 10 prime 12 prime 14 composite 16 prime 18 prime 20 composite 22 prime 24 composite 26 composite 28 prime 30 prime 32 composite 34 composite 36 prime 38 composite 40 prime 42 prime 44 composite 46 prime 48 composite 50 composite 52 prime 54 composite 56 composite 58 prime 60 prime 62 composite 64 composite 66 prime 68 composite 70 prime 72 prime 74 composite 76 composite 78 prime 80 composite 82 prime 84 composite 86 composite 88 prime 90 composite 92 composite 94 composite 96 prime 98 composite 100";

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