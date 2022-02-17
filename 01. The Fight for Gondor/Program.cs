using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            

            //int plateHP = plates.Dequeue();

            for (int wave = 1; wave <= waves; wave++)
            { 
                Stack<int> warrior = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

                if (wave % 3 == 0) // building defenses
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                //int warriorHP = warrior.Pop();

                while (true)
                {
                    if (warrior.Peek() > plates.Peek())
                    {
                        warrior.Push(warrior.Pop() - plates.Dequeue());
                    }
                    else if (warrior.Peek() < plates.Peek())
                    {
                        plateHP -= warriorHP;

                        if (warrior.Count() == 0)
                        {
                            break;
                        }

                        warriorHP = warrior.Pop();
                    }
                    else
                    {
                        CheckEnd(warrior, plates, warriorHP);

                        if (warrior.Count() == 0)
                        {
                            plateHP = plates.Dequeue();
                            break;
                        }

                        plateHP = plates.Dequeue();
                        warriorHP = warrior.Pop();
                    }
                }
            }

            Console.WriteLine("The people successfully repulsed the orc's attack.");
            if (!plates.Any())
            {
                Console.WriteLine($"Plates left: {plateHP}");
            }
            else
            {
                Console.WriteLine($"Plates left: {plateHP}, {string.Join(", ", plates)}");
            }
        }

        public static void CheckEnd(Stack<int> warrior, Queue<int> plates, int warriorHp)
        {
            if (plates.Count == 0)
            {
                
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                if (!warrior.Any())
                {
                    Console.WriteLine($"Orcs left: {warriorHp}");
                }
                else
                {
                    Console.WriteLine($"Orcs left: {warriorHp}, {string.Join(", ", warrior)}");
                }
                Environment.Exit(0);
            }
        }
    }
}
