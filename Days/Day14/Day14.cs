using AdventOfCode2020.Shared;
using Days.Day14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Days
{
    public class Day14 : Day
    {
        private List<string> input = new List<string>();
        private string zeroes = "000000000000000000000000000000000000";
        private int lengtOfMask = 36;
        public Day14()
        {
            DayNumber = 14;
            Title = "Docking Data";
        }

        public override void Puzzle1()
        {
            string mask = zeroes.Replace("0", "X");
            Dictionary<int, long> memory = new Dictionary<int, long>();
            //Filling the memory
            foreach (string line in input)
            {
                int memLocation;
                string value;
                if (line.Contains("mask"))
                {
                    mask = line.Split(" = ")[1];
                }
                else
                {
                    string tempLine = line.Replace("mem[", "");
                    memLocation = int.Parse(tempLine.Split("] = ")[0]);
                    value = (zeroes + Convert.ToString(int.Parse(tempLine.Split("] = ")[1]), 2)).Right(lengtOfMask);
                    //Console.WriteLine($"Mem: {memLocation} and value: {value}");
                    memory[memLocation] = Convert.ToInt64(StringExtensions.MaskValue(mask, value),2);
                }               
            }

            //Adding everything together
            long temp = 0;
            foreach(int key in memory.Keys)
            {
                //Console.WriteLine($"Mem: {key} and value: {memory[key]}");
                temp += memory[key];
            }
            Console.WriteLine(temp);
            
        }

        public override void Puzzle2()
        {
            Dictionary<long, long> memory = new Dictionary<long, long>();
            string mask = zeroes;

            //Filling the memory
            foreach (string line in input)
            {
                string memLocation;
                string value;
                if (line.Contains("mask"))
                {
                    mask = line.Split(" = ")[1];
                }
                else
                {
                    string tempLine = line.Replace("mem[", "");
                    memLocation = (zeroes + Convert.ToString(int.Parse(tempLine.Split("] = ")[0]), 2)).Right(lengtOfMask);
                    memLocation = StringExtensions.MaskValueMemory(mask, memLocation);

                    List<string> memories = new List<string>() { "" };
                    foreach (char element in memLocation)
                    {
                        List<string> tempMemories = new List<string>() { };
                        if (element == 'X')
                        {
                            foreach (string memoryAdd in memories)
                            {
                                tempMemories.Add(memoryAdd + '0');
                                tempMemories.Add(memoryAdd + '1');
                            }
                        }
                        else
                        {
                            foreach(string memoryAdd in memories)
                            {
                                tempMemories.Add(memoryAdd + element);
                            }
                        }
                        memories = tempMemories;
                        
                    }

                    value = tempLine.Split("] = ")[1];
                    foreach (string memoryLine in memories.Where(x => x.Count() == lengtOfMask))
                    {
                        //Console.WriteLine(memoryLine);
                        memory[Convert.ToInt64(memoryLine,2)] = int.Parse(value);
                    }

                }
            }

            //Adding everything together
            long temp = 0;
            foreach (long key in memory.Keys)
            {
                //Console.WriteLine($"Mem: {key} and value: {memory[key]}");
                temp += memory[key];
            }
            Console.WriteLine(temp);
        }

        public override void GatherInput()
        {
            input = ReadFile().ToList();
        }
    }
}
