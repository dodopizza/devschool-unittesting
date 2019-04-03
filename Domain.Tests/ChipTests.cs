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

            player.Bet(10, 3);
            
            Assert.AreEqual(0, player.Chips);
            Assert.AreEqual(1, player.CurrentBets.Count);
            Assert.AreEqual(10, player.CurrentBets[0].Amount);
            Assert.AreEqual(3, player.CurrentBets[0].Score);
        }

        [Test]
        public void PlayerCantBetMoreChipsThanHeHas()
        {
            var player = Create.Player()
                .WithChips(10)
                .Please();

            Assert.Throws<InvalidOperationException>(() => player.Bet(10 + 1, 3));
        }

        [Test]
        public void PlayerCanBetTwice()
        {
            var player = Create.Player()
                .WithChips(15)
                .Please();

            player.Bet(10, 3);
            player.Bet(5, 4);
            
            Assert.AreEqual(0, player.Chips);
            Assert.AreEqual(2, player.CurrentBets.Count);
            Assert.AreEqual(10, player.CurrentBets[0].Amount);
            Assert.AreEqual(3, player.CurrentBets[0].Score);
            Assert.AreEqual(5, player.CurrentBets[1].Amount);
            Assert.AreEqual(4, player.CurrentBets[1].Score);
        }
    }
}