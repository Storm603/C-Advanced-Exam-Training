using System;

namespace T02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());

            char[,] territory = new char[dimentions, dimentions];

            int br = 0;
            int bc = 0;

            for (int i = 0; i < territory.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < territory.GetLength(1); j++)
                {
                    territory[i, j] = input[j];
                    if (territory[i,j] == 'B')
                    {
                        br = i;
                        bc = j;
                    }
                }
            }

            int polinatedFlowers = 0;
            string movement = Console.ReadLine();

            while (movement != "End")
            {
                territory[br, bc] = '.';

                if (movement == "up")
                {
                    br--;
                    if (!IsInRange(territory, br, bc))
                    {
                        break;
                    }
                    if (territory[br,bc] == 'O')
                    {
                        territory[br, bc] = '.';

                        br--;
                    }
                }
                else if (movement == "down")
                {
                    br++;
                    if (!IsInRange(territory, br, bc))
                    {
                        break;
                    }
                    if (territory[br, bc] == 'O')
                    {
                        territory[br, bc] = '.';

                        br++;
                    }
                }
                else if (movement == "left")
                {
                    bc--;
                    if (!IsInRange(territory, br, bc))
                    {
                        break;
                    }
                    if (territory[br, bc] == 'O')
                    {
                        territory[br, bc] = '.';

                        bc--;
                    }
                }
                else if (movement == "right")
                {
                    bc++;
                    if (!IsInRange(territory, br, bc))
                    {
                        break;
                    }
                    if (territory[br, bc] == 'O')
                    {
                        territory[br, bc] = '.';

                        bc++;
                    }
                }

                if (!IsInRange(territory, br, bc))
                {
                    break;
                }

                if (territory[br,bc] == 'f')
                {
                    polinatedFlowers++;
                }

                territory[br, bc] = 'B';

                movement = Console.ReadLine();
            }

            if (!IsInRange(territory, br, bc))
            {
                Console.WriteLine("The bee got lost!");
            }

            if (polinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to polinate {polinatedFlowers} flowers!");
            }

            for (int i = 0; i < territory.GetLength(0); i++)
            {
                for (int j = 0; j < territory.GetLength(1); j++)
                {
                    Console.Write(territory[i,j]);
                }

                Console.WriteLine();
            }

        }

        public static bool IsInRange(char[,] territory, int br, int bc)
        {
            return br >= 0 && br < territory.GetLength(0) && bc >= 0 && bc < territory.GetLength(1);
        }
    }
}
