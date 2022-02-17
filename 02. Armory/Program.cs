using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _02._Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] armory = new Char[size, size];

            int or = 0;
            int oc = 0;
            int swordsBought = 0;
            int index = 0;

            string[] coordinates = new string[2];

            for (int i = 0; i < armory.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < armory.GetLength(1); j++)
                {
                    armory[i, j] = input[j];

                    if (armory[i,j] == 'A')
                    {
                        or = i;
                        oc = j;
                    }

                    if (armory[i,j] == 'M')
                    {
                        coordinates[index] = $"{i} {j}";
                        index++;
                    }
                }
            }

            while (true)
            {
                string movement = Console.ReadLine();

                armory[or, oc] = '-';

                if (movement == "up")
                {
                    or--;
                }
                else if (movement == "down")
                {
                    or++;
                }
                else if (movement == "left")
                {
                    oc--;
                }
                else
                {
                    oc++;
                }

                if (or >= 0 && or < armory.GetLength(0) && oc >= 0 && oc < armory.GetLength(1))
                {
                    if (armory[or,oc] >= 49 && armory[or,oc] <= 57)
                    {
                        swordsBought += int.Parse(armory[or, oc].ToString());
                    }
                    else if (armory[oc,or] == 'M')
                    {
                        int[] zero = coordinates[0].Split(" ").Select(int.Parse).ToArray();
                        int[] one = coordinates[1].Split(" ").Select(int.Parse).ToArray();

                        if (zero[0] == or && zero[1] == oc)
                        {
                            armory[or, oc] = '-';

                            or = one[0];
                            oc = one[1];
                        }
                        else
                        {
                            armory[or, oc] = '-';

                            or = zero[0];
                            oc = zero[1];
                        }
                    }

                    armory[or, oc] = 'A';

                    if (swordsBought >= 65)
                    {
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("I do not need more swords!");
                    break;
                }
            }

            Console.WriteLine($"The king paid {swordsBought} gold coins.");
            for (int i = 0; i < armory.GetLength(0); i++)
            {
                for (int j = 0; j < armory.GetLength(1); j++)
                {
                    Console.Write(armory[i,j]);
                }

                Console.WriteLine();
            }
        }
    }
}
