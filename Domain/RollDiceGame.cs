using System;
using System.Collections.Generic;

namespace Domain
{
    public class RollDiceGame
    {
        public IDice Dice { get; }

        public RollDiceGame(IDice dice)
        {
            Dice = dice;
        }
        
        private List<IPlayer> players = new List<IPlayer>();

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
            var luckyScore = Dice.GetScore();
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

    public interface IDice
    {
        int GetScore();
    }

    public class Dice : IDice
    {
        public int GetScore()
        {
            return new Random(DateTime.Now.Millisecond).Next(1, 6);
        }
    }
}