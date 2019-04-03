namespace Domain
{
    public class Player
    {
        public void Join(Game game)
        {
            CurrentGame = game;
        }

        public Game CurrentGame { get; private set; }
    }
}