using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary2
{
    class Program
    {
        static Random random = new Random();

        public static string RandomString(int size)
        {
            StringBuilder stringBuilder = new StringBuilder();
            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = (char)(65 + random.Next(0, 27));
                stringBuilder.Append(ch);
            }

            return stringBuilder.ToString();
        }

        static void Main(string[] args)
        {
            Dictionary dictionary = new Dictionary();

            dictionary.Add("apple", "яблуко");
            dictionary.Add("pear", "груша");
            dictionary.Add("blackberry", "ожина");


            dictionary.Add("kiwi", "ківі");
            dictionary.Add("banana", "банан");

            dictionary.Add("orange", "апельсин");
            dictionary.Add("tangerine", "мандарин");
            dictionary.Add("dates", "фініки");
            dictionary.Add("grape", "виноград");
            dictionary.Add("melon", "диня");

            dictionary.Add("watermelon", "кавун");
            dictionary.Add("apricot", "абрикос");
            dictionary.Add("gooseberry", "агрус");

            dictionary.Add("lemon", "лимон");
            dictionary.Add("nectarine", "нектарин");

            dictionary.Add("pineapple", "ананас");
            dictionary.Add("raspberry", "малина");
            dictionary.Add("plum", "слива");
            dictionary.Add("star fruit", "карамболь");

            for (int i = 0; i < 1000000; i++)
            {
                string key = RandomString(50);
                string value = RandomString(50);

                dictionary.Add(key, value);

            }

            //Console.WriteLine(dictionary.Get("GPRTR"));
            //Console.WriteLine(dictionary.Get("IXEIF"));
            //Console.WriteLine(dictionary.Get("QIJXO"));
            //Console.WriteLine(dictionary.Get("YPJPV"));



            Console.ReadKey();
        }
    }
}
