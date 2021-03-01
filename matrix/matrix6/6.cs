using System;

namespace matrix6
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
            int length = ReadInt("length is:");
            int width = ReadInt("width is:");
            int[,] matrix = new int[length, width];
            for (int i = 0; i < width; i++)
            {

                for (int j = 0; j < length; j++)
                {
                    if (i == 0 && j >= 0 && j < length)
                    {
                        matrix[j, i] = 1;
                    }
                    else if (j == 0 && i >= 0 && i < width)
                    {
                        matrix[j,i] = 1;
                    }
                    else
                    {
                        matrix[j, i] = matrix[j, i - 1] + matrix[j - 1,i];
                    }

                }
            }
            DisplayMatrix(matrix);
            Console.ReadKey();


        }
    }
}
