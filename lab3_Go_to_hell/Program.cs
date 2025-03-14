namespace lab3_Go_to_hell
{
    iinternal class Program
    {
        static int[][] Input()
        {
            Console.WriteLine("Введіть кількість масивів");
            int n = int.Parse(Console.ReadLine());

            int[][] stack = new int[n][];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть елементи масиву номер {i + 1} через пробіл");
                stack[i] = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            }
            return stack;
        }
        static byte Choice()
        {
            Console.WriteLine("Виберіть умову завдання:\n" +
                              "1) \n" +
                              "2) \n" +
                              "3) \n" +
                              "0) Вийти з програми");

            byte choice;
            byte countOfBlocks = 4;
            do
            {
                try
                {
                    choice = byte.Parse(Console.ReadLine());
                    if (choice <= countOfBlocks) return choice;
                    Problem();
                }
                catch { Problem(); }
            } while (true);
        }
        static void Problem() => Console.WriteLine("Спробуйте ще раз");
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            do
            {
                //bool create = true;

                byte choice = Choice();
                if (choice == 0) return;

                int[][] jagged = Input();

                Action action = choice switch
                {
                    1 => () => MakscoldSolution.Foo(jagged),
                    2 => () => Problem(),
                    3 => () => Problem(),
                    _ => () => Problem(),
                };
                action();

                //Console.WriteLine("Ввести нову матрицю?\n" +
                //                  "1) Так\n" +
                //                  "Other) Ні");



            } while (true);

        }
    }
}