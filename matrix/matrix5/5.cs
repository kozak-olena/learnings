using System;

namespace matrix5
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
            int lengthOfFirst = ReadInt("length of first matrix is:");
            int widthOfFirst = ReadInt("width of first matrix is:");
            int lengthOfsecond = ReadInt("length of second matrix is:");
            int widthOfsecond = ReadInt("width of second matrix is:");
            int[,] firstMatrix = new int[lengthOfFirst, widthOfFirst];
            int[,] secondMatrix = new int[lengthOfsecond, widthOfsecond];
            Random random = new Random();
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    firstMatrix[i, j] = random.Next(1, 15);
                }
            }
            DisplayMatrix(firstMatrix);
            Console.WriteLine();

            for (int i = 0; i < secondMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < secondMatrix.GetLength(1); j++)
                {
                    secondMatrix[i, j] = random.Next(1, 15);
                }
            }
            DisplayMatrix(secondMatrix);
            Console.WriteLine();

            if (lengthOfFirst == lengthOfsecond && widthOfFirst == widthOfsecond) //2*2; 4*4
            {
                int sum = 0;
                int[,] newMatrix = new int[lengthOfFirst, widthOfFirst];
                for (int i = 0; i < lengthOfFirst; i++)
                {
                    for (int j = 0; j < widthOfFirst; j++)
                    {
                        for (int k = 0; k < widthOfFirst; k++)
                        {
                            sum = sum + firstMatrix[k, j] * secondMatrix[i, k];
                        }
                        newMatrix[i, j] = sum;
                        sum = 0;
                    }
 
                }

                int min = 0;
                for (int i = 0; i < newMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < newMatrix.GetLength(1); j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            min = newMatrix[i, j];
                        }
                        else
                        {
                            if (newMatrix[i, j] < min)
                            {
                                min = newMatrix[i, j];
                            }
                        }
                    }
                }
                DisplayMatrix(newMatrix);
                Console.WriteLine(min);

            }
            else if (lengthOfFirst == widthOfsecond && lengthOfFirst != lengthOfsecond && widthOfFirst != widthOfsecond)
            {
                int[,] newMatrix = new int[lengthOfsecond, widthOfFirst];
                int sum = 0;
                for (int i = 0; i < lengthOfsecond; i++)
                {
                    for (int j = 0; j < widthOfFirst; j++)
                    {
                        for (int k = 0; k < widthOfsecond; k++)
                        {
                            sum = sum + firstMatrix[k, j] * secondMatrix[i, k];
                        }
                        newMatrix[i, j] = sum;
                        sum = 0;

                    }

                }
                int min = 0;
                for (int i = 0; i < newMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < newMatrix.GetLength(1); j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            min = newMatrix[i, j];
                        }
                        else
                        {
                            if (newMatrix[i, j] < min)
                            {
                                min = newMatrix[i, j];
                            }
                        }
                    }
                }
                DisplayMatrix(newMatrix);
                Console.WriteLine($"min is {min}");
            }
            else
            {
                Console.WriteLine("multiplication is impossible");
            }
            Console.ReadKey();

        }
    }
}
