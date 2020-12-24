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
            for (int i = 1; i <= 100; i++)
            {
                List<Hex> allTilesIncDupes = new List<Hex>();
                foreach (Hex tile in blackTiles)
                {
                    allTilesIncDupes.Add(tile);
                    allTilesIncDupes.Add(new Hex(tile.x + 1, tile.y - 1, tile.z));
                    allTilesIncDupes.Add(new Hex(tile.x - 1, tile.y + 1, tile.z));

                    allTilesIncDupes.Add(new Hex(tile.x + 1, tile.y, tile.z - 1));
                    allTilesIncDupes.Add(new Hex(tile.x - 1, tile.y, tile.z + 1));

                    allTilesIncDupes.Add(new Hex(tile.x, tile.y - 1, tile.z + 1));
                    allTilesIncDupes.Add(new Hex(tile.x, tile.y + 1, tile.z - 1));
                } 
                // At this point, we have a list of all the tiles, but there might be duplicate values in this list => remove dupes
                List<Hex> allTiles = new List<Hex>();
                //foreach(Hex tile in allTilesIncDupes)
                //{
                //    if (!allTiles.Any(x => x.AreTilesEqual(tile)))
                //    {
                //        allTiles.Add(tile);
                //    }
                //}
                allTiles = allTilesIncDupes;
                // At this point, we have all tiles we need to check
                List<Hex> newblackTiles = new List<Hex>();
                foreach (Hex tile in allTiles)
                {
                    int blackTilesInHood = 0;
                    for (int rangeX = -1; rangeX <= 1; rangeX++)
                    {
                        for (int rangeY = -1; rangeY <= 1; rangeY++)
                        {
                            for (int rangeZ = -1; rangeZ <= 1; rangeZ++)
                            {
                                if((rangeX == 0 && rangeY != 0 && rangeZ != 0) || (rangeX != 0 && rangeY == 0 && rangeZ != 0) || (rangeX != 0 && rangeY != 0 && rangeZ == 0))
                                {
                                    if (blackTiles.Any(temp => temp.AreTilesEqual(new Hex(tile.x + rangeX, tile.y + rangeY, tile.z + rangeZ))))
                                    {
                                        blackTilesInHood++;
                                    }
                                }
                            }
                        }
                    }
                    if (blackTiles.Any(x => x.Equals(tile)) && (blackTilesInHood == 1 || blackTilesInHood == 2))
                    {
                        if (!newblackTiles.Any(x => x.AreTilesEqual(tile)))
                        {
                            newblackTiles.Add(tile);
                        }
                    }
                    if (!blackTiles.Any(x => x.Equals(tile)) && blackTilesInHood == 2)
                    {
                        if (!newblackTiles.Any(x => x.AreTilesEqual(tile)))
                        {
                            newblackTiles.Add(tile);
                        }
                    }
                }
                blackTiles = new List<Hex>(newblackTiles);
                Console.WriteLine($"Day {i}: {blackTiles.Count}");
            }
            //Console.WriteLine($"Finale: {blackTiles.Count}");
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
                    blackTiles.Add(currentTile);
                }
                else
                {
                    blackTiles.Remove(blackTiles.Single(x => x.AreTilesEqual(currentTile)));
                }
            }
        }
    }
}
