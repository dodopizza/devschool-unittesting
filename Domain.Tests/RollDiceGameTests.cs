using System;
using Domain.Dice;
using Moq;
using NUnit.Framework;

namespace Domain.Tests
{
    public class RollDiceGameTests
    {
        [Test]
        public void PlayerWins_WhenBetOnLuckyScore()
        {
            var mockDice = new Mock<IDice>();
            mockDice.Setup(x => x.GetScore()).Returns(5);
            var game = new RollDiceGame(mockDice.Object);
            var player = new Player();
            player.Join(game);
            player.Bet(new Bet(new Chip(1), 5));

            game.Play();

            Assert.True(player.Has(new Chip(6)));
        }

        [Test]
        public void SomePlayerWins_WhenLuckyScoreRolled()
        {
            var mockDice = new Mock<IDice>();
            mockDice.Setup(x => x.GetScore()).Returns(5);
            var game = new RollDiceGame(mockDice.Object);

            var winnerMock = GetPlayerWithScore(5);
            var loserMock = GetPlayerWithScore(6);

            game.AddPlayer(winnerMock.Object);
            game.AddPlayer(loserMock.Object);


            game.Play();


            winnerMock.Verify(mock => mock.Win(It.IsAny<int>()), Times.Once());
            loserMock.Verify(mock => mock.Lose(), Times.Once());
        }

        private Mock<Player> GetPlayerWithScore(int score)
        {
            var playerWithScore = new Mock<Player>();
            playerWithScore.Setup(x => x.CurrentBet).Returns(new Bet(new Chip(1), score));

            return playerWithScore;
        }
    }
}