using System;

namespace recursion_H
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

        static bool IsItPrime(int n, int divider)
        {

            if (divider == n)
            {
                return true;
            }
            else if (n % divider == 0)
            {
                return false;
            }
            else
            {
                bool isItPrime = IsItPrime(n, divider + 1);

                return isItPrime;
            }


        }

        static void Main(string[] args)
        {
            int n = ReadInt("n = ");
            int divider = 2;
            bool isItPrime = IsItPrime(n, divider);
            Console.WriteLine($"{isItPrime}");
            Console.ReadKey();
        }
    }
}
