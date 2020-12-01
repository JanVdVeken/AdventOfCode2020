using AdventOfCode2020.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day2 : Day
    {
        public List<int> input;
        public Day2()
        {
            DayNumber = 2;
            Title = "Hier komt dag nummer 2";
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
