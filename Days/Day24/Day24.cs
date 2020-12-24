using AdventOfCode2020.Shared;
using Days.Day24;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day24 : Day
    {
        private List<string> input = new List<string>();
        private List<Hex> blackTiles;

        public Day24()
        {
            DayNumber = 24;
            Title = "Lobby Layout";
        }

        public override void Puzzle1()
        {
            Console.WriteLine($"We have {blackTiles.Count} black tiles");
        }

        public override void Puzzle2()
        {


        }

        public override void GatherInput()
        {
            input = ReadFile().ToList();
            blackTiles = new List<Hex>();
            foreach (string line in input)
            {
                int currentX = 0;
                int currentY = 0;
                int currentZ = 0;
                for(int currentIndex = 0; currentIndex < line.Length; currentIndex++)
                {
                    switch (line[currentIndex].ToString())
                    {
                        case "e":
                            currentX++;
                            currentY--;
                            break;
                        case "s":
                            if (line[currentIndex+1] == 'w')
                            {
                                currentX--;
                                currentZ++;
                                currentIndex++;
                                break;
                            }
                            else
                            {
                                currentY--;
                                currentZ++;
                                currentIndex++;
                                break;
                            }
                        case "w":
                            currentX--;
                            currentY++;
                            break;
                        case "n":
                            if (line[currentIndex+1] == 'w')
                            {
                                currentY++;
                                currentZ--;
                                currentIndex++;
                                break;
                            }
                            else
                            {
                                currentX++;
                                currentZ--;
                                currentIndex++;
                                break;
                            }
                    }
                }
                Hex currentTile = new Hex(currentX, currentY, currentZ);
                if(!blackTiles.Any(x => x.AreTilesEqual(currentTile)))
                {
                    blackTiles.Add(new Hex(currentX, currentY, currentZ));
                }
                else
                {
                    blackTiles.Remove(blackTiles.Single(x => x.AreTilesEqual(currentTile)));
                }
            }
        }
    }
}
