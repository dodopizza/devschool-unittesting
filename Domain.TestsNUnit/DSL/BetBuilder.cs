using Domain;

namespace Tests
{
    public class BetBuilder
    {
        private int _chips;
        private int _score;

        public BetBuilder WithChips(int chips)
        {
            _chips = chips;
            return this;
        }

        public BetBuilder On(int score)
        {
            _score = score;
            return this;
        }

        public Bet Please()
        {
            return new Bet(new Chip(_chips), _score);
        }
    }
}