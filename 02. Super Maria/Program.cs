using System;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace _02._Super_Maria
{
    class Program
    {
        static void Main(string[] args)
        {

            int lives = int.Parse(Console.ReadLine());

            int dimentions = int.Parse(Console.ReadLine());

            char[,] matrix = new Char[dimentions, dimentions];

            int r = 0;
            int c = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (input[j] == 'M')
                    {
                        r = i;
                        c = j;
                    }

                    matrix[i, j] = input[j];
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string movement = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);

                matrix[row, col] = 'B';

                matrix[r, c] = '-';

                switch (movement)
                {
                    case "W":
                        if (r - 1 >= 0)
                        {
                            r--;
                        }
                        break;
                    case "A":
                        if (c - 1 >= 0)
                        {
                            c--;
                        }
                        break;
                    case "S":
                        if (r + 1 < matrix.GetLength(1))
                        {
                            r++;
                        }
                        break;
                    case "D":
                        if (c + 1 < matrix.GetLength(0))
                        {
                            c++;
                        }
                        break;
                }

                lives--;

                
                if (matrix[r, c] == 'B')
                {
                    lives -= 2;
                }
                else if (matrix[r, c] == 'P')
                {
                    matrix[r, c] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    break;
                }

                if (lives <= 0)
                {
                    Console.WriteLine($"Mario died at {r};{c}.");
                    matrix[r, c] = 'X';
                    break;
                }

                matrix[r, c] = 'M';

            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }

        }
    }
}
