using System;
using System.Collections.Generic;

namespace Domain
{
    public class RollDiceGame
    {
        private List<IPlayer> players = new List<IPlayer>();
        private readonly IDice _luckyScore;

        public RollDiceGame(IDice luckyScore = null)
        {
            _luckyScore = luckyScore;
        }
        
        public void AddPlayer(IPlayer player)
        {
            if (players.Count == 6)
            {
                throw new TooManyPlayersException();
            }
            players.Add(player);
        }

        public void RemovePlayer(IPlayer player)
        {
            players.Remove(player);
        }

        public void Play()
        {
            var luckyScore = _luckyScore?.Roll() ?? new Random(DateTime.Now.Millisecond).Next(1, 6);
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