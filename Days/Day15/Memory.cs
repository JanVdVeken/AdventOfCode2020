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
    }
}
