using Domain;
using NUnit.Framework;

namespace Tests
{
    public class PlayerJoinsGame
    {
        [Test]
        public void WhenNotInAGame_ThenJoinSuccessfully()
        {
            var game = new Game();
            var player = new Player();

            player.Join(game);

            Assert.AreEqual(game, player.CurrentGame);
        }
    }
}