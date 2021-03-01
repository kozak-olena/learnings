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
            _array = Helpers.ExpandArray(_array, newElement);
        }

        public int Pop()
        {
            int element = _array[_array.Length - 1];

            _array = Helpers.CompressArray(_array);

            return element;
        }

        public int PopAt(int index)
        {
            _array = Helpers.RewriteArrayVicaVersa(_array);
            int element = _array[index];
            _array = Helpers.RewriteArrayVicaVersa(_array);

            return element;
        }

        public int GetLength()
        {
            int length = _array.Length;
            return length;
        }
    }
}
