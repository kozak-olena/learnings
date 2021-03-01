using System;

namespace matrix36b
{
    class NumbersOflineAndHowManyTimesItIsMet
    {
        public int IndexOfLine;
        public int NumberOfSimilarities;
        public NumbersOflineAndHowManyTimesItIsMet(int nubmersOfLine, int numberOfTimes)
        {
            IndexOfLine = nubmersOfLine;
            NumberOfSimilarities = numberOfTimes;
        }
    }
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
        static NumbersOflineAndHowManyTimesItIsMet[] RewriteNumberOfCoinsidingNumbersAndItsLine(NumbersOflineAndHowManyTimesItIsMet[] array, NumbersOflineAndHowManyTimesItIsMet newElement)
        {
            int arrayLength = 0;
            if (array != null)
            {
                arrayLength = array.Length;
            }
            NumbersOflineAndHowManyTimesItIsMet[] result = new NumbersOflineAndHowManyTimesItIsMet[arrayLength + 1];
            for (int j = 0; j < arrayLength; j++)
            {
                result[j] = array[j];

            }
            result[result.Length - 1] = newElement;
            return result;
        }




        static int FindSimilarities(int[] numbersOfFirstLine, int[] numbersOfCurrentLine)
        {
            int countSimilarities = 0;
            int cycle1Number = 0;
            int cycle2Number = 0;
            int j = 0;
            for (int i = 0; i < numbersOfFirstLine.Length; i++)
            {
                do
                {
                    cycle1Number = numbersOfFirstLine[i];
                    cycle2Number = numbersOfCurrentLine[j];
                    if (cycle1Number < cycle2Number)
                    {
                        break;
                    }
                    else
                    {
                        if (j != numbersOfCurrentLine.Length - 1)
                        {
                            j++;
                        }
                        else
                        {
                            if (cycle1Number == cycle2Number)
                            {
                                countSimilarities++;
                            }
                            return countSimilarities;
                        }
                    }
                }
                while (cycle1Number != cycle2Number);
                if (cycle1Number == cycle2Number)
                {
                    countSimilarities++;
                }

            }

            return countSimilarities;
        }


        static void Main(string[] args)
        {
            int numberOfRows = ReadInt("number of rows is:");
            int numberOfColumns = ReadInt("number of columns is: ");
            int[,] matrix = CreateRandomMatrix(numberOfRows, numberOfColumns);
            int index = 0;
            int[] arrayOfFirstLine = GetCurrentSortedArray(index, matrix, numberOfColumns);
            NumbersOflineAndHowManyTimesItIsMet[] indexLineAndNumberOfsimilarities = new NumbersOflineAndHowManyTimesItIsMet[numberOfRows];
            int countOfSimilarities = 0;
            for (int i = 1; i < numberOfRows; i++)
            {
                int[] arrayOfCurrentLine = GetCurrentSortedArray(i, matrix, numberOfColumns);
                countOfSimilarities = FindSimilarities(arrayOfFirstLine, arrayOfCurrentLine);
                indexLineAndNumberOfsimilarities[i-1] = new NumbersOflineAndHowManyTimesItIsMet(i, countOfSimilarities);
                Console.WriteLine($"number of line {indexLineAndNumberOfsimilarities[i-1].IndexOfLine + 1} and number of similarities {indexLineAndNumberOfsimilarities[i-1].NumberOfSimilarities}");
            }
            int countOfLines = 0;
            for (int i = 0; i < numberOfRows-1; i++)
            {
                if (indexLineAndNumberOfsimilarities[i].NumberOfSimilarities >= numberOfColumns / 2)
                {
                    countOfLines++;
                }
            }
            Console.WriteLine($"number of similar lines is {countOfLines}");
            Console.ReadKey();


        }
    }
}
