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
            //foreach(int key in tiles.Keys)
            //{
            //    Console.WriteLine(key +":");
            //    tiles[key].PrintTile();
            //    Console.WriteLine();
            //}

            tiles[tiles.Keys.ToList()[0]].PrintTile();
            
            Console.WriteLine("\nFlippedLR:");
            tiles[tiles.Keys.ToList()[0]].FlipLR();
            tiles[tiles.Keys.ToList()[0]].PrintTile();

            Console.WriteLine("\nFlippedUD:");
            tiles[tiles.Keys.ToList()[0]].FlipUD();
            tiles[tiles.Keys.ToList()[0]].PrintTile();

            Console.WriteLine("\nFlippedR(1):");
            tiles[tiles.Keys.ToList()[0]].RotateR(1);
            tiles[tiles.Keys.ToList()[0]].PrintTile();
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
        }
    }
}
