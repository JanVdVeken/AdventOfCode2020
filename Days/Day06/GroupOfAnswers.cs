using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day06
{
    class GroupOfAnswers
    {
        public Dictionary<char, int> answers = new Dictionary<char, int>();

        public GroupOfAnswers(string input)
        {
            foreach (char character in input)
            {
                if (answers.ContainsKey(character))
                {
                    answers[character] += 1;
                }
                else
                {
                    answers.Add(character,1);
                }
            }
        }

        public int returnKeySize()
        {
            //Console.WriteLine($"Group with total: {answers.Keys.Count}");
            return answers.Keys.Count();
        }
    }
}
