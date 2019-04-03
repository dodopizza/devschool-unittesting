using System;
using JoyCasino.Domain;
using Xunit;

namespace JoyCasino.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void WhenJoinsGame_ThenInGame()
        {
            var player = new Player();
            var game = new Game();

            player.JoinGame(game);
            
            Assert.True(player.IsInGame);
        }
    }
}