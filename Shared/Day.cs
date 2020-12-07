using Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2020.Shared
{
    public abstract class Day
    {
        public string Title;
        public int DayNumber;
        public Day()
        {
        }
        public void PrintInfo()
        {
            Console.WriteLine($"{DayNumber}. {Title}");
        }
        public void HandleSelect()
        {
            Console.WriteLine("Do you want to solve Part 1 or 2?");
            GatherInput();
            switch (Console.ReadLine())
            {
                case "1":
                    Puzzle1();
                    break;
                case "2":
                    Puzzle2();
                    break;
                default:
                    Console.WriteLine($"Not implemented");
                    HandleSelect();
                    break;
            }
            
        }

        public void Deselect()
        {
            Console.WriteLine("Press Key to go back to main menu");
            Console.ReadKey();
            Console.Clear();
        }
        protected IEnumerable<string> ReadFile()
        {
            var resources = Assembly.GetCallingAssembly().GetManifestResourceNames().ToList();
            using Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream(resources.Single(x => x.EndsWith("Input.txt")));
            using StreamReader reader = new StreamReader(stream);
            return reader.ReadAllLines().ToArray();
        }

        public abstract void GatherInput();

        public abstract void Puzzle1();

        public abstract void Puzzle2();
    }
}
