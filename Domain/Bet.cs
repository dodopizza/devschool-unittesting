namespace Domain
{
    public class Bet
    {
        public Bet(Chip chips, int score)
        {
            Chips = chips;
            Score = score;
        }

        public Chip Chips { get; }
        public int Score { get; }
    }
}