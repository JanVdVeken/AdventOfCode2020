using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day04
{
    
    class Passport
    {
        public Dictionary<string, string> fields = new Dictionary<string, string>();

        public Passport(string inputString)
        {
            List<string> inputPairs = inputString.Split(" ").ToList();
            foreach(string inputPair in inputPairs)
            {
                var split = inputPair.Split(":");
                var key = split[0];
                var value = split[1];

                fields.Add(key, value);

            }
        }

        public void PrintPassport()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("This password has the following pairs: " + System.Environment.NewLine);
            foreach(string key in fields.Keys)
            {
                sb.Append($" \t key: {key} => value: {fields[key]} \n");
            }
            Console.WriteLine(sb.ToString());
        }

        public bool CheckIfKeysExists(List<string> keyToCheck)
        {
            bool ans = true;
            foreach(string key in keyToCheck)
            {
                ans = fields.ContainsKey(key) && ans;
            }
            return ans;
        }
    }
}
