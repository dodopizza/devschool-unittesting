using System;
using NUnit.Framework;

namespace Domain.Tests
{
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsNotInGame_WhenNew()
        {
            var player = new Player();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void CanJoinGame_WhenNotInGame()
        {
            var game = new RollDiceGame();
            var player = new Player();

            player.Join(game);

            Assert.True(player.IsInGame);
        }

        [Test]
        public void CanLeaveGame_WhenInGame()
        {
            var game = new RollDiceGame();
            var player = new Player();
            player.Join(game);

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void FailsToJoinGame_WhenInGame()
        {
            var game = new RollDiceGame();
            var player = new Player();
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => player.Join(game));
        }

        [Test]
        public void HasChips_WhenBuyChips()
        {
            var chip = new Chip(10);
            var player = new Player();

            player.Buy(chip);

            Assert.True(player.Has(chip));
        }

        [Test]
        public void CurrentBetIsSet_WhenBet()
        {
            var chip = new Chip(10);
            var bet = new Bet(chip, 10);
            var player = new Player();
            player.Buy(chip);

            player.Bet(bet);

            Assert.AreEqual(bet, player.CurrentBet);
        }

        [Test]
        public void ChipsAmountAdded_WhenWins()
        {
            var player = new Player();

            player.Win(10);

            Assert.True(player.Has(new Chip(10)));
        }

        [Test]
        public void CurrentBetIsSet_WhenLose()
        {
        }
    }
}