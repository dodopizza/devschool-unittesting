using System;

namespace Domain
{
    public class Player
    {
        public void Join(Game game)
        {
            if (CurrentGame != null)
                throw new InvalidOperationException();

            CurrentGame = game;
            game.AddPlayer(this);
        }

        public Game CurrentGame { get; private set; }
        public int CurrentChipsAmount { get; set; }

        public void LeaveCurrentGame()
        {
            if (CurrentGame == null)
                throw new InvalidOperationException();

            CurrentGame.RemovePlayer(this);
            CurrentGame = null;
        }

        public void BuyChips(int amount)
        {
            CurrentChipsAmount += amount;
        }

        public void Bet(Bet bet)
        {
            if (bet.Amount > CurrentChipsAmount)
                throw new InvalidOperationException();

            CurrentChipsAmount -= bet.Amount;
            CurrentGame.Bet(this, bet);
        }
    }
}