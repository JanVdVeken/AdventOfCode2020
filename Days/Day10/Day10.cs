using AdventOfCode2020.Shared;
using Days.Day10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day10 : Day
    {
        private List<Adapter> inputs = new List<Adapter>();

        public Day10()
        {
            DayNumber = 10;
            Title = "Adapter Array";
        }

        public override void Puzzle1()
        {
            
            Dictionary<int, int> countSteps = new Dictionary<int, int>();

            var sortedInput = inputs.OrderBy(x => x.ownJolts).ToList();

            sortedInput.ForEach(x => x.PrintInfo());

            for (int i = 1; i < sortedInput.Count(); i++)
            {
                int difference = sortedInput[i].ownJolts - sortedInput[i-1].ownJolts;
                if (difference <=3)
                {
                    if(countSteps.ContainsKey(difference))
                    {
                        countSteps[difference] += 1;
                    }
                    else
                    {
                        countSteps.Add(difference, 1);
                    }
                }
                else
                {
                    break;
                }
            }

            foreach(int key in countSteps.Keys)
            {
                Console.WriteLine($"{key} => {countSteps[key]}");
            }
            Console.WriteLine( $"Difference = {countSteps[countSteps.Keys.Min()] * countSteps[countSteps.Keys.Max()]}");

            
        }

        public override void Puzzle2()
        {


        }

        public override void GatherInput()
        {
            var inputListInt = ReadFile().Select(int.Parse).ToList();
            int max = inputListInt.Max() + 3;
            foreach(int element in inputListInt)
            {
                inputs.Add(new Adapter(element, max));
            }
            //Adding the firts one
            inputs.Add(new Adapter(0, max));
            //Adding last one
            inputs.Add(new Adapter(max, 0));
        }
    }
}
