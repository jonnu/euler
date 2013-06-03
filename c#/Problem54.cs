using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Problem54 : Problem
    {
        public override void Process()
        {
            int playerOneWon = ReadPokerHandsFromFile()
                .Where(hands => hands.Item1 > hands.Item2)
                .Count();

            Console.WriteLine("First player won {0} hands of poker", playerOneWon);
        }

        private IEnumerable<Tuple<PokerHand, PokerHand>> ReadPokerHandsFromFile()
        {
            string raw = ReadTextFile("Problem54.txt", false);
            using (StringReader reader = new StringReader(raw))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return new Tuple<PokerHand, PokerHand>(
                        new PokerHand(line.Substring(0, 14)),
                        new PokerHand(line.Substring(15, 14))
                    );
                }
            }
        }
    }

    class PokerCard : IComparable
    {
        public enum Suits
        {
            Heart,
            Diamond,
            Club,
            Spade
        }

        public enum Cards
        {
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        }

        public Suits Suit { get; private set; }
        public Cards Card { get; private set; }
        public string Alias { get; private set; }

        public PokerCard(string cardString)
        {
            char[] cardData = cardString.ToCharArray();

            Alias = cardString;
            Card = GetCardFromChar(cardData[0]);
            Suit = GetSuitFromChar(cardData[1]);
        }

        public int CompareTo(Object obj)
        {
            if (!(obj is PokerCard))
                throw new ArgumentException("Object must be a PokerCard");

            // Compare card face, suits do not matter
            PokerCard compareCard = (PokerCard)obj;
            if (Card == compareCard.Card)
                return 0;

            return Card > compareCard.Card ? 1 : -1;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is PokerCard))
                return false;

            return CompareTo(obj) == 0;
        }

        public static bool operator ==(PokerCard card1, PokerCard card2)
        {
            return card1.Equals(card2);
        }

        public static bool operator !=(PokerCard card1, PokerCard card2)
        {
            return !(card1 == card2);
        }

        public static bool operator <(PokerCard card1, PokerCard card2)
        {
            return card1.CompareTo(card2) < 0;
        }

        public static bool operator >(PokerCard card1, PokerCard card2)
        {
            return card1.CompareTo(card2) > 0;
        }

        public override int GetHashCode()
        {
            return ((int)Suit | (int)Card);
        }

        public override string ToString()
        {
            return Alias;
        }

        static public Cards GetCardFromChar(char card)
        {
            switch ((int)Char.ToUpper(card))
            {
                case 50: return Cards.Two;
                case 51: return Cards.Three;
                case 52: return Cards.Four;
                case 53: return Cards.Five;
                case 54: return Cards.Six;
                case 55: return Cards.Seven;
                case 56: return Cards.Eight;
                case 57: return Cards.Nine;
                case 84: return Cards.Ten;
                case 74: return Cards.Jack;
                case 81: return Cards.Queen;
                case 75: return Cards.King;
                case 65: return Cards.Ace;
                default: throw new ArgumentException("Unknown Card: " + card);
            }
        }

        static public Suits GetSuitFromChar(char suit)
        {
            switch (Char.ToUpper(suit))
            {
                case 'H': return Suits.Heart;
                case 'D': return Suits.Diamond;
                case 'C': return Suits.Club;
                case 'S': return Suits.Spade;
                default: throw new ArgumentException("Unknown Suit: " + suit);
            }
        }
    }

    class PokerHand : IComparable
    {
        public enum Weights
        {
            HighCard,
            OnePair,
            TwoPairs,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        }

        private PokerCard[] hand = new PokerCard[5];
        public Weights Weight { get; private set; }

        public PokerHand(string cardData)
        {
            string[] cardStringArray = cardData.Split(' ');
            for (int n = 0; n < cardStringArray.Length; n++)
            {
                hand[n] = new PokerCard(cardStringArray[n]);
            }

            Weight = ComputeWeight();
        }

        public PokerHand(PokerCard[] cardArray)
        {
            for (int n = 0; n < cardArray.Length; n++)
            {
                hand[n] = cardArray[n];
            }

            Weight = ComputeWeight();
        }

        private void SortHand()
        {
            hand = hand.OrderBy(card => card.Card).ToArray();
        }

        private PokerCard GetLowestCard()
        {
            return hand.OrderBy(card => card.Card).First();
        }

        private PokerCard GetHighestCard()
        {
            return hand.OrderBy(card => card.Card).Last();
        }

        public Dictionary<PokerCard.Cards, int> GroupCardsByFrequency()
        {
            return hand
                .GroupBy(card => card.Card)
                .OrderByDescending(x => x.Count())
                .ToDictionary(x => x.Key, x => x.Count());
        }

        private bool ContainsRun()
        {
            var sortedHand = hand.OrderBy(card => card.Card);
            int currentValue = (int)sortedHand.First().Card;
            for (int i = 1; i < sortedHand.Count(); i++)
            {
                int nextValue = (int)sortedHand.ElementAt(i).Card;
                if (currentValue + 1 != nextValue)
                    return false;

                currentValue = nextValue;
            }

            return true;
        }

        private Weights ComputeWeight()
        {
            int distinctSuits = hand.Select(x => x.Suit).Distinct().Count();
            var groupedCards = GroupCardsByFrequency();

            // Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.
            if (distinctSuits == 1 && ContainsRun() && GetLowestCard().Card == PokerCard.Cards.Ten)
                return Weights.RoyalFlush;

            // Straight Flush: All cards are consecutive values of same suit.
            if (distinctSuits == 1 && ContainsRun())
                return Weights.StraightFlush;

            // Four of a Kind: Four cards of the same value.
            if (groupedCards.Max(x => x.Value) == 4)
                return Weights.FourOfAKind;

            // Full House: Three of a kind and a pair.
            if (groupedCards.Count() == 2)
                return Weights.FullHouse;

            // Flush: All cards of the same suit.
            if (distinctSuits == 1)
                return Weights.Flush;

            // Straight: All cards are consecutive values.
            if (ContainsRun())
                return Weights.Straight;

            // Three of a Kind: Three cards of the same value.
            if (groupedCards.Max(x => x.Value) == 3)
                return Weights.ThreeOfAKind;

            // Two Pairs: Two different pairs.
            if (groupedCards.Where(x => x.Value == 2).Count() == 2)
                return Weights.TwoPairs;

            // One Pair: Two cards of the same value.
            if (groupedCards.Where(x => x.Value == 2).Count() == 1)
                return Weights.OnePair;

            // High Card: Highest value card.
            return Weights.HighCard;
        }

        public IEnumerable<PokerCard> GetCards()
        {
            SortHand();
            for (int n = hand.Length - 1; n >= 0; n--)
                yield return hand[n];
        }

        public int CompareTo(Object obj)
        {
            if (!(obj is PokerHand))
                throw new ArgumentException("Can only compare to PokerHand objects");

            PokerHand compareHand = (PokerHand)obj;

            // If we have equal hand weights, run additional logic
            if (compareHand.Weight == Weight)
            {
                switch (Weight)
                {
                    // Scenarios where only the highest card matters
                    case Weights.StraightFlush:
                    case Weights.Straight:
                    case Weights.Flush:
                    case Weights.HighCard:
                        return GetHighestCard().CompareTo(compareHand.GetHighestCard());

                    // Scenarios where we compare groups of cards
                    case Weights.FullHouse:
                    case Weights.FourOfAKind:
                    case Weights.ThreeOfAKind:
                    case Weights.TwoPairs:
                    case Weights.OnePair:
                        Dictionary<PokerCard.Cards, int> leftGroups, rightGroups;
                        leftGroups = GroupCardsByFrequency();
                        rightGroups = compareHand.GroupCardsByFrequency();

                        for (int i = 0; i < leftGroups.Count(); i++)
                        {
                            int comparisonValue = leftGroups.ElementAt(i).Key.CompareTo(rightGroups.ElementAt(i).Key);
                            if (comparisonValue == 0)
                                continue;

                            return comparisonValue;
                        }

                        return 0;
                }

            }

            return Weight > compareHand.Weight ? 1 : -1;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is PokerHand))
                return false;

            return CompareTo(obj) == 0;
        }

        public static bool operator ==(PokerHand hand1, PokerHand hand2)
        {
            return hand1.Equals(hand2);
        }

        public static bool operator !=(PokerHand hand1, PokerHand hand2)
        {
            return !(hand1 == hand2);
        }

        public static bool operator <(PokerHand hand1, PokerHand hand2)
        {
            return hand1.CompareTo(hand2) < 0;
        }

        public static bool operator >(PokerHand hand1, PokerHand hand2)
        {
            return hand1.CompareTo(hand2) > 0;
        }

        public override string ToString()
        {
            SortHand();
            StringBuilder sb = new StringBuilder();
            for (int n = 0; n < hand.Length; n++)
            {
                sb.AppendFormat("{0} ", hand[n].ToString());
            }

            sb.AppendFormat("({0, 12})", Enum.GetName(typeof(Weights), Weight));
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 0;
            for (int n = 0; n < hand.Length; n++)
            {
                hash ^= hand[n].GetHashCode();
            }

            return hash;
        }
    }
}
