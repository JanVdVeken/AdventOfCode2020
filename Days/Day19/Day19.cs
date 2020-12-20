using AdventOfCode2020.Shared;
using Days.Day19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Days
{
    public class Day19 : Day
    {
        private List<string> input = new List<string>();
        private List<string> regexes = new List<string>();
        private List<string> messages = new List<string>();

        public Day19()
        {
            DayNumber = 19;
            Title = "Monster Messages";
        }

        public override void Puzzle1()
        {
            Dictionary<int, string> dictRegexes = MessageHelper.CreateRegexDict(regexes);
            Regex regex0 = new Regex("^"+dictRegexes[0]+"$");
            var ans = 0;
            foreach(string message in messages)
            {
                if (regex0.IsMatch(message))
                {
                    //Console.WriteLine(message);
                    ans++;
                }
            }
            Console.WriteLine($"We have found {ans} matches");

        }

        public override void Puzzle2()
        {


        }

        public override void GatherInput()
        {
            input = ReadFile().ToList();
            foreach (string line in input.Where(x=>input.IndexOf(x) < input.IndexOf(string.Empty)))
            {
                regexes.Add(line.Replace("\"",""));
            }
            foreach (string line in input.Where(x => input.IndexOf(x) > input.IndexOf(string.Empty)))
            {
                messages.Add(line);
            }
        }
    }
}
