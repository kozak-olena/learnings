using System;

namespace matrix_31
{
    class ElementAndItsCoordinates
    {
        public int Element;
        public int CoordinateI;
        public int CoordinateJ;
        public ElementAndItsCoordinates(int element, int coordinateI, int coordinateJ)
        {
            Element = element;
            CoordinateI = coordinateI;
            CoordinateJ = coordinateJ;
        }
    }
    class ElementAndItsCoordinatesAndDifference
    {
        public ElementAndItsCoordinates ElementAndItsCoordinates;
        public int Difference;
        public ElementAndItsCoordinatesAndDifference(ElementAndItsCoordinates elementAndItsCoordinates, int difference)
        {
            ElementAndItsCoordinates = elementAndItsCoordinates;
            Difference = difference;
        }
    }


    class Program
    {
        static ElementAndItsCoordinatesAndDifference[] RewriteElementAndItsCoordinate(ElementAndItsCoordinatesAndDifference[] array, ElementAndItsCoordinatesAndDifference elementAndItsCoordinates)
        {
            ElementAndItsCoordinatesAndDifference[] resultOfElementAndItsCoordinates = new ElementAndItsCoordinatesAndDifference[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                resultOfElementAndItsCoordinates[i] = array[i];
            }
            resultOfElementAndItsCoordinates[resultOfElementAndItsCoordinates.Length - 1] = elementAndItsCoordinates;
            return resultOfElementAndItsCoordinates;
        }

        static ElementAndItsCoordinatesAndDifference[] SortArray(ElementAndItsCoordinatesAndDifference[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    ElementAndItsCoordinatesAndDifference firstObject = array[j];
                    int firstDif = firstObject.Difference;
                    ElementAndItsCoordinatesAndDifference secObject = array[j + 1];
                    int secDif = secObject.Difference;
                    if (secDif < firstDif)
                    {
                        array[j + 1] = firstObject;
                        array[j] = secObject;

                    }
                }
            }
            return array;
        }

        static ElementAndItsCoordinatesAndDifference[] FindMinimalDifferences(ElementAndItsCoordinatesAndDifference[] array)
        {
            ElementAndItsCoordinatesAndDifference[] newArrayOfElementsAndDifference = new ElementAndItsCoordinatesAndDifference[0];
            ElementAndItsCoordinatesAndDifference firstElementOfArray = array[0];
            int firstDif = firstElementOfArray.Difference;
            newArrayOfElementsAndDifference = RewriteElementAndItsCoordinate(newArrayOfElementsAndDifference,firstElementOfArray);
            for (int i = 1; i < array.Length; i++)
            {
                ElementAndItsCoordinatesAndDifference currentElement = array[i];
                int currentDif = currentElement.Difference;
                if (currentDif == firstDif)
                {
                    newArrayOfElementsAndDifference = RewriteElementAndItsCoordinate(newArrayOfElementsAndDifference, currentElement);
                }
                else
                {
                    break;
                }
            }
            return newArrayOfElementsAndDifference;
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
        static int AriphmeticMean(int[,] matrix, int numberOfColumns, int numberOfRows)
        {
            int sumOfAllElements = 0;
            int ariphmeticMean = 0;
            int numberOfAllElementsOfMatrix = 0;
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    sumOfAllElements = matrix[j, i] + sumOfAllElements;
                    numberOfAllElementsOfMatrix++;
                }
            }
            ariphmeticMean = sumOfAllElements / numberOfAllElementsOfMatrix;
            return ariphmeticMean;
        }

        static int[,] CreateRandomMatrix(int numberOfRows, int numberOfColumns)
        {
            int[,] matrix = new int[numberOfColumns, numberOfRows];
            Random random = new Random();
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    matrix[j, i] = random.Next(1, 10);
                }
            }
            DisplayMatrix(matrix);
            return matrix;
        }


        static void Main(string[] args)
        {
            int numberOfRows = ReadInt($"number of rows is: ");
            int numberOfColumns = ReadInt($"number of columns is: ");
            int[,] matrix = CreateRandomMatrix(numberOfRows, numberOfColumns);
            int ariphmeticMean = AriphmeticMean(matrix, numberOfColumns, numberOfRows);
            Console.WriteLine($"ariph mean is:{ariphmeticMean}");

            ElementAndItsCoordinatesAndDifference[] elementAndItsCoordinatesAndDifferences = new ElementAndItsCoordinatesAndDifference[0];
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    ElementAndItsCoordinates elementAndItsCoordinates = new ElementAndItsCoordinates(matrix[j, i], i, j);
                    int difference = Math.Abs(matrix[j, i] - ariphmeticMean);
                    ElementAndItsCoordinatesAndDifference elementAndItsCoordinatesAndDifference = new ElementAndItsCoordinatesAndDifference(elementAndItsCoordinates, difference);
                    elementAndItsCoordinatesAndDifferences = RewriteElementAndItsCoordinate(elementAndItsCoordinatesAndDifferences, elementAndItsCoordinatesAndDifference);
                }
            }
            elementAndItsCoordinatesAndDifferences = SortArray(elementAndItsCoordinatesAndDifferences);
            elementAndItsCoordinatesAndDifferences = FindMinimalDifferences(elementAndItsCoordinatesAndDifferences);
            for (int i = 0; i < elementAndItsCoordinatesAndDifferences.Length; i++)
            {
                Console.WriteLine($"coordinate of element is: i = {elementAndItsCoordinatesAndDifferences[i].ElementAndItsCoordinates.CoordinateI} " +
                    $"and j = {elementAndItsCoordinatesAndDifferences[i].ElementAndItsCoordinates.CoordinateJ}; " +
                    $"value {elementAndItsCoordinatesAndDifferences[i].ElementAndItsCoordinates.Element}");
            }

            Console.ReadKey();

        }
    }
}
