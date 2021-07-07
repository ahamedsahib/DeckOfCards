using System;
using System.Collections.Generic;


namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Deck Of Cards Program");
            Cards cards = new Cards();
            cards.DistributeCards();
        }
    }
}