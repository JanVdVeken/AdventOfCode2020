using AdventOfCode2020.Shared;
using Days.Day22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Days
{
    public class Day22 : Day
    {
        private List<string> input = new List<string>();
        private List<int> player1Deck;
        private List<int> player2Deck;
        public Day22()
        {
            DayNumber = 22;
            Title = "Crab Combat";
        }

        public override void Puzzle1()
        {
            Console.WriteLine("Player 1:");
            player1Deck.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("Player 2:");
            player2Deck.ForEach(x => Console.WriteLine(x));

            while(player1Deck.Count > 0 && player2Deck.Count > 0)
            {
                if(player1Deck.First() > player2Deck.First())
                {
                    DeckShuffler.FinishRound(player1Deck, player2Deck);
                }
                else
                {
                    DeckShuffler.FinishRound(player2Deck, player1Deck);
                }
            }
            long ans = player1Deck.Count() == 0 ? DeckShuffler.CountResult(player2Deck) : DeckShuffler.CountResult(player1Deck);
            Console.WriteLine($"The winning player's score = {ans}");
        }

        public override void Puzzle2()
        {


        }

        public override void GatherInput()
        {
            input = ReadFile().ToList();
            player1Deck = new List<int>();
            player2Deck = new List<int>();
            foreach(string line in input.Where(x => input.IndexOf(x) > input.IndexOf("Player 1:") && input.IndexOf(x) < input.IndexOf("Player 2:")-1))
            {
                player1Deck.Add(int.Parse(line));
            }
            foreach (string line in input.Where(x => input.IndexOf(x) > input.IndexOf("Player 2:")))
            {
                player2Deck.Add(int.Parse(line));
            }
        }
    }
}
