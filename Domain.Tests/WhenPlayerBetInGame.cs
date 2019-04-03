using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerBetInGame
    {
        [Fact]
        public void AndBetWithAmount5ThenPlayerHasBetWithAmount5()
        {
            var player = Create.Player.Please;
            
            player.Bet(5);
            
            Assert.Equal(5, player.CurrentBet);
        }
        
        [Fact]
        public void AndBetWithAmount15ThenPlayerHasBetWithAmount15()
        {
            var player = Create.Player.Please;
            
            player.Bet(15);
            
            Assert.Equal(15, player.CurrentBet);
        }
    }
}