using lab3_Go_to_hell;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public static class MariiaSolution
    {//8. Знищити всі елементи з непарними індексами
        public static int[] Menu(int[] array)
        {
            Console.WriteLine("Початковий масив:");
            OneDimensionalArray.PrintArray(array);

            int choice;
            do
            {
                Console.WriteLine("1) Для виконання програми через Array.Resize().");
                Console.WriteLine("2) Для виконання програми через створення нового масиву.");
                Console.WriteLine("0) Щоб повернутися назад в меню.");
                choice = int.Parse(Console.ReadLine()!);
                switch (choice)
                {
                    case 1:
                        ArrayResizeMethod(ref array);
                        return array;
                    case 2:
                        array = CreateNewArrayMethod(array);
                        return array;
                    case 0:
                        Program.Main();
                        break;
                    default:
                        Console.WriteLine("Команда ''{0}'' не розпізнана. Зробіть, будь ласка, вибір із 1, 2, 0.", choice);
                        break;
                }
            } while (choice != 0);
            return array;
        }
        static void ArrayResizeMethod(ref int[] array)
        {
            Console.WriteLine("Виконую програму через Array.Resize()");
            int n = array.Length;
            int j = 1;
            for (int i = 2; i < n; i+=2)
            {
                array[j++] = array[i];
            }
            Array.Resize(ref array, j);
            Console.WriteLine("Результат виконання програми:");
            OneDimensionalArray.PrintArray(array);
        }
        static int[] CreateNewArrayMethod(int[] array)
        {
            Console.WriteLine("Виконую програму через створення нового масиву");
            int n = array.Length;
            int[] result_array = new int[(n + 1) / 2];
            int j = 0;
            for (int i = 0; i < n; i+=2)
            {
                result_array[j++] = array[i];
            }
            array = result_array;
            Console.WriteLine("Кінцевий масив:");
            OneDimensionalArray.PrintArray(array);
            return array;
        }
    }
}
