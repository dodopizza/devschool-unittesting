namespace Domain.Tests
{
    public class PlayerBuilder
    {
        public Player Please
        {
            get
            {
                var result = new Player();
                if (Game != null)
                {
                    result.Join(Game);
                }

                return result;
            }
        }
        
        private Game Game { get; set; }

        public PlayerBuilder InGame(Game game)
        {
            Game = game;
            return this;
        }

        public PlayerBuilder InGame()
        {
            Game = new Game();
            return this;
        }
    }
}