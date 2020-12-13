using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day13
{
    class Bus
    {
        public int numberOfMinutes;
        public Bus(int input)
        {
            numberOfMinutes = input;
        }

        public int GetTimeToWait(int earliestTime)
        {
            return numberOfMinutes - (earliestTime % numberOfMinutes);
        }

        public long GetTimeToWait(long earliestTime)
        {
            return numberOfMinutes - (earliestTime % numberOfMinutes);
        }

        public long GetTheRest(long earliestTime)
        {
            return earliestTime % numberOfMinutes;
        }
    }
}
