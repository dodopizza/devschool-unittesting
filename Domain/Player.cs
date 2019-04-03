using System;

namespace Domain
{
    public class Player
    {
        public void Join(Game game)
        {
            if (InGame) throw new InvalidOperationException();
            
            Game = game;
        }

        public bool InGame => Game != null;
        
        private Game Game { get; set; }
        
        private int Amount { get; set; }
        public int CurrentBet { get; private set; }

        public void Left()
        {
            if (!InGame) throw new InvalidOperationException();

            Game = null;
        }

        public void Buy(int amount)
        {
            Amount += amount;
        }

        public bool HasChips(int amount)
        {
            return Amount >= amount;
        }

        public void Bet(int amount)
        {
            CurrentBet = amount;
        }
    }
}