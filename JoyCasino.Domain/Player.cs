namespace JoyCasino.Domain
{
    public class Player
    {
        public bool IsInGame { get; set; }

        public void JoinGame(Game game)
        {
            IsInGame = true;
        }

        public void LeaveGame(Game game)
        {
            IsInGame = false;
        }
    }
}