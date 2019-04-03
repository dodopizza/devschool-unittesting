using System;
using System.Collections.Generic;

namespace Domain
{
    public class Game
    {
        private readonly Dictionary<Player, List<Bet>> _betByPlayer = new Dictionary<Player, List<Bet>>();
        public IReadOnlyDictionary<Player, List<Bet>> BetByPlayer => _betByPlayer;

        public void AddPlayer(Player player)
        {
            if (_betByPlayer.Count >= 6)
                throw new InvalidOperationException();

            _betByPlayer[player] = new List<Bet>();
        }
        
        public void RemovePlayer(Player player)
        {
            _betByPlayer.Remove(player);
        }

        public void Bet(Player player, Bet bet)
        {
            _betByPlayer[player].Add(bet);
        }
    }
}