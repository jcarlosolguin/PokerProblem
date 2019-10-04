using System;
using System.Collections.Generic;

namespace PokerHand
{
    public class PokerGame
    {
        //Keeps track of cards to avoid cheaters.
        private Dictionary<string, bool> _cards;
        private List<PokerHand> _hands;

        public PokerGame()
        {
            _cards = new Dictionary<string, bool>();
        }

        public void AddPlayer(string playerName, string[] cards)
        {

        }

        private void SelectCard(string card)
        {

            //check the cards hasn't come out before
            if(_cards.ContainsKey(card))
            {
                throw new Exception("This card["+card+"] has already been used. Someone is cheating.");
            }
        }
    }
}
