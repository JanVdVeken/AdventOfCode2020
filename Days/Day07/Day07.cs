using AdventOfCode2020.Shared;
using Days.Day07;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day07 : Day
    {
        private List<Bag> input;
        
        public Day07()
        {
            DayNumber = 7;
            Title = "Handy Haversacks";
        }

        public override void Puzzle1()
        {
            string bagToFind = "shiny gold";
            var ans = input.Count(x => x.checkIfThisOrChildContainsBag(bagToFind, input));
            Console.WriteLine($"We've found {bagToFind} bag {ans} times");
        }

        public override void Puzzle2()
        {
            string bagToFind = "shiny gold";
            var ans = input.Single(x => x.name.Equals(bagToFind)).CountHowManyBagsInsideThisOne(input);

            Console.WriteLine($"We've found {ans - 1} bags in {bagToFind}");
        }

        public override void GatherInput()
        {
            input = new List<Bag>();
            var lines = ReadFile().ToList();
            foreach (string line in lines)
            {
                var temp = line.Split(" bags contain ");

                input.Add(new Bag(temp[0], temp[1]));
            }

        }

    }
}