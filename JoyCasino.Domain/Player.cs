using System;
using System.Collections.Generic;

namespace JoyCasino.Domain
{
    public class Player
    {
        private readonly Dictionary<int, int> _currentBetsByScore;

        public bool IsInGame { get; private set; }
        public int ChipsAmount { get; private set; }

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

        public void Bet(int amount, int score)
        {
            if (amount > ChipsAmount)
            {
                throw new InvalidOperationException();
            }

            _currentBetsByScore[score] = amount;
        }

        public int GetBetForScore(int score)
        {
            return _currentBetsByScore[score];
        }
    }
}