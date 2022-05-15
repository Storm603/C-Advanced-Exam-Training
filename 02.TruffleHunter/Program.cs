using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace _02.TruffleHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> trufflesGathered = new Dictionary<char, int>()
            {
                {'B', 0},
                {'S', 0},
                {'W', 0}
            };

            int trufflesEatenByBoar = 0;
            int forestSize = int.Parse(Console.ReadLine());

            char[,] forest = new char[forestSize, forestSize];

            for (int i = 0; i < forest.GetLength(0); i++)
            {
                char[] inputLine = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    forest[i, j] = inputLine[j];
                }
            }

            string action = Console.ReadLine();

            while (action != "Stop the hunt")
            {
                string[] tokens = action.Split();
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (tokens[0] == "Collect")
                {
                    if (trufflesGathered.ContainsKey(forest[row,col]))
                    {
                        trufflesGathered[forest[row, col]]++;
                        forest[row, col] = '-';
                    }
                }
                else if (tokens[0] == "Wild_Boar")
                {
                    string direction = tokens[3];

                    if (direction == "up")
                    {
                        
                        for (int i = row; i < forest.GetLength(1); i-=2)
                        {
                            if (!IsInRange(forest, i, col))
                            {
                                break;
                            }
                            if (trufflesGathered.ContainsKey(forest[i, col]))
                            {
                                trufflesEatenByBoar++;
                                forest[i, col] = '-';
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < forest.GetLength(1); i += 2)
                        {
                            if (!IsInRange(forest, i, col))
                            {
                                break;
                            }
                            if (trufflesGathered.ContainsKey(forest[i, col]))
                            {
                                trufflesEatenByBoar++;
                                forest[i, col] = '-';
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i < forest.GetLength(0); i -= 2)
                        {
                            if (!IsInRange(forest, i, col))
                            {
                                break;
                            }
                            if (trufflesGathered.ContainsKey(forest[row, i]))
                            {
                                trufflesEatenByBoar++;
                                forest[row, i] = '-';
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i < forest.GetLength(0); i += 2)
                        {
                            if (!IsInRange(forest, row, i))
                            {
                                break;
                            }
                            if (trufflesGathered.ContainsKey(forest[row, i]))
                            {
                                trufflesEatenByBoar++;
                                forest[row, i] = '-';
                            }
                        }
                    }
                }
                action = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {trufflesGathered['B']} black, {trufflesGathered['S']} summer, and {trufflesGathered['W']} white truffles.");
            Console.WriteLine($"The wild boar has eaten {trufflesEatenByBoar} truffles.");

            for (int i = 0; i < forest.GetLength(0); i++)
            {
                for (int j = 0; j < forest.GetLength(1); j++)
                {
                    Console.Write(forest[i,j] + " ");
                }

                Console.WriteLine();
            }
        }

        public static bool IsInRange(char[,] forest, int row, int col)
        {
            return row >= 0 && row < forest.GetLength(0) && col >= 0 && col < forest.GetLength(1);
        }
    }
}
