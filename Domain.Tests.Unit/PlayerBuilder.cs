namespace Domain.Tests
{
    public class PlayerBuilder
    {
        private Bet _bet;

        public PlayerBuilder WithBetOn(int score)
        {
            WithBet(Create.Bet().On(score).Please());
            return this;
        }

        public PlayerBuilder WithBet(Bet bet)
        {
            _bet = bet;
            return this;
        }

        public Player Please()
        {
            var player = new Player();
            if (_bet != null)
                player.Bet(_bet);

            return player;
        }
    }
}