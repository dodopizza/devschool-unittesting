using Domain.Tests.DSL;
using NUnit.Framework;

namespace Domain.Tests
{
    public class ChipTests
    {
        [Test]
        public void PlayerShouldBuyChips()
        {
            var player = Create.Player().Please();

            player.BuyChips(10);
            
            Assert.AreEqual(10, player.Chips);
        }
    }
}