using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day21
{
    class Food
    {
        public List<string> ingredients = new List<string>();
        public List<string> allergens = new List<string>();
        public Food(string input)
        {
            FillIngredientsAndAllergens(input);
        }

        private void FillIngredientsAndAllergens(string input)
        {
            string ingredientsString = input.Split("(").ToList()[0].Trim();
            string allergeneString = input.Split("(").ToList()[1];
            ingredientsString.Split(" ").ToList().ForEach(x => ingredients.Add(x));
            foreach (string element in allergeneString.Split(" ").ToList().Where(x => !x.Equals("contains")))
            {
                allergens.Add(element.Replace(",", "").Replace(")", ""));
            }
        }

        public void PrintAllergens()
        {
            allergens.ForEach(x => Console.WriteLine(x));
        }

        public void PrintIngredients()
        {
            ingredients.ForEach(x => Console.WriteLine(x));
        }
    }
}
