namespace JoyCasino.Domain
{
    public class Player
    {
        public bool IsInGame { get; set; }
        
        public int ChipsAmount { get; set; }
        public int CurrentBet { get; set; }

        public void JoinGame(Game game)
        {
            IsInGame = true;
        }

        public void LeaveGame(Game game)
        {
            IsInGame = false;
        }

        public void BuyChips(int amount)
        {
            ChipsAmount += amount;
        }

        public void Bet(int amount)
        {
            CurrentBet = amount;
        }
    }
}