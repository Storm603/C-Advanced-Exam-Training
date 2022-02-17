using System;
using System.Data;

namespace T02._The_Battle_of_The_Five_Armies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());

            int dimentions = int.Parse(Console.ReadLine());

            int r = 0;
            int c = 0;

            char[] arr = Console.ReadLine().ToCharArray();
            char[,] world = new Char[dimentions, arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                world[0, i] = arr[i];
            }

            for (int i = 1; i < dimentions; i++)
            {
                arr = Console.ReadLine().ToCharArray();

                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] == 'A')
                    {
                        r = i;
                        c = j;
                    }
                    world[i, j] = arr[j];
                }
                
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);

                world[row, col] = 'O';
                world[r, c] = '-';

                armor--;

                if (command == "up")
                {
                    r--;
                    if (!(r < world.GetLength(0) && r >= 0))
                    {
                        r++;
                    }
                }
                else if (command == "down")
                {
                    r++;
                    if (!(r < world.GetLength(0) && r >= 0))
                    {
                        r--;
                    }
                }
                else if (command == "left")
                {
                    c--;
                    if (!(c < world.GetLength(1) && c >= 0))
                    {
                        c++;
                    }

                }
                else if (command == "right")
                {
                    c++;
                    if (!(c < world.GetLength(1) && c >= 0))
                    {
                        c++;
                    }
                }

                
                if (world[r, c] == 'O')
                {
                    armor -= 2;
                }

                if (armor <= 0)
                {
                    Console.WriteLine($"The army was defeated at {r};{c}.");
                    world[r, c] = 'X';
                    break;
                }

                if (world[r,c] == 'M')
                {
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    world[r, c] = '-';
                    break;
                }

                world[r, c] = 'A';
            }

            for (int i = 0; i < world.GetLength(0); i++)
            {
                for (int j = 0; j < world.GetLength(1); j++)
                {
                    Console.Write(world[i,j]);
                }

                Console.WriteLine();
            }
        }
    }
}
