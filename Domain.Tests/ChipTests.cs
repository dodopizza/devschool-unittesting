using System;
using Domain.Tests.DSL;
using NUnit.Framework;

namespace Domain.Tests
{
    public class ChipTests
    {
        [Test]
        public void PlayerShouldBuyChips()
        {
            var player = Create.Player().Please();

            player.BuyChips(10);
            
            Assert.AreEqual(10, player.Chips);
        }

        [Test]
        public void PlayerShouldBetInGame()
        {
            var player = Create.Player()
                .WithChips(10)
                .Please();

            player.Bet(new Bet(10, 3));
            
            Assert.AreEqual(10, player.GetBetAmount(3));
        }

        [Test]
        public void PlayerCantBetMoreChipsThanHeHas()
        {
            var player = Create.Player()
                .WithChips(10)
                .Please();
            
            var bet = new Bet(10 + 1, 3);


            Assert.Throws<InvalidOperationException>(() => player.Bet(bet));
        }

        [Test]
        public void PlayerCanBetTwice()
        {
            var player = Create.Player()
                .WithChips(15)
                .Please();

            player.Bet(new Bet(10, 3));
            player.Bet(new Bet(5, 4));

            Assert.AreEqual(10, player.GetBetAmount(3));
            Assert.AreEqual(5, player.GetBetAmount(4));
        }

        [Test]
        public void PlayerCanRaiseBet()
        {
            var player = Create.Player()
                .WithChips(15)
                .Please();
            
            player.Bet(new Bet(10, 3));
            player.Bet(new Bet(5, 3));
            
            Assert.AreEqual(15, player.GetBetAmount(3));
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(35)]
        [TestCase(90)]
        public void PlayerCanBetMultipleOf5(int betCount)
        {
            var player = Create.Player()
                .WithChips(betCount)
                .Please();

            var bet = new Bet(betCount, 1);
            
            player.Bet(bet);
        }
        
        [Test]
        [TestCase(3)]
        [TestCase(16)]
        [TestCase(19)]
        [TestCase(53)]
        [TestCase(69)]
        public void PlayerCantBetMultipleOf5(int betCount)
        {
            var player = Create.Player()
                .WithChips(betCount)
                .Please();

            var bet = new Bet(betCount, 1);
            
            Assert.Throws<InvalidOperationException>(() => player.Bet(bet));
        }
    }
}