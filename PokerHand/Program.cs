using System;

namespace PokerHand
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            PokerGame game = new PokerGame();

            string player = Console.ReadLine();
            string cards = "";
            if (!player.Equals(""))
            {
                cards = Console.ReadLine();
            }

            int nPlayers = 1;

            try
            {
                while (!player.Equals("") && !cards.Equals("") && nPlayers <= 10)
                {
                    game.AddPlayer(player, cards.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

                    player = Console.ReadLine();
                    if (!player.Equals(""))
                    {
                        cards = Console.ReadLine();
                    }

                    nPlayers++;

                }

                foreach (PokerHand p in game.GetWinners())
                {
                    Console.WriteLine(p.PlayerName + " wins");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong. " + ex.Message);
            }
        }
    }
}
