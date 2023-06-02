using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PrintFirstCharacter();
        }

        public static void PrintFirstCharacter()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter a line of text (or press Enter to quit): ");
                    string line = Console.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }

                    char firstChar = line[0];
                    Console.WriteLine("First character: " + firstChar);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Empty line! Please enter a valid line of text.");
                }
            }
        }
    }
}