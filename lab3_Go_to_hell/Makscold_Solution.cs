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
        public static void SplitLine(ref int[][] jagged)
        {
            Console.WriteLine(
            """
            ------------------------------------------------------------------------------------------------------------------------
                                                          MAKSCOLD SOLUTION (БЛОК #2)
            ------------------------------------------------------------------------------------------------------------------------
            """);
            Console.WriteLine("Початковий масив:");
            JaggedArray.PrintJagged(jagged);

            int[] countOfEven = TestCountOfEven(jagged);

            int[][] result = new int[jagged.Length][];

            Array.Copy(jagged[0], 0, firstPart, 0, splitIndex);
            Array.Copy(jagged[0], splitIndex, secondPart, 0, firstLineLength - splitIndex);

            int[][] result = new int[jagged.Length + 1][];
            result[0] = firstPart;
            result[1] = secondPart;

            for (int i = 1; i < jagged.Length; i++)
            {
                result[i] = new int[jagged[i].Length + countOfEven[i]]; // Initialize the inner array
                int indexOfJagged = 0;
                for (int j = 0; j < result[i].Length; j++)
                {
                    result[i][j] = jagged[i][indexOfJagged++];
                    if (result[i][j] % 2 == 0 && j + 1 < result[i].Length) result[i][++j] = 0;
                }
            }

            jagged = result;

            Console.WriteLine("Кінцевий масив:");
            JaggedArray.PrintJagged(jagged);
        }
        static int[] TestCountOfEven(int[][] jagged)
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

        //15. Вставити після кожного парного елемента елемент із значенням 0
        public static void ZeroAfterEven(ref int[] array)
        {
            Console.WriteLine(
            """
            ------------------------------------------------------------------------------------------------------------------------
                                                          MAKSCOLD SOLUTION (БЛОК #1)
            ------------------------------------------------------------------------------------------------------------------------
            """);
            Console.WriteLine("Початковий масив:");
            OneDimensionalArray.PrintArray(array);

            int countOfEven = CountOfEven(array);

            int[] result = new int[array.Length + countOfEven];


            int indexOfarray = 0;
            for (int j = 0; j < result.Length; j++)
            {
                result[j] = array[indexOfarray++];
                if (result[j] % 2 == 0 && j + 1 < result.Length) result[++j] = 0;
            }
            array = result;

            Console.WriteLine("Кінцевий масив:");
            OneDimensionalArray.PrintArray(array);
        }
        static int CountOfEven(int[] array)
        {
            int count = 0;
            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] % 2 == 0) count++;
            }
            return count;
        }
    }
}
