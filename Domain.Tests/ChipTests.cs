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
            Assert.AreEqual(10, player.CurrentBet.Amount);
            Assert.AreEqual(3, player.CurrentBet.Score);
        }

        [Test]
        public void PlayerCantBetMoreChipsThanHeHas()
        {
            var player = Create.Player()
                .WithChips(10)
                .Please();

            Assert.Throws<InvalidOperationException>(() => player.Bet(10 + 1, 3));
        }
    }
}