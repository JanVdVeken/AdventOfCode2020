using AdventOfCode2020.Shared;
using Days.Day16;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day16 : Day
    {
        private List<string> input = new List<string>();
        private List<string> nearbyTickets = new List<string>();
        private string myTicket;
        private List<int[]> ranges = new List<int[]>();

        public Day16()
        {
            DayNumber = 16;
            Title = "Ticket Translation";
        }

        public override void Puzzle1()
        {
            //Console.WriteLine("Ranges:");
            //ranges.ForEach(x => Console.WriteLine($"{x[0]} till {x[1]}"));
            //Console.WriteLine($"MyTicket: {myTicket}");
            //Console.WriteLine("nearbyTickets:");
            //nearbyTickets.ForEach(x => Console.WriteLine($"{x}"));

            //Check foreach number in the NearbyTickets if it is allowed
            List<int> invalidNumbers = new List<int>();
            foreach(string nearbyTicket in nearbyTickets)
            {
                List<int> numbers = nearbyTicket.Split(",").Select(int.Parse).ToList();
                //numbers.ForEach(x => Console.WriteLine(x));

                foreach (int number in numbers)
                {
                    if (!Tickets.CheckIfTicketIsInRange(number, ranges))
                    {
                        //Console.WriteLine("Adding " + number);
                        invalidNumbers.Add(number);
                    }
                }
                
            }
            //Finally add all the invalidNumbers together
            Console.WriteLine($"Total sum of the invalid numbers = {invalidNumbers.Sum()}");
            
        }

        public override void Puzzle2()
        {


        }

        public override void GatherInput()
        {
            var Input = ReadFile().ToList();
            int lineYourTicket = Input.IndexOf("your ticket:");
            int lineNearbyTicket = Input.IndexOf("nearby tickets:");
            foreach (string line in Input.Where(x => !x.Equals("")))
            {
                if (Input.IndexOf(line) < lineYourTicket)
                {
                    var temp = line.Split(": ");
                    temp = temp[1].Split(" or ");
                    //At thist point we have XX-XX and XX-XX
                    foreach(var element in temp)
                    {
                        var tempElement = element.Split("-");
                        int[] tempRange = { int.Parse(tempElement[0]), int.Parse(tempElement[1])};
                        ranges.Add(tempRange);
                    }

                }
                else if(Input.IndexOf(line) > lineYourTicket && Input.IndexOf(line) < lineNearbyTicket)
                {
                    myTicket = line;
                }
                else if(Input.IndexOf(line) > lineNearbyTicket)
                {
                    nearbyTickets.Add(line);
                }
            }
        }
    }
}
