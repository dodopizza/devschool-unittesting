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
            player.Bet(10.BetOn(4));

            Assert.AreEqual(10.BetOn(4), game.BetByPlayer[player][0]);
        }
        
        [Test]
        public void WhenHeHas11Chips_ThenHeHas1Chip()
        {
            var player = new Player();
            var game = new Game();
            player.Join(game);
            player.BuyChips(11);
            player.Bet(10.BetOn(5));

            Assert.AreEqual(1, player.CurrentChipsAmount);
        }

        [Test]
        public void WhenHeHas9Chips_ThenThrowException()
        {
            var player = new Player();
            var game = new Game();
            player.Join(game);
            player.BuyChips(9);

            Assert.Throws<InvalidOperationException>(() => player.Bet(10.BetOn(1)));
        }
    }
}