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

        [Test]
        public void WhenThereAre6PlayersInThatGame_ThenThrowsException()
        {
            var game = new Game();
            var player1 = new Player();
            var player2 = new Player();
            var player3 = new Player();
            var player4 = new Player();
            var player5 = new Player();
            var player6 = new Player();
            var player7 = new Player();
            player1.Join(game);
            player2.Join(game);
            player3.Join(game);
            player4.Join(game);
            player5.Join(game);
            player6.Join(game);

            Assert.Throws<InvalidOperationException>(() => player7.Join(game));
        }
    }
}