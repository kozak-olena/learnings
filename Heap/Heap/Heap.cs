using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Heap
    {
        public Heap(int size)
        {
            _array = new int[size];
        }
        private int[] _array;
        private int _count;

        public void Add(int value)
        {
            if (_count > _array.Length - 1)
            {
                throw new Exception("HeapOverFlow");
            }
            else
            {
                _array[_count] = value;
                _count++;
                int currentIndex = _count - 1;
                int parentIndex = GetParentIndex(currentIndex);

                while (currentIndex > 0 && _array[parentIndex] > _array[currentIndex])
                {
                    Swap(currentIndex, parentIndex);
                    currentIndex = parentIndex;
                    parentIndex = GetParentIndex(currentIndex);
                }
            }
        }

        private int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        private void Swap(int currentIndex, int parentIndex)
        {
            int temp = _array[currentIndex];
            _array[currentIndex] = _array[parentIndex];
            _array[parentIndex] = temp;
        }

        public void DeleteMin()
        {
            if (_count == 0)
            {
                Console.Write("array is empty");
            }
            else
            {
                _array[0] = _array[_count - 1];
                _array[_count - 1] = 0;
                _count--;
                SortAfterDelete();
            }
        }

        private void SortAfterDelete()
        {
            int currentIndex = 0;
            int leftChildIndex;
            int rightChildIndex;

            //!
            int minIndex = currentIndex;
            while (currentIndex < _count)
            {
                leftChildIndex = currentIndex * 2 + 1;
                rightChildIndex = currentIndex * 2 + 2;

                if (leftChildIndex < _count && rightChildIndex < _count)
                {
                    if (_array[leftChildIndex] < _array[currentIndex])
                    {
                        minIndex = leftChildIndex;
                    }

                    if (_array[rightChildIndex] < _array[minIndex])
                    {
                        minIndex = rightChildIndex;
                    }

                    if (minIndex == currentIndex)
                    {
                        break;
                    }

                    Swap(currentIndex, minIndex);
                    currentIndex = minIndex;
                }
                else
                {
                    break;
                }

            }
            

        }

    }
}
