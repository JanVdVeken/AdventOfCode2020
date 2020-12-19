using AdventOfCode2020.Shared;
using Days.Day18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day18 : Day
    {
        private List<string> input = new List<string>();

        public Day18()
        {
            DayNumber = 18;
            Title = "Operation Order";
        }

        public override void Puzzle1()
        {
            long sum = 0;
            foreach(string operation in input)
            {
                //Console.WriteLine(Operations.CalcOperation(operation));
                sum += Operations.CalcOperation(operation);
            }
            Console.WriteLine($"The sum of the resulting values is {sum}");
        }

        public override void Puzzle2()
        {
            long sum = 0;
            foreach (string operation in input)
            {
                //Console.WriteLine(Operations.CalcOperationFirstAddition(operation));
                sum += Operations.CalcOperationFirstAddition(operation);
            }
            Console.WriteLine($"The sum of the resulting values is {sum}");

        }

        public override void GatherInput()
        {
            input = ReadFile().ToList();
        }
    }
}
