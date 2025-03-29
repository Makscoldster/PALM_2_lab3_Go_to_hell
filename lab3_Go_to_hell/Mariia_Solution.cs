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
            Console.WriteLine("Початковий масив:");
            Program.PrintJagged(jagged);

            int choice;
            do
            {
                Console.WriteLine("1) Для виконання програми через Array.Resize().");
                Console.WriteLine("2) Для виконання програми через створення нового масиву.");
                Console.WriteLine("0) Щоб повернутися назад в меню.");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ArrayResizeMethod(jagged);
                        return jagged;
                    case 2:
                        jagged = CreateNewArrayMethod(jagged);
                        return jagged;
                    case 0:
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
            Console.WriteLine("Виконую програму через Array.Resize()");
            for (int i = 0; i < jagged.Length; i++)
            {
                int k = 0;
                for (int j = 0; j < jagged[i].Length; j += 2)
                {
                    jagged[i][k++] = jagged[i][j];
                }
                Array.Resize(ref jagged[i], k);
            }
            Console.WriteLine("Результат виконання програми:");
            Program.PrintJagged(jagged);
        }
        static int[][] CreateNewArrayMethod(int[][] jagged)
        {
            Console.WriteLine("Виконую програму через створення нового масиву");
            int n = jagged.Length;
            int[][] result_jagged = new int[n][];
            int m, k;
            for (int i = 0; i < n; i++)
            {
                m = jagged[i].Length;
                k = 0;
                result_jagged[i] = new int[(m+1) / 2];
                for (int j = 0; j < m; j+=2)
                {
                    result_jagged[i][k++] = jagged[i][j];
                }
            }
            Console.WriteLine("Кінцевий масив:");
            Program.PrintJagged(result_jagged);
            return result_jagged;
        }
    }
}
