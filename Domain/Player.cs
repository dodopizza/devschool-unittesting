using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Player
    {
        public void Join(Game game)
        {
            if (InGame) throw new InvalidOperationException();
            
            Game = game;
        }

        public bool InGame => Game != null;
        
        private Game Game { get; set; }

        public int Amount { get; private set; }

        public int CurrentBetAmount => CurrentBets.Sum(x => x.Amount);
        public IEnumerable<Bet> CurrentBets => _currentBets;
        
        private readonly List<Bet> _currentBets = new List<Bet>();

        public void Left()
        {
            if (!InGame) throw new InvalidOperationException();

            Game = null;
        }

        public void Buy(int amount)
        {
            Amount += amount;
        }

        public bool HasChips(int amount)
        {
            return Amount >= amount;
        }

        public void Bet(int amount, int score)
        {
            if (amount > Amount) throw new InvalidOperationException();

            _currentBets.Add(new Bet(score, amount));
            
            Amount -= amount;
        }

        public void Loose()
        {
            _currentBets.Clear();
        }

        public void Win()
        {
            Amount += CurrentBetAmount * 6;
        }

        public void Play(int score)
        {
            Amount += CurrentBets.Where(x => x.Score == score).Sum(x => x.Amount) * 6;
            
            _currentBets.Clear();
        }
    }

    public class Bet
    {
        public Bet(int score, int amount)
        {
            Score = score;
            Amount = amount;
        }

        public int Score { get; }
        public int Amount { get; }
    }
}