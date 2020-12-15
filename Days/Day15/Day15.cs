using AdventOfCode2020.Shared;
using Days.Day15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day15 : Day
    {
        private Dictionary<int,int> input = new Dictionary<int, int>();

        public Day15()
        {
            DayNumber = 15;
            Title = "Rambunctious Recitation";
        }

        public override void Puzzle1()
        {
            //input.Keys.ToList().ForEach(x => Console.WriteLine($"Number: {x}, last seen: {input[x]}"));
            int currentCounter = input.Count()+1;
            int previousNumber = input.Keys.Last();
            input.Remove(input.Keys.Last());
            while (currentCounter <= 2020)
            {
                int newNumber = Memory.GetNewNumber(previousNumber, currentCounter, input);
                //Console.WriteLine($"PreviousNumber = {previousNumber} => newNumber = {newNumber}");
                if(input.ContainsKey(previousNumber))
                {
                    input[previousNumber] = currentCounter-1;
                }
                else
                {
                    input.Add(previousNumber, currentCounter-1);
                }
                previousNumber = newNumber;
                currentCounter++;
            }
            //input.Keys.ToList().ForEach(x => Console.WriteLine($"Number: {x}, last seen: {input[x]}"));
            Console.WriteLine($"The number on position 2020 = {previousNumber}");
        }

        public override void Puzzle2()
        {


        }

        public override void GatherInput()
        {
            var tempinput = ReadFile().First().Split(',').Select(int.Parse).ToList();
            input = tempinput.ToDictionary(x => x, x => tempinput.IndexOf(x) + 1);
        }
    }
}
