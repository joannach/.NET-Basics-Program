using System.Collections;

namespace GameOfLife.Tests
{
    public class LifeGridsData
    {
        public static IEnumerable BaseGenerations
        {
            get
            {
                yield return new TestCaseData(new char[,]
                    {
                        { '.', '.', '.' },
                        { '.', '*', '.' },
                        { '.', '.', '.' }
                    })
                    .Returns(new char[,]
                    {
                        { '.', '.', '.' },
                        { '.', '.', '.' },
                        { '.', '.', '.' }
                    });
                yield return new TestCaseData(new char[,]
                    {
                        { '*', '*', '*' },
                        { '*', '*', '*' },
                        { '*', '*', '*' }
                    })
                    .Returns(new char[,]
                    {
                        { '*', '.', '*' },
                        { '.', '.', '.' },
                        { '*', '.', '*' }
                    });
                yield return new TestCaseData(12, 4).Returns(3);
            }
        }
    }
}