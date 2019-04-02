using System;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerLeaveGame
    {
        [Fact]
        public void ThenPlayerLeft()
        {
            var player = PlayerBuilder.GetPlayer().InGame().Build();
            
            player.LeaveGame();

            Assert.False(player.IsInGame);
        }
        
        [Fact]
        public void AndPlayerNotInGameThenPlayerNotLeft()
        {
            var player = PlayerBuilder.GetPlayer().Build();

            Assert.Throws<InvalidOperationException>(() => player.LeaveGame());
        }
    }
}