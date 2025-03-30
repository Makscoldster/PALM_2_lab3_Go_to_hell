using Lab3;
using lab3_Go_to_hell;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_Go_to_hell
{
    internal class Program
    {
        public static byte Choice(byte countOfBlocks = 4)
        {
            byte choice;
            do
            {
                try
                {
                    choice = byte.Parse(Console.ReadLine()!);
                    if (choice <= countOfBlocks) return choice;
                    ShowProblemMessage();
                }
                catch { ShowProblemMessage(); }
            } while (true);
        }
        public static void ShowProblemMessage() => Console.WriteLine("Спробуйте ще раз");
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            bool wantNewMatrix = true;
            int[][] jagged = null!;
            int[] array = null!;
            do
            {
                //bool create = true;
                Console.WriteLine(
                    """
                    Виберіть умову завдання:
                    Блок #1:
                    1) Вставити після кожного парного елемента елемент із значенням 0
                    2) Знищити всі елементи з непарними індексами
                    3) Вставити К елементів, починаючи з номеру T
                    Блок #2:
                    4) Якщо перший (технічно 0-й) рядок довший 10 елементів, то розбити його на два приблизно рівні:
                    перша половина елементів іде в один рядок (він стає 0-м), решта елементів цього рядку йде в інший
                    рядок (1-й), подальші рядки зсуваються далі (вниз); якщо початкова довжина 0-го рядка непарна, то
                    новий 0-й рядок має бути на 1 елемент коротшим, чим новий 1-й.
                    5) Додати рядок після рядка, що містить мінімальний елемент (якщо у різних місцях є кілька елементів з
                    однаковим мінімальним значенням, то брати останній з них)
                    6) Знищити рядки, починаючи з рядка К1 і до рядка К2 (якщо в масиві фактично є лише деякі з таких
                    рядків, знищити всі, які можна знищити)
                    0) Вийти з програми
                    """);

                byte choiceBlock = Choice(6);
                if (choiceBlock == 0) return;
                if (choiceBlock < 4 && array == null)
                {
                    array = OneDimensionalArray.Input();
                }
                else if (choiceBlock > 3 && jagged == null)
                {
                    jagged = JaggedArray.Input();
                }
                else if (wantNewMatrix)
                {
                    if (choiceBlock < 4) array = OneDimensionalArray.Input();
                    else jagged = JaggedArray.Input();
                }

                switch (choiceBlock)
                {
                    case 1:
                        MakscoldSolution.ZeroAfterEven(ref array);
                        break;
                    case 2:
                        array = MariiaSolution.Menu(array);
                        break;
                    case 3:
                        //Jenlast_Solution.InsertElements(array);
                        break;
                    case 4:
                        MakscoldSolution.TestZeroAfterEven(ref jagged);
                        break;
                    case 5:
                        //Jenlast_Solution.InsertElements(jagged);
                        break;
                    case 6:
                        //Jenlast_Solution.InsertElements(jagged);
                        break;
                    default:
                        ShowProblemMessage();
                        break;
                }
                if (choiceBlock<4) wantNewMatrix = array.Length == 0 || AskForNewMatrix();
                else wantNewMatrix = jagged.Length == 0 || AskForNewMatrix();
            } while (true);
        }
        static bool AskForNewMatrix()
        {
            Console.WriteLine(
                """
                Ввести нову матрицю?
                1) Так
                Other) Ні
                """);

            try
            {
                byte input = byte.Parse(Console.ReadLine()!);
                return input == 1;
            }
            catch 
            {
                ShowProblemMessage();
                return false;
            }
        }
    }
}