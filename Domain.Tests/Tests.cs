using System;
using NUnit.Framework;

namespace Domain.Tests
{
    public class PlayerJoinsGame
    {
        [Test]
        public void WhenGameEmpty_CanJoin()
        {
            // Arrange
            var player = new Player();
            var game = new RollDiceGame();
            
            // Act
            player.Join(game);
            
            // Assert
            Assert.IsTrue(player.IsInGame);
        }
        
        [Test]
        public void WhenAlreadyJoinedAnotherGame_CannotJoin()
        {
            // Arrange
            var player = new Player();
            var game = new RollDiceGame();             
            player.Join(game);
            var otherGame = new RollDiceGame();
            
            // Act // Assert
            Assert.Throws<InvalidOperationException>(() => player.Join(otherGame));
        }

        [Test]
        public void WhanGameFull_CannotJoin()
        {
            // Arrange
            RollDiceGame game = new RollDiceGame();

            for (var i = 0; i < 6; i++)
            {
                new Player().Join(game);
            }
            
            // Act // Assert
            Assert.Throws<TooManyPlayersException>(() => new Player().Join(game));
        }
    }
    
    public class PlayerLeavesGame
    {
        [Test]
        public void WhenNotInGame_CannotLeave()
        {
            // Arrange // Act // Assert
            Assert.Throws<InvalidOperationException>(() => new Player().LeaveGame());
        }
        
        [Test]
        public void WhenInGame_CanLeave()
        {
            // Arrange
            var player = new Player();
            var game = new RollDiceGame();            
            player.Join(game);
            
            // Act
            player.LeaveGame();
            
            // Assert
            Assert.IsFalse(player.IsInGame);
        }
    }
}