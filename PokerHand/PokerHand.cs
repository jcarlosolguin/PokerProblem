using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHand
{
    public enum HandWinLevel
    {
        None, Flush, ThreeOfKind, Pair, HighCard
    }
    public class PokerHand
    {
        public string PlayerName { get;}
        public int HighestCard { get { return _highestCard; } }
        private int _highestCard;
        private Dictionary<int,int> _cards;
        private int _nCards;
        private HandWinLevel _winLevel;
        private bool _sameSuit;
        private char _lastSuit;

        /// <summary>
        /// Returns the highest type of hand the player has.
        /// </summary>
        /// <value>The hand type level.</value>
        public HandWinLevel WinLevel 
        {
            get
            {
                if(_winLevel == HandWinLevel.None)
                {
                    CheckWinLevel();
                }
                return _winLevel;

            }
        }

        public PokerHand(string playerName)             
        {
            this.PlayerName = playerName;
            _highestCard = -1;
            _cards = new Dictionary<int,int>();
            _nCards = 0;
            _sameSuit = true;
            _lastSuit = 'n';
        }

        public void AddCard(string card)
        {
            if (_nCards == 5)
            {
                throw new Exception("Too many cards on hand.");
            }

            Card _card = ParseCard(card);

            //Check the suit only if all cards so far are the same.
            if (_sameSuit)
            {
                CheckSuit(_card.Suit);
            }


            if (_cards.ContainsKey(_card.Value))
            {
                _cards[_card.Value]++;
            }
            else
            {
                _cards.Add(_card.Value, 1);
            }

            _nCards++;

        }

        public List<int> GetCardValues()
        {
            return _cards.Keys.OrderBy(x => x).ToList();
        }

        private void CheckSuit(char suit)
        {
            if (_lastSuit == 'n')
            {
                _lastSuit = suit;
            }
            else if (_lastSuit != suit)
            {
                _sameSuit = false;
            }
        }

        private Card ParseCard(string card)
        {
            string suit = card.Substring(card.Length - 1).ToLower();
            string cardNumber = card.Substring(0, card.Length - 1).ToLower();
            int cardValue = 0;
            switch (cardNumber)
            {
                case "a":
                    cardValue = 14;
                    break;
                case "j":
                    cardValue = 11;
                    break;
                case "q":
                    cardValue = 12;
                    break;
                case "k":
                    cardValue = 13;
                    break;
                default:
                    if(!int.TryParse(cardNumber, out cardValue))
                    {
                        throw new Exception("Card value["+cardNumber+"] has a wrong format. Expecting A, J, Q, K or a number.");
                    }
                    break;
            }
            if (cardValue > 14 || cardValue < 2)
            {
                throw new Exception("Wrong card value [" + cardValue + "].");
            }

            if(suit != "c" && suit != "d" && suit != "h" && suit != "s")
            {
                throw new Exception("Wrong suit ["+suit+"].");
            }

            Card result = new Card();
            result.Value = cardValue;
            result.Suit = suit.ToCharArray()[0];

            return result;
        }

        private void CheckWinLevel()
        {
            if(_nCards == 5)
            {
                switch (_cards.Count)
                {
                    case 5:
                        _highestCard = _cards.Keys.OrderBy(x => x).First();
                        if (_sameSuit)
                        {
                            _winLevel = HandWinLevel.Flush;
                        } 
                        else
                        {
                            _winLevel = HandWinLevel.HighCard;
                        }
                        break;
                    case 4:
                        _highestCard = _cards.First(x => x.Value == 2).Key;
                        _winLevel = HandWinLevel.Pair;                   
                        break;
                    case 3:
                        _highestCard = _cards.First(x => x.Value == 3).Key;
                        _winLevel = HandWinLevel.ThreeOfKind;
                        break;
                    case 2:
                        _highestCard = _cards.First(x => x.Value == 4).Key;
                        _winLevel = HandWinLevel.ThreeOfKind;
                        break;
                    case 1:
                        throw new Exception("Someone is cheating. There are 5 cards with the same value.");

                }               
            }

        }

    }
}
