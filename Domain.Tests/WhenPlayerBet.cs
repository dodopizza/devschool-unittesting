using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerBet
    {
        [Fact]
        public void ThenBetUpdated()
        {
            var player = new Player();
            var bet = new Bet(new Chip(1), 1);
            
            player.Bet(bet);

            Assert.Equal(bet, player.CurrentBet);
        }
    }
}