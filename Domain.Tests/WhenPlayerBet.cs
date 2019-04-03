using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerBet
    {
        [Fact]
        public void ThenBetUpdated()
        {
            const int amount = 1;
            var player = Create.Player.Please();
            
            player.Bet(new Bet(new Chip(amount), 0));

            Assert.Equal(amount, player.CurrentBet.Chips.Amount);
        }
    }
}