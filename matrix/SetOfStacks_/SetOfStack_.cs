using SetOfStacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetOfStacks
{
    class SetOfStacks
    {
        private Stack[] _arrayOfStacks;

        public SetOfStacks()
        {
            Stack[] newArray = new Stack[1];
            _arrayOfStacks = newArray;

            _arrayOfStacks[0] = new Stack();
        }


        public void Push(int element)
        {


            Stack lastStack = _arrayOfStacks[_arrayOfStacks.Length - 1];
            int lengthOfStack = lastStack.GetLength();
            if (lengthOfStack < 5)
            {
                lastStack.Push(element);
            }

            else
            {

                Stack newStack = new Stack();
                newStack.Push(element);

                _arrayOfStacks = HelpersForSet.ExpandSetOfStacks(_arrayOfStacks, newStack);


            }


        }

        public int Peek() 
        {
            int element = 0;
            Stack lastStack = HelpersForSet.GetLastStack(_arrayOfStacks);

            int legthOfStack = lastStack.GetLength();
            if (legthOfStack > 0)
            {
                element = lastStack.Peek();
            }

            else
            {
                Console.WriteLine("InvalidOperationException");
            }

            return element;
        }



        public int GetLengthLastStack(SetOfStacks setOfStacks)
        {
            Stack lastStack = setOfStacks._arrayOfStacks[_arrayOfStacks.Length - 1];
            int lengthOfStack = 0;

            lengthOfStack = lastStack.GetLength();

            return lengthOfStack;
        }

        public int Pop()
        {
            int element = 0;
            Stack lastStack = HelpersForSet.GetLastStack(_arrayOfStacks);
            int lengthOfStack = lastStack.GetLength();

            if (lengthOfStack > 0)
            {
                element = lastStack.Pop();

            }
            else
            {
                _arrayOfStacks = HelpersForSet.CompresSetOfStacks(_arrayOfStacks);
                lastStack = _arrayOfStacks[_arrayOfStacks.Length - 1];
                element = lastStack.Pop();
            }

            return element;
        }

        public int PopAt(int indexOfStack)
        {
            Stack stackAtIndex = _arrayOfStacks[indexOfStack];
            int element = 0;

            element = stackAtIndex.Pop();


            return element;
        }

        public void PushElement(int element, SetOfStacks setOfStacks)
        {
            element = HelpersForSet.ReadInt(" ");
            setOfStacks.Push(element);
        }






    }
}
