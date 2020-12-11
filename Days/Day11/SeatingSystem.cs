using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day11
{
    class SeatingSystem
    {
        string[] currentSeatings;
        string[] previousSeatings;

        public SeatingSystem(string[] input)
        {
            previousSeatings = input.Select(a => (string)a.Clone()).ToArray();
            currentSeatings = input.Select(a => (string)a.Clone()).ToArray();
        }

        public bool UpdateSeating()
        {
            currentSeatings = new string[previousSeatings.Length];
            for (int y = 0; y < previousSeatings.Count(); y++) 
            {
                StringBuilder sb = new StringBuilder();
                for (int x = 0; x < previousSeatings[0].Count(); x++)
                {
                    if (previousSeatings[y][x] == 'L' || previousSeatings[y][x] == '#')
                    {
                        if (previousSeatings[y][x] == 'L')
                        {
                            sb.Append(checkIfAdjacentSeatsAreEmpty(x, y) ? '#' : 'L'); 
                        }
                        else
                        {
                            sb.Append(checkIfXOrMoreSeatsAreTaken(x, y, 4) ? 'L' : '#');
                        }
                    }
                    else
                    {
                        sb.Append('.');
                    }
                    currentSeatings[y] = sb.ToString();
                }
            }
            for(int i = 0; i < previousSeatings[0].Count();i++)
            {
                if(previousSeatings[i].Equals(currentSeatings[i]))
                {
                    return true;
                }
            }
            previousSeatings = new string[currentSeatings.Length];
            previousSeatings = currentSeatings.Select(a => (string)a.Clone()).ToArray();
            return false;
        }

        public void loopUpdateSeating()
        {
            while(!UpdateSeating())
            {
                PrintCurrentArray();
                loopUpdateSeating();
            }
        }

        public bool checkIfXOrMoreSeatsAreTaken(int x, int y, int amountOfSeats)
        {
            int counter = 0;
            for(int yCheck = y-1; yCheck <= y+1; yCheck++)
            {
                for (int xCheck = x - 1; xCheck <= x + 1; xCheck++)
                {
                    if(!(xCheck == x  && yCheck == y))
                    {
                        if(xCheck >= 0 && yCheck >= 0 && yCheck < previousSeatings.Count() && xCheck < previousSeatings[0].Count())
                        {
                            if(previousSeatings[yCheck][xCheck] == '#')
                            {
                                counter++;
                            }
                        }

                    }

                }
            }
            //Console.WriteLine(counter);
            return counter >= amountOfSeats;
        }
        public bool checkIfAdjacentSeatsAreEmpty(int x, int y)
        {
            for (int yCheck = y - 1; yCheck <= y + 1; yCheck++)
            {
                for (int xCheck = x - 1; xCheck <= x + 1; xCheck++)
                {
                    if (!(xCheck == x && yCheck == y))
                    {
                        if (xCheck >= 0 && yCheck >= 0 && yCheck < previousSeatings.Count() && xCheck < previousSeatings[0].Count())
                        {
                            if (previousSeatings[yCheck][xCheck] == '#')
                            {
                                return false;
                            }
                        }

                    }

                }
            }
            //Console.WriteLine(counter);
            return true;
        }

        public int countOccupiedSeats()
        {
            int counter = 0;
            foreach (var line in currentSeatings)
            {
                foreach (var character in line)
                {
                    counter += character == '#' ? 1 : 0;
                }
            }
            return counter;
        }
        public void PrintCurrentArray()
        {
            foreach (var line in currentSeatings)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("");
        }
    }
}
