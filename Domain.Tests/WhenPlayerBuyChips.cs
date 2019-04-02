using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerBuyChips
    {
        [Fact]
        public void ThenHeOwnChips()
        {
            var player = new Player();
            var chip = new Chip(1);
            
            player.Buy(chip);

            Assert.True(player.Has(chip));
        }
        
        [Fact]
        public void ThenPlayerHaveNotMoreAviableChips()
        {
            var player = new Player();
            var chip = new Chip(1);
            
            player.Buy(chip);

            Assert.False(player.Has(new Chip(5)));
        }
    }
}