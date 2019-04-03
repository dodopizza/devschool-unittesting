using System;

namespace Domain
{
    public class Player
    {
        public Game CurrentGame { get; private set; }
        
        public void Join(Game game)
        {
            this.CurrentGame = game;
        }
    }
}