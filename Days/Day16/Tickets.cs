using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day16
{
    class Tickets
    {
        public static bool CheckIfTicketIsInRange(int ticketNumber, List<int[]> ranges)
        {
            bool ans = false;
            foreach(int[] range in ranges)
            {
                if (ticketNumber >= range[0] && ticketNumber <= range[1])
                {
                    ans = true;
                }
            }
            return ans;
        }
    }
}
