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
            var player = CreatePlayer();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void CanJoinGame_WhenNotInGame()
        {
            var game = new RollDiceGame(new Randomizer.Randomizer(
                (from, to) => new Random(DateTime.Now.Millisecond).Next(from, to)
            ));
            var player = CreatePlayer();

            player.Join(game);

            Assert.True(player.IsInGame);
        }

        [Test]
        public void CanLeaveGame_WhenInGame()
        {
            var game = CreateRollDiceGame();
            var player = CreatePlayer();
            player.Join(game);

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void FailsToJoinGame_WhenInGame()
        {
            var game = CreateRollDiceGame();
            var player = CreatePlayer();
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => player.Join(game));
        }

        private static RollDiceGame CreateRollDiceGame()
        {
            var game = new RollDiceGame(new Randomizer.Randomizer(
                (from, to) => new Random(DateTime.Now.Millisecond).Next(from, to)
            ));
            return game;
        }

        [Test]
        public void HasChips_WhenBuyChips()
        {
            var chip = CreateChip(10);
            var player = CreatePlayer();

            player.Buy(chip);

            Assert.True(player.Has(chip));
        }

        [Test]
        public void CurrentBetIsSet_WhenBet()
        {
            var bet = CreateBet(1, 2);
            var player = CreatePlayer();
            player.Buy(CreateChip(1));

            player.Bet(bet);

            Assert.AreEqual(bet, player.CurrentBet);
        }

        private static Player CreatePlayer()
        {
            var player = new Player();
            return player;
        }

        private static Bet CreateBet(int amount, int score)
        {
            var chip = CreateChip(amount);
            var bet = new Bet(chip, score);
            return bet;
        }

        private static Chip CreateChip(int amount)
        {
            var chip = new Chip(amount);
            return chip;
        }

        [Test]
        public void ChipsAmountAdded_WhenWins()
        {
            var player = CreatePlayer();

            player.Win(10);

            Assert.True(player.Has(new Chip(10)));
        }

        [Test]
        public void CurrentBetIsSet_WhenLose()
        {
        }
    }
}