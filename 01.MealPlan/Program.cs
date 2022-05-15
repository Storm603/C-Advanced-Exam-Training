using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.MealPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mealCalorieTable = new Dictionary<string, int>()
            {
                {"salad", 350},
                {"soup", 490},
                {"pasta", 680},
                {"steak", 790}
            };

            Queue<string> meals = new Queue<string>(Console.ReadLine().Split());
            Stack<int> caloriesPerDay = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int mealCount = 0;
            int dailyCalories = caloriesPerDay.Peek();

            while (meals.Count > 0 && caloriesPerDay.Count > 0)
            {
                while (meals.Count > 0)
                {
                    dailyCalories -= mealCalorieTable[meals.Dequeue()];

                    mealCount++;

                    if (dailyCalories <= 0)
                    {
                        caloriesPerDay.Pop();
                        if (caloriesPerDay.Count == 0)
                        {
                            break;
                        }
                        dailyCalories += caloriesPerDay.Peek();
                        break;
                    }
                }
            }

            if (meals.Count > 0)
            {
                Console.WriteLine($"John ate enough, he had {mealCount} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
            else if (caloriesPerDay.Count > 0)
            {
                List<int> temp = caloriesPerDay.ToList();
                temp.RemoveAt(0);
                temp.Insert(0, dailyCalories);
                Console.WriteLine($"John had {mealCount} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", temp)} calories.");
            }
        }
    }
}
