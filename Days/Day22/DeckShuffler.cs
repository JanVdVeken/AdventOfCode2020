using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day22
{
    class DeckShuffler
    {

        public static void FinishRound(List<int> winner, List<int> loser)
        {
            int FirstToBack = winner.First();
            int SecondToBack = loser.First();
            winner.RemoveAt(0);
            loser.RemoveAt(0);
            winner.Add(FirstToBack);
            winner.Add(SecondToBack);
        }

        public static long CountResult(List<int> input)
        {
            long ans = 0;
            foreach(int element in input)
            {
                ans += element * (input.Count - input.IndexOf(element));
            }
            return ans;
        }

    }
}
