using System;
using System.Collections.Generic;

namespace Domain
{
    public class Player
    {
        private bool _isInGame;

        public int Chips { get; private set; }

        public bool IsInGame => _isInGame;

        private readonly List<Bet> _bets = new List<Bet>();
        public Bet[] Bets => _bets.ToArray();

        public void JoinGame(Game game)
        {
            if (_isInGame)
            {
                throw new Exception("Cant join game because already joined");
            }
            _isInGame = true;
        }

        public void LeaveGame()
        {
            if (!_isInGame)
            {
                throw new Exception("Cant leave because game not started");
            }
            _isInGame = false;
        }

        public void BuyChips(int count)
        {
            Chips += count;
        }

        public void Bet(int chips, int score)
        {
            if (Chips < chips)
            {
                throw new Exception("Not enought Chips");
            }

            _bets.Add(new Bet(chips, score));
            Chips -= chips;
        }
    }
}