using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerBuyChips
    {
        [Fact]
        public void ThenPlayerOwnsChips()
        {
            var player = Create.Player.Please;

            player.Buy(5);

            Assert.True(player.HasChips(5));
        }
    }
}