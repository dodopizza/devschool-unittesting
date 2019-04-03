using Domain;
using NUnit.Framework;

namespace Tests
{
    public class PlayerBuys10Chips
    {
        [Test]
        public void WhenHeHas0Chips_ThenHeHas10Chips()
        {
            var player = new Player();
            player.BuyChips(10);
            
            Assert.AreEqual(10, player.CurrentChipsAmount); 
        }
    }
}