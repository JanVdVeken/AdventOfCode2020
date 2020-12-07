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
        private List<Bag> input = new List<Bag>();
        public Day07()
        {
            DayNumber = 7;
            Title = "Handy Haversacks";
        }

        public override void Puzzle1()
        {
           foreach(Bag luggage in input)
            {
                luggage.printBagInfo();
            }
        }

        public override void Puzzle2()
        {
        }

        public override void GatherInput()
        {
            var lines = ReadFile().ToList();
            foreach (string line in lines)
            {
                var temp = line.Split(" bags contain ");

                input.Add(new Bag(temp[0], temp[1]));
            }

        }

    }
}