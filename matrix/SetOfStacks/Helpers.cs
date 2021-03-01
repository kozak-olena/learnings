using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetOfStacks
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

        public static int [] ExpandArray( int [] array, int element)
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

            int[] resultOfArray = new int[array.Length - 1];
            for (int i = 0; i < array.Length - 1; i++)
            {
                resultOfArray[i] = array[i];
            }

            return resultOfArray;
        }

        public static int[] RewriteArrayVicaVersa(int[] inputingArray)
        {

            int[] newArray = new int[inputingArray.Length];
            for (int i = 0; i <= inputingArray.Length - 1; i++)
            {
                newArray[i] = inputingArray[inputingArray.Length - 1 - i];
            }

            return newArray;

        }
    }
}
