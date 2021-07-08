using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    public static class Extensions  
    {
        public static int findIndex<T>(this T[] array, T item)
        {
            return Array.IndexOf(array, item);
        }
    }
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
            
            Dictionary<string, List<string>> players = new Dictionary<string, List<string>>();

            Random rand = new Random();
            int randomSuit, randomRank;
            int playercount = 1;
            while (playercount <= 4)
            {
                List<string> playerCard = new List<string>();
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
            
            PrintPlayerCards(players);
        }

        public void PrintPlayerCards(Dictionary<string, List<string>> players)
        {
            foreach (KeyValuePair<string, List<string>> i in players)
            {
                Console.WriteLine($"*\n{i.Key} has\n*");
                foreach (string j in i.Value)
                {
                    Console.WriteLine(j);
                }
                SortCards(i.Value, i.Key);
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
        public void SortCards(List<string> playerCard, string playerName)
        {
            int x, y;
            //Bubble sort algorithm used to sort the elements in the array
            for (int i = 0; i < playerCard.Count - 1; i++)
            {
                
                for (int j = 0; j < playerCard.Count - i - 1; j++)
                {
                    x = cardRank.findIndex(playerCard[j].Split(" ")[0]);
                    y = cardRank.findIndex(playerCard[j + 1].Split(" ")[0]);
                    //swap if x greater than y
                    if (x > y)
                    {
                        string temp = playerCard[j];
                        playerCard[j] = playerCard[j + 1];
                        playerCard[j + 1] = temp;
                    }

                }

            }
            Console.WriteLine("*****AFTER SORTING*******");
            foreach (string j in playerCard)
            {
                Console.WriteLine(j);
            }

        }
    }
}



