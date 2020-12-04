using AdventOfCode2020.Shared;
using Days.Day04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day04 : Day
    {
        private List<Passport> input;
        List<string> needsToExist = new List<string>()
            {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid",
                //"cid",
            };
        public Day04()
        {
            DayNumber = 4;
            Title = "Passport Processing";
            input = new List<Passport>();
        }

        public override void Puzzle1()
        {

            var validPassports = input.Count(x => x.CheckIfKeysExists(needsToExist));
            Console.WriteLine($"We got {validPassports} valid passports.");

        }

        public override void Puzzle2()
        {
            var validPassports = input.Count(x => x.CheckIfPassportIsValid(needsToExist));
            Console.WriteLine($"We got {validPassports} valid passports.");
        }

        public override void GatherInput()
        {
            var lines = ReadFile().ToList();
            var formattedInputs = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach(string line in lines)
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
                input.Add(new Passport(formattedLine.Trim()));
            }
        }
    }
}
