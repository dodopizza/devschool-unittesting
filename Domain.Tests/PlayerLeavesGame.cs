using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
    public class PlayerLeavesGame
    {
        [Test]
        public void WhenInAGame_ThenLeavesSuccessfully()
        {
            var game = new Game();
            var player = new Player();
            player.Join(game);

            player.LeaveCurrentGame();

            Assert.Null(player.CurrentGame);
        }

        [Test]
        public void WhenNotInAGame_ThenThrowsException()
        {
            var player = new Player();

            Assert.Throws<InvalidOperationException>(() => player.LeaveCurrentGame());
        }
    }
}