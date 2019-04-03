using Domain;
using Moq;

namespace Tests
{
    public class GameBuilder
    {
        private IDiceRoller _diceRoller = new DiceRoller();
        private int _playerAmount = 1;
        private Bet[] _bets;

        public GameBuilder WithLuckyRoll(int roll)
        {
            var diceRollerMoq = new Mock<IDiceRoller>();
            diceRollerMoq.Setup(r => r.Roll()).Returns(roll);
            _diceRoller = diceRollerMoq.Object;
            return this;
        }

        public GameBuilder WithPlayerBets(params Bet[] bets)
        {
            _bets = bets;
            return this;
        }

        public RollDiceGame Please()
        {
            var game = new RollDiceGame(_diceRoller);

            for (int i = 0; i < _playerAmount; i++)
            {
                var player = new Player();

                if (i < _bets.Length)
                {
                    player.Bet(_bets[i]);
                }

                game.AddPlayer(player);
            }
            
            return game;
        }
    }
}