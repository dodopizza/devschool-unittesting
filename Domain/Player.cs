using System;

namespace Domain
{
    public class Player
    {
        public Game CurrentGame { get; private set; }
        
        public void Join(Game game)
        {
            if (this.CurrentGame != null)
            {
                throw new InvalidOperationException("Player already in game");
            }

            this.CurrentGame = game;
        }

        public void LeaveGame()
        {
            if (this.CurrentGame is null)
            {
                throw new InvalidOperationException("Player already not in game");
            }
            
            this.CurrentGame = null;
        }
    }
}