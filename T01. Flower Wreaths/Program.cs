using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int storedFlowers = 0;
            int wreaths = 0;

            while (roses.Count > 0 && lilies.Count > 0)
            {
                if (roses.Peek() + lilies.Peek() == 15)
                {
                    wreaths++;
                    roses.Dequeue();
                    lilies.Pop();
                }
                else if (roses.Peek() + lilies.Peek() > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else
                {
                    storedFlowers += roses.Dequeue();
                    storedFlowers += lilies.Pop();
                }
            }

            int final = storedFlowers / 15;
            wreaths += final;
            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
