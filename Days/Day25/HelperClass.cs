using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day25
{
    class HelperClass
    {
        public static long CalcSubjectNumber(long value, int subjectNumber, int divider)
        {
            value *= subjectNumber;
            return value % 20201227;
        }
    }
}
