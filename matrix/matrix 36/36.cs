using System;

namespace matrix_36
{
    class NumberOfCoinsidingNumbersAndItsLine
    {
        public int NumberOfCoinsidingNumbers;
        public int NumberOfCurrentLine;
        public NumberOfCoinsidingNumbersAndItsLine(int numberOfCoinsidingElements, int numberOfLine)
        {
            NumberOfCoinsidingNumbers = numberOfCoinsidingElements;
            NumberOfCurrentLine = numberOfLine;
        }
    }
    class Program
    {
        static NumberOfCoinsidingNumbersAndItsLine[] RewriteNumberOfCoinsidingNumbersAndItsLine(NumberOfCoinsidingNumbersAndItsLine[] array, NumberOfCoinsidingNumbersAndItsLine newElement)
        {
            int arrayLength = 0;
            if (array != null)
            {
                arrayLength = array.Length;
            }
            NumberOfCoinsidingNumbersAndItsLine[] result = new NumberOfCoinsidingNumbersAndItsLine[arrayLength + 1];
            for (int j = 0; j < arrayLength; j++)
            {
                result[j] = array[j];

            }
            result[result.Length - 1] = newElement;
            return result;


        }
        static int[] SortArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length-1; j++)
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
        static NumberOfCoinsidingNumbersAndItsLine[] SortNumberOfCoinsidingNumbersAndItsLines(NumberOfCoinsidingNumbersAndItsLine[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length-1; j++)
                {
                    NumberOfCoinsidingNumbersAndItsLine firstNumb = array[j];
                    int firstNumber = firstNumb.NumberOfCoinsidingNumbers;
                    NumberOfCoinsidingNumbersAndItsLine secNumb = array[j + 1];
                    int secondNumber = secNumb.NumberOfCoinsidingNumbers;
                    if (secondNumber < firstNumber)
                    {
                        array[j + 1] = firstNumb;
                        array[j] = secNumb;

                    }
                }
            }
            return array;
        }

        static NumberOfCoinsidingNumbersAndItsLine[] FindMinimal(NumberOfCoinsidingNumbersAndItsLine[] arrayOfCoinsidingNumbersAndItsLines)
        {
            NumberOfCoinsidingNumbersAndItsLine[] newArrayOfNumberOfCoinsidingNumbersAndItsLines = new NumberOfCoinsidingNumbersAndItsLine[0];
            NumberOfCoinsidingNumbersAndItsLine firstElement = newArrayOfNumberOfCoinsidingNumbersAndItsLines[0];
            int firstElementOfArray = newArrayOfNumberOfCoinsidingNumbersAndItsLines[0].NumberOfCoinsidingNumbers;
            newArrayOfNumberOfCoinsidingNumbersAndItsLines = RewriteNumberOfCoinsidingNumbersAndItsLine(newArrayOfNumberOfCoinsidingNumbersAndItsLines, firstElement);

            for (int i = 1; i < arrayOfCoinsidingNumbersAndItsLines.Length; i++)
            {
                NumberOfCoinsidingNumbersAndItsLine currentElement = arrayOfCoinsidingNumbersAndItsLines[i];
                int currentElementOfArray = currentElement.NumberOfCoinsidingNumbers;
                if (currentElementOfArray == firstElementOfArray)
                {
                    newArrayOfNumberOfCoinsidingNumbersAndItsLines = RewriteNumberOfCoinsidingNumbersAndItsLine(newArrayOfNumberOfCoinsidingNumbersAndItsLines, currentElement);
                }
                else
                {
                    break;
                }
            }
            return newArrayOfNumberOfCoinsidingNumbersAndItsLines;
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
        static int[,] CreateRandomMatrix(int numberOfRows, int numberOfColumns)
        {
            int[,] matrix = new int[numberOfColumns, numberOfRows];
            Random random = new Random();
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    matrix[j, i] = random.Next(1, 21);
                }
            }
            DisplayMatrix(matrix);
            return matrix;
        }
        static int[] GetCurrentSortedArray(int indexI, int[,] matrix, int numberOfColumns)
        {
            int[] currentArray = new int[numberOfColumns];
            for (int j = 0; j < numberOfColumns; j++)
            {
                currentArray[j] = matrix[j, indexI];
            }
            currentArray = SortArray(currentArray);
            return currentArray;
        }
        static NumberOfCoinsidingNumbersAndItsLine CompareTheLines(int[] firstLine, int[] currentLine, int index)
        {
            int numberOfCounsidingNumbers = 0;
            for (int i = 0; i < firstLine.Length; i++)
            {
                if (firstLine[i] == currentLine[i])
                {
                    numberOfCounsidingNumbers++;

                }
            }
            NumberOfCoinsidingNumbersAndItsLine numberOfCoinsidingNumbersAndItsLine = new NumberOfCoinsidingNumbersAndItsLine(numberOfCounsidingNumbers, index);

            return numberOfCoinsidingNumbersAndItsLine;
        }


        static void Main(string[] args)
        {
            int numberOfRows = ReadInt("number of rows is:");
            int numberOfColumns = ReadInt("number of columns is: ");
            int[,] matrix = CreateRandomMatrix(numberOfRows, numberOfColumns);
            int[] arrayOfNumbersOfFirstLine = new int[numberOfColumns];
            NumberOfCoinsidingNumbersAndItsLine[] numberOfCoinsidingNumbersAndItsLine = new NumberOfCoinsidingNumbersAndItsLine[numberOfRows-1];
            int indexOfTheLine = 0;
            arrayOfNumbersOfFirstLine = GetCurrentSortedArray(indexOfTheLine, matrix, numberOfColumns);
            int[] arrayOfCurrentNumbersOfCurrentLine = new int[numberOfColumns];

            for (indexOfTheLine = 1; indexOfTheLine < numberOfRows; indexOfTheLine++)
            {
                arrayOfCurrentNumbersOfCurrentLine = GetCurrentSortedArray(indexOfTheLine, matrix, numberOfColumns);
                NumberOfCoinsidingNumbersAndItsLine coinsidingNumbersAndItsLine = CompareTheLines(arrayOfNumbersOfFirstLine, arrayOfCurrentNumbersOfCurrentLine, indexOfTheLine);
                numberOfCoinsidingNumbersAndItsLine[indexOfTheLine-1] = coinsidingNumbersAndItsLine;
            }

            numberOfCoinsidingNumbersAndItsLine = SortNumberOfCoinsidingNumbersAndItsLines(numberOfCoinsidingNumbersAndItsLine);
             
            Console.ReadKey();


        }
    }
}
