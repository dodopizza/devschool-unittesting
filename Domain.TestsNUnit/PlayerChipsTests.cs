using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
    public class PlayerChipsTests
    {
        private Player _player;
        private Chip _tenChips;

        [SetUp]
        public void SetUp()
        {
            _player = new Player();
            _tenChips = new Chip(10);
        }

        [Test]
        public void PlayerShouldBeAbleToBuyChips()
        {
            _player.Buy(_tenChips);

            Assert.True(_player.Has(_tenChips));
        }

        [Test]
        public void PlayerShouldHasGetChips_WhenHeWin()
        {
            _player.Win(10);
            
            Assert.True(_player.Has(new Chip(10)));
        }
    }
}