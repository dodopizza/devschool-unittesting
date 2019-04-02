using System;
using Domain;
using Xunit;

namespace TestProject1
{
    public class WhenPlayer
    {
        [Fact]
        public void StartsGame_IsInGame()
        {
            var player = new Player();
            player.Join(new RollDiceGame());
            Assert.True(player.IsInGame);
        }

        [Fact]
        public void IsInGame_CanNotStartsGameAgain()
        {
            var player = new Player();
            player.Join(new RollDiceGame());
            Assert.Throws<InvalidOperationException>(
                () => player.Join(new RollDiceGame())
            );
        }

        [Fact]
        public void EndsGame_NoMoreInGame()
        {
            var player = new Player();
            player.Join(new RollDiceGame());
            player.LeaveGame();
            Assert.False(player.IsInGame);
        }
    }
}