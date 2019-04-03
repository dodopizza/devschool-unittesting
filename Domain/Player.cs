using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Player
    {
        public Game CurrentGame { get; private set; }

        public int Chips { get; private set; }
        private readonly List<Bet> _currentBets = new List<Bet>();

        public int GetBetAmount(int score)
        {
            var amount = _currentBets.Where(b => b.Score == score).Sum(b => b.Amount);
            return amount;
        }    

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
            this._currentBets.Add(new Bet(chipCount, score));
        }
    }
}