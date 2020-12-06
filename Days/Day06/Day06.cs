using AdventOfCode2020.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day06 : Day
    {
        public List<string> input;
        public Day06()
        {
            DayNumber = 6;
            Title = "Custom Customs";
        }

        public override void Puzzle1()
        {

        }

        public override void Puzzle2()
        {

        }

        public override void GatherInput()
        {
            var lines = ReadFile().ToList();
            var formattedInputs = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
            {
                if (!string.Equals(line, string.Empty))
                {
                    sb.Append(line.Trim() + " ");
                }
                else
                {
                    formattedInputs.Add(sb.ToString());
                    sb.Clear();
                }
            }
            formattedInputs.Add(sb.ToString());
            sb.Clear();

            foreach (string formattedLine in formattedInputs.Where(x => x.Trim() != string.Empty))
            {
                Console.WriteLine(formattedLine.Trim());
                //input.Add(new Passport(formattedLine.Trim()));
            }
        }
    }
    }
}