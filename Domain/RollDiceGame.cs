using System;
using System.Collections.Generic;
using Domain.Dice;

namespace Domain
{
    public class RollDiceGame
    {
        private List<Player> players = new List<Player>();
        private readonly IDice _dice;

        public RollDiceGame(IDice dice)
        {
            _dice = dice;
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
            var rollCount = _dice.GetScore();

            int luckyScore;
            var i = 0;
            do
            {
                luckyScore = _dice.GetScore();
                i++;
            } while (i < rollCount);

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