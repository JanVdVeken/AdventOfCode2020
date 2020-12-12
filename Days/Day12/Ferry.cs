using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days.Day12
{
    class Ferry
    {
        List<string> route;
        //Left-right
        int posX;
        //up-down
        int posY;

        int posWPX;
        int posWPY;

        Directions facingDirection;
        public Ferry(List<string> input, int startX, int startY, Directions startingDirection)
        {
            route = input;
            posX = startX;
            posY = startY;
            facingDirection = startingDirection;

        }
        public Ferry(List<string> input, int startX, int startY, Directions startingDirection, int startWPX, int startWPY)
        {
            route = input;
            posX = startX;
            posY = startY;
            posWPX = startWPX;
            posWPY = startWPY;
            facingDirection = startingDirection;
        }

        public void MoveFerry()
        {
            foreach (string instruction in route)
            {
                Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
                Match result = re.Match(instruction.Trim());
                string action = result.Groups[1].ToString();
                int value = int.Parse(result.Groups[2].ToString());
                SingleInstructionFerry(action, value);
            }
        }
        public void MoveFerryWithWaypoint()
        {
            foreach (string instruction in route)
            {
                Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
                Match result = re.Match(instruction.Trim());
                string action = result.Groups[1].ToString();
                int value = int.Parse(result.Groups[2].ToString());
                SingleInstructionWayPoint(action, value);
            }
        }
        private void SingleInstructionWayPoint(string action, int value)
        {
            switch (action)
            {
                case "N":
                    posWPY += value;
                    break;
                case "S":
                    posWPY -= value;
                    break;
                case "E":
                    posWPX += value;
                    break;
                case "W":
                    posWPX -= value;
                    break;
                case "L":
                    
                    if (value>0)
                    {
                        for (int i = 0; i < (Math.Abs(value) / 90); i++)
                        {
                            var tempL = posWPY;
                            posWPY = posWPX;
                            posWPX = -tempL;
                        }
                    }
                    else
                    {
                        SingleInstructionWayPoint("R", -value);
                    }
                    break;
                case "R":
                    if(value>0)
                    {
                        for (int i = 0; i < (Math.Abs(value) / 90); i++)
                        {
                            var tempR = posWPX;
                            posWPX = posWPY;
                            posWPY = -tempR;
                        }
                    }
                    else
                    {
                        SingleInstructionWayPoint("L", -value);
                    }

                    break;
                case "F":
                    posX += (posWPX * value);
                    posY += (posWPY * value);
                    break;
            }
        }


        private void SingleInstructionFerry(string action, int value)
        {
            int correctedValue = 0;
            switch (action)
            {
                case "N":
                    posY += value;
                    break;
                case "S":
                    posY -= value;
                    break;
                case "E":
                    posX += value;
                    break;
                case "W":
                    posX -= value;
                    break;
                case "L":
                    //Console.WriteLine($"1) Ferry facing {facingDirection} on {posX} and {posY}");
                    //Console.WriteLine($"{action} and {value}");
                    correctedValue = (int)facingDirection - ((value / 90) % 4);
                    facingDirection = (Directions)((correctedValue <= 0 ? (4 + correctedValue) : correctedValue) %4);
                    //Console.WriteLine($"2) Ferry facing {facingDirection} on {posX} and {posY}");
                    break;
                case "R":
                    //Console.WriteLine($"1) Ferry facing {facingDirection} on {posX} and {posY}");
                    //Console.WriteLine($"{action} and {value}");
                    correctedValue = (int)facingDirection + ((value / 90) % 4);
                    facingDirection = (Directions)((correctedValue <= 0 ? (4 + correctedValue) : correctedValue) %4);
                    //Console.WriteLine($"2) Ferry facing {facingDirection} on {posX} and {posY}");
                    break;
                case "F":
                    SingleInstructionFerry(facingDirection.ToString(), value);
                    break;
            }
        }


        public int calcManhattanDistance()
        {
            //Console.WriteLine($"x: {Math.Abs(posX)} y: { Math.Abs(posY)}");
            return Math.Abs(posX) + Math.Abs(posY);
        }
    }
}
