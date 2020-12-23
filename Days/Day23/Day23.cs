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
            int currrentMove = 0;
            for (int move = 1; move <= 100; move++)
            {
                Console.WriteLine($"-- move {move} --");
                if(currrentMove >= cups.Count)
                {
                    currrentMove = 0;
                }
                Cups.MakeMove(cups, currrentMove);
                currrentMove++;
            }
            Console.WriteLine($"-- Final --");
            Cups.PrintCups(cups, -1);

            StringBuilder sbFinale = new StringBuilder();
            while (1 != cups[cups.Count()-1])
            {
                cups.Add(cups[0]);
                cups.RemoveAt(0);
            }
            cups.ForEach(x => sbFinale.Append(x));
            Console.WriteLine($"Cuplabels = {sbFinale.ToString().Replace("1","")}");
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
