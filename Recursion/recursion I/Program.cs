using System;

namespace recursion_I
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
         


        static void Main(string[] args)
        {
            int n = ReadInt("n = ");

        }
    }
}
