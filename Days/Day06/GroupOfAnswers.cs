using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day06
{
    class GroupOfAnswers
    {
        public Dictionary<char, int> allAnswers = new Dictionary<char, int>();
        public Dictionary<char,bool> sharedAnswers = new Dictionary<char,bool>();
        public GroupOfAnswers(string input)
        {
            fillAllAnswers(input);
            FillSharedAnswers(input);
        }

        public void fillAllAnswers(string input)
        {
            foreach (char character in input.Replace(" ",""))
            {
                if (allAnswers.ContainsKey(character))
                {
                    allAnswers[character] += 1;
                }
                else
                {
                    allAnswers.Add(character, 1);
                }
            }
        }

        public void FillSharedAnswers(string input)
        {
            var group = input.Split(" ");
            foreach (string person in group)
            {
                //Console.WriteLine(person);
                if(person == group.First())
                {
                    foreach(char character in person)
                    {
                        if(!sharedAnswers.ContainsKey(character))
                        { 
                            sharedAnswers.Add(character, true); 
                        }
                        
                    }
                    
                }
                else
                {
                    foreach(char character in sharedAnswers.Keys)
                    {
                        if (!person.Contains(character))
                        {
                            sharedAnswers[character] = false;
                        }
                    }
                }
            }
            //Console.WriteLine(sharedAnswers.Count(x => x.Value == true));
        }


        public int returnKeySize()
        {
            //Console.WriteLine($"Group with total: {answers.Keys.Count}");
            return allAnswers.Keys.Count();
        }
    }
}
