using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerJoinsGame
    {
        [Fact]
        public void ThenPlayerInGame()
        {
            var player = Create.Player.Please;
            var game = Create.Game.Please;
            
            player.Join(game);
            
            Assert.True(player.InGame);
        }
    }
}