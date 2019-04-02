namespace Domain.Tests
{
    public class FakePlayer : IPlayer
    {
        public Bet CurrentBet { get; set; }
        public int WinWasCalled { get; set; }
        public void Win(int chipsAmount)
        {
            WinWasCalled++;
        }

        public int LoseWasCalled { get; set; }
        public void Lose()
        {
            LoseWasCalled++;
        }
    }
}