using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerBuyChips
    {
        [Fact]
        public void ThenHeOwnChips()
        {
            var player = PlayerBuilder.GetPlayer().Build();

            player.Buy(new Chip(1));

            Assert.True(player.Has(new Chip(1)));
        }
        
        [Fact]
        public void ThenPlayerHaveNotMoreAvailableChips()
        {
            var player = PlayerBuilder.GetPlayer().Build();

            player.Buy(new Chip(1));

            Assert.False(player.Has(new Chip(5)));
        }
    }
}