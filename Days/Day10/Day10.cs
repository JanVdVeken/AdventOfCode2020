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
            inputs.ForEach(x => x.PrintInfo());
            List<Adapter> checkedList = new List<Adapter>();
            Dictionary<int, int> countSteps = new Dictionary<int, int>();
            int currentJolts = 0;

            while (checkedList.Count() != inputs.Count())
            {
                Console.WriteLine($"{inputs.First().rangeOfReceivingJolts()[0]} {inputs.First().rangeOfReceivingJolts()[1]}");
                int newJolts = inputs.Where(x => Enumerable.Range(x.rangeOfReceivingJolts()[0], x.rangeOfReceivingJolts()[1]).Contains(currentJolts)).ToList().Min(y => y.ownJolts);
                
                if (countSteps.ContainsKey(newJolts-currentJolts)) 
                {
                    countSteps[newJolts - currentJolts] += 1; 
                }
                else
                {
                    countSteps[newJolts - currentJolts] = 1;
                }
                checkedList.Add(inputs.Single(x => x.ownJolts == newJolts));
                currentJolts = newJolts;
            }

            foreach(int key in countSteps.Keys)
            {
                Console.WriteLine($"{key} => {countSteps[key]}");
            }
            

            
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
            
        }
    }
}
