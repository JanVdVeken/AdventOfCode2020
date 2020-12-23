using AdventOfCode2020.Shared;
using Days.Day23;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day23 : Day
    {
        private List<string> input = new List<string>();
        private List<int> cups;
        public Day23()
        {
            DayNumber = 23;
            Title = "Crab Cups";
        }

        public override void Puzzle1()
        {
            //cups.ForEach(x => Console.WriteLine(x));
            for(int move = 1; move <= 10; move++)
            {
                Console.WriteLine($"-- move {move} --");
                Cups.MakeMove(cups, move%(cups.Count-1));
            }
        }

        public override void Puzzle2()
        {


        }

        public override void GatherInput()
        {
            input = ReadFile().ToList();
            cups = new List<int>();
            foreach(char number in input.First())
            {
                cups.Add(int.Parse(number.ToString()));
            }

        }
    }
}
