using System;

namespace matrix_97
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

        static double[] RewriteArray(double[] array, double element)
        {
            double[] resultOfArray = new double[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                resultOfArray[i] = array[i];
            }
            resultOfArray[resultOfArray.Length - 1] = element;
            return resultOfArray;
        }

        static double[] GetArrayOfDiagonales(int[,] matrix, int indexI, int indexJ, double[] arrayOfNumbersOfDiagonal)
        {

            do
            {
                arrayOfNumbersOfDiagonal = RewriteArray(arrayOfNumbersOfDiagonal, matrix[indexJ, indexI]);
                indexJ--;
                indexI++;


            }
            while (indexJ != matrix.GetLength(0) - 1 && indexI != matrix.GetLength(0) - 1);

            return arrayOfNumbersOfDiagonal;
        }

        static double ArithmeticaMeanOfElements(double[] arrayOfElements)
        {

            double sum = 0;
            double arithmeticalMean = 0;
            for (int i = 0; i < arrayOfElements.Length; i++)
            {

                sum = sum + arrayOfElements[i];
            }
            arithmeticalMean = sum / arrayOfElements.Length;

            return arithmeticalMean;
        }

        static double[] GetArayOfCurrentMaxElementInDiagonal(int[,] matrix, double[] arrayOfArithMeans, int indexI, int indexJ)
        {
            double arithmeticalMean = 0;

            double[] arrayOfNumbersOfDiagonal = new double[0];
            arrayOfNumbersOfDiagonal = GetArrayOfDiagonales(matrix, indexI, indexJ, arrayOfNumbersOfDiagonal);
            arithmeticalMean = ArithmeticaMeanOfElements(arrayOfNumbersOfDiagonal);
            arrayOfArithMeans = RewriteArray(arrayOfArithMeans, arithmeticalMean);


            return arrayOfArithMeans;

        }


        static double[] GetAllArraysOfArithmeticalMeans(int[,] matrix)
        {
            int indexI = matrix.GetLength(0) - 1;
            int indexJ = 0;
            double[] arrayOfArithmeticalMeans = new double[0];

            while (indexJ < matrix.GetLength(0) - 1)
            {
                arrayOfArithmeticalMeans = GetArayOfCurrentMaxElementInDiagonal(matrix, arrayOfArithmeticalMeans, indexI, indexJ);
                indexJ++;
            }

            indexJ++;

            while (indexI < matrix.GetLength(0))
            {
                arrayOfArithmeticalMeans = GetArayOfCurrentMaxElementInDiagonal(matrix, arrayOfArithmeticalMeans, indexI, indexJ);
                indexI--;
            }

            return arrayOfArithmeticalMeans;


        }

        static void DisplayArray(double[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"arithmetical mean of {i + 1} = {array[i]}");
            }

        }

        static void Main(string[] args)
        {
            int numberOfColumnsAndRows = ReadInt("length of matrix if ");
            int[,] matrix = CreateRandomMatrix(numberOfColumnsAndRows, numberOfColumnsAndRows);
            double[] arrayOfArithmeticalMeans = GetAllArraysOfArithmeticalMeans(matrix);
            DisplayArray(arrayOfArithmeticalMeans);


            Console.ReadKey();
        }
    }
}
