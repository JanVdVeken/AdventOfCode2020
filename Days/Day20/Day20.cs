using AdventOfCode2020.Shared;
using Days.Day20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day20 : Day
    {
        private Dictionary<int, List<string>> tiles = new Dictionary<int, List<string>>();

        public Day20()
        {
            DayNumber = 20;
            Title = "Jurassic Jigsaw";
        }

        public override void Puzzle1()
        {
            tiles.Keys.ToList().ForEach(x => Console.WriteLine($"Tile {x}: {}"));
        }

        public override void Puzzle2()
        {


        }

        public override void GatherInput()
        {
            List<string> input = ReadFile().ToList();
            int tileNumber = 0;
            foreach (string line in input.Where(x => !x.Equals(string.Empty)))
            {
                if (line.Contains("Tile"))
                {
                    tileNumber = int.Parse(line.Replace("Tile ", "").Replace(":",""));
                    tiles.Add(tileNumber, new List<string>());
                }
                else
                {
                    tiles[tileNumber].Add(line);
                }

            }
        }
    }
}
