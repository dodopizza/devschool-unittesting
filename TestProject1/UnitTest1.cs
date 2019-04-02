using System;
using Domain;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void IsInGame_True_After_Join()
        {
            var player = new Player();
            player.Join(new RollDiceGame());
            Assert.True(player.IsInGame);
        }

        [Fact]
        public void Join_Throws_If_Called_Twice()
        {
            var player = new Player();
            player.Join(new RollDiceGame());
            Assert.Throws<InvalidOperationException>(
                () => player.Join(new RollDiceGame())
            );
        }

        [Fact]
        public void IsInGame_False_After_Leave()
        {
            var player = new Player();
            player.Join(new RollDiceGame());
            player.LeaveGame();
            Assert.False(player.IsInGame);
        }
    }
}