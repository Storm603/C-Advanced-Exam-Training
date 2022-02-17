using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace T01._Birthday_Celebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int wastedFood = 0;

            int guest = guests.Peek();
            int plate = 0;

            while (guests.Count != 0 && plates.Count != 0)
            {
                plate = plates.Peek();

                if (guest > plate)
                {
                    guest -= plate;
                }
                else if (guest < plate)
                {
                    wastedFood += plate - guest;

                    guests.Dequeue();
                    if (guests.Count > 0)
                    {
                        guest = guests.Peek();
                    }
                }
                else
                {
                    guests.Dequeue();
                    if (guests.Count > 0)
                    {
                        guest = guests.Peek();
                    }
                }
                plates.Pop();

            }

            if (guests.Count > 0)
            {
                guests.Dequeue();
                List<int> vict = new List<int>(guests);
                vict.Insert(0, guest);
                Console.WriteLine($"Guests: {string.Join(" ", vict)}");
            }
            else if (plates.Count > 0)
            {
                //plates.Pop();
                List<int> vict = new List<int>(plates);
                //vict.Insert(0, plate);
                Console.WriteLine($"Plates: {string.Join(" ", vict)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
