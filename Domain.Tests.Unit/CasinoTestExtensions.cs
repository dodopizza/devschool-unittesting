namespace Domain.Tests
{
    public static class CasinoTestExtensions
    {
        public static Chip Chips(this int count)
        {
            return new Chip(count);
        }

        public static Bet BetOn(this Chip chips, int score)
        {
            return new Bet(chips, score);
        }
    }
}