using AdventOfCode2020.Shared;
using Days.Day17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day17 : Day
    {
        List<Cube> activeCubes = new List<Cube>();
        List<Cube> cubes = new List<Cube>();
        public Day17()
        {
            DayNumber = 17;
            Title = "Conway Cubes";
        }

        public override void Puzzle1()
        {
            activeCubes = cubes.Where(x => x.value == '#').ToList();
            //Console.WriteLine("Before the calcs:");
            //cubes.ForEach(x => x.printCubeProps());
            for (int loopCounter = 1; loopCounter <= 6; loopCounter++)
            {
                Console.WriteLine($"Loop nr: {loopCounter}");
                List<Cube> newCubes = new List<Cube>();
                int smallestX = activeCubes.OrderBy(cube => cube.x).First().x-1;
                int biggestX = activeCubes.OrderBy(cube => cube.x).Last().x+1;
                //Console.WriteLine($"X from: {smallestX} till: {biggestX}");
                int smallestY = activeCubes.OrderBy(cube => cube.y).First().y-1;
                int biggestY = activeCubes.OrderBy(cube => cube.y).Last().y+1;
                //Console.WriteLine($"Y from: {smallestY} till: {biggestY}");
                int smallestZ = activeCubes.OrderBy(cube => cube.z).First().z-1;
                int biggestZ = activeCubes.OrderBy(cube => cube.z).Last().z+1;
                //Console.WriteLine($"Z from: {smallestZ} till: {biggestZ}");
                for (int incX = smallestX; incX <= biggestX; incX++)
                { 
                    for (int incY = smallestY; incY <= biggestY; incY++)
                    {
                        for (int incZ = smallestZ; incZ <= biggestZ; incZ++)
                        {
                            //Loop over all the points in our vision
                            //Console.WriteLine($"x: {incX}, y: {incY}, z: {incZ}");
                            int activeCubesInHood = 0;
                            for (int rangeX = -1; rangeX <= 1; rangeX++)
                            {
                                for (int rangeY = -1; rangeY <= 1; rangeY++)
                                {
                                    for (int rangeZ = -1; rangeZ <= 1; rangeZ++)
                                    {
                                        if (!(rangeX ==0 && rangeY == 0 && rangeZ == 0))
                                        {
                                            if (activeCubes.Any(temp => temp.checkIfPointsAreTheSame(incX + rangeX, incY + rangeY, incZ + rangeZ)))
                                            {
                                                activeCubesInHood++;
                                            }
                                        }

                                    }
                                }
                            }
                            if (activeCubes.Any(x => x.checkIfPointsAreTheSame(incX, incY, incZ)) )
                            {
                                if (activeCubesInHood == 2 || activeCubesInHood == 3)
                                {
                                    newCubes.Add(new Cube(incX, incY, incZ, '#'));
                                }
                                else
                                {
                                    newCubes.Add(new Cube(incX, incY, incZ, '.'));
                                }
                            }
                            else
                            {
                                if (activeCubesInHood == 3)
                                {
                                    newCubes.Add(new Cube(incX, incY, incZ, '#'));
                                }
                                else
                                {
                                    newCubes.Add(new Cube(incX, incY, incZ, '.'));
                                }
                            }
                        }
                    }
                }
                
                cubes = new List<Cube>(newCubes);
                //Console.WriteLine("After the calcs:");
                //cubes.ForEach(x => x.printCubeProps());
                activeCubes = cubes.Where(x => x.value == '#').ToList();
                Console.WriteLine($"Amount of active cubes = {activeCubes.Count}");
            }
        }

        public override void Puzzle2()
        {
            activeCubes = cubes.Where(x => x.value == '#').ToList();
            //Console.WriteLine("Before the calcs:");
            //cubes.ForEach(x => x.printCubeProps());
            for (int loopCounter = 1; loopCounter <= 6; loopCounter++)
            {
                Console.WriteLine($"Loop nr: {loopCounter}");
                List<Cube> newCubes = new List<Cube>();
                int smallestX = activeCubes.OrderBy(cube => cube.x).First().x - 1;
                int biggestX = activeCubes.OrderBy(cube => cube.x).Last().x + 1;
                //Console.WriteLine($"X from: {smallestX} till: {biggestX}");
                int smallestY = activeCubes.OrderBy(cube => cube.y).First().y - 1;
                int biggestY = activeCubes.OrderBy(cube => cube.y).Last().y + 1;
                //Console.WriteLine($"Y from: {smallestY} till: {biggestY}");
                int smallestZ = activeCubes.OrderBy(cube => cube.z).First().z - 1;
                int biggestZ = activeCubes.OrderBy(cube => cube.z).Last().z + 1;
                //Console.WriteLine($"Z from: {smallestZ} till: {biggestZ}");
                int smallestW = activeCubes.OrderBy(cube => cube.w).First().w - 1;
                int biggestW = activeCubes.OrderBy(cube => cube.w).Last().w + 1;
                //Console.WriteLine($"Z from: {smallestZ} till: {biggestZ}");
                for (int incX = smallestX; incX <= biggestX; incX++)
                {
                    for (int incY = smallestY; incY <= biggestY; incY++)
                    {
                        for (int incZ = smallestZ; incZ <= biggestZ; incZ++)
                        {
                            for (int incW = smallestW; incW <= biggestW; incW++)
                            {
                                //Loop over all the points in our vision
                                //Console.WriteLine($"x: {incX}, y: {incY}, z: {incZ}");
                                int activeCubesInHood = 0;
                                for (int rangeX = -1; rangeX <= 1; rangeX++)
                                {
                                    for (int rangeY = -1; rangeY <= 1; rangeY++)
                                    {
                                        for (int rangeZ = -1; rangeZ <= 1; rangeZ++)
                                        {
                                            for(int rangeW = -1; rangeW <= 1; rangeW++)
                                            {
                                                if (!(rangeX == 0 && rangeY == 0 && rangeZ == 0 && rangeW == 0))
                                                {
                                                    if (activeCubes.Any(temp => temp.checkIfPointsAreTheSame(incX + rangeX, incY + rangeY, incZ + rangeZ, incW + rangeW)))
                                                    {
                                                        activeCubesInHood++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (activeCubes.Any(x => x.checkIfPointsAreTheSame(incX, incY, incZ, incW)))
                                {
                                    if (activeCubesInHood == 2 || activeCubesInHood == 3)
                                    {
                                        newCubes.Add(new Cube(incX, incY, incZ, incW, '#'));
                                    }
                                    else
                                    {
                                        newCubes.Add(new Cube(incX, incY, incZ, incW, '.'));
                                    }
                                }
                                else
                                {
                                    if (activeCubesInHood == 3)
                                    {
                                        newCubes.Add(new Cube(incX, incY, incZ, incW, '#'));
                                    }
                                    else
                                    {
                                        newCubes.Add(new Cube(incX, incY, incZ, incW, '.'));
                                    }
                                }
                            } 
                        }
                    }
                }

                cubes = new List<Cube>(newCubes);
                //Console.WriteLine("After the calcs:");
                //cubes.ForEach(x => x.printCubeProps());
                activeCubes = cubes.Where(x => x.value == '#').ToList();
                Console.WriteLine($"Amount of active cubes = {activeCubes.Count}");
            }
        }

        public override void GatherInput()
        {
            List<string> input = new List<string>();
            input = ReadFile().ToList();
            for(int x = 0; x < input[0].Count(); x++)
            {
                for(int y = 0; y < input.Count(); y++)
                {
                    //No need for the Z, because everything starts on the first plane
                    cubes.Add(new Cube(x, y, 0,0, input[y][x]));
                }
            }
        }
    }
}
