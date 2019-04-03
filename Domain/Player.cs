using System;

namespace Domain
{
    public class Player
    {
        private bool _isInGame;

        public int Chips { get; private set; }

        public void JoinGame(Game game)
        {
            if (_isInGame)
            {
                throw new Exception("Cant join game because already joined");
            }
            _isInGame = true;
        }

        public bool IsInGame => _isInGame;

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
    }
}