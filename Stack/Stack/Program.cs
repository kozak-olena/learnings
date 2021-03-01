using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack<T>
    {
        public List<T> items = new List<T>();

        public int Count => items.Count;
        public void Push(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new Exception("There are no elements");
            }
            else
            {

                T element = items.ElementAt(Count - 1);
                items.RemoveAt(Count - 1);

                return element;

            }
        }




    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int a = random.Next(15);
                stack.Push(a);

            }
            int element = stack.Pop();
            element = stack.Pop();
            element = stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();


            Console.ReadKey();
        }


    }
}
