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
    }
}