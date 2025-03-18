using Lab3;

namespace lab3_Go_to_hell
{
    internal class Program
    {
        public static void PrintJagged(int[][] jagged)
        {
            foreach (var arr in jagged) Console.WriteLine(String.Join(' ', arr));
        }

        static int[][] Input()
        {

            Console.WriteLine("Виберіть спосіб заповення:\n" +
                                  "1) Через пробіли або табуляції \n" +
                                  "2) Випадково з задянням меж рандому\n" +
                                  "3) З файлу Intup.txt\n" + // Потібдно реалізувати ввід даних з текстового фазду
                                  "0) Вийти з програми");


            byte ChoiceMethod = Choice(3);

            uint n;
            do
            {
                try
                {
                    Console.WriteLine("Введіть кількість масивів");
                    n = uint.Parse(Console.ReadLine());
                    break;
                }
                catch { ShowProblemMessage(); }
            }
            while (true);

            int[][] jagged;

            Func<int[][]> action = ChoiceMethod switch
            {
                1 => () => InputInSingleLine(n),
                2 => () => InputRamdomly(n),
                3 => () => ShowProblemMessageWithReturn(),
                _ => () => ShowProblemMessageWithReturn(),
            };

            jagged = action();

            static int[][] InputInSingleLine(uint n)
            {

                int[][] jagged = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Введіть елементи масиву номер {i + 1}");
                    jagged[i] = Array.ConvertAll(Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
                }
                return jagged;
            }

            static int[][] InputRamdomly(uint n)
            {
                Console.WriteLine("Вкажіть кількість елементів у всіх підмасивах");
                uint length = uint.Parse(Console.ReadLine());

                int minRange;
                int maxRange;
                do
                {
                    Console.WriteLine("Введіть мінімальну межу рандому:");
                    minRange = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введіть максимальну межу рандому:");
                    maxRange = int.Parse(Console.ReadLine());

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

            return jagged;
        }
        static byte Choice(byte countOfBlocks = 4)
        {
            byte choice;
            do
            {
                try
                {
                    choice = byte.Parse(Console.ReadLine());
                    if (choice <= countOfBlocks) return choice;
                    ShowProblemMessage();
                }
                catch { ShowProblemMessage(); }
            } while (true);
        }
        static void ShowProblemMessage() => Console.WriteLine("Спробуйте ще раз");
        static int[][] ShowProblemMessageWithReturn()
        {
            Console.WriteLine("Спробуйте ще раз");
            return new int[0][];
        }
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            do
            {
                //bool create = true;
                Console.WriteLine("Виберіть умову завдання:\n" +
                                  "1) Вставити після кожного парного елемента елемент із значенням 0 \n" +
                                  "2) Знищити всі елементи з непарними індексами\n" +
                                  "3) \n" +
                                  "0) Вийти з програми");

                byte choiceBlock = Choice(3);
                if (choiceBlock == 0) return;

                int[][] jagged = Input();

                Action action = choiceBlock switch
                {
                    1 => () => MakscoldSolution.ZeroAfterEven(jagged),
                    2 => () => MariiaSolution.Menu(jagged),
                    3 => () => ShowProblemMessage(),
                    _ => () => ShowProblemMessage(),
                };
                action();

                //Console.WriteLine("Ввести нову матрицю?\n" +
                //                  "1) Так\n" +
                //                  "Other) Ні");



            } while (true);

        }
    }
}