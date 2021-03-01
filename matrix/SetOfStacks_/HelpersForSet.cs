using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetOfStacks
{
    class HelpersForSet
    {
        public static int ReadInt(string question)
        {
            Console.Write(question);
            string answer = Console.ReadLine();
            int result = int.Parse(answer);
            return result;
        }

        public static int[] ExpandArray(int[] array, int element)
        {

            int[] resultOfArray = new int[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                resultOfArray[i] = array[i];
            }
            resultOfArray[resultOfArray.Length - 1] = element;
            return resultOfArray;
        }

        public static Stack GetLastStack(Stack [] setOfStacks)
        {
            Stack lastStack = setOfStacks[setOfStacks.Length - 1];

            return lastStack;

        }


        public static Stack[] ExpandSetOfStacks(Stack[] setOfStack, Stack stack)
        {
            Stack[] newSetOfStacks = new Stack[setOfStack.Length + 1];

            for (int i = 0; i < setOfStack.Length; i++)
            {
                newSetOfStacks[i] = setOfStack[i];
            }

            newSetOfStacks[newSetOfStacks.Length - 1] = stack;

            return newSetOfStacks;

        }

        public static Stack[] CompresSetOfStacks(Stack[] array)
        {

            Stack[] resultOfArray = new Stack[array.Length - 1];
            for (int i = 0; i < array.Length - 1; i++)
            {
                resultOfArray[i] = array[i];
            }

            return resultOfArray;
        }

        public static int[] CompressArray(int[] array)
        {

            int[] resultOfArray = new int[array.Length - 1];
            for (int i = 0; i < array.Length - 1; i++)
            {
                resultOfArray[i] = array[i];
            }

            return resultOfArray;
        }

        public static Stack GetStackByIndex(Stack [] setOfStacks, int indexOfStack)
        {
            Stack stackByIndex = new Stack();
            stackByIndex = setOfStacks[indexOfStack];

            return stackByIndex;

        }


        
    }
}
