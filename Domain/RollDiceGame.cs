using System;
using System.Collections.Generic;
using Domain.Randomizer;

namespace Domain
{
    public class RollDiceGame
    {
        private List<Player> players = new List<Player>();
        private readonly IRandomizer _randomizer;

        public RollDiceGame(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public void AddPlayer(Player player)
        {
            if (players.Count == 6)
            {
                throw new TooManyPlayersException();
            }

            players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }

        public void Play()
        {
            var luckyScore = _randomizer.GetScore(1, 6);

            foreach (var player in players)
            {
                if (player.CurrentBet.Score == luckyScore)
                {
                    player.Win(player.CurrentBet.Chips.Amount * 6);
                }
                else
                {
                    player.Lose();
                }
            }
        }
    }
}