using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {

            Tree tree = new Tree();
            Random random = new Random();

            tree.Insert(12);
            tree.Insert(5);

            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(8);
            tree.Insert(11);
            tree.Insert(15);
            tree.Insert(17);
            tree.Insert(13);
            tree.Insert(14);
            tree.Insert(20);
            tree.Insert(18);


            //tree.Delete(5);
            //tree.Delete(15);
            //tree.Delete(20);
            //tree.Delete(9);
            //tree.Delete(17);
            //tree.Delete(1);
            //tree.Delete(3);
            //tree.Delete(18);
            tree.Delete(12);
            int[] array = tree.InOrderTraverse();

            Console.ReadKey();
        }
    }
}
