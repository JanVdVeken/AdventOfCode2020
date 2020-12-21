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
            foreach (int key1 in tiles.Keys)
            {
                foreach (int key2 in tiles.Keys.Where(x => x != key1))
                {
                    tiles[key1].AddPossibleMatchingTile(tiles[key2]);
                }
            }
            List<Tile> tileList = tiles.Values.ToList();

            Tile[,] tilesInOrder = new Tile[(int)Math.Sqrt(tiles.Count), (int)Math.Sqrt(tiles.Count)];
            Tile nextTile = new Tile();
            for (int c = 0; c < (int)Math.Sqrt(tiles.Count); c++)
            { 
                for (int r = 0; r < (int)Math.Sqrt(tiles.Count); r++)
                {
                    Console.WriteLine($"Currently at c={c}, r={r}");
                    if (c == 0 && r == 0)
                    {
                        nextTile = tileList.Where(x => x.matchingTiles.Count == 2).ToList().First();
                        while (!nextTile.allConnectingEdges.Contains(nextTile.GetRightSide()) || !nextTile.allConnectingEdges.Contains(nextTile.GetBottomSide()))
                            nextTile.RotateR(1);
                    }
                    else if (r == 0)
                    {
                        var lastRight = tilesInOrder[r, c - 1].GetRightSide();
                        nextTile = tilesInOrder[r, c - 1].matchingTiles.Single(e => !e.isUsed && (e.allConnectingEdges.Contains(lastRight)));
                        while (!nextTile.GetLeftSide().Equals(lastRight) && !Extensions.Reverse(nextTile.GetLeftSide()).Equals(lastRight))
                        {
                            nextTile.RotateR(1);
                        }
                        if (!nextTile.GetLeftSide().Equals(lastRight))
                        {
                            nextTile.FlipUD();
                        }
                    }
                    else
                    {
                        var lastBottom = tilesInOrder[r - 1, c].GetBottomSide();
                        nextTile = tilesInOrder[r - 1, c].matchingTiles.Single(e => !e.isUsed && (e.allConnectingEdges.Contains(lastBottom)));
                        while (!nextTile.GetTopSide().Equals(lastBottom) && !Extensions.Reverse(nextTile.GetTopSide()).Equals(lastBottom))
                        {
                            nextTile.RotateR(1);
                        }
                        if (!nextTile.GetTopSide().Equals(lastBottom))
                        {
                            nextTile.FlipLR();
                        }

                    }
                    tilesInOrder[r, c] = nextTile;
                    nextTile.isUsed = true;
                }
            }

            for(int i = 0; i < (int)Math.Sqrt(tiles.Count); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < (int)Math.Sqrt(tiles.Count); j++)
                {
                    Console.WriteLine();
                    tilesInOrder[j, i].PrintTile();
                }
            }
            //At this point, we have an array of all the grids

        }

        public override void GatherInput()
        {
            List<string> input = ReadFile().ToList();
            tiles = new Dictionary<int, Tile>();
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
