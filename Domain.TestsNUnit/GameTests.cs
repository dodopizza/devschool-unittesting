using AutoFixture;
using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class GameTests
    {
        private const int LuckyScore = 3;
        private const int UnluckyScore = 4;
        
        private RollDiceGame _game;
        private Player _player;
        
        [SetUp]
        public void SetUp()
        {
            var diceRollerMock = new Mock<IDiceRoller>();
            diceRollerMock.Setup(roller => roller.Roll()).Returns(LuckyScore);
            
            _game = new RollDiceGame(diceRollerMock.Object);
            _player = new Player();
            _game.AddPlayer(_player);
        }
        
        [Test]
        public void WhenPlayerWin_ShouldIncreaseChips6Times()
        {   
            _player.Bet(new Bet(new Chip(10), LuckyScore));
            
            _game.Play();
            
            Assert.True(_player.Has(new Chip(6 * 10)));
        }
        
        [Test]
        public void WhenPlayerLose_ShouldHasNoCurrentBet()
        {
            _player.Bet(new Bet(new Chip(10), UnluckyScore));
            
            _game.Play();
            
            Assert.Null(_player.CurrentBet);
        }
    }
}