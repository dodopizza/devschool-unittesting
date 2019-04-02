using NUnit.Framework;

namespace Domain.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenCreatePlayer_IsNotInGame()
        {
            var player = new Player();
            
            Assert.False(player.IsInGame);
        }

        [Test]
        public void WhenCreatePlayer_CanJoinGame()
        {
            var game = new RollDiceGame();
            var player = new Player();
            
            player.Join(game);
            
            Assert.True(player.IsInGame);
        }

        [Test]
        public void WhenPlayerInGame_CanLeaveGame()
        {
            var game = new RollDiceGame();
            var player = new Player();
            player.Join(game);
            
            player.LeaveGame();
            
            Assert.False(player.IsInGame);
        }
    }
}