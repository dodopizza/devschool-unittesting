namespace Domain.Tests.Fakes
{
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