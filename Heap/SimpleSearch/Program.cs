using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSearch
{
    public static class ArrayHelper
    {
        private static void CheckArray<T>(T[] a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("Массив не может быть null");
            }

            if (a.Length == 0)
            {
                throw new ArgumentException("Длина массива должна быть больше нуля");
            }
        }

        public static int LinearSearch<T>(T[] array, T key) where T : struct, IEquatable<T> //Визначає узагальнений метод, який застосовує тип 
                                                                                            //значення або клас для створення типового методу для 
                                                                                            //визначення рівності екземплярів.
                                                                                            //struct = беруться до уваги лише value type


        {
            CheckArray(array);

            for (int i = 0; i < array.Length; ++i)
            {
                // сравниваем текущее значение с искомым
                if (array[i].Equals(key))
                {
                    return i;
                }
            }
            //если ничего не нашли
            throw new Exception("Item not found");
        }

        public static int IndexOfMin<T>(T[] a) where T : struct, IComparable<T>
        {
            CheckArray(a);

            int indexMin = 0;
            T min = a[0];
            for (int i = 1; i < a.Length; ++i)
            {
                if (a[i].CompareTo(min) < 0) //аналог записи a[i] < min, для обобщений
                {
                    min = a[i];
                    indexMin = i;
                }
            }

            return indexMin;
        }

        public static T MinValue<T>(T[] a) where T : struct, IComparable<T> //where Constraint -  обмеження
        {
            CheckArray(a);

            T min = a[0];
            for (int i = 1; i < a.Length; ++i)
            {
                if (a[i].CompareTo(min) < 0)
                {
                    min = a[i];
                }
            }

            return min;
        }
        public static int IndexOfMax<T>(T[] a) where T : struct, IComparable<T>
        {
            CheckArray(a);

            int indexMax = 0;
            T max = a[0];
            for (int i = 1; i < a.Length; ++i)
            {
                if (a[i].CompareTo(max) > 0) //аналог записи a[i] > max, для обобщений
                {
                    max = a[i];
                    indexMax = i;
                }
            }

            return indexMax;
        }
        public static T MaxValue<T>(T[] a) where T : struct, IComparable<T>
        {
            CheckArray(a);

            T max = a[0];
            for (int i = 1; i < a.Length; ++i)
            {
                if (a[i].CompareTo(max) > 0)
                {
                    max = a[i];
                }
            }
            return max;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 6, 2, 4, 9, 0, 1, 3, 7, 8 };

            int index = ArrayHelper.LinearSearch(array, 22);
            if (index == -1)
            {
                Console.WriteLine("Элемент не найден");
            }
            int a = ArrayHelper.LinearSearch(array, 4);
            Console.WriteLine($"Индекс элемента со значением 4 равен {a}");
            Console.WriteLine($"Минимальный элемент массива: индекс {ArrayHelper.IndexOfMin(array)}; значение {ArrayHelper.MinValue(array)};");
            Console.WriteLine($"Максимальный элемент массива: индекс {ArrayHelper.IndexOfMax(array)}; значение {ArrayHelper.MaxValue(array)};");

            Console.ReadLine();

        }
    }
}

namespace A
{
    class B
    {
        public void C() { }
    }
    static class BExtentions
    {
        public static void NewMeth(this B b, int a) { }
    }
    class D
    {
        void E()
        {
            B b = new B();
            b.C();
            b.NewMeth(15);
            BExtentions.NewMeth(b, 15);
        }
    }

}