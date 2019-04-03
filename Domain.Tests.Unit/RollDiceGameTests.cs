using System.Linq;
using Moq;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class RollDiceGameTests
    {
        private readonly Chip AnyAmountOfChips = 15.Chips();

        private IDieRoller CreateDieRoller(int returnValue)
        {
            var mock = new Mock<IDieRoller>();
            mock.Setup((roller) => roller.RollDice()).Returns(returnValue);
            return mock.Object;
        }

        private Mock<IPlayer> CreatePlayerWithBet(Bet bet)
        {
            var mock = new Mock<IPlayer>();
            mock.Setup(p => p.CurrentBet).Returns(bet);
            return mock;
        }

        [Test]
        public void GameIsPlayed_WhenPlayerBetsOnLuckyScore_ThenPlayerWins()
        {
            var playerMock = CreatePlayerWithBet(AnyAmountOfChips.BetOn(5));
            var roller = CreateDieRoller(5);
            var game = new RollDiceGame(roller);
            game.AddPlayer(playerMock.Object);

            game.Play();

            playerMock.Verify(m => m.Win(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GameIsPlayed_WhenPlayerBetsOnUnluckyScore_ThenPlayerLoses()
        {
            var playerMock = CreatePlayerWithBet(AnyAmountOfChips.BetOn(4));
            var roller = CreateDieRoller(5);
            var game = new RollDiceGame(roller);
            game.AddPlayer(playerMock.Object);

            game.Play();

            playerMock.Verify(m => m.Lose(), Times.Once);
        }

        [Test]
        public void GameIsPlayed_WhenPlayerBetsOnUnluckyScore_ThenPlayerDoesntGainMoney()
        {
            var player = new Player();
            player.Bet(AnyAmountOfChips.BetOn(4));
            var roller = CreateDieRoller(5);
            var game = new RollDiceGame(roller);
            game.AddPlayer(player);

            game.Play();

            Assert.AreEqual(0, player.AvailableChipsAmount);
        }

        [Test]
        public void GameIsPlayed_WhenPlayerBets15ChipsOnLuckyScore_ThenPlayerGains15xWinFactorChips()
        {
            var player = new Player();
            player.Bet(15.Chips().BetOn(5));
            var roller = CreateDieRoller(5);
            var game = new RollDiceGame(roller);
            game.AddPlayer(player);

            game.Play();

            Assert.AreEqual(15 * RollDiceGame.WinFactor, player.AvailableChipsAmount);
        }


        [Test]
        public void MaximumAmountOfPlayersIs6()
        {
            Assert.AreEqual(6, RollDiceGame.MaxPlayers);
        }

        [Test]
        public void GameAddsPlayer_WhenAlreadyHasMaximumAmountOfPlayers_ThenThrowError()
        {
            var game = Create.Game()
                .WithMaximumAmountOfPlayers()
                .Please();

            Assert.Throws<TooManyPlayersException>(() => game.AddPlayer(new Player()));
        }

        [Test]
        public void GamePlay_WhenMultiplePlayersParticipate_ThenAllPlayersBetsAreEmptied()
        {
            var game = Create.Game()
                .WithANumberOfPlayers(3)
                .WithPlayerBetsOn(4, 5, 6)
                .WithLuckyRoll(5)
                .Please();

            game.Play();

            Assert.Multiple(() =>
            {
                Assert.Null(game.Players[0].CurrentBet);
                Assert.Null(game.Players[1].CurrentBet);
                Assert.Null(game.Players[2].CurrentBet);
            });
        }

        public static class Create
        {
            public static GameBuilder Game()
            {
                return new GameBuilder();
            }
            
            public static BetBuilder Bet()
            {
                return new BetBuilder();
            }
       }

        public class GameBuilder
        {
            private int _playerAmount;
            private Bet[] _bets = {};
            private IDieRoller _dieRoller = new RandomDieRoller();

            public RollDiceGame Please()
            {
                var game = new RollDiceGame(_dieRoller);
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
        }
    }

    public class BetBuilder
    {
        private int _chipsAmount = 1;
        private int _score = 1;
        public Bet Please()
        {
            return _chipsAmount.Chips().BetOn(_score);
        }

        public BetBuilder On(int score)
        {
            _score = score;
            return this;
        }
    }
}