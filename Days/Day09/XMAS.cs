using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day09
{
    class XMAS
    {

        public static bool CheckIfsSumCanBeMade(long input, List<long> preamble)
        {
            for(int i = 0; i < preamble.Count();i++)
            {
                for (int j = 0; j < preamble.Count(); j++)
                {
                    if(i != j && preamble[i] + preamble[j] == input)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
