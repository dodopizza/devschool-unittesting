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

        public void LeaveGame()
        {
            if (this.CurrentGame is null)
            {
                throw new InvalidOperationException("Player already not in game");
            }
            
            CurrentGame = null;
        }
    }
}