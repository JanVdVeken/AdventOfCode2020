using AdventOfCode2020.Shared;
using Days.Day21;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day21 : Day
    {
        private List<string> input = new List<string>();
        private Dictionary<string, List<string>> possibleIngredientsForAllergens;
        List<Food> foods;
        public Day21()
        {
            DayNumber = 21;
            Title = "Allergen Assessment";
        }

        public override void Puzzle1()
        {
            Dictionary<string,int> allIngredients = new Dictionary<string,int>();
            Dictionary<string,int> allAllergens = new Dictionary<string,int>();
            foreach (Food food in foods)
            {
                foreach(string allergen in food.allergens)
                {
                    if(allAllergens.ContainsKey(allergen))
                    {
                        allAllergens[allergen]++;
                    }
                    else
                    {
                        allAllergens.Add(allergen, 1);
                    }
                }
                foreach (string ingredient in food.ingredients)
                {
                    if (allIngredients.ContainsKey(ingredient))
                    {
                        allIngredients[ingredient]++;
                    }
                    else
                    {
                        allIngredients.Add(ingredient, 1);
                    }
                }
            }

            possibleIngredientsForAllergens = new Dictionary<string, List<string>>();
            allAllergens.Keys.ToList().ForEach(x => possibleIngredientsForAllergens.Add(x,allIngredients.Keys.ToList()));
            //At this point, we say that each of the allergens can be caused by every ingredient
            //This list must be reduced to the minimum
            foreach(Food food in foods)
            {
                foreach(string allergen in food.allergens)
                {
                    possibleIngredientsForAllergens[allergen] = possibleIngredientsForAllergens[allergen].Intersect(food.ingredients).ToList();
                }
            }
            //At this point, we have all the possible ingredient for each of the allergens
            //foreach(string key in possibleIngredientsForAllergens.Keys)
            //{
            //    Console.WriteLine("=> " + key + ":");
            //    possibleIngredientsForAllergens[key].ForEach(x => Console.WriteLine(x));
            //}
            //Delete all the other possibilities that have already been taken
            List<string> knownAllergenIngredients = new List<string>();
            while(possibleIngredientsForAllergens.Values.Any(x => x.Count >1))
            {
                foreach(string key in possibleIngredientsForAllergens.Keys.Where(x => possibleIngredientsForAllergens[x].Count == 1))
                {
                    if(!knownAllergenIngredients.Contains(possibleIngredientsForAllergens[key].First()))
                    {
                        knownAllergenIngredients.Add(possibleIngredientsForAllergens[key].First());
                    }
                }
                foreach(string key in possibleIngredientsForAllergens.Keys.Where(x => possibleIngredientsForAllergens[x].Count > 1))
                {
                    possibleIngredientsForAllergens[key] = possibleIngredientsForAllergens[key].Except(knownAllergenIngredients).ToList();
                }
            }

            knownAllergenIngredients = new List<string>();
            foreach (string key in possibleIngredientsForAllergens.Keys.Where(x => possibleIngredientsForAllergens[x].Count == 1))
            {
                if (!knownAllergenIngredients.Contains(possibleIngredientsForAllergens[key].First()))
                {
                    knownAllergenIngredients.Add(possibleIngredientsForAllergens[key].First());
                }
            }
            //knownAllergenIngredients.ForEach(x => Console.WriteLine(x));
            //At this point, we have the link for each of the allergens

            int ans = 0;
            foreach (string key in allIngredients.Keys.Where(x => !knownAllergenIngredients.Contains(x)))
            {
                ans += allIngredients[key];
            }
            Console.WriteLine($"Part 1: The count of the ingredients that cannot possibly contain any of the allergens = {ans}");
        }

        public override void Puzzle2()
        {
            Puzzle1();
            StringBuilder sb = new StringBuilder();
            foreach (string allergen in possibleIngredientsForAllergens.Keys.ToList().OrderBy(x => x))
            {
                sb.Append(possibleIngredientsForAllergens[allergen].First());
                sb.Append(",");
            }
            sb.Length--;
            Console.WriteLine($"Part 2:{sb.ToString()}");
        }

        public override void GatherInput()
        {
            input = ReadFile().ToList();
            foods = new List<Food>();
            input.ForEach(x => foods.Add(new Food(x)));
            //foreach (Food food in foods)
            //{
            //    Console.WriteLine($"===== Food #{foods.IndexOf(food) + 1} =====");
            //    Console.WriteLine("=> Ingredients:");
            //    food.PrintIngredients();
            //    Console.WriteLine("=> Allergens:");
            //    food.PrintAllergens();
            //}
        }
    }
}
