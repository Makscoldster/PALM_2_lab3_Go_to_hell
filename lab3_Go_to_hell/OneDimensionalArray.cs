using System;

using System.IO;

namespace Lab3
{
    public static class OneDimensionalArray
    {
        public static readonly char[] Separators = [ ' ', '\t' ];
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
                3) З файлу input_array.txt
                0) Повернутися в меню
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
                case 0:
                    Program.Main();
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
            uint length;
            do
            {
                try
                {
                    Console.WriteLine("Вкажіть кількість елементів у масиві:");
                    length = uint.Parse(Console.ReadLine()!);
                    break;
                }
                catch { Program.ShowProblemMessage(); }
            }
            while (true);

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
                string line = File.ReadAllText("input_array.txt");
                return Array.ConvertAll(line.Split(Separators, StringSplitOptions.RemoveEmptyEntries), int.Parse);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка при читанні файлу: " + ex.Message);
                return Array.Empty<int>();
            }
        }
    }
}
