using Domain;
using NUnit.Framework;

namespace Tests
{
    public class PlayerBets10ChipsOn1And5ChipsOn2
    {
        [Test]
        public void WhenHeHas26Chips_ThenGameStoresAllHisBets()
        {
            var player = new Player();
            var game = new Game();
            player.Join(game);
            player.BuyChips(11);
            player.Bet(1.BetOn(10));
            player.Bet(2.BetOn(5));

            Assert.Multiple(() =>
            {
                Assert.AreEqual(1.BetOn(10), game.BetByPlayer[player][0]);
                Assert.AreEqual(2.BetOn(5), game.BetByPlayer[player][1]);
            });
        }
    }
}