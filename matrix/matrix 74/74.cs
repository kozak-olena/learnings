using System;

namespace matrix_74
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

        static int[] SortArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    int firstNumb = array[j];
                    int secNumb = array[j + 1];
                    if (secNumb < firstNumb)
                    {
                        array[j + 1] = firstNumb;
                        array[j] = secNumb;

                    }
                }
            }
            return array;
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

      


        static int[] GiveArrayOfNeighbours(int[,] matrix, int indexI, int indexJ)
        {
            int[] arrayOfNeigbours = new int[0];
            int x = indexJ;
            int y = indexI;

            if (indexI - 1 >= 0 && indexI < matrix.GetLength(1) && indexJ - 1 >= 0 && indexJ < matrix.GetLength(0))
            {
                arrayOfNeigbours = RewriteArray(arrayOfNeigbours, matrix[indexJ - 1, indexI - 1]);
            }

            if (indexI - 1 >= 0 && indexI < matrix.GetLength(1) && indexJ >= 0 && indexJ < matrix.GetLength(0))
            {
                arrayOfNeigbours = RewriteArray(arrayOfNeigbours, matrix[indexJ, indexI - 1]);
            }

            if (indexI - 1 >= 0 && indexI < matrix.GetLength(1) && indexJ + 1 >= 0 && indexJ + 1 < matrix.GetLength(0))
            {
                arrayOfNeigbours = RewriteArray(arrayOfNeigbours, matrix[indexJ + 1, indexI - 1]);
            }

            if (indexI >= 0 && indexI < matrix.GetLength(1) && indexJ + 1 >= 0 && indexJ + 1 < matrix.GetLength(0))
            {
                arrayOfNeigbours = RewriteArray(arrayOfNeigbours, matrix[indexJ + 1, indexI]);
            }

            if (indexI + 1 >= 0 && indexI + 1 < matrix.GetLength(1) && indexJ + 1 >= 0 && indexJ + 1 < matrix.GetLength(0))
            {
                arrayOfNeigbours = RewriteArray(arrayOfNeigbours, matrix[indexJ + 1, indexI + 1]);
            }

            if (indexI + 1 >= 0 && indexI + 1 < matrix.GetLength(1) && indexJ >= 0 && indexJ < matrix.GetLength(0))
            {
                arrayOfNeigbours = RewriteArray(arrayOfNeigbours, matrix[indexJ, indexI + 1]);
            }

            if (indexI + 1 >= 0 && indexI + 1 < matrix.GetLength(1) && indexJ - 1 >= 0 && indexJ - 1 < matrix.GetLength(0))
            {
                arrayOfNeigbours = RewriteArray(arrayOfNeigbours, matrix[indexJ - 1, indexI + 1]);
            }

            if (indexI >= 0 && indexI < matrix.GetLength(1) && indexJ - 1 >= 0 && indexJ - 1 < matrix.GetLength(0))
            {
                arrayOfNeigbours = RewriteArray(arrayOfNeigbours, matrix[indexJ - 1, indexI]);
            }


            return arrayOfNeigbours;
        }

        static bool IsItLocalMin(int[] arrayOfNeighbours, int localMinimum)
        {
            arrayOfNeighbours = SortArray(arrayOfNeighbours);
            bool isItLocalMinimum = false;

            for (int i = 0; i < arrayOfNeighbours.Length - 1; i++)
            {
                if (localMinimum > arrayOfNeighbours[i])
                {
                    isItLocalMinimum = false;
                    return isItLocalMinimum;
                }
                else
                {
                    isItLocalMinimum = true;
                }
            }

            return isItLocalMinimum;
        }


        static void Main(string[] args)
        {

            int numberOfRows = ReadInt("number of rows is:");
            int numberOfColumns = ReadInt("number of columns is: ");
            int[,] matrix = CreateRandomMatrix(numberOfRows, numberOfColumns);
            int[,] auxiliaryMatrix = new int[numberOfColumns, numberOfRows];
            int[] arrayOfNeighbours = new int[0];
            int localMinimum = 0;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    localMinimum = matrix[j, i];
                    arrayOfNeighbours = GiveArrayOfNeighbours(matrix, i, j);
                    bool isItLocalMin = IsItLocalMin(arrayOfNeighbours, localMinimum);

                    if (isItLocalMin)
                    {
                        auxiliaryMatrix[j, i] = 0;
                    }
                    else
                    {
                        auxiliaryMatrix[j, i] = localMinimum;
                    }
                }
            }
            Console.WriteLine();
            DisplayMatrix(auxiliaryMatrix, numberOfRows, numberOfColumns);

            Console.ReadKey();

        }
    }
}
