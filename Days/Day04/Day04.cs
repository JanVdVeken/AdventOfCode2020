using AdventOfCode2020.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day04 : Day
    {
        public List<int> input;
        public Day04()
        {
            DayNumber = 4;
            Title = "TBD";
        }

        public override void Puzzle1()
        {
            
        }

        public override void Puzzle2()
        {
            
        }

        public override void GatherInput()
        {
            input = ReadFile().Select(int.Parse).ToList();
        }
    }
}
