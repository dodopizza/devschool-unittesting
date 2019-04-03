using System;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerLeaveGame
    {
        [Fact]
        public void ThenPlayerLeft()
        {
            var player = Create.Player.InGame().Please();
            
            player.LeaveGame();

            Assert.False(player.IsInGame);
        }
        
        [Fact]
        public void AndPlayerNotInGameThenPlayerNotLeft()
        {
            var player = Create.Player.Please();

            Assert.Throws<InvalidOperationException>(() => player.LeaveGame());
        }
    }
}