using AdventOfCode2020.Shared;
using Days.Day09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day09 : Day
    {
        private List<long> input = new List<long>();

        public Day09()
        {
            DayNumber = 9;
            Title = "Encoding Error";
        }

        public override void Puzzle1()
        {
            int preambleSize = 25;
            for(int i = preambleSize; i < input.Count(); i++)
            {
                if (!XMAS.CheckIfsSumCanBeMade((input[i]), input.GetRange(i - preambleSize, preambleSize)))
                {
                    Console.WriteLine($"{input[i]} Can't be made by combining 2 digits of the preamble");
                    break;
                }
            }
        }

        public override void Puzzle2()
        {

        }

        public override void GatherInput()
        {
            input = ReadFile().Select(long.Parse).ToList();
        }

    }
}