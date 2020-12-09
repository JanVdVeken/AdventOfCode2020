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
                if (!XMAS.CheckIfSumCanBeMade((input[i]), input.GetRange(i - preambleSize, preambleSize)))
                {
                    Console.WriteLine($"{input[i]} Can't be made by combining 2 digits of the preamble");
                    break;
                }
            }
        }

        public override void Puzzle2()
        {
            int preambleSize = 25;
            int wrongPosition = 0;
            for (int i = preambleSize; i < input.Count(); i++)
            {
                if (!XMAS.CheckIfSumCanBeMade((input[i]), input.GetRange(i - preambleSize, preambleSize)))
                {
                    Console.WriteLine($"{input[i]} Can't be made by combining 2 digits of the preamble");
                    wrongPosition = i;
                    break;
                }
            }

            for(int j =0; j< input.Count(); j++)
            {
                for(int k = 2 ; k <= input.Count() - j; k++)
                {
                    if(XMAS.CheckIfSumCanBeMadeInList(input[wrongPosition],input.GetRange(j,k)))
                    {
                        long smallestNumber = input.GetRange(j, k).Min();
                        long biggestNumber = input.GetRange(j, k).Max();
                        Console.WriteLine($"The sum of {smallestNumber} and {biggestNumber} equals {smallestNumber + biggestNumber}");
                    }
                }
            }

        }

        public override void GatherInput()
        {
            input = ReadFile().Select(long.Parse).ToList();
        }

    }
}