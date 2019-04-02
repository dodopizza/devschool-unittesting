using System;
using System.Collections.Generic;

namespace Domain
{
    public class RollDiceGame
    {
        private readonly IDiceRoller _diceRoller;

        public RollDiceGame(IDiceRoller diceRoller)
        {
            _diceRoller = diceRoller;
        }
        
        private List<Player> players = new List<Player>();

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
            var rollCount = _diceRoller.Roll();

            int luckyScore = 0;
            for (int i = 0; i < rollCount; i++)
            {
                luckyScore = _diceRoller.Roll();
            }
            
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