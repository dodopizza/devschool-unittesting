using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerWin
    {
        [Fact]
        public void ThenCurrentBetIsEmpty()
        {
            var player = new Player();
            var bet = new Bet(new Chip(1), 1);
            player.Bet(bet);
            
            player.Win(1);

            Assert.Null(player.CurrentBet);
        }
        
        [Fact]
        public void ThenAvailableChipsUpdated()
        {
            const int winChips = 1;
            
            var player = new Player();
            var bet = new Bet(new Chip(1), 1);
            player.Bet(bet);
            
            player.Win(winChips);

            Assert.True(player.Has(new Chip(winChips)));
        }
    }
}