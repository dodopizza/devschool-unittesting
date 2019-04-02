using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerWin
    {
        [Fact]
        public void ThenCurrentBetIsEmpty()
        {
            var player = PlayerBuilder.GetPlayer().WithBet(1, 1).Build();
            
            player.Win(1);

            Assert.Null(player.CurrentBet);
        }
        
        [Fact]
        public void ThenAvailableChipsUpdated()
        {
            var player = PlayerBuilder.GetPlayer().WithBet(1, 1).Build();
            
            player.Win(1);

            Assert.True(player.Has(new Chip(1)));
        }
    }
}