namespace JoyCasino.Domain
{
    public class Bet
    {
        public int ChipAmount { get; }

        public int Score { get; }

        public Bet(int chipAmount, int score)
        {
            ChipAmount = chipAmount;
            Score = score;
        }
    }
}