﻿using System;
using System.Collections.Generic;

namespace Domain
{
    public class RollDiceGame
    {
        private readonly IScoreSource _scoreSource;
        private List<Player> players = new List<Player>();

        public RollDiceGame(IScoreSource scoreSource)
        {
            _scoreSource = scoreSource;
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
            var luckyScore = _scoreSource.GetScore();
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