using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerLooseGame
    {
        [Fact]
        public void ThenPlayerLooseBet()
        {
            var player = Create.Player.WithChips(10).WithBetAtScoreAndAmount(1, 10).Please;
            
            player.Loose();
            
            Assert.Equal(0, player.CurrentBetAmount);
        }
        
        [Fact]
        public void ThenPlayerLooseChips()
        {
            var player = Create.Player.WithChips(15).WithBetAtScoreAndAmount(1, 10).Please;
            
            player.Loose();
            
            Assert.Equal(5, player.Amount);
        }
    }
}