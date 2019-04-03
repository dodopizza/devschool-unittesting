using JoyCasino.Domain;

namespace JoyCasino.Tests.Dsl
{
    public class PlayerBuilder
    {
        private Game _game;

        public PlayerBuilder InGame(Game game)
        {
            _game = game;

            return this;
        }

        public Player Build()
        {
            var player = new Player();
            
            player.JoinGame(_game);

            return player;
        }
    }
}