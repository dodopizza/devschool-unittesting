namespace Domain.Tests
{
    public class PlayerBuilder
    {
        private Player Current { get; } = new Player();

        public static PlayerBuilder GetPlayer()
        {
            return new PlayerBuilder();
        }

        public PlayerBuilder WithBet(int amount, int score)
        {
            Current.Bet(new Bet(new Chip(amount), score));
            return this;
        }
        
        public Player Build()
        {
            return Current;
        }

        public PlayerBuilder InGame()
        {
            Current.Join(new RollDiceGame(new Dice()));
            return this;
        }

        public PlayerBuilder JoinRollDiceGameWithLuckyScore(int luckyScore)
        {
            var game = new RollDiceGame(new DiceMock(luckyScore));
            Current.Join(game);

            return this;
        }
    }
}