using System;

namespace matrix_8__dark_yellow_
{
    class ChampionshipMetrics
    {
        public int NumberOfTeamsWhichWonMoreThanLost;
        public int[] TeamsWithoutFails;
        public bool ThereIsOneTeamWhichWonMoreThanHalfOfGames;
        //public ChampionshipMetrics()
        //{
        // TeamsWithoutFails = new int[0];
        // }
    }
    class Program
    {
        static int[] rewriteArray(int[] array, int newElement)
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

        static void ProcessTeam(int countVictory, int countFails, ChampionshipMetrics championshipMetrics, int index)
        {

            if (countFails == 0)
            {
                championshipMetrics.TeamsWithoutFails = rewriteArray(championshipMetrics.TeamsWithoutFails, index);

            }

            if (countVictory > countFails)
            {
                championshipMetrics.NumberOfTeamsWhichWonMoreThanLost++;

            }
        }

        static ChampionshipMetrics GetChampionshipMetrics(int[,] matrix, int numberOfRowsAndColumns)
        {
            ChampionshipMetrics championshipmetrics = new ChampionshipMetrics();

            championshipmetrics.ThereIsOneTeamWhichWonMoreThanHalfOfGames = false;
            for (int i = 0; i < numberOfRowsAndColumns; i++)
            {
                int countFails = 0;
                int countVictory = 0;
                for (int j = 0; j < numberOfRowsAndColumns; j++)
                {
                    if (i != j)
                    {
                        if (matrix[j, i] == 0)
                        {
                            countFails++;
                        }
                        if (matrix[j, i] == 2)
                        {
                            countVictory++;
                        }
                    }
                }

                ProcessTeam(countVictory, countFails, championshipmetrics, i);

                if (countVictory > numberOfRowsAndColumns / 2)
                {
                    championshipmetrics.ThereIsOneTeamWhichWonMoreThanHalfOfGames = true;
                }
            }
            return championshipmetrics;


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
            int numberOfRowsAndColumns = ReadInt("number of rows and columns is ");
            int[,] matrix = new int[numberOfRowsAndColumns, numberOfRowsAndColumns];
            Random random = new Random();


            for (int i = 0; i < numberOfRowsAndColumns; i++)
            {
                for (int j = 0; j < numberOfRowsAndColumns; j++)
                {
                    if (i == j)
                    {
                        matrix[j, i] = 0;
                    }
                    else
                    {
                        matrix[j, i] = random.Next(0, 3);
                    }
                }
            }
            DisplayMatrix(matrix);

            ChampionshipMetrics championshipMetrics = GetChampionshipMetrics(matrix, numberOfRowsAndColumns);
            if (championshipMetrics.TeamsWithoutFails != null)
            {
                for (int i = 0; i < championshipMetrics.TeamsWithoutFails.Length; i++)
                {
                    Console.WriteLine($"team without fails is: {championshipMetrics.TeamsWithoutFails[i]}");
                }
            }
            Console.WriteLine($"number of commands which won more than failed {championshipMetrics.NumberOfTeamsWhichWonMoreThanLost}, " + "\n" +
                        $"is there at least one command which won more than half of games - {championshipMetrics.ThereIsOneTeamWhichWonMoreThanHalfOfGames}");
            Console.ReadKey();

        }


    }
}
