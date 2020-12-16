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
        private List<string> puzzle2NearbyTickets = new List<string>();
        private string myTicket;
        private List<int[]> ranges = new List<int[]>();
        private Dictionary<string, List<int[]>> namedRanges = new Dictionary<string, List<int[]>>();

        public Day16()
        {
            DayNumber = 16;
            Title = "Ticket Translation";
        }

        public override void Puzzle1()
        {
            Console.WriteLine($"At this point, we have found {nearbyTickets.Count} nearby tickets");
            List<int> invalidNumbers = new List<int>();
            foreach(string nearbyTicket in nearbyTickets)
            {
                List<int> numbers = nearbyTicket.Split(",").Select(int.Parse).ToList();
                //numbers.ForEach(x => Console.WriteLine(x));
                bool CorrectTicket = true;

                foreach (int number in numbers)
                {
                    if (!Tickets.CheckIfTicketIsInRange(number, ranges))
                    {
                        //Console.WriteLine("Adding " + number);
                        invalidNumbers.Add(number);
                        CorrectTicket = false;
                    }
                }

                if(CorrectTicket)
                {
                    puzzle2NearbyTickets.Add(nearbyTicket);
                }
                
            }
            //Finally add all the invalidNumbers together
            Console.WriteLine($"Puzzle1: Total sum of the invalid numbers = {invalidNumbers.Sum()}");
            
        }

        public override void Puzzle2()
        {
            Console.WriteLine($"We need to do puzzle one first, to delete the wrong tickets");
            Puzzle1();
            Console.WriteLine($"At this point, we have found {puzzle2NearbyTickets.Count} correct tickets");
            Dictionary<string, List<int>> correctLocations = new Dictionary<string, List<int>>();
            int amountOfColums = namedRanges.Count();
            List<List<int>> columnsValues = new List<List<int>>();
            for(int i = 0; i < amountOfColums; i++)
            {
                List<int> temp = new List<int>();
                foreach(string ticket in puzzle2NearbyTickets)
                {
                    temp.Add(int.Parse(ticket.Split(",")[i]));
                }
                columnsValues.Add(temp);
            }
            //At this point, we have all the values of the columns in a list. The values can be check if they all fit a range.
            while(correctLocations.Count() != amountOfColums)
            {
                string workingKey = string.Empty;
                foreach(string key in namedRanges.Keys)
                {
                    List<int[]> currentRanges = namedRanges[key];
                    int currentColumnNumber = 0;
                    foreach(List<int> column in columnsValues)
                    {
                        if (column.All(x => Tickets.CheckIfTicketIsInRange(x, currentRanges)))
                        {
                            workingKey = key;
                            if(correctLocations.ContainsKey(key))
                            {
                                correctLocations[key].Add(currentColumnNumber);
                            }
                            else
                            {
                                correctLocations.Add(key, new List<int>() {currentColumnNumber});
                            }
                        }
                        currentColumnNumber++;
                    }
                    if (workingKey != string.Empty)
                    {
                        break;
                    }
                }
                namedRanges.Remove(workingKey);
            }
            //At this point we have a dict with the names and all possible positions of the columns.
            //foreach(string key in correctLocations.Keys)
            //{
            //    Console.WriteLine($"{key} has {correctLocations[key].Count()} possible columns ");
            //    correctLocations[key].ForEach(x => Console.WriteLine( "\t" + x));
            //}

            //Delete all the other possibilities that have already been taken
            int columnToDelete = correctLocations.Values.Single(x => x.Count() == 1)[0];
            while (correctLocations.Values.Any(x => x.Count > 1))
            {
                int newColumnToDelete = 0;
                foreach (List<int> values in correctLocations.Values.Where(x => x.Count > 1))
                {
                    values.Remove(values.Single(x => x == columnToDelete));
                    if(values.Count() == 1)
                    {
                        newColumnToDelete = values[0];
                    }
                }
                columnToDelete = newColumnToDelete;
            }
            //At this point, we have a dictionary with names and columns
            long ans = 1;
            foreach(string key in correctLocations.Keys.Where(x => x.Contains("departure")))
            {
                ans *= long.Parse(myTicket.Split(",")[correctLocations[key][0]]);
            }

            Console.WriteLine($"The product of the values with \"departure\" = {ans} ");
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
                    var stringRange = temp[0];
                    temp = temp[1].Split(" or ");
                    //At thist point we have XX-XX and XX-XX
                    List<int[]> tempList = new List<int[]>();
                    foreach(var element in temp)
                    {
                        var tempElement = element.Split("-");
                        int[] tempRange = { int.Parse(tempElement[0]), int.Parse(tempElement[1])};
                        ranges.Add(tempRange);
                        tempList.Add(tempRange);
                    }

                    namedRanges.Add(stringRange, tempList);

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
