using System;

namespace matrix_46
{
    class TryFindElement
    {
        public int Element;
        public bool Successes;
        public TryFindElement(int elemnt, bool successes)
        {
            Element = elemnt;
            Successes = successes;
        }

    }
    class Program
    {
        static int[] RewriteNumberOfCoinsidingNumbersAndItsLine(int[] array, int newElement)
        {
            int arrayLength = 0;
            if (array != null)
            {
                arrayLength = array.Length;
            }
            int[] result = new int[arrayLength + 1];
            for (int j = 0; j < arrayLength; j++)
            {
                result[j] = array[j];

            }
            result[result.Length - 1] = newElement;
            return result;


        }
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

        static int[] GetArrayOfTheRow(int indexI, int[,] matrix, int numberOfColumns)
        {
            int[] currentArray = new int[numberOfColumns];
            for (int j = 0; j < numberOfColumns; j++)
            {
                currentArray[j] = matrix[j, indexI];
            }

            return currentArray;
        }

        static int[] GetArrayOfTheColumn(int indexJ, int[,] matrix, int numberOfRows)
        {
            int[] currentArray = new int[numberOfRows];
            for (int i = 0; i < numberOfRows; i++)
            {
                currentArray[i] = matrix[indexJ, i];
            }

            return currentArray;
        }

        static bool IsItMaxElementInRow(int[] arrayOfMatrixsLine, int indexOfElement)
        {
            bool isItMaxElement = false;
            int i = indexOfElement;
            int currentChekingElement = arrayOfMatrixsLine[i];
            int j = 0;

            while (j != arrayOfMatrixsLine.Length)
            {
                int currentElementOfLine = arrayOfMatrixsLine[j];
                if (i != j)
                {
                    if (currentChekingElement < currentElementOfLine)
                    {
                        isItMaxElement = false;
                        return isItMaxElement;
                    }
                    else
                    {
                        j++;
                        isItMaxElement = true;
                    }
                }
                else
                {
                    j++;
                }

            }

            return isItMaxElement;
        }

        static bool IsItMinElementInTheColumn(int[] arrayOfMatrixsColumn, int indexOfElement)
        {
            bool isItMinElement = false;
            int j = indexOfElement;
            int currentCheckingElement = arrayOfMatrixsColumn[j];
            int i = 0;

            while (i != arrayOfMatrixsColumn.Length)
            {
                if (i != j)
                {
                    int currentElementOfTheColumn = arrayOfMatrixsColumn[i];

                    if (currentElementOfTheColumn < currentCheckingElement)
                    {
                        isItMinElement = false;
                        return isItMinElement;
                    }
                    else
                    {
                        i++;
                        isItMinElement = true;
                    }

                }
                else
                {
                    i++;
                }
            }
            return isItMinElement;

        }

        static TryFindElement TryFindElement(int[,] matrix, int indexOfRow, int indexOfColumn, int numberOfRows, int numberOfColumns)
        {
            int element = 0;
            bool successes = false;
            TryFindElement tryFindElement = new TryFindElement (element, successes);
            
            int[] currentArrayOfRow = GetArrayOfTheRow(indexOfRow, matrix, numberOfColumns);
            bool isItMaxElement = IsItMaxElementInRow(currentArrayOfRow, indexOfColumn);

            if (isItMaxElement)
            {
                int[] currentArrayOfColumn = GetArrayOfTheColumn(indexOfColumn, matrix, numberOfRows);
                bool isItMaxAndMinElement = IsItMinElementInTheColumn(currentArrayOfColumn, indexOfRow);

                if (isItMaxAndMinElement)
                {
                    successes = true;
                    element = matrix[indexOfColumn, indexOfRow];
                    Console.WriteLine(indexOfColumn);
                    Console.WriteLine(indexOfRow);
                }

            }
            tryFindElement.Element = element;
            tryFindElement.Successes = successes;

            return tryFindElement;
        }


        static void Main(string[] args)
        {
            int numberOfRows = ReadInt("number of rows is:");
            int numberOfColumns = ReadInt("number of columns is: ");
            int[,] matrix = CreateRandomMatrix(numberOfRows, numberOfColumns);
            int[] arrayOfCurrentLine = new int[numberOfColumns];
            int[] arrayOfcurrentColumn = new int[numberOfRows];
            int currentElement = 0;
            bool isItElement = false;
            TryFindElement tryFindElement = new TryFindElement(currentElement,isItElement);
            int countElements = 0;

            for (int j = 0; j < numberOfRows; j++)
            {
                int k = 0;

                while (k != numberOfColumns)
                {
                    tryFindElement = TryFindElement(matrix, j, k, numberOfRows, numberOfColumns);
                    if (tryFindElement.Successes)
                    {
                        Console.WriteLine($"{tryFindElement.Element}:{k}, {j}");
                        countElements++;
                    }
                    k++;
                }


            }

            if (countElements == 0)
            {
                Console.WriteLine(countElements);
            }
            Console.ReadKey();


        }
    }
}


