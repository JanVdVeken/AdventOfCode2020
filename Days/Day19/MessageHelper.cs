using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days.Day19
{
    class MessageHelper
    {
        public static Dictionary<int, string> CreateRegexDict(List<string> regexes)
        {
            Dictionary<int, string> regexesDict= new Dictionary<int, string>();
            foreach(string line in regexes)
            {
                regexesDict.Add(int.Parse(line.Split(": ")[0]), line.Split(": ")[1]);
            }
            //regexesDict.Keys.ToList().ForEach(x => Console.WriteLine($"{x} => {regexesDict[x]}"));
            //Console.WriteLine(solveDict(regexesDict, 0));
            regexesDict[0] = solveDict(regexesDict,0);
            return regexesDict;
        }

        private static string solveDict(Dictionary<int, string> dictToSolve, int toSolve)
        {
            StringBuilder sb = new StringBuilder();
            if(dictToSolve[toSolve].Contains(" | "))
            {
                sb.Append("(");
            }
            foreach (string part in dictToSolve[toSolve].Split(" "))
            {
                if (int.TryParse(part, out int parsedPart))
                {
                    sb.Append(solveDict(dictToSolve, parsedPart));    
                }
                else
                {
                    sb.Append(part);
                }
            }
            if (dictToSolve[toSolve].Contains(" | "))
            {
                sb.Append(")");
            }
            return sb.ToString();
        }
    }
}
