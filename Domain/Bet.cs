namespace Domain
{
    public class Bet
    {
        public Bet(int amount, int score)
        {
            Amount = amount;
            Score = score;
        }

        public int Amount { get; }
        public int Score { get; }
    }
}