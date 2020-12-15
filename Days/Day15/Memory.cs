using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day15
{
    class Memory
    {
        public static int GetNewNumber(int previousNumber, int currentCounter, Dictionary<int,int> input)
        {
            if(input.ContainsKey(previousNumber))
            {
                return currentCounter - input[previousNumber] -1 ;
            }
            else
            {
                return 0;
            }
        }

        public static int SolvePuzzle(Dictionary<int,int> input, int goal)
        {
            Dictionary<int, int> inputDict = input;
            //input.Keys.ToList().ForEach(x => Console.WriteLine($"Number: {x}, last seen: {input[x]}"));
            int currentCounter = inputDict.Count() + 1;
            int previousNumber = inputDict.Keys.Last();
            input.Remove(inputDict.Keys.Last());
            while (currentCounter <= goal)
            {
                int newNumber = GetNewNumber(previousNumber, currentCounter, inputDict);
                //Console.WriteLine($"PreviousNumber = {previousNumber} => newNumber = {newNumber}");
                if (inputDict.ContainsKey(previousNumber))
                {
                    inputDict[previousNumber] = currentCounter - 1;
                }
                else
                {
                    inputDict.Add(previousNumber, currentCounter - 1);
                }
                previousNumber = newNumber;
                currentCounter++;
            }
            //input.Keys.ToList().ForEach(x => Console.WriteLine($"Number: {x}, last seen: {input[x]}"));
            return previousNumber;
        }
    }
}
