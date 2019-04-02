using System;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerJoinGame
    {
        [Fact]
        public void ThenPlayerJoined()
        {
            var player = PlayerBuilder.GetPlayer().Build();

            player.Join(new RollDiceGame(new Dice()));

            Assert.True(player.IsInGame);
        }
        
        [Fact]
        public void AndPlayerInGameThenPlayerNotJoined()
        {
            var player = PlayerBuilder.GetPlayer().InGame().Build();

            Assert.Throws<InvalidOperationException>(() => player.Join(new RollDiceGame(new Dice())));
        }
    }
}