using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day14
{
    public static class StringExtensions
    {
        public static string Right(this string str, int length)
        {
            return str.Substring(str.Length - length, length);
        }

        public static string MaskValue(string mask, string value)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < mask.Length; i++)
            {
                switch (mask[i])
                {
                    case 'X':
                        sb.Append(value[i]);
                        break;
                    default:
                        sb.Append(mask[i]);
                        break;
                }
            }
            return sb.ToString();
        }

        public static string MaskValueMemory(string mask, string value)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < mask.Length; i++)
            {
                switch (mask[i])
                {
                    case '0':
                        sb.Append(value[i]);
                        break; 
                    default:
                        sb.Append(mask[i]);
                        break;
                }
            }
            return sb.ToString();
        }
    }
}
