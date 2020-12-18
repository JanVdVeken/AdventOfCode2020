using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day18
{
    class Operations
    {
        public static long CalcOperation(string input)
        {
            while(input.Contains("(") || input.Contains(")"))
            {
                //Console.WriteLine(input);
                int lastOpening = input.LastIndexOf("(") +1 ;
                int firstClosingAfterLastOpening = input.Substring(lastOpening).IndexOf(')');
                string parenthesis = input.Substring(lastOpening-1, firstClosingAfterLastOpening+2);
                string replacement = CalcOperation(input.Substring(lastOpening, firstClosingAfterLastOpening)).ToString();
                input = input.Replace(parenthesis, replacement);
            }
            List<string> tempOperations = input.Split(" ").ToList();
            if (tempOperations.Count == 1)
            {
                return long.Parse(tempOperations[0]);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < tempOperations.Count-2; i++)
                {
                    sb.Append(tempOperations[i] + " ");
                }
                string inputWithoutLastThree = sb.ToString().Trim();
                if (tempOperations[tempOperations.Count-2] == "*")
                {
                    return (CalcOperation(inputWithoutLastThree) * long.Parse(tempOperations.Last().ToString()));
                }
                else
                {
                    return (CalcOperation(inputWithoutLastThree) + long.Parse(tempOperations.Last().ToString()));
                }
            }
        }
    }
}
