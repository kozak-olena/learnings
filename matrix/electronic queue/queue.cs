using System;

namespace electronic_queue
{
    class Program
    {
        static int GetMyNumberAndFakeI(int index, int indexOfCurrentPatiente)
        {
            int fakeI = 1;

            if (index == indexOfCurrentPatiente)
            {
                Console.WriteLine("There are no numbers");
            }
            else
            {
                Console.WriteLine(index);
                fakeI = index;

            }

            return fakeI;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int i = 1;
            int indexOfCurrentPatiente = 0; ;
            int fakeI = 1;


            while (input != " ")
            {

                if (input == "get my number")
                {
                    if (i <= 5)
                    {

                        fakeI = GetMyNumberAndFakeI(i, indexOfCurrentPatiente);
                        i++;
                    }
                    else
                    {
                        i = 1;
                        fakeI = GetMyNumberAndFakeI(i, indexOfCurrentPatiente);
                        i++;
                    }
                }

                else if (input == "next")
                {

                    if (fakeI <= indexOfCurrentPatiente)
                    {
                        Console.WriteLine($"there no patients!");
                    }
                    else
                    {
                        indexOfCurrentPatiente++;

                    }
                }

                else if (input == "current number")
                {
                    if (indexOfCurrentPatiente < 1)
                    {
                        Console.WriteLine("dinner");
                    }
                    else
                    {
                        Console.WriteLine($"current number is {indexOfCurrentPatiente}");
                    }
                }
                input = Console.ReadLine();
            }

            Console.ReadKey();
        }

    }

}


