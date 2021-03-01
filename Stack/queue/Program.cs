using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue
{
    public class Queue<T>
    {
        List<T> items = new List<T>();
        public int Count => items.Count();

        public void Enqueue(T item)
        {
            items.Add(item);
        }

        public T Dequeue()
        {
            T resultElement;
            if (Count == 0)
            {
                throw new Exception("the are no items");
            }
            else
            {
                resultElement = items.First();
                items.RemoveAt(0);
            }

            return resultElement;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(6);
            queue.Enqueue(5);
            queue.Enqueue(10);
            queue.Enqueue(13);

            int element;
            element = queue.Dequeue();
            element = queue.Dequeue();
            element = queue.Dequeue();
            element = queue.Dequeue();
            element = queue.Dequeue();

            Console.ReadKey();

        }
    }
}
