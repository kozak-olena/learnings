using System;

namespace matrix2
{
    class Program
    {
        static int ReadInt(string question)
        {
            Console.Write(question);
            string answer = Console.ReadLine();
            int result = int.Parse(answer);
            return result;
        }

        static void DisplayMatrix(int[,] matrix)
        {
            int length = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    int currentNumb = matrix[j, i];
                    Console.Write($" {currentNumb} ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int length = 3;
            int width = 3;
            int[,] firstMatrix = new int[length, width];
            int[,] secondMatrix = new int[length, width];
            int[,] sumOfMatrix = new int[length, width];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {

                    int currentNumber = random.Next(0, 10);
                    firstMatrix[i, j] = currentNumber;
                }
            }
            DisplayMatrix(firstMatrix);
            Console.WriteLine();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {

                    int currentNumber = random.Next(0, 10);
                    secondMatrix[i, j] = currentNumber;
                }
            }
            DisplayMatrix(secondMatrix);
            Console.WriteLine();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {                                                                         //   a b c    
                    sumOfMatrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];            //a  5 5 5 
                }                                                                         //b  0 0 0 
            }                                                                             //c  1 1 1 
            DisplayMatrix(sumOfMatrix);
            Console.WriteLine();

            int sumOfDiagonals = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j == i)
                    {
                        sumOfDiagonals = sumOfDiagonals + sumOfMatrix[i, j];
                    }
                }
            }
            Console.WriteLine($"sum of diagonals: {sumOfDiagonals}");
            Console.ReadKey();
        }
    }
}
