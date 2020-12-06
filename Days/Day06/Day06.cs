using AdventOfCode2020.Shared;
using Days.Day06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day06 : Day
    {
        private List<GroupOfAnswers> input = new List<GroupOfAnswers>();
        public Day06()
        {
            DayNumber = 6;
            Title = "Custom Customs";
        }

        public override void Puzzle1()
        {
            int amount = 0;
            foreach(GroupOfAnswers group in input)
            {
                amount += group.returnKeySize();
                Console.WriteLine(group.answers.Keys.Count());
            }

            Console.WriteLine($"We've got {amount} yes answers");
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
                    sb.Append(line.Trim());
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
                input.Add(new GroupOfAnswers(formattedLine.Trim()));
                //Console.WriteLine(formattedLine);
            }
        }

    }
}