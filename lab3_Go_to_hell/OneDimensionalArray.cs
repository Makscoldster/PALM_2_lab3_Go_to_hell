using System;
using System.Collections.Generic;
using System.IO;

namespace lab3_Go_to_hell
{
    internal class OneDimensionalArray
    {
        private static readonly char[] Separators = [ ' ', '\t' ];
        public static void PrintArray(int[] array)
        {
            Console.WriteLine(String.Join(' ', array));
        }

        public static int[] Input()
        {
            Console.WriteLine(
                """
                ------------------------------------------------------------------------------------------------------------------------
                                                                ВИБІР СПОСОБУ ЗАПОВНЕННЯ
                ------------------------------------------------------------------------------------------------------------------------
                1) Через пробіли або табуляції
                2) Випадково з задянням меж рандому
                3) З файлу Intup.txt
                0) Вийти з програми
                """);

            byte ChoiceMethod = Program.Choice(3);
            int[] array = null!;

            switch (ChoiceMethod)
            {
                case 1:
                    array = InputInSingleLine();
                    break;
                case 2:
                    array = InputRandomly();
                    break;
                case 3:
                    array = InputFromFile();
                    break;
                default:
                    Program.ShowProblemMessage();
                    break;
            }
            return array;
        }

        static int[] InputInSingleLine()
        {
            Console.WriteLine("Введіть елементи масиву через пробіл або табуляцію:");
            return Array.ConvertAll(Console.ReadLine()!.Split(Separators, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }

        static int[] InputRandomly()
        {
            Console.WriteLine("Вкажіть кількість елементів у масиві:");
            int length = int.Parse(Console.ReadLine()!);

            int minRange, maxRange;
            do
            {
                Console.WriteLine("Введіть мінімальну межу рандому:");
                minRange = int.Parse(Console.ReadLine()!);

                Console.WriteLine("Введіть максимальну межу рандому:");
                maxRange = int.Parse(Console.ReadLine()!);

                if (minRange > maxRange)
                    Console.WriteLine("Мінімальна межа не може бути більшою за максимальну. Спробуйте знову.");

            } while (minRange > maxRange);
            
            Random rndGen = new();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
                array[i] = rndGen.Next(minRange, maxRange + 1);

            return array;
        }

        static int[] InputFromFile()
        {
            try
            {
                string line = File.ReadAllText("input.txt");
                return Array.ConvertAll(line.Split(Separators, StringSplitOptions.RemoveEmptyEntries), int.Parse);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при читанні файлу: " + ex.Message);
                //return new int[0];
                #pragma warning disable IDE0301
                return Array.Empty<int>();
                #pragma warning restore IDE0301
            }
        }
    }
}
