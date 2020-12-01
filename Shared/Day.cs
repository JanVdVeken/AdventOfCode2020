using System;
using System.Diagnostics;
using System.IO;
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
            var inputConsole = Convert.ToDouble(Console.ReadLine());
            
            switch (inputConsole)
            {
                case 1:
                    Puzzle1();
                    break;
                case 2:
                    Puzzle2();
                    break;
                default:
                    Console.WriteLine($"Not implemented");
                    //timer.Stop();
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
        public string GetFilePath()
        //@Plat wat is die assembly?
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"input.txt");
        }
        public abstract void ReadFile();

        public abstract void Puzzle1();

        public abstract void Puzzle2();

    }
}
