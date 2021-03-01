using System;

namespace recursion
{
    class Program
    {
        static int Factorial(int n)
        {

            if (n == 0)
            {
                return 1;
            }
            else
            {
                int factorialNminus1 = Factorial(n - 1);

                return factorialNminus1 * n;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Факториал числа {n} равен {Factorial(n)}");
            Console.ReadLine();
        }
    }
}
