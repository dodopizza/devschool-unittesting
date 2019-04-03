using System;
using Domain.Tests.Dsl;
using NUnit.Framework;

namespace Domain.Tests
{
    public class PlayerTests
    {
        [Test]
        public void IsNotInGame_WhenNew()
        {
            var player = Create.Player();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void CanJoinGame_WhenNotInGame()
        {
            var game = Create.Game();
            var player = Create.Player();

            player.Join(game);

            Assert.True(player.IsInGame);
        }

        [Test]
        public void CanLeaveGame_WhenInGame()
        {
            var player = Create.Player().InGame();

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void FailsToJoinGame_WhenInGame()
        {
            var game = Create.Game();

            var player = Create.Player();

            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => player.Join(game));
        }

        [Test]
        public void HasChips_WhenBuyChips()
        {
            var chip = Create.Chip();
            var player = Create.Player();

            player.Buy(chip);

            Assert.True(player.Has(chip));
        }

        [Test]
        public void CurrentBetIsSet_WhenBet()
        {
            var player = Create.Player().WithChips();
            var bet = Create.Bet();

            player.Bet(bet);

            Assert.AreEqual(bet, player.CurrentBet);
        }

        [Test]
        public void ChipsAmountAdded_WhenWins()
        {
            var player = Create.Player();

            player.Win(10);

            Assert.True(player.Has(new Chip(10)));
        }
    }
}