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
            PrintCups(cups, position-1);
            List<int> pickupCups = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                pickupCups.Add(cups[(position + i) % (cups.Count-1)]);
            }
            PrintPickUps(pickupCups);
            int destination = cups[position];
            while (pickupCups.Contains(destination))
            {
                destination--;
                if (destination <= 0)
                {
                    destination = cups.Count() - 1;
                }
            }
            PrintDestination(destination);
        }

        private static void PrintCups(List<int> cups, int position)
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
