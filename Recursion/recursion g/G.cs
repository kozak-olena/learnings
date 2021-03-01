using System;

namespace recursion_g
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

        static int OutputComplexNumber(int n)
        {
            int divisionReminder = 0;
            if (n<10)
            {
                divisionReminder = n % 10;
                Console.Write($"{divisionReminder} ");
                return n * 10;
            }
            else
            {
                divisionReminder = n % 10;
                int nDividedBy10 = OutputComplexNumber((n-divisionReminder)/10);
                Console.Write($"{divisionReminder} ");
                return n;
            }
        }

        static void Main(string[] args)
        {
            int n = ReadInt("n = ");
            n = OutputComplexNumber(n);

            Console.ReadKey();
        }
    }
}
