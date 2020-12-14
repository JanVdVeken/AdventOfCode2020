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
        private List<Bus> inputPart2 = new List<Bus>();
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
            //Own interpretation of "Chinese remainder theorem"
            bool timeFound = false;
            long currentTime = 0;
            long increment = 1;
            int currentPositionInList = 0;
            while (!timeFound)
            {
                currentTime += increment;
                if(inputPart2[currentPositionInList].GetTheRest(currentTime + currentPositionInList) == 0)
                {
                    increment *= inputPart2[currentPositionInList].numberOfMinutes;
                    currentPositionInList++;
                }
                if(currentPositionInList == inputPart2.Count())
                {
                    timeFound = true;
                }
            }
            Console.WriteLine(currentTime);

        }
        
        public override void GatherInput()
        {
            var lines = ReadFile().ToList();
            startingTime = int.Parse(lines[0]);
            foreach (string stringBus in lines[1].Split(","))
            {
                if (stringBus.Equals("x"))
                {
                    inputPart2.Add(new Bus(1));
                }
                else
                {
                    inputPart2.Add(new Bus(int.Parse(stringBus)));
                    input.Add(new Bus(int.Parse(stringBus)));
                }

            }
        }
    }
}
