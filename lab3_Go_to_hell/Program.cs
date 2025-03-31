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
                    ------------------------------------------------------------------------------------------------------------------------
                                                                         ВИБІР ЗАВДАННЯ
                    ------------------------------------------------------------------------------------------------------------------------
                    БЛОК #1:
                    1) Вставити після кожного парного елемента елемент із значенням 0
                    2) Знищити всі елементи з непарними індексами
                    3) Вставити К елементів, починаючи з номеру T
                    БЛОК #2:
                    4) Розбити перший рядок (при довжині >10 символів) на 2 (1-й коротший, якщо довжина непарна). Зсунути решту рядків вниз.
                    5) Вставити рядок після останнього рядка з мінімальним елементом.
                    6) Видалити рядки з К1 до К2 (або всі можливі, якщо К1/К2 недійсні).
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
                        MakscoldSolution.Block_1_Taks_15(ref array);
                        break;
                    case 2:
                        array = MariiaSolution.Menu(array);
                        break;
                    case 3:
                        Jenlast_Solution.InsertElements(array);
                        break;
                    case 4:
                        MakscoldSolution.Block_2_Taks_15(ref jagged);
                        break;
                    case 5:
                        MariiaSolution.FindMinElement(ref jagged);
                        break;
                    case 6:
                        Jenlast_Solution.DeleteRowsFromK1ToK2(jagged);
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