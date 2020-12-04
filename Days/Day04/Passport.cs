using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public bool CheckIfPassportIsValid(List<string> keyToCheck)
        {
            bool ans;
            if(!CheckIfKeysExists(keyToCheck))
            {
                ans = false;
            }
            else
            {
                ans = CheckByr() && CheckIyr() && CheckEyr() && CheckHgt() && CheckHcl() && CheckEcl() && CheckPid();
            }
            return ans;
        }
        public bool CheckPid()
        {
            var rg = new Regex("^[0-9]{9}$");
            bool ans = true;
            if (!rg.IsMatch(fields["pid"]))
            {
                ans = false;
            }
            Console.WriteLine($"pid: {fields["pid"] } is {ans}.");
            return ans;
        }
        public bool CheckEcl()
        {
            List<string> possibleEyeColors = new() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            bool ans = true;
            if(!possibleEyeColors.Contains(fields["ecl"]))
            {
                ans = false;
            }
            Console.WriteLine($"ecl: {fields["ecl"] } is {ans}.");
            return ans;
        }
        public bool CheckHcl()
        {
            var rg = new Regex("^#[0-9a-f]{6}$");
            bool ans = true;
            if(!rg.IsMatch(fields["hcl"]))
            {
                ans = false;
            }
            Console.WriteLine($"hcl: {fields["hcl"] } is {ans}.");
            return ans;
        }
        public bool CheckHgt()
        {
            string hgt = fields["hgt"];
            bool ans = true;
            if (int.TryParse(hgt.Substring(0, hgt.Length - 2), out int ghtInt) )
            {
               if (hgt.EndsWith("cm") )
                {
                    if (ghtInt < 150 || ghtInt > 193)
                    {
                        ans = false;
                    }
                }
                else if(hgt.EndsWith("in"))
                {
                    if (ghtInt<59 || ghtInt>76)
                    {
                        ans = false;
                    }
                }
                else
                {
                    ans = false;
                }
            }
            else
            {
                ans = false;
            }
            Console.WriteLine($"hgt: {fields["hgt"] } is {ans}.");
            return ans;
        }
        public bool CheckEyr()
        {
            bool ans = true;

            string eyr = fields["eyr"];
            if (int.TryParse(eyr, out int eyrInt))
            {
                if (eyr.Length != 4 || eyrInt < 2020 || eyrInt > 2030)
                {
                    ans = false;
                }
            }
            else
            {
                ans = false;
            }
            Console.WriteLine($"eyr: {fields["eyr"] } is {ans}.");
            return ans;
        }
        public bool CheckIyr()
        {
            bool ans = true;

            string iyr = fields["iyr"];
            if (int.TryParse(iyr, out int iyrInt))
            {
                if (iyr.Length != 4 || iyrInt < 2010 || iyrInt > 2020)
                {
                    ans = false;
                }
            }
            else
            {
                ans = false;
            }
            Console.WriteLine($"iyr: {fields["iyr"] } is {ans}.");
            return ans;
        }

        public bool CheckByr()
        {
            bool ans = true;

            string byr = fields["byr"];
            if(int.TryParse(byr, out int byrInt))
            {
                if (byr.Length != 4 || byrInt < 1920 || byrInt > 2002)
                {
                    ans = false;
                }
            }
            else
            {
                ans = false;
            }
            Console.WriteLine($"byr: {fields["byr"] } is {ans}.");
            return ans;
        }

    }
}
