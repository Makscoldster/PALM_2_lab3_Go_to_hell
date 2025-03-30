using System;
using System.Collections.Generic;
using System.IO;

namespace lab3_Go_to_hell
{
    internal class OneDimensionalArray
    {
        public static void PrintArray(int[] array)
        {
            Console.WriteLine(String.Join(' ', array));
        }

        public static int[] Input()
        {
            Console.WriteLine("Виберіть спосіб заповнення:\n" +
                              "1) Через пробіли або табуляції \n" +
                              "2) Випадково з заданими межами рандому\n" +
                              "3) З файлу input.txt\n" +
                              "0) Вийти з програми");

            byte ChoiceMethod = Program.Choice(3);
            int[] array = null;

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
            return Array.ConvertAll(Console.ReadLine()!.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
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

            Random rndGen = new Random();
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
                return Array.ConvertAll(line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при читанні файлу: " + ex.Message);
                return new int[0];
            }
        }
    }
}
