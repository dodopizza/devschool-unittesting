using System;
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
        
        [Test]
        public void WhenAlreadyInADifferentGame_ThenThrowsException()
        {
            var game = new Game();
            var player = new Player();
            player.Join(game);
            var otherGame = new Game();

            Assert.Throws<InvalidOperationException>(() => player.Join(otherGame));
        }
        
        [Test]
        public void WhenAlreadyInThatGame_ThenThrowsException()
        {
            var game = new Game();
            var player = new Player();
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => player.Join(game));
        }

    }
}