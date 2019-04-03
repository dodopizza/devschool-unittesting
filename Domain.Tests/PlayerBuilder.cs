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

                if (Amount > 0)
                {
                    result.Buy(Amount);
                }

                return result;
            }
        }
        
        private Game Game { get; set; }
        private int Amount { get; set; }

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

        public PlayerBuilder WithChips(int amount)
        {
            Amount = amount;
            return this;
        }
    }
}