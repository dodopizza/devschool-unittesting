namespace Domain.Tests
{
    public class RollDiceGameBuilder
    {
        public static RollDiceGameBuilder GetGame()
        {
            return new RollDiceGameBuilder();
        }

        public RollDiceGameBuilder WithLuckyScore(int score)
        {
            Score = score;
            return this;
        }

        public RollDiceGame Build()
        {
            return new RollDiceGame(new DiceMock(Score));
        }

        private int Score { get; set; }
    }
}