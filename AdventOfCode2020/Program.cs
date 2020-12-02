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
        };
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Which Day do you want ?");
                days.Where(x => x.Title != null).ToList().ForEach(x => x.PrintInfo());
                var selectedDayNumber = Convert.ToInt32(Console.ReadLine());
                var selectedDay = days.First(x => x.DayNumber == Convert.ToInt32(selectedDayNumber));
                //Execute the correct puzzle
                selectedDay.HandleSelect();
                //Go back to the overview menu
                selectedDay.Deselect();
            }
        }
    }
}
