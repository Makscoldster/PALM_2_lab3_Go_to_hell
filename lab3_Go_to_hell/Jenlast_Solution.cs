using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab3_Go_to_hell;

namespace Lab3
{
    internal class Jenlast_Solution
    {
        public static void InsertElements(int[][] jagged)
        {
            // boba
            Console.WriteLine("Початковий масив:");
            Program.PrintJagged(jagged);

            int k, rowIndex, coloumn;
            do
            {
                Console.Write("Введіть кількість елементів яку потрібно вставити в масив: ");
                k = int.Parse(Console.ReadLine());
                Console.Write("Введіть номер рядка масиву, в якому будуть вставлятись елементи (рахунок починається з 0): ");
                rowIndex = int.Parse(Console.ReadLine());
                Console.Write("Введіть номер елементу починаючи з якого будуть вставлятись елементи: ");
                coloumn = int.Parse(Console.ReadLine());

                if (rowIndex < 0 || rowIndex >= jagged.Length)
                {
                    Console.WriteLine("Некоректно введено номер рядка");
                }
                else if (coloumn < 0 || coloumn >= jagged[rowIndex].Length)
                {
                    Console.WriteLine("Некоректно введено номер елементу");
                }
                else break;

            } while (true);

            int[] row = jagged[rowIndex];

            Array.Resize(ref row, row.Length + k);

            for (int i = row.Length - 1; i >= coloumn + k; i--)
            {
                row[i] = row[i - k];
            }

            string[] new_nums;
            do
            {
                Console.Write($"Введіть нові елементи, які додадуться до масиву після {coloumn} елементу: ");
                new_nums = Console.ReadLine().Split();
                if (new_nums.Length > k)
                {
                    Console.WriteLine("Значення кількості елементів, які потрібно вставити та сама кількість елементів не співпадають, спробуйте ще раз.");
                }
                else break;

            } while (true);

            for (int i = 0; i < k; i++)
            {
                row[coloumn + i] = int.Parse(new_nums[i]);
            }

            jagged[rowIndex] = row;

            Console.WriteLine("Кінцевий масив:");
            Program.PrintJagged(jagged);
        }
    }
}
