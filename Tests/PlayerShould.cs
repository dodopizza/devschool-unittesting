using System;
using System.Runtime.InteropServices;
using Domain;
using Xunit;

namespace Tests
{
    public class PlayerShould
    {
        [Fact]
        public void JoinGame()
        {
            var player = new Player();
            var game = new Game();

            player.JoinGame(game);

            Assert.True(player.IsInGame);
        }

        [Fact]
        public void LeaveGame()
        {
            var player = new Player();

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Fact]
        public void CantLeaveGameIfNotJoined()
        {
            var player = new Player();

            Assert.Throws<Exception>(() => player.LeaveGame());
        }

        [Fact]
        public void JoinOnlyOneGame()
        {
            var player = new Player();
            var game1 = new Game();
            var game2 = new Game();

            player.JoinGame(game1);

            Assert.Throws<Exception>(() => player.JoinGame(game2));
        }
    }
}