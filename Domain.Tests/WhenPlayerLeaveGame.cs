using System;
using Domain.Tests.Builders;
using FluentAssertions;
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

            player.IsInGame.Should().BeFalse();
        }
        
        [Fact]
        public void AndPlayerNotInGameThenPlayerNotLeft()
        {
            var player = Create.Player.Please();

            Assert.Throws<InvalidOperationException>(() => player.LeaveGame());
        }
    }
}