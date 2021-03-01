using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("1- enqueue; ");
            Console.Write("2 - dequeue; ");
            Console.Write("3 - peek; ");
            Console.Write("0 - break; ");
            int element = 0;
            int number = 0;

            Queue queue = new Queue();


            do
            {
                Console.WriteLine();

                number = Helpers.ReadInt("what you choose? - ");

                if (number == 1)
                {
                    while (true)
                    {
                        element = Helpers.ReadInt(" ");
                        if (element == 0)
                        {
                            break;
                        }
                        else
                        {
                            queue.Enqueue(element);
                        }

                    }
                }
                else if (number == 2)
                {
                    element = queue.Dequeue();
                    Console.WriteLine($"dequeue = {element}");
                }
                else if (number == 3)
                {
                    element = queue.Peek();
                    Console.WriteLine($"peek = {element}");
                }
                else
                {
                    break;
                }

            }
            while (number != 0);

            Console.ReadKey();

        }
    }
}
