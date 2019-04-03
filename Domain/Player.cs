using System;

namespace Domain
{
    public class Player
    {
        public void Join(Game game)
        {
            Game = game;
        }

        public bool InGame => Game != null;
        private Game Game { get; set; }

        public void Left()
        {
            if (!InGame) throw new InvalidOperationException();

            Game = null;
        }
    }
}