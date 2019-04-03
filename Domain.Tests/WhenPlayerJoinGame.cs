using System;
using Domain.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerJoinGame
    {
        [Fact]
        public void ThenPlayerJoined()
        {
            var player = Create.Player.Please();
            var game = Create.Game.Please();
            
            player.Join(game);

            player.IsInGame.Should().BeTrue();
        }
        
        [Fact]
        public void AndPlayerInGameThenPlayerNotJoined()
        {
            var player = Create.Player.InGame().Please();
            var game = Create.Game.Please();
            
            Assert.Throws<InvalidOperationException>(() => player.Join(game));
        }
    }
}