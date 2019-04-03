using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
    public class PlayerBets10Chips
    {
        [Test]
        public void WhenHeHas11Chips_GameStoresHisBet()
        {
            var player = new Player();
            var game = new Game();
            player.Join(game);
            player.BuyChips(11);
            player.Bet(10);

            Assert.IsTrue(game.BetByPlayer[player] == 10);
        }
        
        [Test]
        public void WhenHeHas11Chips_ThenHeHas1Chip()
        {
            var player = new Player();
            var game = new Game();
            player.Join(game);
            player.BuyChips(11);
            player.Bet(10);

            Assert.AreEqual(1, player.CurrentChipsAmount);
        }

        [Test]
        public void WhenHeHas9Chips_ThenThrowException()
        {
            var player = new Player();
            var game = new Game();
            player.Join(game);
            player.BuyChips(9);

            Assert.Throws<InvalidOperationException>(() => player.Bet(10));
        }
    }
}