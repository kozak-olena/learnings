using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetOfStacks
{
    class Stack
    {
        private int[] _array;

        public Stack()
        {
            int[] newArray = new int[0];
            _array = newArray;

        }

        public void Push(int newElement)
        {
            _array = HelpersForSet.ExpandArray(_array, newElement);
        }

        public int Pop()
        {
            int element = _array[_array.Length - 1];

            _array = HelpersForSet.CompressArray(_array);

            return element;
        }

        public int Peek()
        {
            int element = _array[_array.Length - 1];

            return element;

        }


        public int GetLength()
        {
            int length = _array.Length;
            return length;
        }
    }

    class Programm
    {
        static void Main(string[] args)
        {
            Console.Write("1- push element; ");
            Console.Write("2 - pop element; ");
            Console.Write("3 - popAt element by index; ");
            Console.Write("4 - peek; ");
            Console.Write("0 - break; ");
            int element = 0;
            int number = 0;

            SetOfStacks setOfStacks = new SetOfStacks();
            setOfStacks = new SetOfStacks();

            do
            {
                Console.WriteLine();

                number = HelpersForSet.ReadInt("what you choose? - ");

                if (number == 1)
                {
                    while (true)
                    {
                        element = HelpersForSet.ReadInt(" ");


                        if (element == 0)
                        {
                            break;
                        }
                        else
                        {
                            int lengthOfLastStack = setOfStacks.GetLengthLastStack(setOfStacks);

                            if (lengthOfLastStack == 4)
                            {
                                Console.WriteLine();
                                setOfStacks.Push(element);
                            }

                            else
                            {
                                setOfStacks.Push(element);
                            }
                        }

                    }


                }
                else if (number == 2)
                {

                    element = setOfStacks.Pop();
                    Console.WriteLine($"pop = {element}");
                }
                else if (number == 3)
                {

                    int index = HelpersForSet.ReadInt("index = ");
                    element = setOfStacks.PopAt(index);
                    Console.WriteLine($"pop by stack index {index} = {element}");
                }
                else if (number == 4)
                {
                    element = setOfStacks.Peek();
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