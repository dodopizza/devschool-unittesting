using System.Linq;
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

        public RollDiceGameBuilder WithDice(IDice dice)
        {
            Dice = dice;
            return this;
        }

        public RollDiceGame Please()
        {
            return new RollDiceGame(Dice ?? (Score.HasValue ? GetDiceMock(Score.Value) : new Dice()));
        }

        private static IDice GetDiceMock(int score)
        {
            return new DiceMock(score);
            
            var mock = new Mock<IDice>();
            mock.Setup(x=>x.GetScore()).Returns(score).Verifiable();

            return mock.Object;
        }

        private static IDice GetRepeatDiceMock(int score)
        {
            var mock = new Mock<IDice>();
            mock.Setup(x => x.GetScore()).Returns(() => Enumerable.Range(0, It.IsInRange(1,6, Range.Inclusive)).Select(x => It.IsInRange(1,6, Range.Inclusive)).Last());

            return mock.Object;
        }

        private int? Score { get; set; }

        private IDice Dice { get; set; }
    }

    public class DiceMock : IDice
    {
        private int Score { get; }
        
        public int RollCount { get; private set; }

        public DiceMock(int score)
        {
            Score = score;
        }

        public int GetScore()
        {
            RollCount++;
            return Score;
        }
    }
}