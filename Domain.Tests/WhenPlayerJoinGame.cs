using System;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerJoinGame
    {
        [Fact]
        public void ThenPlayerJoined()
        {
            var player = Create.Player.Please();

            player.Join(new RollDiceGame(new Dice()));

            Assert.True(player.IsInGame);
        }
        
        [Fact]
        public void AndPlayerInGameThenPlayerNotJoined()
        {
            var player = Create.Player.InGame().Please();

            Assert.Throws<InvalidOperationException>(() => player.Join(new RollDiceGame(new Dice())));
        }
    }
}