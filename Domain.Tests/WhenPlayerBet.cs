using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerBet
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

        [Fact] 
        public void AndPlayerHas15ChipsAndBets5ThenPlayerHas10Chips()
        {
            var player = Create.Player.WithChips(15).Please;
            
            player.Bet(5);
            
            Assert.Equal(10, player.Amount);
        }
    }
}