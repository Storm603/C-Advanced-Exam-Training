using System;
using System.Linq;

namespace T02._Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            int[] coordinates = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            char[,] field = new char[dimentions, dimentions];

            int p1Ships = 0;
            int p2Ships = 0; 
            int destroyedTotal = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = input[j];
                    if (field[i, j] == '<')
                    {
                        p1Ships++;
                    }
                    else if (field[i, j] == '>')
                    {
                        p2Ships++;
                    }
                }
            }

            for (int i = 0; i < coordinates.Length; i += 2)
            {
                int row = coordinates[i];
                int col = coordinates[i + 1];

                if (!IsInRange(field, row, col))
                {
                    continue;
                }

                if (field[row, col] == '<')
                {
                    field[row, col] = 'X';
                    p1Ships--;
                    destroyedTotal++;
                }
                else if (field[row, col] == '>')
                {
                    field[row, col] = 'X';
                    p2Ships--;
                    destroyedTotal++;
                }
                else if (field[row, col] == '#')
                {
                    for (int j = row - 1; j < row + 2; j++)
                    {
                        for (int k = col - 1; k < col + 2; k++)
                        {
                            if (IsInRange(field, j, k))
                            {
                                if (field[j, k] == '<')
                                {
                                    field[j, k] = 'X';
                                    p1Ships--;
                                    destroyedTotal++;
                                }
                                else if (field[j, k] == '>')
                                {
                                    field[j, k] = 'X';
                                    p2Ships--;
                                    destroyedTotal++;
                                }
                            }
                        }
                    }
                }
                if (p1Ships == 0 || p2Ships == 0)
                {
                    break;
                }
            }

            if (p1Ships > 0 && p2Ships > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {p1Ships} ships left. Player Two has {p2Ships} ships left.");
            }
            else if (p2Ships == 0)
            {
                Console.WriteLine($"Player One has won the game! {destroyedTotal} ships have been sunk in the battle.");
            }
            else if (p1Ships == 0)
            {
                Console.WriteLine($"Player Two has won the game! {destroyedTotal} ships have been sunk in the battle.");
            }
        }

        public static bool IsInRange(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }
    }
}
