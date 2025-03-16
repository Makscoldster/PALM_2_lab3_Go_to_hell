using lab3_Go_to_hell;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public static class MakscoldSolution
    {//15. Вставити після кожного парного елемента елемент із значенням 0
        public static void ZeroAfterEven(int[][] jagged)
        {
            Console.WriteLine("Початковий масив:");
            Program.PrintJagged(jagged);

            int[] countOfEven = CountOfEven(jagged);

            int[][] result = new int[jagged.Length][];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[jagged[i].Length+countOfEven[i]]; // Initialize the inner array
                int indexOfJagged = 0;
                for (int j = 0; j < result[i].Length; j++)
                {
                    result[i][j] = jagged[i][indexOfJagged++];
                    if (result[i][j] % 2 == 0 && j + 1 < result[i].Length) result[i][++j] = 0;
                }
            }
            jagged = result;

            Console.WriteLine("Кінцевий масив:");
            Program.PrintJagged(jagged);
        }
        static int[] CountOfEven(int[][] jagged)
        {
            int[] countOfEven = new int[jagged.Length];
            for (int i = 0; i < jagged.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    if (jagged[i][j] % 2 == 0) count++;
                }
                countOfEven[i] = count;
            }
            return countOfEven;
        }
    }
}
