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
    {//15. Розбити перший рядок (при довжині >10 символів) на 2 (1-й коротший, якщо довжина непарна). Зсунути решту рядків вниз.
        public static void Block_2_Task_15(ref int[][] jagged)
        {
            Console.WriteLine(
            """
            ------------------------------------------------------------------------------------------------------------------------
                                                          MAKSCOLD SOLUTION (БЛОК #2)
            ------------------------------------------------------------------------------------------------------------------------
            """);
            Console.WriteLine("Початковий масив:");
            JaggedArray.PrintJagged(jagged);

            int firstLineLength = jagged[0].Length;
            if (firstLineLength > 10)
            {
                int splitIndex = (firstLineLength) / 2;

                int[] firstPart = new int[splitIndex];
                int[] secondPart = new int[firstLineLength - splitIndex];

                for (int i = 0; i < splitIndex; i++)
                {
                    firstPart[i] = jagged[0][i];
                }
                for (int i = splitIndex; i < firstLineLength; i++)
                {
                    secondPart[i - splitIndex] = jagged[0][i];
                }

                int[][] result = new int[jagged.Length + 1][];
                result[0] = firstPart;
                result[1] = secondPart;

                for (int i = 1; i < jagged.Length; i++)
                {
                    result[i + 1] = jagged[i];
                }

                jagged = result;
            }

            Console.WriteLine("Кінцевий масив:");
            JaggedArray.PrintJagged(jagged);
        }
        //15. Вставити після кожного парного елемента елемент із значенням 0
        public static void Block_1_Task_15(ref int[] array)
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
