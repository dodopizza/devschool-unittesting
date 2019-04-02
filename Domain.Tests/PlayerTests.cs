using System;
using NUnit.Framework;

namespace Domain.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void PlayerLeavesGame_WhenNotInAGame_ThrowsException()
        {
            var player = new Player();
            Assert.Throws<InvalidOperationException>(() => player.LeaveGame());
        }
    }
}