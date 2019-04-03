using JoyCasino.Domain;

namespace JoyCasino.Tests.Dsl
{
    public class PlayerBuilder
    {
        private Game _game;
        private int _chipsAmount;

        public PlayerBuilder InGame(Game game = default)
        {
            _game = game ?? new Game();

            return this;
        }

        public Player Build()
        {
            var player = new Player();
            
            player.JoinGame(_game);

            if (_chipsAmount > 0)
            {
                player.BuyChips(_chipsAmount);
            }

            return player;
        }

        public PlayerBuilder WithChips(int amount)
        {
            _chipsAmount = amount;

            return this;
        }
    }
}