using Domain;
using NUnit.Framework;
using Tests.DSL;

namespace Tests
{
    [TestFixture]
    public class PlayerChipsTests
    {
        [Test]
        public void Buy1Chip_Has1Chip()
        {
            var player = new Player();

            player.Buy(1.Chips());

            Assert.IsTrue(player.Has(1.Chips()));
        }

        [Test]
        public void ByDefault_HasNoChips()
        {
            var player = new Player();

            Assert.IsFalse(player.Has(1.Chips()));
        }

        [Test]
        public void Buy1Chip_HasNo2Chip()
        {
            var player = new Player();

            player.Buy(1.Chips());

            Assert.IsFalse(player.Has(2.Chips()));
        }

        [Test]
        public void Buy2Chip_Has2Chip()
        {
            var player = new Player();

            player.Buy(2.Chips());

            Assert.IsTrue(player.Has(2.Chips()));
        }
    }
}