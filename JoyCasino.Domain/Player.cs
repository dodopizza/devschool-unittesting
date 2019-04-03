namespace JoyCasino.Domain
{
    public class Player
    {
        public bool IsInGame { get; set; }
        
        public int ChipsAmount { get; set; }

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
    }
}