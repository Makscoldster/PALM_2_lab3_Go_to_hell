using lab3_Go_to_hell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab3
{
    public static class MariiaSolution
    {
        //8. Знищити всі елементи з непарними індексами
        public static void Block_1_Task_8(ref int[] array)
        {
            Console.WriteLine(
            """
            ------------------------------------------------------------------------------------------------------------------------
                                                           MARIIA SOLUTION (БЛОК #1)
            ------------------------------------------------------------------------------------------------------------------------
            """);
            Console.WriteLine("Початковий масив:");
            OneDimensionalArray.PrintArray(array);

            int choice;
            do
            {
                Console.WriteLine(
                """
                1) Для виконання програми через Array.Resize().
                2) Для виконання програми через створення нового масиву.
                0) Щоб повернутися назад в меню.
                """);
                choice = int.Parse(Console.ReadLine()!);
                switch (choice)
                {
                    case 1:
                        ArrayResizeMethod(ref array);
                        break;
                    case 2:
                        CreateNewArrayMethod(ref array);
                        break;
                    case 0:
                        Program.Main();
                        break;
                    default:
                        Program.ShowProblemMessage();
                        break;
                }
            } while (choice != 0);
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
        static void CreateNewArrayMethod(ref int[] array)
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
        }
        //14. Додати рядок після рядка, що містить мінімальний елемент (якщо у різних місцях є кілька елементів з
        //однаковим мінімальним значенням, то брати останній з них)
        public static void Block_2_Task_14(ref int[][] jagged)
        {
            Console.WriteLine(
            """
            ------------------------------------------------------------------------------------------------------------------------
                                                           MARIIA SOLUTION (БЛОК #2)
            ------------------------------------------------------------------------------------------------------------------------
            """);
            Console.WriteLine("Початковий масив:");
            JaggedArray.PrintJagged(jagged);
            int min = jagged[0][0];
            int index = 0;
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    if (min >= jagged[i][j])
                    {
                        min = jagged[i][j];
                        index = i;
                    }
                }
            }
            Console.WriteLine($"Мінімальний елемент {min} в {index+ 1} рядку.");
            AddRow(ref jagged, index);
            Console.WriteLine("Результат виконання програми:");
            JaggedArray.PrintJagged(jagged);
        }
        static void AddRow(ref int[][] jagged, int index)
        {
            int n = jagged.Length+1;
            Array.Resize(ref jagged, n);
            for (int j = n - 2; j > index; j--)
            {
                jagged[j+1] = jagged[j];
            }
            jagged[index + 1] = new int[jagged[index].Length];
        }
    }
}
