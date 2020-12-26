using AdventOfCode2020.Shared;
using Days.Day25;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day25 : Day
    {
        private List<string> input = new List<string>();
        int cardPublicKey;
        int doorPublicKey;
        int subjectNumber = 7;
        public Day25()
        {
            DayNumber = 25;
            Title = "Combo Breaker";
        }

        public override void Puzzle1()
        {
            long value = 1;
            int iCard = 0;

            while(value != cardPublicKey)
            {
                iCard++;
                value = HelperClass.CalcSubjectNumber(value, subjectNumber, 20201227);
            }
            Console.WriteLine(iCard);

            value = 1;
            int iDoor = 0;
            while (value != doorPublicKey)
            {
                iDoor++;
                value = HelperClass.CalcSubjectNumber(value, subjectNumber, 20201227);
            }
            Console.WriteLine(iDoor);

            value = 1;
            for(int i = 0; i < iCard; i ++)
            {
                value = HelperClass.CalcSubjectNumber(value, doorPublicKey, 20201227); ;
            }
            Console.WriteLine(value);
        }

        public override void Puzzle2()
        {
            //Not needed
            Console.WriteLine("This was a free star!");
        }

        public override void GatherInput()
        {
            input = ReadFile().ToList();
            cardPublicKey = int.Parse(input.First());
            doorPublicKey = int.Parse(input.Last());
        }
    }
}
