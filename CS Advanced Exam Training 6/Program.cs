using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace CS_Advanced_Exam_Training_6
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> scarf = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            List<int> collection = new List<int>();

            while (scarf.Any() && hats.Any())
            {
                if (hats.Peek() > scarf.Peek())
                {
                    collection.Add(scarf.Dequeue() + hats.Pop());
                }
                else if (scarf.Peek() > hats.Peek())
                {
                    hats.Pop();
                }
                else if (scarf.Peek() == hats.Peek())
                {
                    scarf.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {collection.Max()}");
            collection.ForEach(x => Console.Write(x + " "));
        }
    }
}
