using AdventOfCode2020.Shared;
using Days.Day12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day12 : Day
    {
        private List<string> input = new List<string>();

        public Day12()
        {
            DayNumber = 12;
            Title = "Rain Risk";
        }

        public override void Puzzle1()
        {
            Ferry ferry = new Ferry(input,0,0, Directions.E);
            ferry.MoveFerry();
            Console.WriteLine($"The manhattan distance is {ferry.calcManhattanDistance()}");
        }

        public override void Puzzle2()
        {
            Ferry ferry = new Ferry(input, 0, 0, Directions.E, 10, 1);
            ferry.MoveFerryWithWaypoint();
            Console.WriteLine($"The manhattan distance is {ferry.calcManhattanDistance()}");
        }

        public override void GatherInput()
        {
            input = ReadFile().ToList();
        }
    }
}
