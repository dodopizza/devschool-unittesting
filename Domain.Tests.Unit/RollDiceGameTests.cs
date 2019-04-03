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
    }
}