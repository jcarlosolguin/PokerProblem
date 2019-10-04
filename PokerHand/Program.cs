using System;

namespace PokerHand
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            PokerGame game = new PokerGame();

            string player = Console.ReadLine();
            string cards = Console.ReadLine();

            while (!player.Equals("") && !cards.Equals(""))
            {
                game.AddPlayer(player, cards.Split(new char[]   {','}, StringSplitOptions.RemoveEmptyEntries));
                player = Console.ReadLine();
                cards = Console.ReadLine();

            }
            foreach(PokerHand p in game.GetWinners())
            {
                Console.Write(p.PlayerName + " wins");
            }
        }
    }
}
