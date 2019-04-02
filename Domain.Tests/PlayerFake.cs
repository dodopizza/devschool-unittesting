namespace Domain.Tests
{
    public class PlayerFake : IPlayer
    {
        public PlayerFake(int score)
        {
            CurrentBet = new Bet(new Chip(1), score);
        }
        
        public void Win(int chipsAmount)
        {
            WinCount++;
        }

        public int WinCount { get; private set; }

        public void Lose()
        {
            LoseCount++;
        }

        public Bet CurrentBet { get; }

        public int LoseCount { get; private set; }
    }
}