using System;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {
            player = new Player();
            anyGame = new RollDiceGame();
            anyOtherGame = new RollDiceGame();
            anyBet = new Bet(42.Chips(), 1);
        }

        private Player player;
        private RollDiceGame anyGame;
        private RollDiceGame anyOtherGame;
        private Bet anyBet;

        [Test]
        public void PlayerJoinsGame_WhenAlreadyInAGame_ThrowsException()
        {
            player.Join(anyGame);

            Assert.Throws<InvalidOperationException>(() => player.Join(anyOtherGame));
        }

        [Test]
        public void PlayerJoinsGame_WhenNotInAGame_JoinsSuccessfully()
        {
            player.Join(anyGame);

            Assert.True(player.IsInGame);
        }

        [Test]
        public void PlayerLeavesGame_WhenAlreadyInAGame_LeavesSuccessfully()
        {
            player.Join(anyGame);

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }


        [Test]
        public void PlayerLeavesGame_WhenNotInAGame_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => player.LeaveGame());
        }

        [Test]
        public void PlayerLoses_AfterHeMadeABet_HeHasNoBet()
        {
            player.Bet(anyBet);

            player.Lose();

            Assert.IsNull(player.CurrentBet);
        }

        [Test]
        public void PlayerWins10Chips_WhenPlayerHas0Chips_HeDoesntHave11Chips()
        {
            player.Win(10);

            Assert.False(player.Has(11.Chips()));
        }

        [Test]
        public void PlayerWins10Chips_WhenPlayerHas0Chips_HeHas10Chips()
        {
            player.Win(10);

            Assert.True(player.Has(10.Chips()));
        }
    }

    public static class PlayerTestExtensions
    {
        public static Chip Chips(this int count)
        {
            return new Chip(count);
        }
    }
}