using System;

namespace PokerHand
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            PokerHand _hand = new PokerHand("Carlos");
            _hand.AddCard("8S");
            _hand.AddCard("8D");
            _hand.AddCard("AD");

            string line = Console.ReadLine();
            int lineNumber = 1;

            while (!line.Equals(""))
            {
                if(lineNumber % 2 != 0)
                {
                    //It's a name of player
                }

                line = Console.ReadLine();
                lineNumber++;
            }
        }
    }
}
