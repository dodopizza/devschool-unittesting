using System;
using System.Collections.Generic;

namespace Domain
{
    public class Game
    {
        private readonly Dictionary<Player, int> _betByPlayer = new Dictionary<Player, int>();
        public IReadOnlyDictionary<Player, int> BetByPlayer => _betByPlayer;

        public void AddPlayer(Player player)
        {
            if (_betByPlayer.Count >= 6)
                throw new InvalidOperationException();

            _betByPlayer[player] = 0;
        }
        
        public void RemovePlayer(Player player)
        {
            _betByPlayer.Remove(player);
        }

        public void Bet(Player player, int amount)
        {
            _betByPlayer[player] += amount;
        }
    }
}