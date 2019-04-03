using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Game
    {
        private readonly IDiceRoller _diceRoller;
        private List<Player> _players = new List<Player>();

        public Game(IDiceRoller diceRoller)
        {
            _diceRoller = diceRoller;
        }
        
        public void Play()
        {
            var luckyScore = _diceRoller.Roll();

            foreach (var player in _players)
            {
                var luckyBet = player.GetBetAmount(luckyScore);
                if (luckyBet > 0)
                {
                    player.WinChips(luckyBet * 6);
                }

                player.ClearBets();
            }
        }

        internal void AddPlayer(Player player)
        {
            _players.Add(player);
        }
        
        internal void RemovePlayer(Player player)
        {
            _players.Remove(player);
        }
    }
}