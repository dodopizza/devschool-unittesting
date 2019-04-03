namespace Domain
{
    public struct Bet
    {
        public Bet(int score, int amount)
        {
            Score = score;
            Amount = amount;
        }
        public int Score { get; private set; }
        public int Amount { get; private set; }
    }
}