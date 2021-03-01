using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Helpers
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

        public static int[] CompressArray(int[] array)
        {
            int[] resultArray = new int[array.Length - 1];

            for (int i = 0; i < array.Length-1; i++)
            {
                resultArray[i] = array[i + 1];
            }
            return resultArray;

        }

    }
}

