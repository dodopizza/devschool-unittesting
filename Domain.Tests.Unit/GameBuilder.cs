using System;
using System.Linq;
using Moq;

namespace Domain.Tests
{
    public class GameBuilder
    {
        private int _playerAmount;
        private IPlayer[] _players = { };
        private Bet[] _bets = { };
        private IDieRoller _dieRoller = new RandomDieRoller();

        public RollDiceGame Please()
        {
            var game = new RollDiceGame(_dieRoller);
            for (int i = 0; i < Math.Max(_playerAmount, _players.Length); i++)
            {
                IPlayer player;
                if (i < _players.Length)
                {
                    player = _players[i];
                }
                else
                {
                    player = new Player();
                }

                if (i < _bets.Length)
                {
                    player.Bet(_bets[i]);
                }

                game.AddPlayer(player);
            }

            return game;
        }

        public GameBuilder WithMaximumAmountOfPlayers()
        {
            _playerAmount = 6;
            return this;
        }

        public GameBuilder WithANumberOfPlayers(int number)
        {
            _playerAmount = number;
            return this;
        }

        public GameBuilder WithPlayerBets(params Bet[] bets)
        {
            _bets = bets;
            return this;
        }

        public GameBuilder WithPlayerBetsOn(params int[] scores)
        {
            _bets = scores.Select(s => Create.Bet().On(s).Please()).ToArray();
            return this;
        }

        public GameBuilder WithLuckyRoll(int roll)
        {
            var mock = new Mock<IDieRoller>();
            mock.Setup((roller) => roller.RollDice()).Returns(roll);
            _dieRoller = mock.Object;
            return this;
        }

        public GameBuilder WithPlayers(params IPlayer[] players)
        {
            _players = players;
            return this;
        }
    }
}