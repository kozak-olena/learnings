using System;

namespace recursion_4
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

        static bool TryDegreeOfTwo(float n)
        {

            if (n == 1)
            {
                return true;
            }
            else if (n < 1)
            {
                return false;
            }
            else
            {
                bool isDegreeOfTwo = TryDegreeOfTwo(n / 2);
                return isDegreeOfTwo;


            }
        }

        static void Main(string[] args)
        {
            float n = ReadInt($"n = ");
            bool isThedegreeOfTwo = false;
            isThedegreeOfTwo = TryDegreeOfTwo(n);
            Console.WriteLine($"{isThedegreeOfTwo}");
            Console.ReadKey();
        }
    }
}
