using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary dictionary = new Dictionary();

            dictionary.Add("apple", "яблуко");
            dictionary.Add("cherry", "вишня");
            dictionary.Add("pear", "груша"); 
            dictionary.Add("banana", "банан");
             
            Console.WriteLine(dictionary.Get("cherry"));
            Console.WriteLine(dictionary.Get("apple"));

            dictionary.Add("orange", "апельсин");
            dictionary.Add("tangerine", "мандарин");
            dictionary.Add("dates", "фініки");
            dictionary.Add("grape", "виноград");
            dictionary.Add("melon", "диня");
            
            dictionary.Add("watermelon", "кавун");
            dictionary.Add("apricot", "абрикос");
            Console.WriteLine(dictionary.Get("melon"));
            Console.WriteLine(dictionary.Get("dates"));
            dictionary.Add("gooseberry", "агрус");

        }
    }
}
