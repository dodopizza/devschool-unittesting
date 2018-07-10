namespace Domain
{
    public class Bet
    {
        public Chip Chips { get; }
        public int Score { get; }

        public Bet(Chip chips, int score)
        {
            Chips = chips;
            Score = score;
        }
    }
}