namespace Domain
{
    public interface IPlayer
    {
        void Win(int chipsAmount);

        void Lose();

        Bet CurrentBet { get; }
    }
}