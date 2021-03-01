using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            Heap heap = new Heap();
            heap.Add(12);
            heap.Add(23);
            heap.Add(6);
            heap.Add(34);
            heap.Add(10);
            heap.Add(3);
            heap.Add(25);
            heap.Add(65);
            heap.Add(2);
            heap.Add(100);
            heap.Add(11);

            heap.DeleteMin();
            heap.DeleteMin();
            heap.DeleteMin();
            heap.DeleteMin();
            heap.DeleteMin();
            heap.DeleteMin();
            heap.DeleteMin();
            heap.DeleteMin();
            heap.DeleteMin();
            heap.DeleteMin();
            heap.DeleteMin();

            Console.ReadKey();

        }
    }
}
