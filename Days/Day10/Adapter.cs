using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day10
{
    class Adapter
    {
        private int minReceivingJolts;
        public int ownJolts;
        public int sendingJolts;
        public Adapter(int current, int max)
        {
            ownJolts = current;
            minReceivingJolts = ownJolts - 3;
            sendingJolts = max;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Adapter with following specs: {minReceivingJolts} receiving, {ownJolts} own rating, {sendingJolts} sending. {rangeOfReceivingJolts()[0]} en {rangeOfReceivingJolts()[1]}");
        }

        public int[] rangeOfReceivingJolts()
        {
            int[] returnArray = new int[2] { minReceivingJolts, ownJolts-1};
            return returnArray;
        }
    }
}
