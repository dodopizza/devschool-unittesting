namespace Domain
{
    public class Bet
    {
        public Bet(int chips, int score)
        {
            Chips = chips;
            Score = score;
        }

        public int Chips { get; }

        public int Score { get; }
    }
}