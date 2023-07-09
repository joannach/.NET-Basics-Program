namespace GameOfLife
{
    public class GameOfLife
    {
        int[][] directions = new int[][]
{
            new int[] { -1, -1 },  
            new int[] { -1, 0 },   
            new int[] { -1, 1 },   
            new int[] { 0, -1 },  
            new int[] { 0, 1 },    
            new int[] { 1, -1 },  
            new int[] { 1, 0 },    
            new int[] { 1, 1 }
};
        public GameOfLife() { }

        public char[,] GetNextGeneration(char[,] baseGeneration)
        {
            int rows = baseGeneration.GetLength(0);
            int cols = baseGeneration.GetLength(1);
            char[,] nextGeneration = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int liveNeighbors = 0;

                    foreach (int[] direction in directions)
                    {
                        int neighborRow = row + direction[0];
                        int neighborCol = col + direction[1];

                        if (neighborRow >= 0 && neighborRow < rows && neighborCol >= 0 && neighborCol < cols &&
                            baseGeneration[neighborRow, neighborCol] == '*')
                        {
                            liveNeighbors++;
                        }
                    }

                    char cell = baseGeneration[row, col];

                    if (cell == '*')
                    {
                        if (liveNeighbors < 2 || liveNeighbors > 3)
                        {
                            nextGeneration[row, col] = '.';
                        }
                        else
                        {
                            nextGeneration[row, col] = '*';
                        }
                    }
                    else if (cell == '.')
                    {
                        if (liveNeighbors == 3)
                        {
                            nextGeneration[row, col] = '*';
                        }
                        else
                        {
                            nextGeneration[row, col] = '.';
                        }
                    }
                }
            }

            return nextGeneration;
        }
    }
}
