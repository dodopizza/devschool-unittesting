using System;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void PlayerLeavesGame_WhenNotInAGame_ThrowsException()
        {
            var player = new Player();
            Assert.Throws<InvalidOperationException>(() => player.LeaveGame());
        }

        [Test]
        public void PlayerLeavesGame_WhenAlreadyInAGame_LeavesSuccessfully()
        {
            var player = new Player();

            player.Join(new RollDiceGame());
            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void PlayerJoinsGame_WhenNotInAGame_JoinsSuccessfully()
        {
            var player = new Player();

            player.Join(new RollDiceGame());

            Assert.True(player.IsInGame);
        }

        [Test]
        public void PlayerJoinsGame_WhenAlreadyInAGame_ThrowsException()
        {
            var player = new Player();

            player.Join(new RollDiceGame());

            Assert.Throws<InvalidOperationException>(() => player.Join(new RollDiceGame()));
        }

        [Test]
        public void PlayerWins10Chips_WhenPlayerHas0Chips_HeHas10Chips()
        {
            var player = new Player();

            player.Win(10);

            Assert.True(player.Has(new Chip(10)));
        }

        [Test]
        public void PlayerWins10Chips_WhenPlayerHas0Chips_HeDoesntHave11Chips()
        {
            var player = new Player();

            player.Win(10);

            Assert.False(player.Has(new Chip(11)));
        }

        [Test]
        public void PlayerLoses_AfterHeMadeABet_HeHasNoBet()
        {
            var player = new Player();
            player.Bet(new Bet(new Chip(42), 1));

            player.Lose();

            Assert.IsNull(player.CurrentBet);
        }
    }
}