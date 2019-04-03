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
            var sixPlayers = new[] {new Player(), new Player(), new Player(), new Player(), new Player(), new Player()};
            foreach (var player in sixPlayers)
            {
                player.Join(game);
            }

            var player7 = new Player();

            Assert.Throws<InvalidOperationException>(() => player7.Join(game));
        }
        
        [Test]
        public void WhenThereWere6PlayersInThatGameAndOneLeft_ThenJoinSuccessfully()
        {
            var game = new Game();
            var sixPlayers = new[] {new Player(), new Player(), new Player(), new Player(), new Player(), new Player()};
            foreach (var player in sixPlayers)
            {
                player.Join(game);
            }
            sixPlayers[0].LeaveCurrentGame();

            var player7 = new Player();
            player7.Join(game);

            Assert.AreEqual(game, player7.CurrentGame);
        }
    }
}