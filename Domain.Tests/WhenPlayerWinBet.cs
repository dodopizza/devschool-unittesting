using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerWinBet
    {
        [Fact]
        public void AndBetAmount10ThenPlayerGets60Chips()
        {
            var player = Create.Player.WithChips(10).WithBetAtScoreAndAmount(1, 10).Please;
            
            player.Win();
            
            Assert.Equal(6 * 10, player.Amount);
        }
    }
}