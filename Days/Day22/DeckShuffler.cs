using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day22
{
    class DeckShuffler
    {

        public static void RoundOfCombat(List<int> winner, List<int> loser)
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
        public static void RoundOfRecursiveCombat(List<int> Deck1, List<int> Deck2, int gameNumber)
        {
            bool didDeck1Win = false;
            bool didWeEnterSubGame = false;
            if(Deck1.First() < Deck1.Count && Deck2.First() < Deck2.Count)
            {
                didDeck1Win = SubGame(new List<int>(Deck1.GetRange(1, Deck1.First())), new List<int>(Deck2.GetRange(1, Deck2.First())), gameNumber);
                didWeEnterSubGame = true;
            }
            if (((Deck1.First() > Deck2.First()) && !didWeEnterSubGame) || (didWeEnterSubGame && didDeck1Win))
            {
                DeckShuffler.RoundOfCombat(Deck1, Deck2);
            }
            else
            {
                DeckShuffler.RoundOfCombat(Deck2, Deck1);
            }
        }

        public static bool SubGame(List<int> Deck1, List<int> Deck2, int gameNumber)
        {   //true = deck1 won subgame
            gameNumber++;
            int roundNumber = 1;
            List<String> firstTimeDeck1 = new List<String>();
            List<String> firstTimeDeck2 = new List<String>();
            while (Deck1.Count > 0 && Deck2.Count > 0)
            {
                StringBuilder sb1 = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();
                Deck1.ForEach(x => sb1.Append(x.ToString()));
                Deck2.ForEach(x => sb2.Append(x.ToString()));
                if (firstTimeDeck1.Contains(sb1.ToString()) || firstTimeDeck2.Contains(sb2.ToString()))
                {
                    //Console.WriteLine("RecursionRule");
                    return true;
                }
                else
                {
                    firstTimeDeck1.Add(sb1.ToString());
                    firstTimeDeck2.Add(sb2.ToString());
                }
                //Console.WriteLine($" ===== Round {roundNumber} (Game {gameNumber}) ===== ");
                //Console.Write("P1: ");
                //Deck1.ForEach(x => Console.Write(x + " "));
                //Console.WriteLine();
                //Console.Write("P2: ");
                //Deck2.ForEach(x => Console.Write(x + " "));
                //Console.WriteLine();
                RoundOfRecursiveCombat(Deck1, Deck2, gameNumber);
                roundNumber++;


            }
            bool didDeck1Win = Deck1.Count == 0 ? false: true;
            return didDeck1Win;
        }

    }
}
