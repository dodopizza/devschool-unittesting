using System;
using System.Collections.Generic;

namespace JoyCasino.Domain
{
    public class Player
    {
        public bool IsInGame { get; set; }
        
        public int ChipsAmount { get; set; }
        public int CurrentBet { get; set; }
        private readonly Dictionary<int, int> _currentBetsByScore;

        public Player()
        {
            _currentBetsByScore = new Dictionary<int, int>();
        }

        public void JoinGame(Game game)
        {
            IsInGame = true;
        }

        public void LeaveGame(Game game)
        {
            IsInGame = false;
        }

        public void BuyChips(int amount)
        {
            ChipsAmount += amount;
        }

        public void Bet(int amount, int score = default)
        {
            if (amount > ChipsAmount)
            {
                throw new InvalidOperationException();
            }
                
            _currentBetsByScore[score] = amount;
            CurrentBet = amount;
        }

        public int GetBetForScore(int score)
        {
            return _currentBetsByScore[score];
        }
    }
}