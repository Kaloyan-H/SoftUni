using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Cards
{
    internal class Program
    {
        static void Main()
        {
            string[] args = Console.ReadLine()
                .Split(", ");

            List<Card> deck = new List<Card>();

            foreach (var arg in args)
            {
                string[] cardArgs = arg.Split(' ');

                try
                {
                    deck.Add(new Card(cardArgs[0], cardArgs[1]));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(' ', deck));
        }
    }

    public class Card
    {
        private readonly string[] VALID_FACES = new string[]
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10",
            "J", "Q", "K", "A"
        };
        private readonly string[] VALID_SUITS = new string[]
        {
            "S", "H", "D", "C"
        };
        private readonly ArgumentException INVALID_CARD = new ArgumentException("Invalid card!");
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get { return face; }
            private set
            {
                if (!VALID_FACES.Contains(value))
                {
                    throw INVALID_CARD;
                }
                else
                {
                    face = value;
                }
            }
        }
        public string Suit
        {
            get { return suit; }
            private set
            {
                switch (value)
                {
                    case "S":
                        suit = '\u2660'.ToString();
                        break;
                    case "H":
                        suit = '\u2665'.ToString();
                        break;
                    case "D":
                        suit = '\u2666'.ToString();
                        break;
                    case "C":
                        suit = '\u2663'.ToString();
                        break;
                    default:
                        throw INVALID_CARD;
                }
            }
        }

        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }
}
