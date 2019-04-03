using System.Collections.Generic;
using Moq;

namespace Domain.Tests.DSL
{
    public class GameBuilder
    {
        private List<Player> _players = new List<Player>();
        private IDiceRoller _diceRoller = new RandomDiceRoller();
        
        public Game Please()
        {
            var game = new Game(_diceRoller);
            _players.ForEach(p => p.Join(game));
            return game;
        }

        public GameBuilder With(Player player)
        {
            _players.Add(player);
            return this;
        }

        public GameBuilder WithLuckyScore(int luckyScore)
        {
            var diceRollerMock = new Mock<IDiceRoller>();
            diceRollerMock.Setup(r => r.Roll()).Returns(luckyScore);
            _diceRoller = diceRollerMock.Object;
            return this;
        }
    }
}