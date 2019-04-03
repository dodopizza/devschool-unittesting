using Domain.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerWin
    {
        [Fact]
        public void ThenCurrentBetIsEmpty()
        {
            var player = Create.Player.WithBet(1, 1).Please();
            
            player.Win(1);

            player.CurrentBet.Should().BeNull();
        }
        
        [Fact]
        public void ThenAvailableChipsUpdated()
        {
            var player = Create.Player.WithBet(1, 1).Please();
            
            player.Win(1);

            var chip = Create.Chip.WithAmount(1).Please();
            player.Has(chip).Should().BeTrue();
        }
    }
}