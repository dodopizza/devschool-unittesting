using System;
using Domain;
using Xunit;

namespace DomainTests
{
    public class PlayerTests
    {
        [Fact]
        public void IfInGame_ShouldThrowException()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => player.Join(game));
        }
        
        [Fact]
        public void IfNotInGame_ShouldJoinGameSuccessfully()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);

            Assert.Equal(true, player.IsInGame);
        }

        [Fact]
        public void IfNotInGame_LeaveShouldThrow()
        {
            var player = new Player();
            
            Assert.Throws<InvalidOperationException>(() => player.LeaveGame());
        }
    }
}