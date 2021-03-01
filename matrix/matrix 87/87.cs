using System;

namespace matrix_87
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

        static int[] GetArrayOfCurrentDiagonal(int[,] matrix, int indexI, int indexJ)
        {
            int[] arrayOfCurrentDiagonales = new int[0];
            do
            {
                arrayOfCurrentDiagonales = RewriteArray(arrayOfCurrentDiagonales, matrix[indexJ, indexI]);
                indexI++;
                indexJ--;
            }
            while (indexI < matrix.GetLength(0) && indexI >= 0 && indexJ < matrix.GetLength(0) - 1 && indexJ >= 0);

            return arrayOfCurrentDiagonales;
        }

        static int GetMaxElement(int[] arrayOfElementsOfDiagonal)
        {
            int maxElement = 0;

            for (int i = 0; i < arrayOfElementsOfDiagonal.Length; i++)
            {
                int currentElement = arrayOfElementsOfDiagonal[i];
                if (currentElement > maxElement)
                {
                    maxElement = currentElement;
                }
            }


            return maxElement;
        }

        static int[] CountMaxElements(int[,] matrix, int i, int j, int[] arrayOfMaxElements)
        {
            int maxElement = 0;
            int[] arrayOfCurrentDiagonal = GetArrayOfCurrentDiagonal(matrix, i, j);
            maxElement = GetMaxElement(arrayOfCurrentDiagonal);
            arrayOfMaxElements = RewriteArray(arrayOfMaxElements, maxElement);

            return arrayOfMaxElements;

        }


        static int[] GetArrayOfMaxElements(int[,] matrix)
        {
            int indexI = 0;
            int indexJ = 0;
            int[] arrayOfMaxElements = new int[0];

            while (indexJ < matrix.GetLength(0) - 1)
            {
                arrayOfMaxElements = CountMaxElements(matrix, indexI, indexJ, arrayOfMaxElements);
                indexJ++;
            }

            indexI++;

            while (indexI < matrix.GetLength(0))
            {
                arrayOfMaxElements = CountMaxElements(matrix, indexI, indexJ, arrayOfMaxElements);
                indexI++;
            }

            return arrayOfMaxElements;

        }

        static void DisplayArray(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"max element {i + 1} diagonal is {array[i]}");
            }

        }


        static void Main(string[] args)
        {
            int numberOfColumnsAndRows = ReadInt("length of matrix is ");
            int[,] matrix = CreateRandomMatrix(numberOfColumnsAndRows, numberOfColumnsAndRows);
            int[] arrayOfMaxElements = GetArrayOfMaxElements(matrix);
            DisplayArray(arrayOfMaxElements);

            Console.ReadKey();

        }
    }
}
