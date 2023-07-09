namespace GameOfLife.Tests
{
    public class GameOfLifeTests
    {
        public GameOfLife gameOfLife;

        [SetUp]
        public void TestSetUp()
        {
            gameOfLife = new GameOfLife();
        }

        [TestCaseSource(nameof(GetNextGenerationTestCases))]
        public void GetNextGeneration_ManyDifferentBaseGenerations(char[,] baseGeneration, char[,] nextGeneration)
        {
            // Act
            var outputGeneration = gameOfLife.GetNextGeneration(baseGeneration);

            // Assert
            Assert.AreEqual(outputGeneration, nextGeneration);
        }

        private static object[] GetNextGenerationTestCases =
        {
            new object[]
            {
                new char[,]
                {
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' }
                },
                new char[,]
                {
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' }
                }
            },
            new object[]
            {
                new char[,]
                {
                    { '.', '.', '.', '.' },
                    { '.', '*', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' }
                },
                new char[,]
                {
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' }
                }
            },
            new object[]
            {
                new char[,]
                {
                    { '.', '.', '.', '.' },
                    { '.', '*', '*', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' }
                },
                new char[,]
                {
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' }
                }
            },
            new object[]
            {
                new char[,]
                {
                    { '.', '.', '.', '.' },
                    { '.', '*', '.', '.' },
                    { '.', '*', '.', '.' },
                    { '.', '.', '.', '.' }
                },
                new char[,]
                {
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' },
                    { '.', '.', '.', '.' }
                }
            }
        };
    }
}