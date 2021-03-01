using System;
using System.Diagnostics;

namespace matrix_92
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

        static void DisplayMatrix(int[,] matrix, int numberOfRows, int numberOfColumns)
        {

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    int currentNumb = matrix[j, i];
                    string currentNumbString = $" {currentNumb} ";
                    Console.Write(currentNumbString.PadLeft(4));
                }
                Console.WriteLine();
            }
        }

        static int[,] CreateRandomMatrix(int numberOfRows, int numberOfColumns)
        {
            int[,] matrix = new int[numberOfColumns, numberOfRows];
            Random random = new Random();
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    matrix[j, i] = random.Next(1, 51);
                }
            }
            DisplayMatrix(matrix, numberOfRows, numberOfColumns);
            return matrix;
        }

        static int[] RewriteArray(int[] array, int elementAndItsCoordinates)
        {
            int[] resultOfArray = new int[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                resultOfArray[i] = array[i];
            }
            resultOfArray[resultOfArray.Length - 1] = elementAndItsCoordinates;
            return resultOfArray;
        }

        static int[,] ResetToZero(int[,] matrix)
        {

            int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(0)];
            int currentIndexOfColumn = 0;
            int currentIndexOfRow = 0;


            for (int i = 0; i <= matrix.GetLength(0) / 2; i++)
            {
                while (currentIndexOfColumn < matrix.GetLength(0))
                {
                    newMatrix[currentIndexOfColumn, i] = matrix[currentIndexOfColumn, i];
                    currentIndexOfColumn++;

                    while (currentIndexOfColumn >= i + 1 && currentIndexOfColumn < matrix.GetLength(0) - i - 1)
                    {
                        newMatrix[currentIndexOfColumn, i] = 0;
                        currentIndexOfColumn++;
                    }
                }

                currentIndexOfColumn = 0;
                currentIndexOfRow++;
            }

            for (int i = currentIndexOfRow; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    newMatrix[j, i] = matrix[j, i];
                }
            }

            return newMatrix;

        }

        static void Main(string[] args)
        {
            int lenthOfMatrix = ReadInt("length of matrix is ");
            int[,] matrix = CreateRandomMatrix(lenthOfMatrix, lenthOfMatrix);
            int[,] tempMatrix = new int[lenthOfMatrix, lenthOfMatrix];
            int centreOfMatrix = matrix.GetLength(0) - 1 / 2;
            tempMatrix = ResetToZero(matrix);

            Console.WriteLine();

            DisplayMatrix(tempMatrix, tempMatrix.GetLength(0), tempMatrix.GetLength(0));

            Console.ReadKey();

        }
    }
}
