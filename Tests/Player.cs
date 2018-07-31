using System;

namespace Tests
{
    internal class Player
    {
        public int AvailableChips { get; set; }

        public Player()
        {
        }

        internal void EnterGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void BuyChips(Casino casino, int i)
        {
            
        }

        public void MakeBet(Game game, int betNumber, int betChips)
        {
            game.Bank += betChips;
        }
    }
}