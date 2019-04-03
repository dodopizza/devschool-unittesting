using System;

namespace Domain
{
    public class Game
    {
        private int _numberOfPlayers = 0;

        public void AddPlayer()
        {
            if (_numberOfPlayers >= 6)
                throw new InvalidOperationException();

            _numberOfPlayers++;
        }
        
        public void RemovePlayer()
        {
            _numberOfPlayers--;
        }
    }
}