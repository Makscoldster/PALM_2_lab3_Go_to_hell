using System;
using System.Linq;

namespace Lab3
{
    
    internal class Jenlast_Solution
    {
        public static void Block_1_Task_12(ref int[] array)
        {
            // boba
            Console.WriteLine(
            """
            ------------------------------------------------------------------------------------------------------------------------
                                                          JENLAST SOLUTION (БЛОК #1)
            ------------------------------------------------------------------------------------------------------------------------
            """);

            Console.WriteLine("Початковий масив:");
            OneDimensionalArray.PrintArray(array);

            int k = 0, t;
            do
            {
                Console.WriteLine("Введіть кількість елементів яку потрібно вставити в масив: ");
                k = int.Parse(Console.ReadLine()!);
                if (k < 0) Program.ShowProblemMessage();
            }
            while (k < 0);
            
            if ((array.Length == 0 || array.Length == 1 ) && k != 0)
            {
                array = ZeroArray(array, k);
            }
            else if (array.Length != 0 && k != 0)
            {
                array = NormalArray(array, k);
            }

            Console.WriteLine("Кінцевий масив:");
            OneDimensionalArray.PrintArray(array);
        }
        public static int[] NormalArray(int[] array, int k)
        {
            int t;
            do
            {
                Console.WriteLine("Введіть номер елементу починаючи з якого будуть вставлятись елементи: ");
                t = int.Parse(Console.ReadLine()!);
                if (t < 0 || t > array.Length) Program.ShowProblemMessage();
            }
            while (t < 0 || t > array.Length);

            Array.Resize(ref array, array.Length + k);

            for (int i = array.Length - 1; i >= t + k; i--)
            {
                array[i] = array[i - k];
            }

            string[] new_nums;
            do
            {
                Console.WriteLine($"Введіть нові елементи, які додадуться до масиву з {t} елементу: ");
                new_nums = Console.ReadLine()!.Split();
                if (new_nums.Length > k)
                {
                    Console.WriteLine("Значення кількості елементів, які потрібно вставити та сама кількість елементів не співпадають, спробуйте ще раз.");
                }
                else break;

            } while (true);

            for (int i = 0; i < k; i++)
            {
                array[t + i] = int.Parse(new_nums[i]);
            }

            return array;
        }
        public static int[] ZeroArray(int[] array, int k)
        {
            int[] new_nums;
            do
            {
                Console.WriteLine($"Введіть нові елементи, які додадуться до масиву: ");
                new_nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                if (new_nums.Length > k)
                {
                    Console.WriteLine("Значення кількості елементів, які потрібно вставити та сама кількість елементів не співпадають, спробуйте ще раз.");
                }
                else break;

            } while (true);

            array = new_nums;

            return array;
        }
        public static void Block_2_Task_4(ref int[][] jagged)
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

            Console.WriteLine("Введіть номер рядка починаючи з якого рядки будуть знищуватись (рахунок починається з 0): ");
            k1 = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Введіть номер рядка до якого будуть видалятись рядки (рахунок починається з 0): ");
            k2 = int.Parse(Console.ReadLine()!);

            if (k1 < 0)
            {
                k1 = 0;
            }
            if (k2 > jagged.Length - 1)
            {
                k2 = jagged.Length - 1;
            }

            int[][] newjagged;
            newjagged = NewJaggedArray(jagged, k1, k2);

            jagged = newjagged;

            Console.WriteLine("Кінцевий масив:");
            JaggedArray.PrintJagged(jagged);
        }
        static int[][] NewJaggedArray(int[][] jagged, int k1, int k2)
        {
            // розраховуємо кількість рядків, які треба видалити
            int start = Math.Min(k1, k2);
            int end = Math.Max(k1, k2);
            int cnt = end - start + 1;

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