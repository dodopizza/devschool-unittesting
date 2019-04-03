namespace Domain.Tests.DSL
{
    public class PlayerBuilder
    {
        private Game _game;

        public Player Please()
        {
            var player = new Player();
            if (_game != null)
            {
                player.Join(_game);
            }

            return player;
        }

        public PlayerBuilder In(Game game)
        {
            _game = game;
            return this;
        }
    }
}