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

        [TestCaseSource(typeof(LifeGridsData), nameof(LifeGridsData.BaseGenerations))]
        public void GetNextGeneration_ManyDifferentBaseGenerations(char[,] baseGeneration, char[,] nextGeneration)
        {
            // Act
            var outputGeneration = gameOfLife.GetNextGeneration(baseGeneration);

            // Assert
            Assert.AreEqual(outputGeneration, nextGeneration);
        }
    }
}