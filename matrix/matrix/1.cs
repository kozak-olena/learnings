using System;

namespace matrix
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

        static void DisplayMatrix(int [,] matrix)
        {
            int length = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            for (int i = 0;i<width;i++)
            {
                for (int j = 0; j < length; j++)
                {
                    int currentNumb = matrix[j,i];
                    Console.Write($" {currentNumb} ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            SetOfStacks x = new SetOfStacks();

            int n = ReadInt("n = ");
            int m = ReadInt("m = ");
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < m; j++)
                    {
                        int currentNumb = ReadInt("number is:");
                        matrix[i, j] = currentNumb;
                    }
                }
                else
                {
                    for (int j = m - 1; j >=0; j--) //j=m m==40; j=m-j; 
                    {
                        int currentNumb = ReadInt("number is:");
                        matrix[i, j] = currentNumb;
                    }
                }
            }
            DisplayMatrix(matrix);
            Console.ReadKey();
             

        }
    }
}
