namespace Domain.Tests.DSL
{
    public class PlayerBuilder
    {
        private Game _game;
        private int _chips;

        public Player Please()
        {
            var player = new Player();
            if (_game != null)
            {
                player.Join(_game);
            }
            
            player.BuyChips(_chips);

            return player;
        }

        public PlayerBuilder In(Game game)
        {
            _game = game;
            return this;
        }

        public PlayerBuilder WithChips(int chips)
        {
            _chips = chips;
            return this;
        }
    }
}