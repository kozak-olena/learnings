using System;

namespace matrix_3
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
            int[,] firstMatrix = new int [length,width];
            int[] vector = new int[width];
            int[] resultVector = new int[width];
            Random random = new Random();
            for (int i = 0; i<length;i++)
            {
                for (int j = 0;j<width;j++)
                {
                    int currentNumber = random.Next(0,10);
                    firstMatrix[i,j] = currentNumber;
                }
            }
            DisplayMatrix(firstMatrix);
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                int currentNumber = random.Next(0,10);
                vector[i] = currentNumber;
                Console.Write($" {vector[i]} ");
            }
            Console.WriteLine();
            for (int i = 0; i<length;i++)
            {
                int resultMatrixElement = firstMatrix[0,i]*vector[0]+firstMatrix[1,i]*vector[1]+firstMatrix[2,i]*vector[2];
                resultVector[i] = resultMatrixElement;
            }
            Console.Write($"{resultVector[0]} {resultVector[1]} {resultVector[2]}");
            Console.ReadKey();
            

        }
    }
}
