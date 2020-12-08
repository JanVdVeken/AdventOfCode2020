using AdventOfCode2020.Shared;
using Days.Day08;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day08 : Day
    {
        private List<string> input = new List<string>();

        public Day08()
        {
            DayNumber = 8;
            Title = "Handheld Halting";
        }

        public override void Puzzle1()
        {
            HandheldConsole gameConsole = new HandheldConsole(input);
            gameConsole.ExecuteInstructions();
        }

        public override void Puzzle2()
        {

        }

        public override void GatherInput()
        {
            input = ReadFile().ToList();
        }

    }
}