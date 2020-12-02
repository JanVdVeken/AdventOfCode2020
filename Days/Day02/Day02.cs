using AdventOfCode2020.Shared;
using Days.Day02;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day02 : Day
    {
        private List<Password> inputList;

        public Day02()
        {
            DayNumber = 2;
            Title = "Password Philosophy";
            inputList = new List<Password>();
        }

        public override void Puzzle1()
        {
            ReadFile();
            var output = inputList.Count(x => x.CheckPasswordRegex() == true);
            Console.WriteLine($"We got {output} valid passwords");

        }

        public override void Puzzle2()
        {
            ReadFile();
            var output = inputList.Count(x => x.CheckPassWordNewPolicy() == true);
            Console.WriteLine($"We got {output} valid passwords");

        }

        public override void ReadFile()
        {
            var tempInput = File.ReadAllLines(GetFilePath());
            foreach(string inputString in tempInput)
            {
                var temp = inputString.Split(": ");
                var stringToCheck = temp[1];
                var inputRegex = temp[0].Split(" ");
                int minOccur = int.Parse(inputRegex[0].Split("-")[0]);
                int MaxOccur = int.Parse(inputRegex[0].Split("-")[1]);
                char CharacterToCheck = inputRegex[1].First();

                inputList.Add(new Password(minOccur,MaxOccur,CharacterToCheck, stringToCheck));

            }
        }
    }
}
