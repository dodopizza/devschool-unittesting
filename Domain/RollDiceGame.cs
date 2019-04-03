using System;
using System.Collections.Generic;

namespace Domain
{
    public class RollDiceGame
    {
        private readonly IDieRoller _dieRoller;
        private readonly List<IPlayer> players = new List<IPlayer>();
        public const int MaxPlayers = 6; 
        public const int WinFactor = 6;
        public IReadOnlyList<IPlayer> Players => players;

        public RollDiceGame(IDieRoller dieRoller)
        {
            _dieRoller = dieRoller;
        }

        public void AddPlayer(IPlayer player)
        {
            if (players.Count == MaxPlayers) throw new TooManyPlayersException();
            players.Add(player);
        }
 
        public void RemovePlayer(IPlayer player)
        {
            players.Remove(player);
        }

        public void Play()
        {
            var luckyScore = _dieRoller.RollDice();
            foreach (var player in players)
                if (player.CurrentBet.Score == luckyScore)
                    player.Win(player.CurrentBet.Chips.Amount * WinFactor);
                else
                    player.Lose();
        }
    }
}