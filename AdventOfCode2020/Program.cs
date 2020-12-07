using AdventOfCode2020.Days;
using AdventOfCode2020.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    class Program
    {
        public static List<Day> days = new()
        {
            new Day01(),
            new Day02(),
            new Day03(),
            new Day04(),
            new Day05(),
            new Day06(),
            new Day07(),
        };
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Which Day do you want ?");
                days.Where(x => x.Title != null).ToList().ForEach(x => x.PrintInfo());
                var input = Console.ReadLine();
                if (int.TryParse(input, out var chosenDay) && days.SingleOrDefault(x => x.DayNumber == chosenDay) != null)
                {
                    var day = days.Single(x => x.DayNumber == chosenDay);
                    day.HandleSelect();
                    day.Deselect();
                }
                else
                {
                    Console.WriteLine("Day not found, Press Key to go back to main menu");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }
    }
}
