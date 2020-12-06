using AdventOfCode2020.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day05 : Day
    {
        public List<string> input;
        public Day05()
        {
            DayNumber = 5;
            Title = "Binary Boarding";
        }

        public override void Puzzle1()
        {
            int maxId = 0;
            foreach(string inputline in input)
            {
                int currentRow = calcRow(127, inputline.Substring(0,inputline.Length - 3));
                int currentColumn = calcColumn(7, inputline.Substring(inputline.Length -3));
                maxId = Math.Max(maxId, currentRow * 8 + currentColumn);
            }

            Console.WriteLine($"The highest id is {maxId}");

        }

        public override void Puzzle2()
        {
            List<int> allPositions = new List<int>();
            foreach (string inputline in input)
            {
                int currentRow = calcRow(127, inputline.Substring(0, inputline.Length - 3));
                int currentColumn = calcColumn(7, inputline.Substring(inputline.Length - 3));
                allPositions.Add(currentRow*8 + currentColumn);
            }
            allPositions.Sort();
            for(int i = 1; i < allPositions.Count()-1;i++)
            {
                if((allPositions[i] + 1) != allPositions[i+1])
                {
                    Console.WriteLine($"Your seat is {allPositions[i] +1}");
                }
            }
        }

        public override void GatherInput()
        {
            input = ReadFile().ToList();
        }

        public int calcRow(int maxRow, string inputline) 
        {
            int minRow = 0;
            foreach(char character in inputline)
            {
                decimal div = (maxRow - minRow) / 2 +1 ;
                if (character == 'F')
                {
                    maxRow -= (int)Math.Ceiling(div);
                }
                else
                {
                    minRow += (int)Math.Floor(div);
                }
                //Console.WriteLine($"minRow = {minRow} and maxRow = {maxRow}");
            }
            
            return minRow;
        }

        public int calcColumn(int maxCol, string inputline)
        {
            int minCol = 0;
            foreach (char character in inputline)
            {
                decimal div = (maxCol - minCol)/2 +1;
                if (character == 'L')
                {
                    maxCol -= (int)Math.Ceiling(div);
                }
                else
                {
                    minCol += (int)Math.Floor(div);
                }
            }
            //Console.WriteLine($"Mincol = {minCol} and Maxcol = {maxCol}");
            return minCol;
        }
    }
}