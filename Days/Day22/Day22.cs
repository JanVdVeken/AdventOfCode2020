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
            while(player1Deck.Count > 0 && player2Deck.Count > 0)
            {
                if(player1Deck.First() > player2Deck.First())
                {
                    DeckShuffler.RoundOfCombat(player1Deck, player2Deck);
                }
                else
                {
                    DeckShuffler.RoundOfCombat(player2Deck, player1Deck);
                }
            }
            long ans = player1Deck.Count() == 0 ? DeckShuffler.CountResult(player2Deck) : DeckShuffler.CountResult(player1Deck);
            Console.WriteLine($"The winning player's score = {ans}");
        }

        public override void Puzzle2()
        {
            int gameNumber = 1;
            int roundNumber = 1;
            while (player1Deck.Count > 0 && player2Deck.Count > 0)
            {
                //Console.WriteLine($" ===== Round {roundNumber} (Game {gameNumber}) ===== ");
                //Console.Write("P1: ");
                //player1Deck.ForEach(x => Console.Write(x + " "));
                //Console.WriteLine();
                //Console.Write("P2: ");
                //player2Deck.ForEach(x => Console.Write(x + " "));
                //Console.WriteLine();
                DeckShuffler.RoundOfRecursiveCombat(player1Deck, player2Deck, gameNumber);
                roundNumber++;
            }
            long ans = player1Deck.Count() == 0 ? DeckShuffler.CountResult(player2Deck) : DeckShuffler.CountResult(player1Deck);
            Console.WriteLine($"The winning player's score = {ans}");
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
