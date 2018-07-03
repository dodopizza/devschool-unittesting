using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Domain;
using Xunit;

namespace DomainTests
{
    public class UnitTest1
    {
        [Fact]
        [Description("Я, как игрок, могу войти в игру")]
        public void JoinGame_IfNotInGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            
            player.Join(game);
            
            Assert.Equal(true, player.IsInGame);
        }
        
        [Fact]
        [Description("Я, как игрок не могу войти в игру 2 раза")]
        public void JoinGame_IfInGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => { player.Join(game); });
        }
        
        [Fact]
        [Description("Я, как игрок, могу играть только в одну игру одновременно")]
        public void JoinGame_IfInAnotherGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            var anotherGame = new RollDiceGame();
            
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => { player.Join(anotherGame); });
        }
        
        [Fact]
        [Description("Я, как игрок, не могу выйти из игры, если я в нее не входил")]
        public void LeaveGame_IfNotInGame()
        {
            var player = new Player();
            
            Assert.Throws<InvalidOperationException>(() => { player.LeaveGame(); });
        }
        
        [Fact]
        [Description("Я, как игрок, могу выйти из игры")]
        public void LeaveGame_IfInGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            
            player.Join(game);
            player.LeaveGame();
            
            Assert.Equal(false, player.IsInGame);
        }
    }
}
