using Domain;
using NUnit.Framework;

namespace Tests
{
    public class GameTests
    {
        private RollDiceGame _game;
        private Player _player;

        [SetUp]
        public void SetUp()
        {
            _game = new RollDiceGame(new DeterminedDiceRoller(3));
            _player = new Player();
            _game.AddPlayer(_player);
        }
        
        
        [Test]
        public void WhenPlayerWin_ShouldIncreaseChips6Times()
        {
            _player.Bet(new Bet(new Chip(10), 3));
            
            _game.Play();
            
            Assert.True(_player.Has(new Chip(6 * 10)));
        }
        
        [Test]
        public void WhenPlayerLose_ShouldHasNoCurrentBet()
        {
            _player.Bet(new Bet(new Chip(10), 4));
            
            _game.Play();
            
            Assert.Null(_player.CurrentBet);
        }
    }
}