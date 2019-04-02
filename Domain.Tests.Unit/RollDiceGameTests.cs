using Moq;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class RollDiceGameTests
    {
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
            var playerMock = CreatePlayerWithBet(15.Chips().BetOn(5));
            var roller = CreateDieRoller(5);
            var game = new RollDiceGame(roller);
            game.AddPlayer(playerMock.Object);

            game.Play();

            playerMock.Verify(m => m.Win(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GameIsPlayed_WhenPlayerBetsOnUnluckyScore_ThenPlayerLoses()
        {
            var playerMock = CreatePlayerWithBet(15.Chips().BetOn(4));
            var roller = CreateDieRoller(5);
            var game = new RollDiceGame(roller);
            game.AddPlayer(playerMock.Object);
            
            game.Play();

            playerMock.Verify(m => m.Lose(), Times.Once);

        }
    }
}