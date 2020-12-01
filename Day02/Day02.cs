using AdventOfCode2020.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day02 : Day
    {
        public List<int> input;
        public Day02()
        {
            DayNumber = 2;
            Title = "TBD";
        }

        public override void Puzzle1()
        {

        }

        public override void Puzzle2()
        {

        }

        public override void ReadFile()
        {
            input = File.ReadAllLines(GetFilePath()).Select(int.Parse).ToList();
        }
    }
}
