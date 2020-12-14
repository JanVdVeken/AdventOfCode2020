using AdventOfCode2020.Shared;
using Days.Day13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day13 : Day
    {
        private List<Bus> input = new List<Bus>();
        private List<Bus> input2 = new List<Bus>();
        int startingTime = 1;
        int maxAmountOfJumps = 0;

        public Day13()
        {
            DayNumber = 13;
            Title = "Shuttle Search";
        }

        public override void Puzzle1()
        {
            Bus earliestBus = input.OrderBy(x => x.GetTimeToWait(startingTime)).First();
            Console.WriteLine($"Bus ID {earliestBus.numberOfMinutes} arrives after {earliestBus.GetTimeToWait(startingTime)} => {earliestBus.numberOfMinutes * earliestBus.GetTimeToWait(startingTime)} ");
        }
        //public override void Puzzle2()
        //{
        //    long timeStamp = 0;
        //    bool timeStampFound = false;
        //    long displayTimeStamp = 0;
        //    while (!timeStampFound)
        //    {

        //        timeStamp++;
        //        displayTimeStamp = timeStamp;
        //        for (int positionInList = 0; positionInList < input2.Count(); positionInList++)
        //        {
        //            if (input2[positionInList].GetTheRest(timeStamp) == 0)
        //            {
        //                timeStamp++;
        //                positionInList++;
        //            }
        //            else
        //            {
        //                break;
        //            }

        //        }
        //    }
        //    Console.WriteLine(displayTimeStamp);
        //}
        public override void Puzzle2()
        {
            long timeStamp = 100000000000000;
            bool timeStampFound = false;
            int positionInList = 0;
            long displayTimeStamp = 0;

            while (!timeStampFound)
            {
                Console.WriteLine(timeStamp);
                timeStamp++;
                if (positionInList == 0)
                {
                    displayTimeStamp = timeStamp;
                }

                if (positionInList == input2.Count() - 1 && input2[positionInList].GetTheRest(timeStamp) == 0)
                {
                    timeStampFound = true;
                }
                else
                {
                    if (input2[positionInList].GetTheRest(timeStamp) == 0)
                    {
                        positionInList++;
                    }
                    else
                    {
                        positionInList = 0;
                    }

                }
            }
            Console.WriteLine($"The first time the sequence started: {displayTimeStamp}");
        }


        public override void GatherInput()
        {
            var lines = ReadFile().ToList();
            startingTime = int.Parse(lines[0]);
            foreach (string stringBus in lines[1].Split(","))
            {
                if (stringBus.Equals("x"))
                {
                    input2.Add(new Bus(1));
                }
                else
                {
                    input.Add(new Bus(int.Parse(stringBus)));
                    input2.Add(new Bus(int.Parse(stringBus)));
                }
                
            }
        }
    }
}
