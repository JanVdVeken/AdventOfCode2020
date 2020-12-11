using AdventOfCode2020.Shared;
using Days.Day11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day11 : Day
    {
        public string[] input;

        public Day11()
        {
            DayNumber = 11;
            Title = "Seating System";
        }

        public override void Puzzle1()
        {
            SeatingSystem Seats = new SeatingSystem(input);
            Seats.LoopUpdateSeating(false);
            Console.WriteLine($"We have counted {Seats.CountOccupiedSeats()} occupied seats.");
        }

        public override void Puzzle2()
        {
            SeatingSystem Seats = new SeatingSystem(input);
            Seats.LoopUpdateSeating(true);
            Console.WriteLine($"We have counted {Seats.CountOccupiedSeats()} occupied seats.");
        }

        public override void GatherInput()
        {
            input = ReadFile().ToArray();
        }
    }
}
