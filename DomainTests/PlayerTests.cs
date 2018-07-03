using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Domain;
using Xunit;

namespace DomainTests
{
    public class PlayerTests
    {
        [Fact]
        [Description("Я, как игрок, могу войти в игру")]
        public void ShouldBeInGame_WhenJoinGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            
            player.Join(game);
            
            Assert.Equal(true, player.IsInGame);
        }
        
        [Fact]
        [Description("Я, как игрок не могу войти в игру 2 раза")]
        public void ShouldThrowException_WhenJoinGameSecondTime()
        {
            var player = new Player();
            var game = new RollDiceGame();
            
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => { player.Join(game); });
        }
        
        [Fact]
        [Description("Я, как игрок, могу играть только в одну игру одновременно")]
        public void ShouldThrowException_WhenJoinAnotherGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            var anotherGame = new RollDiceGame();
            
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => { player.Join(anotherGame); });
        }
        
        [Fact]
        [Description("Я, как игрок, не могу выйти из игры, если я в нее не входил")]
        public void ShouldThrowException_WhenLeaveGameIfNotInGame()
        {
            var player = new Player();
            
            Assert.Throws<InvalidOperationException>(() => { player.LeaveGame(); });
        }
        
        [Fact]
        [Description("Я, как игрок, могу выйти из игры")]
        public void ShouldLeaveGame_WhenInGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            
            player.Join(game);
            player.LeaveGame();
            
            Assert.Equal(false, player.IsInGame);
        }
    }
}
