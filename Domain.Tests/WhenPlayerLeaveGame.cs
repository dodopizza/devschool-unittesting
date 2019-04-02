using System;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerLeaveGame
    {
        [Fact]
        public void ThenPlayerLeft()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);
            
            player.LeaveGame();

            Assert.False(player.IsInGame);
        }
        
        [Fact]
        public void AndPlayerNotInGameThenPlayerNotLeft()
        {
            var player = new Player();

            Assert.Throws<InvalidOperationException>(() => player.LeaveGame());
        }
    }
}