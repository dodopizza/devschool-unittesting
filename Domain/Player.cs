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
            game.AddPlayer();
        }

        public Game CurrentGame { get; private set; }
        public int CurrentChipsAmount { get; set; }

        public void LeaveCurrentGame()
        {
            if (CurrentGame == null)
                throw new InvalidOperationException();

            CurrentGame.RemovePlayer();
            CurrentGame = null;
        }

        public void BuyChips(int amount)
        {
            CurrentChipsAmount += amount;
        }
    }
}