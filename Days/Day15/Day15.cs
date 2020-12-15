using AdventOfCode2020.Shared;
using Days.Day15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day15 : Day
    {
        private Dictionary<int,int> input = new Dictionary<int, int>();

        public Day15()
        {
            DayNumber = 15;
            Title = "Rambunctious Recitation";
        }

        public override void Puzzle1()
        {
            int goal = 2020;
            int ans = Memory.SolvePuzzle(input, goal);
            Console.WriteLine($"The number on position {goal} = {ans}");
        }

        public override void Puzzle2()
        {
            int goal = 30000000;
            int ans = Memory.SolvePuzzle(input, goal);
            Console.WriteLine($"The number on position {goal} = {ans}");
        }

        public override void GatherInput()
        {
            var tempinput = ReadFile().First().Split(',').Select(int.Parse).ToList();
            input = tempinput.ToDictionary(x => x, x => tempinput.IndexOf(x) + 1);
        }
    }
}
