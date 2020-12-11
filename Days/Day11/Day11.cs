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
            Seats.loopUpdateSeating();
            Console.WriteLine($"We have counted {Seats.countOccupiedSeats()} occupied seats.");
        }

        public override void Puzzle2()
        {
            SeatingSystem Seats = new SeatingSystem(input);
            Seats.loopUpdateSeatingInVision();
            //Seats.UpdateSeatingInVision();
            //Seats.PrintCurrentArray();
            //Seats.UpdateSeatingInVision();
            //Seats.PrintCurrentArray();
            Console.WriteLine($"We have counted {Seats.countOccupiedSeats()} occupied seats.");
        }

        public override void GatherInput()
        {
            input = ReadFile().ToArray();
        }
    }
}
