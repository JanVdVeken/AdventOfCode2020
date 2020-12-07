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
        public string name;
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
                    children.Add("no other",0);
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

        public bool checkIfThisOrChildContiansBag(string goalBag, List<Bag> allBags)
        {
            var ans = false;
            foreach(var key in children.Keys)
            {
                if (key.Equals(goalBag) || key.Equals("no other"))
                {
                    if(key.Equals(goalBag))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                else
                {
                    ans = ans || allBags.Single(x => x.name.Equals(key)).checkIfThisOrChildContiansBag(goalBag,allBags);
                }
            }

            return ans; //I've included this, because it was complaining about not always returning an int...
        }

        public int CountHowManyBagsInsideThisOne(List<Bag> allBags)
        {
            var ans = 1;
            foreach (var key in children.Keys)
            {
                Console.WriteLine($"This bag = {name}");
                if (key.Equals("no other"))
                {
                    {
                        return ans;
                    }
                }
                else
                {
                    ans += children[key] * allBags.Single(x => x.name.Equals(key)).CountHowManyBagsInsideThisOne(allBags);
                }
            }

            return ans;
        }
    }
}
