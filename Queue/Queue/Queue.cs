using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Queue
    {
        private int[] _queueArray;

        public Queue()
        {
            int[] newArray = new int[0];
            _queueArray = newArray;
        }

        public void Enqueue(int element)
        {
            _queueArray = Helpers.ExpandArray(_queueArray, element);
        }

        public int Dequeue()
        {
            int element = _queueArray[0];

            _queueArray = Helpers.CompressArray(_queueArray);
            return element;
        }

        public int Peek()
        {
            int element = _queueArray[0];

            return element;
        }
    }
}
