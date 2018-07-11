using Domain;
using Tests.DSL;
using Xunit;

namespace Tests
{
    public class PlayerChipsTests
    {
        [Fact]
        public void Buy1Chip_Has1Chip()
        {
            var player = new Player();

            player.Buy(1.Chips());

            Assert.True(player.Has(1.Chips()));
        }

        [Fact]
        public void ByDefault_HasNoChips()
        {
            var player = new Player();

            Assert.False(player.Has(1.Chips()));
        }

        [Fact]
        public void Buy1Chip_HasNo2Chip()
        {
            var player = new Player();

            player.Buy(1.Chips());

            Assert.False(player.Has(2.Chips()));
        }

        [Fact]
        public void Buy2Chip_Has2Chip()
        {
            var player = new Player();

            player.Buy(2.Chips());

            Assert.True(player.Has(2.Chips()));
        }
    }
}