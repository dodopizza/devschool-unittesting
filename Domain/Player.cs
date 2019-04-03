using System;

namespace Domain
{
    public class Player
    {
        public Game CurrentGame { get; private set; }
        
        public int Chips { get; private set; }
        public Bet CurrentBet { get; set; }

        public void Join(Game game)
        {
            if (this.CurrentGame != null)
            {
                throw new InvalidOperationException("Player already in game");
            }

            this.CurrentGame = game;
        }

        public void LeaveGame()
        {
            if (this.CurrentGame is null)
            {
                throw new InvalidOperationException("Player already not in game");
            }
            
            this.CurrentGame = null;
        }

        public void BuyChips(int chipsCount)
        {
            this.Chips += chipsCount;
        }

        public void Bet(int chipCount, int score)
        {
            if (chipCount > this.Chips)
            {
                throw new InvalidOperationException("Not enough chips for bet");
            }
            
            this.Chips -= chipCount;
            this.CurrentBet = new Bet(chipCount, score);
        }
    }
}