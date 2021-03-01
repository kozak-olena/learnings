using System;

namespace matrix4
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
            int length = ReadInt("length = ");
            int width = ReadInt("width = ");
            int[,] matrixA = new int[length, width];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrixA[i, j] = random.Next(0, 10);
                }
            }
            DisplayMatrix(matrixA);
            Console.WriteLine();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write($"{matrixA[j, i]} ");
                    if (j == length - 1 - i)
                    {
                        // int tepm = i;
                        int newI = j;
                        // i = j;
                        // j = tepm + 1;
                       int newJ =i+1;
                        Console.WriteLine();
                        while (newJ != width)
                        {
                            for (int k = 0; k < j; k++)
                            {
                                Console.Write("  ");
                            }
                            //Console.WriteLine(matrixA[i, j]);
                            Console.WriteLine(matrixA[newI, newJ]);
                            newJ++;
                        }
                        break;
                       // i = tepm;
                       // tepm = 0;
                    }

                }
                Console.WriteLine();

            }
            Console.ReadKey();
        }
    }
}
