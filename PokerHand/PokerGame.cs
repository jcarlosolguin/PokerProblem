using System;
using System.Collections.Generic;
using System.Linq;

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
            _hands = new List<PokerHand>();
        }

        public void AddPlayer(string playerName, string[] cards)
        {
            if(_hands.Count == 10)
            {
                throw new Exception("Number of players was exceeded.");
            }

            if(cards.Length != 5)
            {
                throw new Exception("Wrong number of cards, got " + cards.Length);
            }

            PokerHand player = new PokerHand(playerName);
            foreach(string card in cards)
            {
                player.AddCard(card.Trim());
                SelectCard(card);
            }
            _hands.Add(player);

        }

        public List<PokerHand> GetWinners()
        {
            if(_hands.Count < 2)
            {
                throw new Exception("Not enough players.");
            }
            //Order hands by higher win levels, then by highest card.
            List<PokerHand> sortedHands = _hands
                                            .OrderBy(h => h.WinLevel)
                                            .ThenByDescending(h => h.HighestCard)
                                            .ToList();
            List<PokerHand> winners = new List<PokerHand>();

            winners.Add(sortedHands[0]);

            //Get highest kicker combination
            List<int> highestNumbers = winners[0].GetCardValues();

            //Add any player with similar win level, and Highest Card
            for (int i = 1; i < sortedHands.Count
                            && sortedHands[i].WinLevel == sortedHands[0].WinLevel
                            && sortedHands[i].HighestCard == sortedHands[0].HighestCard;
                             i++)
            {
                winners.Add(sortedHands[i]);

                List<int> cardValues = sortedHands[i].GetCardValues();

                //Check highest kicker combination
                for (int j = 0; j < highestNumbers.Count && j < cardValues.Count; j++)
                {
                    if (cardValues[j] > highestNumbers[j])
                    {
                        highestNumbers = cardValues;
                        break;
                    }
                }

            }

            if(winners.Count > 1)
            {
                for (int i = 0; i < winners.Count;)
                {
                    List<int> cardValues = winners[i].GetCardValues();
                    if(cardValues.Count != highestNumbers.Count)
                    {
                        winners.RemoveAt(i);
                    } else
                    {
                        bool wasRemoved = false;
                        for(int j=0; j<cardValues.Count; j++)
                        {
                            if (cardValues[j] < highestNumbers[j])
                            {
                                winners.RemoveAt(i);
                                wasRemoved = true;
                                break;
                            }
                        }
                        if (!wasRemoved)
                        {
                            i++;
                        }
                    }
                }               
            }

            return winners;
        }

        private void SelectCard(string card)
        {
            //check the cards hasn't come out before
            if(_cards.ContainsKey(card))
            {
                throw new Exception("This card["+card+"] has already been used. Someone is cheating.");
            } 
            else
            {
                _cards.Add(card, true);
            }
        }
    }
}
