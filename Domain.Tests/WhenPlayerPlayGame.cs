using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerPlayGame
    {
        [Fact]
        public void AndLooseThenLooseChips()
        {
            var player = Create.Player.WithChips(10).WithBetAtScoreAndAmount(1, 6).Please;
            
            player.Play(2);
            
            Assert.Equal(4, player.Amount);
            Assert.Equal(0, player.CurrentBetAmount);
        }
        
        [Fact]
        public void AndWinThenWinChips()
        {
            var player = Create.Player.WithChips(10).WithBetAtScoreAndAmount(1, 6).Please;
            
            player.Play(1);
            
            Assert.Equal(40, player.Amount);
            Assert.Equal(0, player.CurrentBetAmount);
        }
    }
}