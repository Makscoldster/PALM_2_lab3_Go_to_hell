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
        public static int[][] Menu(int[][] jagged)
        {
            Console.WriteLine("\nMariia Solution");
            Console.WriteLine("Ваш масив:");
            Program.PrintJagged(jagged);

            int choice;
            do
            {
                Console.WriteLine("Для виконання програми через Array.Resize() введіть 1");
                Console.WriteLine("Для виконання програми через створення нового масиву введіть 2");
                Console.WriteLine("Щоб повернутися назад в меню введіть 0");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Виконую програму через Array.Resize()");
                        ArrayResizeMethod(jagged);

                        Console.WriteLine("Результат виконання програми:");
                        Program.PrintJagged(jagged);
                        Console.WriteLine();
                        return jagged;
                    case 2:
                        Console.WriteLine("Виконую програму через створення нового масиву");
                        jagged = CreateNewArrayMethod(jagged);

                        Console.WriteLine("Результат виконання програми:");
                        Program.PrintJagged(jagged);
                        Console.WriteLine();
                        return jagged;
                    case 0:
                        Console.WriteLine();
                        Program.Main();
                        break;
                    default:
                        Console.WriteLine("Команда ''{0}'' не розпізнана. Зробіть, будь ласка, вибір із 1, 2, 0.", choice);
                        break;
                }
            } while (choice != 0);
            return jagged;
        }
        static void ArrayResizeMethod(int[][] jagged)
        {

        }
        static int[][] CreateNewArrayMethod(int[][] jagged)
        {
            int n = jagged.Length;
            int[][] result_jagged = new int[n][];
            int m, k;
            for (int i = 0; i < n; i++)
            {
                m = jagged[i].Length;
                k = 0;
                if (m%2 == 0) result_jagged[i] = new int[m / 2];
                else result_jagged[i] = new int[m / 2 + 1];
                for (int j = 0; j < m; j+=2)
                {
                    result_jagged[i][k++] = jagged[i][j];
                }
            }
            return result_jagged;
        }
    }
}
