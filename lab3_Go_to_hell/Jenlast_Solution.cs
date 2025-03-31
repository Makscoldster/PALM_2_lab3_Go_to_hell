using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using lab3_Go_to_hell;

namespace Lab3
{
    internal class Jenlast_Solution
    {
        public static void Block_1_Task_12(ref int[] array)
        {
            Console.WriteLine(
            """
            ------------------------------------------------------------------------------------------------------------------------
                                                          JENLAST SOLUTION (БЛОК #1)
            ------------------------------------------------------------------------------------------------------------------------
            """);

            Console.WriteLine("Початковий масив:");
            OneDimensionalArray.PrintArray(array);

            int k, t;
            do
            {
                Console.Write("Введіть кількість елементів яку потрібно вставити в масив: ");
                k = int.Parse(Console.ReadLine());
                Console.Write("Введіть номер елементу починаючи з якого будуть вставлятись елементи (рахунок починається з 0): ");
                t = int.Parse(Console.ReadLine());

                if (t < 0 || t >= array.Length)
                {
                    Program.ShowProblemMessage();
                }
                else break;

            } while (true);

            Array.Resize(ref array, array.Length + k);

            for (int i = array.Length - 1; i >= t + k; i--)
            {
                array[i] = array[i - k];
            }

            string[] new_nums;
            do
            {
                Console.Write($"Введіть нові елементи, які додадуться до масиву після {t} елементу: ");
                new_nums = Console.ReadLine().Split();
                if (new_nums.Length > k)
                {
                    Console.WriteLine("Значення кількості елементів, які потрібно вставити та сама кількість елементів не співпадають, спробуйте ще раз.");
                }
                else break;

            } while (true);

            for (int i = 0; i < k; i++)
            {
                array[t + i + 1] = int.Parse(new_nums[i]);
            }

            Console.WriteLine("Кінцевий масив:");
            OneDimensionalArray.PrintArray(array);
        }
        public static void Block_2_Task_4(int[][] jagged)
        {
            Console.WriteLine(
            """
            ------------------------------------------------------------------------------------------------------------------------
                                                          JENLAST SOLUTION (БЛОК #2)
            ------------------------------------------------------------------------------------------------------------------------
            """);

            Console.WriteLine("Початковий масив:");
            JaggedArray.PrintJagged(jagged);

            int k1, k2;
            do
            {
                Console.Write("Введіть номер рядка починаючи з якого рядки будуть знищуватись (рахунок починається з 0): ");
                k1 = int.Parse(Console.ReadLine());
                Console.Write("Введіть номер рядка до якого будуть видалятись рядки (рахунок починається з 0): ");
                k2 = int.Parse(Console.ReadLine());

                if (k1 < 0 || k1 > jagged.Length - 1)
                {
                    Program.ShowProblemMessage();
                }
                else if (k2 < 0 || k2 > jagged.Length - 1)
                {
                    Console.WriteLine("Некоректно введено номер другого рядка");
                }
                else break;

            } while (true);

            int[][] newjagged;
            if (Math.Min(k1, k2) + 1 == Math.Max(k1,k2))
            {
                newjagged = Exclusion(jagged, k1, k2);
            }
            else
            {
                newjagged = NewJaggedArray(jagged, k1, k2);
            }

            Console.WriteLine("Кінцевий масив:");
            JaggedArray.PrintJagged(newjagged);
        }
        static int[][] Exclusion(int[][] jagged, int k1, int k2)
        {
            int[] rowsIndexes = new int[2];

            rowsIndexes[0] = Math.Min(k1, k2);
            rowsIndexes[1] = Math.Max(k1, k2);

            int[][] newjagged = new int[jagged.Length - 2][];
            int j = 0;
            for (int i = 0; i < jagged.Length; i++)
            {
                if (!rowsIndexes.Contains(i))
                {
                    newjagged[j++] = jagged[i];
                }
            }

            return newjagged;
        }
        static int[][] NewJaggedArray(int[][] jagged, int k1, int k2)
        {
            // розраховуємо кількість рядків, які треба видалити
            int start = Math.Min(k1, k2) + 1;
            int end = Math.Max(k1, k2);
            int cnt = end - start;

            // створюємо масив в якому будуть індекси рядків, які будуть видалятись
            int[] rowsIndexes = new int[cnt];
            for (int i = 0; i < cnt; i++)
            {
                rowsIndexes[i] = start + i;
            }

            // створюємо масив в якому будуть рядки, які не видалились
            int[][] newjagged = new int[jagged.Length - cnt][];
            int j = 0;
            for (int i = 0; i < jagged.Length; i++)
            {
                if (!rowsIndexes.Contains(i))
                {
                    newjagged[j++] = jagged[i];
                }
            }

            return newjagged;
        }
    }
}
