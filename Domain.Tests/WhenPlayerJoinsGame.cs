using System;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerJoinsGame
    {
        [Fact]
        public void AndPlayerNotInGameThenPlayerInGame()
        {
            var player = Create.Player.Please;
            var game = Create.Game.Please;
            
            player.Join(game);
            
            Assert.True(player.InGame);
        }   
        
        [Fact]
        public void AndPlayerInGameThenPlayerCantJoin()
        {
            var game = Create.Game.Please;
            var player = Create.Player.InGame().Please;

            Assert.Throws<InvalidOperationException>(() => player.Join(game));
        }
    }
}