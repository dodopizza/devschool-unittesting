using System;
using Domain.Tests.DSL;
using NUnit.Framework;

namespace Domain.Tests
{
    public class PlayerShould
    {
        [Test]
        public void JoinGame()
        {
            var player = Create.Player().Please();
            var game = Create.Game().Please();

            player.Join(game);
            
            Assert.AreEqual(game, player.CurrentGame);
        }
        
        [Test]
        public void BeAbleToLeaveGame_WhenInGame()
        {
            var game = Create.Game().Please();
            var player = Create.Player()
                .In(game)
                .Please();

            player.LeaveGame();
            
            Assert.Null(player.CurrentGame);
        }

        [Test]
        public void NotLeaveGame_WhenHeIsNotInGame()
        {
            var player = Create.Player().Please();

            Assert.Throws<InvalidOperationException>(player.LeaveGame);
        }

        [Test]
        public void NotJoinGame_WhenHeAlreadyInGame()
        {
            var game = Create.Game().Please();
            var otherGame = Create.Game().Please();

            var player = Create.Player().In(game).Please();

            Assert.Throws<InvalidOperationException>(() => player.Join(otherGame));
        }
    }
}