namespace Domain.Tests
{
    public class DiceBuilder
    {
        public DiceBuilder WithLuckyScore(int score)
        {
            Score = score;
            return this;
        }

        private int Score { get; set; }

        public DiceMock Please()
        {
            return new DiceMock(Score);
        }
    }
}