namespace Domain
{
    public interface IPlayer
    {
        bool IsInGame { get; }

        Bet CurrentBet { get; }

        void Join(RollDiceGame game);

        void LeaveGame();

        void Buy(Chip chips);

        bool Has(Chip chips);

        void Bet(Bet bet);

        void Win(int chipsAmount);

        void Lose();
    }
}