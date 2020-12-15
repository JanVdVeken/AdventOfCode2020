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
            int goal = 2020;
            Dictionary<int, int> input1 = input;
            //input.Keys.ToList().ForEach(x => Console.WriteLine($"Number: {x}, last seen: {input[x]}"));
            int currentCounter = input1.Count()+1;
            int previousNumber = input1.Keys.Last();
            input.Remove(input1.Keys.Last());
            while (currentCounter <= goal)
            {
                int newNumber = Memory.GetNewNumber(previousNumber, currentCounter, input1);
                //Console.WriteLine($"PreviousNumber = {previousNumber} => newNumber = {newNumber}");
                if(input1.ContainsKey(previousNumber))
                {
                    input1[previousNumber] = currentCounter-1;
                }
                else
                {
                    input1.Add(previousNumber, currentCounter-1);
                }
                previousNumber = newNumber;
                currentCounter++;
            }
            //input.Keys.ToList().ForEach(x => Console.WriteLine($"Number: {x}, last seen: {input[x]}"));
            Console.WriteLine($"The number on position {goal} = {previousNumber}");
        }

        public override void Puzzle2()
        {
            int goal = 30000000;
            Dictionary<int, int> input2 = input;
            //input.Keys.ToList().ForEach(x => Console.WriteLine($"Number: {x}, last seen: {input[x]}"));
            int currentCounter = input2.Count() + 1;
            int previousNumber = input2.Keys.Last();
            input2.Remove(previousNumber);
            while (currentCounter <= goal)
            {
                int newNumber = Memory.GetNewNumber(previousNumber, currentCounter, input2);
                //Console.WriteLine($"PreviousNumber = {previousNumber} => newNumber = {newNumber}");
                if (input2.ContainsKey(previousNumber))
                {
                    input2[previousNumber] = currentCounter - 1;
                }
                else
                {
                    input2.Add(previousNumber, currentCounter - 1);
                }
                previousNumber = newNumber;
                currentCounter++;
            }
            //input.Keys.ToList().ForEach(x => Console.WriteLine($"Number: {x}, last seen: {input[x]}"));
            Console.WriteLine($"The number on position {goal} = {previousNumber}");
        }

        public override void GatherInput()
        {
            var tempinput = ReadFile().First().Split(',').Select(int.Parse).ToList();
            input = tempinput.ToDictionary(x => x, x => tempinput.IndexOf(x) + 1);
        }
    }
}
