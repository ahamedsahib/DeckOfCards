﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    class Cards
    {
        string[] cardSuit = new string[] { "Clubs", "Diamond", "Heart", "Spade" };
        string[] cardRank = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        List<string> checkCard = new List<string>();

        public void DistributeCards()
        {

            string[,] cardDeck = new string[cardSuit.Length, cardRank.Length];

            for (int i = 0; i < cardSuit.Length; i++)
            {
                for (int j = 0; j < cardRank.Length; j++)
                {
                    cardDeck[i, j] = $"{cardRank[j]} {cardSuit[i]}";
                }
            }
            PrintDeck(cardDeck);

            Dictionary<string, HashSet<string>> players = new Dictionary<string, HashSet<string>>();

            Random rand = new Random();
            int randomSuit, randomRank;
            int playercount = 1;
            while (playercount <= 4)
            {
                HashSet<string> playerCard = new HashSet<string>();
                while (playerCard.Count < 9)
                {
                    randomSuit = rand.Next(0, cardSuit.Length);
                    randomRank = rand.Next(0, cardRank.Length);
                    if (!checkCard.Contains(cardDeck[randomSuit, randomRank]))
                    {
                        playerCard.Add(cardDeck[randomSuit, randomRank]);
                        checkCard.Add(cardDeck[randomSuit, randomRank]);
                    }
                }
                players.Add($"Player {playercount++}", playerCard);


            }
            Console.WriteLine($"*********{checkCard.Count}*******");
            PrintPlayerCards(players);
        }

        public void PrintPlayerCards(Dictionary<string, HashSet<string>> players)
        {
            foreach (KeyValuePair<string, HashSet<string>> i in players)
            {
                Console.WriteLine($"*\n{i.Key} has\n*");
                foreach (string j in i.Value)
                {
                    Console.WriteLine(j);
                }
            }
        }

        public void PrintDeck(string[,] cardDeck)
        {
            for (int i = 0; i < cardSuit.Length; i++)
            {
                for (int j = 0; j < cardRank.Length; j++)
                {
                    Console.Write($"{cardDeck[i, j]} , ");
                }
            }
        }
    }
}
    



