using System;
using System.Collections.Generic;

namespace Domain
{
    public class RollDiceGame
    {
        private readonly IScoreSource _scoreSource;
        private readonly List<IPlayer> _players = new List<IPlayer>();

        public RollDiceGame(IScoreSource scoreSource)
        {
            _scoreSource = scoreSource;
        }

        public void AddPlayer(IPlayer player)
        {
            if (_players.Count == 6)
            {
                throw new TooManyPlayersException();
            }
            _players.Add(player);
        }

        public void RemovePlayer(IPlayer player)
        {
            _players.Remove(player);
        }

        public void Play()
        {
            var luckyScore = _scoreSource.GetScore();
            foreach (var player in _players)
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