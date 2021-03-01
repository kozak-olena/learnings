using System;

namespace recursion_2
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

        static int OutputNumbersUp(int a, int b)
        {

            if (b < a)
            {
                return b + 1;
            }
            else
            {
                int bMinus1 = OutputNumbersUp(a, b - 1);
                Console.WriteLine($"{b}");
                return b;
            }
        }


        static int OutputDown(int a, int b)
        {
            if (b > a)
            {
                return b - 1;
            }
            else
            {
                int bPlus1 = OutputDown(a, b + 1);
                Console.WriteLine($"{b}");
                return b;
            }
        }

        static void Main(string[] args)
        {
            int a = ReadInt("a = ");
            int b = ReadInt("b = ");
            if (a < b)
            {
                b = OutputNumbersUp(a, b);
            }
            else
            {
                b = OutputDown(a, b);
            }

            Console.ReadKey();

        }

    }
}


