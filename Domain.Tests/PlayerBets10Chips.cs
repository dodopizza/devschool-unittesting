using Domain;
using NUnit.Framework;

namespace Tests
{
    public class PlayerBets10Chips
    {
        [Test]
        public void GameStoresHisBet()
        {
            var player = new Player();
            var game = new Game();
            player.Join(game);
            player.Bet(10);
            
            Assert.IsTrue(game.BetByPlayer[player] == 10);
        }
    }
}