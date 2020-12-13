using AdventOfCode2020.Shared;
using Days.Day13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day13 : Day
    {
        private List<Bus> input = new List<Bus>();
        int startingTime = 1;

        public Day13()
        {
            DayNumber = 13;
            Title = "Shuttle Search";
        }

        public override void Puzzle1()
        {
            Bus earliestBus = input.OrderBy(x => x.GetTimeToWait(startingTime)).First();
            Console.WriteLine($"Bus ID {earliestBus.numberOfMinutes} arrives after {earliestBus.GetTimeToWait(startingTime)} => {earliestBus.numberOfMinutes * earliestBus.GetTimeToWait(startingTime)} ");

        }

        public override void Puzzle2()
        {


        }

        public override void GatherInput()
        {
            var lines = ReadFile().ToList();
            startingTime = int.Parse(lines[0]);
            foreach (string stringBus in lines[1].Split(",").Where(x => !x.Equals("x")))
            {
                input.Add(new Bus(int.Parse(stringBus)));
            }
        }
    }
}
