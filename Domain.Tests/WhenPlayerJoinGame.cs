using System;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerJoinGame
    {
        [Fact]
        public void ThenPlayerJoined()
        {
            var player = new Player();
            var game = new RollDiceGame();
            
            player.Join(game);

            Assert.True(player.IsInGame);
        }
        
        [Fact]
        public void AndPlayerInGameThenPlayerNotJoined()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => player.Join(game));
        }
    }
}