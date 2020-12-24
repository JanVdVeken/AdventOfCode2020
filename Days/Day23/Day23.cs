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
            for(int i = cups.Count+1; i<= 1000000; i++)
            {
                cups.Add(i);
            }
            int currrentMove = 0;
            Console.WriteLine($"{DateTime.Now.ToString("hh:mm:ss")}: -- move {currrentMove} --");
            for (int move = 1; move <= 10000000; move++)
            {
                if(move % 100000 == 0)
                {
                    Console.WriteLine($"{DateTime.Now.ToString("hh:mm:ss")}: -- move {move} --");
                }
                
                if (currrentMove >= cups.Count)
                {
                    currrentMove = 0;
                }
                Cups.MakeMove(cups, currrentMove);
                currrentMove++;
            }
            //Console.WriteLine($"-- Final --");
            int temp = cups.IndexOf(1);
            long temp2 = cups[temp + 1] * cups[temp + 2];
            //Console.WriteLine($"Cuplabels = {cups[temp+1] * cups[temp+2]}");
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Jan\Desktop\OuputD23P2.txt"))
            {
                file.WriteLine(cups[temp + 1]);
                file.WriteLine(cups[temp + 2]);
            }
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
