using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            char[,] bakery = new Char[dimentions, dimentions];

            int mr = 0;
            int mc = 0;
            int collectedMoney = 0;

            List<string> pillars = new List<string>();

            for (int i = 0; i < bakery.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < bakery.GetLength(1); j++)
                {
                    bakery[i, j] = input[j];
                    if (bakery[i,j] == 'S')
                    {
                        mr = i;
                        mc = j;
                    }
                    else if (bakery[i,j] == 'O')
                    {
                        pillars.Add($"{i} {j}");
                    }
                }
            }

            while (collectedMoney < 50)
            {
                string command = Console.ReadLine();
                bakery[mr, mc] = '-';

                if (command == "up")
                {
                    mr--;
                }
                else if (command == "down")
                {
                    mr++;
                }
                else if (command == "left")
                {
                    mc--;
                }
                else if (command == "right")
                {
                    mc++;
                }

                if (!IsInRange(bakery, mr, mc))
                {
                    break;
                }

                if (bakery[mr,mc] == 'O')
                {
                    int[] cooridnatesOne = pillars[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    int[] cooridnatesTwo = pillars[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                    if (mr == cooridnatesOne[0] && mc == cooridnatesOne[1])
                    {
                        bakery[mr, mc] = '-';
                        mr = cooridnatesTwo[0];
                        mc = cooridnatesTwo[1];
                    }
                    else
                    {
                        bakery[mr, mc] = '-';
                        mr = cooridnatesOne[0];
                        mc = cooridnatesOne[1];
                    }
                }
                else if (bakery[mr,mc] >= 49 && bakery[mr,mc] <= 57)
                {
                    collectedMoney += int.Parse(bakery[mr, mc].ToString());
                }

                bakery[mr, mc] = 'S';
            }

            if (!IsInRange(bakery, mr, mc))
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine($"Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {collectedMoney}");

            for (int i = 0; i < bakery.GetLength(0); i++)
            {
                for (int j = 0; j < bakery.GetLength(1); j++)
                {
                    Console.Write(bakery[i,j]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsInRange(char[,] bakery, int mr, int mc)
        {
            return mr >= 0 && mr < bakery.GetLength(0) && mc >= 0 && mc < bakery.GetLength(1);
        }
    }
}
