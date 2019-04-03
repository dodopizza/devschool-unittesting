using Domain.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerBuyChips
    {
        [Fact]
        public void ThenHeOwnChips()
        {
            var player = Create.Player.Please();
            var amount = 1;
            
            player.Buy(new Chip(amount));

            player.Has(Create.Chip.WithAmount(amount).Please()).Should().BeTrue();
        }
        
        [Fact]
        public void ThenPlayerHaveNotMoreAvailableChips()
        {
            var player = Create.Player.Please();

            player.Buy(new Chip(1));

            player.Has(Create.Chip.WithAmount(5).Please()).Should().BeFalse();
        }
    }
}