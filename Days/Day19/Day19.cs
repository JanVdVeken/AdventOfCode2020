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
            List<string> regexes2 = new List<string>();
            foreach(string line in regexes)
            {
                switch (line)
                {
                    //I've replaced the given problem and changed it to a regex
                    case "8: 42":
                        regexes2.Add("8: ( 42 )+");
                        break;
                    case "11: 42 31":
                        regexes2.Add("11: (( 42 ){n} ( 31 ){n})");
                        break;
                    default:
                        regexes2.Add(line);
                        break;
                }
            }
            Dictionary<int, string> dictRegexes = MessageHelper.CreateRegexDict(regexes2);
            
            var ans = 0;
            foreach (string message in messages)
            {
                bool temp = true;
                for(int i =1; i< 100; i++)
                {
                    Regex regex0 = new Regex("^" + dictRegexes[0].Replace("n",i.ToString()) + "$");
                    if (regex0.IsMatch(message) && temp)
                    {
                        //Console.WriteLine(message);
                        ans++;
                        temp = false;
                    }
                }

            }
            Console.WriteLine($"We have found {ans} matches");


        }

        public override void GatherInput()
        {
            input = ReadFile().ToList();
            foreach (string line in input.Where(x=>input.IndexOf(x) < input.IndexOf(string.Empty)))
            {
                regexes.Add(line.Replace("\"", ""));
            }
            foreach (string line in input.Where(x => input.IndexOf(x) > input.IndexOf(string.Empty)))
            {
                messages.Add(line);
            }
        }
    }
}
