using Moq;

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
            return new RollDiceGame(Score.HasValue ? GetDiceMock(Score.Value) : new Dice());
        }

        private static IDice GetDiceMock(int score)
        {
            var mock = new Mock<IDice>();
            mock.Setup(x=>x.GetScore()).Returns(score);

            return mock.Object;
        }

        private int? Score { get; set; }
    }
}