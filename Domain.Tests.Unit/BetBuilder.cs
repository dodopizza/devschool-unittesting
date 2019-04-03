namespace Domain.Tests
{
    public class BetBuilder
    {
        private int _chipsAmount = 1;
        private int _score = 1;
        public Bet Please()
        {
            return _chipsAmount.Chips().BetOn(_score);
        }

        public BetBuilder On(int score)
        {
            _score = score;
            return this;
        }
    }
}