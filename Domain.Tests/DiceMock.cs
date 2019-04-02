namespace Domain.Tests
{
    public class DiceMock : IDice
    {
        public int Score { get; }

        public DiceMock(int score)
        {
            Score = score;
        }

        public int GetScore()
        {
            return Score;
        }
    }
}