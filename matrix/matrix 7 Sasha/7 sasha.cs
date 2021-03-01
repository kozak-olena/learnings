using System;

namespace matrix_7_Sasha
{
    class Program

    {
        static void ShiftArrayElementsByN(int[] array, int n)
        {
            int[] arrayForTempElements = new int[n];
            int index = 0;
            for (int i = array.Length - n; i < array.Length; i++)
            {

                arrayForTempElements[index] = array[i];
                index++;
            }
            for (int i = array.Length - n - 1; i >= 0; i--)
            {
                array[i + n] = array[i];

            }
            for (int i = 0; i < n; i++)
            {
                array[i] = arrayForTempElements[i];
            }

        }


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
                ShiftArrayElementsByN(arrayForMatrix,1);

            }
            DisplayMatrix(matrixLatinSquare);
            Console.ReadKey();
        }
    }
}
