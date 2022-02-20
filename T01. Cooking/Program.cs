using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquid = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            Dictionary<string, int> cooked = new Dictionary<string, int>();
            cooked.Add("Bread", 0);
            cooked.Add("Cake", 0);
            cooked.Add("Pastry", 0);
            cooked.Add("Fruit Pie", 0);

            int temp = 0;
            
            while (liquid.Count > 0 && ingredients.Count > 0)
            {
                bool tru = false;

                if (liquid.Peek() + ingredients.Peek() == 25)
                {
                    cooked["Bread"]++;
                }
                else if (liquid.Peek() + ingredients.Peek() == 50)
                {
                    cooked["Cake"]++;
                }
                else if (liquid.Peek() + ingredients.Peek() == 75)
                {
                    cooked["Pastry"]++;
                }
                else if (liquid.Peek() + ingredients.Peek() == 100)
                {
                    cooked["Fruit Pie"]++;
                }
                else
                {
                    temp = ingredients.Peek() + 3;
                    tru = true;
                }

                liquid.Dequeue();
                ingredients.Pop();

                if (tru)
                    ingredients.Push(temp);
            }

            bool bad = false;

            foreach (KeyValuePair<string, int> keyValuePair in cooked)
            {
                if (keyValuePair.Value == 0)
                {
                    Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
                    bad = true;
                    break;
                }
            }

            if (!bad)
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            

            if (liquid.Count == 0)
                Console.WriteLine("Liquids left: none");
            else
                Console.WriteLine($"Liquids left: {string.Join(", ", liquid)}");

            if (ingredients.Count == 0)
                Console.WriteLine("Ingredients left: none");
            else
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");

            foreach (KeyValuePair<string, int> pair in cooked.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
