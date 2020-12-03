using AdventOfCode2020.Shared;
using Days.Day03;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class Day03 : Day
    {
        public string[] input;
        private Toboggan toboggan;
        //input[y][x]
        
        public Day03()
        {
            DayNumber = 3;
            Title = "Toboggan Trajectory";
            
        }

        public override void Puzzle1()
        {
            toboggan = new Toboggan(0, 0, 3, 1);
            int hits = toboggan.Travel(input);

            Console.WriteLine($"We have hit {hits} trees");
        }

        public override void Puzzle2()
        {
            int hits = 1;
            List<Toboggan> toboggans = new List<Toboggan>()
            {
                new Toboggan(0, 0, 1, 1),
                new Toboggan(0, 0, 3, 1),
                new Toboggan(0, 0, 5, 1),
                new Toboggan(0, 0, 7, 1),
                new Toboggan(0, 0, 1, 2),
            };
            foreach(Toboggan toboggan in toboggans)
            {
                hits *= toboggan.Travel(input);
            }
            
            Console.WriteLine($"We have hit {hits} trees");
        }

        public override void GatherInput()
        {
            input = ReadFile().ToArray();
        }
    }
}

