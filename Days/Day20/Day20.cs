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
        private Dictionary<int, Tile> tiles = new Dictionary<int, Tile>();

        public Day20()
        {
            DayNumber = 20;
            Title = "Jurassic Jigsaw";
        }

        public override void Puzzle1()
        {
            //tiles[tiles.Keys.ToList()[0]].PrintTile();
            //Console.WriteLine("All possible edges:");
            //tiles[tiles.Keys.ToList()[0]].PrintAllPossibleEdges();
            foreach (int key1 in tiles.Keys)
            {
                foreach (int key2 in tiles.Keys.Where(x => x!= key1))
                {
                    tiles[key1].AddPossibleMatchingTile(tiles[key2]);
                }
            }

            long ans = 1;
            foreach (int key in tiles.Keys.Where(x => tiles[x].matchingTiles.Count == 2))
            {
                ans *= key;
            }

            Console.WriteLine($"Product of the corners = {ans}");

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
                    tiles.Add(tileNumber, new Tile());
                }
                else
                {
                    tiles[tileNumber].AddToList(line);
                }
            }
            tiles.Keys.ToList().ForEach(x => tiles[x].CalcAllEdges());
        }
    }
}
