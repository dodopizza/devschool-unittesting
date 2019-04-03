namespace Domain
{
    public static class BetExtensions
    {
        public static Bet BetOn(this int amount, int score)
        {
            return new Bet(score, amount);
        }
    }
}