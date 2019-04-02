using Domain;
using NUnit.Framework;

namespace Tests
{
    public class PlayerBetTests
    {
        private Player _playerWithBet;
        private Chip _tenChips;
        private Bet _bet;

        [SetUp]
        public void SetUp()
        {
            _tenChips = new Chip(10);
            _bet = new Bet(_tenChips, 5);
            _playerWithBet = new Player();
            _playerWithBet.Bet(_bet);
        }
        
        [Test]
        public void BeAbleToCreateBet()
        {
            Assert.AreEqual(_bet, _playerWithBet.CurrentBet);
        }
        
        [Test]
        public void NotHasCurrentBet_WhenHeLose()
        {
            _playerWithBet.Lose();
            
            Assert.Null(_playerWithBet.CurrentBet);
        }
        
        [Test]
        public void NotHasCurrentBet_WhenHeWin()
        {
            _playerWithBet.Win(10);
            
            Assert.Null(_playerWithBet.CurrentBet);
        }
    }
}