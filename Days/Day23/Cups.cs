using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day23
{
    class Cups
    {
        public static void MakeMove(List<int> cups, int position)
        {
            int currentCup = cups[position];
            //PrintCups(cups, position);
            List<int> pickupCups = new List<int>();
            for (int i = 1; i <= 3; i++)
            {
                int temp = position + i;
                if (temp >= cups.Count())
                {
                    temp -= cups.Count();
                }
                pickupCups.Add(cups[temp]);
            }
            //PrintPickUps(pickupCups);
            int destination = cups[position] -1;
            if (destination <= 0)
            {
                destination = cups.Count();
            }
            while (pickupCups.Contains(destination))
            {
                destination--;
                if(destination <= 0)
                {
                    destination = cups.Count();
                }
            }
            //PrintDestination(destination);
            pickupCups.ForEach(x => cups.Remove(x));
            int destinationIndex = cups.IndexOf(destination);
            cups.InsertRange(destinationIndex+1, pickupCups);
            //Remove pickups from cups
            //Add pickups to cups after the destination
            while(currentCup != cups[position])
            {
                cups.Add(cups[0]);
                cups.RemoveAt(0);
            }

        }

        public static void PrintCups(List<int> cups, int position)
        {
            StringBuilder sbConsole = new StringBuilder();
            sbConsole.Append("cups: ");
            foreach (int number in cups)
            {
                if (cups.IndexOf(number) == position)
                {
                    sbConsole.Append("(");
                }
                sbConsole.Append(number);
                if (cups.IndexOf(number) == position)
                {
                    sbConsole.Append(")");
                }
                sbConsole.Append(" ");
            }
            Console.WriteLine(sbConsole.ToString().Trim());
        }
        private static void PrintPickUps(List<int> pickUps)
        {
            StringBuilder sbConsole = new StringBuilder();
            sbConsole.Append("pick up: ");
            pickUps.ForEach(x => sbConsole.Append(x + " "));
            Console.WriteLine(sbConsole.ToString().Trim());
        }

        private static void PrintDestination(int destination)
        {
            Console.WriteLine("Destination:" + destination);
        }

    }
}
