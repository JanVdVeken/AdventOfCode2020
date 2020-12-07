using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Days.Day07
{

    class Bag
    {
        string name;
        Dictionary<string, int> children = new Dictionary<string, int>();

        public Bag(string nameInput, string childrenInput)
        {
            Regex re = new Regex(@"(\d+)([a-zA-Z ]+)");


            name = nameInput;
            var childrenArray = childrenInput.Split("bag");
            foreach(string child in childrenArray.Where(x => !x.Contains(".")))
            {
                if(string.Equals(child, "no other "))
                {
                }
                else
                {
                    Match result = re.Match(child.Trim());
                    children.Add(result.Groups[2].Value.Trim(), int.Parse(result.Groups[1].Value.Trim()));
                }

            }
        }


        public void printBagInfo()
        {
            Console.WriteLine($"This bag ({name}) contains the following bag(s):");
            foreach(var key in children.Keys)
            {
                Console.WriteLine($"\t => {children[key]} {key}");
            };

        }
    }
}
