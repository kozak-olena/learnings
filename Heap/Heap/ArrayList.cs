using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class ArrayList
    {
        private int growthCoeficient = 2;
        private int initialSize = 10;
        private int index = 0;
        private int[] _array;

        public ArrayList()
        {
            int[] newArray = new int[initialSize];
            _array = newArray;
        }

        public void Add(int value)
        {
            if (index < _array.Length)
            {
                _array[index] = value;
                index++;
            }
            else
            {
                int newSize = _array.Length * growthCoeficient;
                int[] newArray = new int[newSize];
                for (int i = 0; i < _array.Length; i++)
                {
                    newArray[i] = _array[i];
                }
                newArray[_array.Length] = value;
                index++;
                _array = newArray;

            }
        }

        public void RemoveAt(int indextOfElement)
        {

            for (int i = indextOfElement; i < index; i++)
            {

                _array[i] = _array[i + 1];

            }

            index--;

        }
    }
}
