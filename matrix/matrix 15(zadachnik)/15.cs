using System;

namespace matrix_15_zadachnik_
{
    class CentreOfMatrix
    {
        public int HorisontalCentre;
        public int VerticalCentre;
        public CentreOfMatrix(int numberOfRowsAndColumns)
        {
            if (numberOfRowsAndColumns % 2 == 0)
            {
                VerticalCentre = numberOfRowsAndColumns / 2;
                HorisontalCentre = numberOfRowsAndColumns / 2 - 1;
            }
            else
            {
                HorisontalCentre = numberOfRowsAndColumns / 2;
                VerticalCentre = numberOfRowsAndColumns / 2;
            }
        }
    }

    class Program
    {
        static int ChangeDirection(int currentDirection)
        {
            if (currentDirection == 1) return 2;
            if (currentDirection == 2) return 3;
            if (currentDirection == 3) return 4;
            if (currentDirection == 4) return 1;
            return -1;
        }

        static int GEtCorridorLengthDecreaseByTurn(int numberOfTurns)
        {
            int result;
            if (numberOfTurns % 2 == 0)
            {
                result = numberOfTurns / 2 - 1;
            }
            else
            {
                result = (numberOfTurns - 1) / 2;
            }
            return result;

        }

        static int GetCorridorLength(int matrixSize, int numberOfTurns)
        {
            int result;
            if (numberOfTurns >= 0 && numberOfTurns <= 2)
            {
                result = matrixSize;
            }
            else
            {
                result = matrixSize - GEtCorridorLengthDecreaseByTurn(numberOfTurns);
            }
            return result;
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
            int numberOfRowsAndColumns = ReadInt("number of rows and columns is:");
            int[,] matrix = new int[numberOfRowsAndColumns, numberOfRowsAndColumns];


            Random random = new Random();
            for (int i = 0; i < numberOfRowsAndColumns; i++)
            {
                for (int j = 0; j < numberOfRowsAndColumns; j++)
                {
                    matrix[j, i] = random.Next(1, 10);
                }
            }
            DisplayMatrix(matrix);
            Console.WriteLine();
            int x = 0;
            int y = 0;
            int currentDirection = 1;
            int numberOfTurns = 0;
            int stepsMade = 0;
            CentreOfMatrix centreOfMatrix = new CentreOfMatrix(numberOfRowsAndColumns);

            while (!(x == centreOfMatrix.HorisontalCentre && y == centreOfMatrix.VerticalCentre))
            {
                if (currentDirection == 1)
                {
                    Console.Write($" {matrix[x, y]} ");
                    x++;
                    stepsMade++;

                    if (stepsMade + 1 == GetCorridorLength(numberOfRowsAndColumns, numberOfTurns))
                    {
                        currentDirection = ChangeDirection(currentDirection);
                        numberOfTurns++;
                        stepsMade = 0;
                        Console.WriteLine();
                    }

                }

                else if (currentDirection == 2)
                {
                    Console.Write($" {matrix[x, y]} ");
                    y++;
                    stepsMade++;

                    if (stepsMade + 1 == GetCorridorLength(numberOfRowsAndColumns, numberOfTurns))
                    {
                        currentDirection = ChangeDirection(currentDirection);
                        numberOfTurns++;
                        stepsMade = 0;
                        Console.WriteLine();

                    }

                }

                else if (currentDirection == 3)
                {
                    Console.Write($" {matrix[x, y]} ");
                    x--;
                    stepsMade++;
                    if (stepsMade + 1 == GetCorridorLength(numberOfRowsAndColumns, numberOfTurns))
                    {
                        currentDirection = ChangeDirection(currentDirection);
                        numberOfTurns++;
                        stepsMade = 0;
                        Console.WriteLine();
                    }

                }

                else if (currentDirection == 4)
                {
                    Console.Write($" {matrix[x, y]} ");
                    y--;
                    stepsMade++;
                    if (stepsMade + 1 == GetCorridorLength(numberOfRowsAndColumns, numberOfTurns))
                    {
                        currentDirection = ChangeDirection(currentDirection);
                        numberOfTurns++;
                        stepsMade = 0;
                        Console.WriteLine();
                    }

                }

            }

            Console.Write($" {matrix[x, y]} ");
            Console.ReadKey();
        }
    }
}
