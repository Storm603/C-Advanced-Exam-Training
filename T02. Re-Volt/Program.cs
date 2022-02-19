using System;
using System.Reflection;

namespace T02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            int commandCount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[dimentions, dimentions];

            int r = 0;
            int c = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                    if (matrix[i,j] == 'f')
                    {
                        r = i;
                        c = j;
                    }
                }
            }

            for (int i = 0; i < commandCount; i++)
            {
                matrix[r, c] = '-';

                int tr = r;
                int tc = c;

                string movement = Console.ReadLine();

                if (movement == "up")
                {
                    r--;
                    if (!IsInRange(matrix, r, c))
                    {
                        r = matrix.GetLength(0) - 1;
                    }

                    if (matrix[r,c] == 'B')
                    {
                        r--;
                        if (!IsInRange(matrix, r, c))
                        {
                            r = matrix.GetLength(0) - 1;
                        }
                    }
                    else if (matrix[r,c] == 'T')
                    {
                        r = tr;
                        c = tc;
                    }
                }
                else if (movement == "down")
                {
                    r++;
                    if (!IsInRange(matrix, r, c))
                    {
                        r = 0;
                    }

                    if (matrix[r, c] == 'B')
                    {
                        r++;
                        if (!IsInRange(matrix, r, c))
                        {
                            r = 0;
                        }
                    }
                    else if (matrix[r, c] == 'T')
                    {
                        r = tr;
                        c = tc;
                    }
                }
                else if (movement == "left")
                {
                    c--;
                    if (!IsInRange(matrix, r, c))
                    {
                        c = matrix.GetLength(1) - 1;
                    }

                    if (matrix[r, c] == 'B')
                    {
                        c--;
                        if (!IsInRange(matrix, r, c))
                        {
                            c = matrix.GetLength(1) - 1;
                        }
                    }
                    else if (matrix[r, c] == 'T')
                    {
                        r = tr;
                        c = tc;
                    }
                }
                else if (movement == "right")
                {
                    c++;
                    if (!IsInRange(matrix, r, c))
                    {
                        c = 0;
                    }

                    if (matrix[r, c] == 'B')
                    {
                        c++;
                        if (!IsInRange(matrix, r, c))
                        {
                            c = 0;
                        }
                    }
                    else if (matrix[r, c] == 'T')
                    {
                        r = tr;
                        c = tc;
                    }
                }

                if (matrix[r,c] == 'F')
                {
                    break;
                }
                
                matrix[r, c] = 'f';
            }

            if (matrix[r, c] == 'F')
            {
                matrix[r, c] = 'f';

                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }

                Console.WriteLine();
            }
        }

        public static bool IsInRange(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
