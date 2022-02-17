using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace _01._Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> forgedSwords = new Dictionary<string, int>();

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int value = steel.Peek() + carbon.Peek();

                if (value == 70)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    if (!forgedSwords.ContainsKey("Gladius"))
                    {
                        forgedSwords.Add("Gladius", 0);
                    }

                    forgedSwords["Gladius"]++;
                }
                else if (value == 80)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    if (!forgedSwords.ContainsKey("Shamshir"))
                    {
                        forgedSwords.Add("Shamshir", 0);
                    }

                    forgedSwords["Shamshir"]++;
                }
                else if (value == 90)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    if (!forgedSwords.ContainsKey("Katana"))
                    {
                        forgedSwords.Add("Katana", 0);
                    }

                    forgedSwords["Katana"]++;
                }
                else if (value == 110)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    if (!forgedSwords.ContainsKey("Sabre"))
                    {
                        forgedSwords.Add("Sabre", 0);
                    }

                    forgedSwords["Sabre"]++;
                }
                else if (value == 150)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    if (!forgedSwords.ContainsKey("Broadsword"))
                    {
                        forgedSwords.Add("Broadsword", 0);
                    }

                    forgedSwords["Broadsword"]++;
                }
                else
                {
                    steel.Dequeue();
                    carbon.Push(carbon.Pop() + 5);
                }
            }

            if (forgedSwords.Any())
            {
                Console.WriteLine($"You have forged {forgedSwords.Values.Sum()} swords.");
                forgedSwords = forgedSwords.OrderBy(x => x.Key).ToDictionary(x => x.Key, x=> x.Value);
            }
            else
            {
                Console.WriteLine("You did not have any resources to forge a sword.");
            }

            if (steel.Any())
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Any())
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            if (forgedSwords.Any())
            {
                foreach (var forgedSwordsKey in forgedSwords)
                {
                    Console.WriteLine($"{forgedSwordsKey.Key}: {forgedSwordsKey.Value}");
                }
            }
        }
    }
}
