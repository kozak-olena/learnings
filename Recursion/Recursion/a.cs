using System;

namespace Recursion
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

        static int OutputNumbers(int n)
        {

            if (n == 0)
            {
                return 1;
            }
            else
            {
                int nMinus1 = OutputNumbers(n - 1);
                Console.WriteLine($"{n}");
                return n;
            }
        }

        static void Main(string[] args)
        {
            int n = ReadInt("n = ");
            n = OutputNumbers(n);

            Console.ReadKey();
        }
    }
}
