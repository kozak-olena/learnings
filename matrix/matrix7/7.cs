using System;

namespace matrix7
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
            int rowsAndColums = ReadInt("length and width is:");
            int[,] matrixLatinSquare = new int[rowsAndColums, rowsAndColums];
            int[] arrayForMatrix = new int[rowsAndColums];
            for (int i = 0; i < rowsAndColums; i++)
            {
                arrayForMatrix[i] = i + 1;
            }
            for (int i = 0; i < rowsAndColums; i++)
            {
                for (int k = 0; k < rowsAndColums; k++)
                {
                    matrixLatinSquare[k, i] = arrayForMatrix[k];
                }
                int secondTemp = 0;
                int firstTemp = arrayForMatrix[0];
                arrayForMatrix[0] = arrayForMatrix[arrayForMatrix.Length - 1];

                for (int j = 1; j < rowsAndColums; j++)
                {
                    if (j % 2 == 0)
                    {
                        firstTemp = arrayForMatrix[j];
                        arrayForMatrix[j] = secondTemp;
                    }
                    else
                    {
                        secondTemp = arrayForMatrix[j];
                        arrayForMatrix[j] = firstTemp;

                    }


                }

            }
            DisplayMatrix(matrixLatinSquare);
            Console.ReadKey();


        }
    }
}
