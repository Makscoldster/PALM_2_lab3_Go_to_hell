using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    public static class JaggedArray
    {
        public static void PrintJagged(int[][] jagged)
        {
            int maxLength = 0;
            int n = jagged.Length;
            int m;
            for (int i = 0; i < n; ++i)
            {
                m = jagged[i].Length;
                for (int j = 0; j < m; ++j)
                {
                    int length = jagged[i][j].ToString().Length;
                    if (length > maxLength)
                        maxLength = length;
                }
            }
            for (int i = 0; i < n; ++i)
            {
                m = jagged[i].Length;
                for (int j = 0; j < m; ++j)
                    Console.Write(jagged[i][j].ToString().PadLeft(maxLength + 1));
                Console.WriteLine();
            }
        }
        public static int[][] Input()
        {
            Console.WriteLine(
                """
                ------------------------------------------------------------------------------------------------------------------------
                                                                ВИБІР СПОСОБУ ЗАПОВНЕННЯ
                ------------------------------------------------------------------------------------------------------------------------
                1) Через пробіли або табуляції
                2) Випадково з задянням меж рандому
                3) З файлу input_jagged.txt
                0) Повернутися в меню
                """);


            byte ChoiceMethod = Program.Choice(3);
            uint n = 0;
            if (ChoiceMethod == 1 || ChoiceMethod == 2)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Введіть кількість підмасивів");
                        n = uint.Parse(Console.ReadLine()!);
                        if (n==0) Program.ShowProblemMessage();
                        else break;
                    }
                    catch { Program.ShowProblemMessage(); }
                }
                while (true);
            }

            int[][] jagged = null!;

            switch (ChoiceMethod)
            {
                case 1:
                    jagged = InputInSingleLine(n);
                    break;
                case 2:
                    jagged = InputRamdomly(n);
                    break;
                case 3:
                    jagged = InputFromFile();
                    break;
                case 0:
                    Program.Main();
                    break;
                default:
                    Program.ShowProblemMessage();
                    break;
            }

            static int[][] InputInSingleLine(uint n)
            {

                int[][] jagged = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Введіть елементи масиву номер {i + 1}");
                    jagged[i] = Array.ConvertAll(Console.ReadLine()!.Split(OneDimensionalArray.Separators, StringSplitOptions.RemoveEmptyEntries), int.Parse);
                    if (jagged[i].Length == 0)
                    {
                        Program.ShowProblemMessage();
                        i--;
                    }

                }
                return jagged;
            }

            static int[][] InputRamdomly(uint n)
            {
                uint length = 0;
                do
                {
                    try
                    {
                        Console.WriteLine("Вкажіть кількість елементів у всіх підмасивах");
                        length = uint.Parse(Console.ReadLine()!);
                        if (length == 0) Program.ShowProblemMessage();
                        else break;
                    }
                    catch { Program.ShowProblemMessage(); }
                }
                while (true);
;
                int minRange;
                int maxRange;
                do
                {
                    Console.WriteLine("Введіть мінімальну межу рандому:");
                    minRange = int.Parse(Console.ReadLine()!);

                    Console.WriteLine("Введіть максимальну межу рандому:");
                    maxRange = int.Parse(Console.ReadLine()!);

                    if (minRange > maxRange)
                        Console.WriteLine("Мінімальна межа не може бути більшою за максимальну. Спробуйте знову.");

                } while (minRange > maxRange);

                Random rndGen = new Random();

                int[][] jagged = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    jagged[i] = new int[length];
                    for (int j = 0; j < jagged[i].Length; j++) jagged[i][j] = rndGen.Next(minRange, maxRange + 1);
                }

                //Console.WriteLine("Згенерована матриця:");
                //PrintJagged(jagged);

                return jagged;
            }
            static int[][] InputFromFile()
            {
                List<int[]> jaggedList = new List<int[]>();
                StreamReader file = new StreamReader("input_jagged.txt");
                string line;
                while ((line = file.ReadLine()!) != null)
                {
                    int[] row = Array.ConvertAll(line.Split(OneDimensionalArray.Separators, StringSplitOptions.RemoveEmptyEntries), int.Parse);
                    jaggedList.Add(row);
                }
                int[][] jagged = new int[jaggedList.Count][];
                for (int i = 0; i < jaggedList.Count; i++)
                {
                    jagged[i] = jaggedList[i];
                }
                if (jagged.Length == 0)
                {
                    Console.WriteLine("Помилка! Масив пустий.");
                    Input();
                }
                return jagged;
            }

            return jagged;
        }
    }
}