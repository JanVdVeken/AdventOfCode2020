using AdventOfCode2020.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day08 : Day
    {
        private List<string> input = new List<string>();

        public Day08()
        {
            DayNumber = 8;
            Title = "TBD";
        }

        public override void Puzzle1()
        {
            foreach(string line in input)
            {
                Console.WriteLine(line);
            }
        }

        public override void Puzzle2()
        {

        }

        public override void GatherInput()
        {
            var lines = ReadFile().ToList();
        }

    }
}