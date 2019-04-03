using System;

namespace Domain
{
    public class Player
    {
        private bool _isInGame;

        public int Chips { get; private set; }

        public bool IsInGame => _isInGame;

        public int BetChips { get; private set; }

        public int BetScore { get; private set; }

        public void JoinGame(Game game)
        {
            if (_isInGame)
            {
                throw new Exception("Cant join game because already joined");
            }
            _isInGame = true;
        }

        public void LeaveGame()
        {
            if (!_isInGame)
            {
                throw new Exception("Cant leave because game not started");
            }
            _isInGame = false;
        }

        public void BuyChips(int count)
        {
            Chips += count;
        }

        public void Bet(int chips, int score)
        {
            if (Chips <= chips)
            {
                throw new Exception("Not enought Chips");
            }
            BetChips = chips;
            BetScore = score;
        }
    }
}