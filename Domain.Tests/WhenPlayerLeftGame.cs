using System;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerLeftGame
    {
        [Fact]
        public void AndPlayerInGameThenPlayerNotInGame()
        {
            var player = Create.Player.InGame().Please;
            
            player.Left();
            
            Assert.False(player.InGame);
        }        
        
        [Fact]
        public void AndPlayerNotInGameThenPlayerCantLeave()
        {
            var player = Create.Player.Please;

            Assert.Throws<InvalidOperationException>(() => player.Left());
        }
    }
}