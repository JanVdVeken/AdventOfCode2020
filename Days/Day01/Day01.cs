using AdventOfCode2020.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day01 : Day
    {
        public List<int> input;
        public Day01()
        {
            DayNumber = 1;
            Title = "Report Repair";
        }

        public override void Puzzle1()
        {
            var temp = 0;
            ReadFile();
            foreach (int inputVal1 in input)
            {
                foreach (int inputVal2 in input)
                {
                    if (inputVal1 + inputVal2 == 2020)
                    {
                        temp = inputVal1 * inputVal2;
                    };

                }
            }
            Console.WriteLine(temp);
        }

        public override void Puzzle2()
        {
            var temp = 0;
            ReadFile();
            foreach (int inputVal1 in input)
            {
                foreach (int inputVal2 in input)
                {
                    foreach (int inputVal3 in input)
                    {
                        if (inputVal1 + inputVal2 + inputVal3 == 2020)
                        {
                            temp = inputVal1 * inputVal2 * inputVal3;
                        };
                    }
                }
            }
            Console.WriteLine(temp);
        }

        public override void ReadFile()
        {
            input = File.ReadAllLines(GetFilePath()).Select(int.Parse).ToList();
        }
    }
}
