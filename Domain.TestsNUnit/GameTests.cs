using Domain;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class GameTests
    {
        private const int LuckyScore = 3;
        private const int UnluckyScore = 4;
        
        private RollDiceGame _game;
        private PlayerSpy _player;
        
        [SetUp]
        public void SetUp()
        {
            var diceRollerMock = new Mock<IDiceRoller>();
            diceRollerMock.Setup(roller => roller.Roll()).Returns(LuckyScore);
            
            _game = new RollDiceGame(diceRollerMock.Object);

            _player = new PlayerSpy();
            
            _game.AddPlayer(_player);
        }
        
        [Test]
        public void WhenPlayerWin_ShouldIncreaseChips6Times()
        {
            var game = Create.Game()
                .WithLuckyRoll(3)
                .WithPlayerBets(
                    Create.Bet().WithChips(10).On(3).Please()
                )
                .Please();
            
            game.Play();
    
            Assert.True(game.Players[0].Has(new Chip(6 * 10)));
        }
        
        [Test]
        public void WhenPlayerWin_ShouldHasNoCurrentBet()
        {
            _player.Bet(new Bet(new Chip(10), LuckyScore));
            
            _game.Play();
            
            Assert.Null(_player.CurrentBet);
        }

        [Test]
        public void WhenPlayerLose_ShouldHasNoCurrentBet()
        {
            _player.Bet(new Bet(new Chip(10), UnluckyScore));
            
            _game.Play();
            
            Assert.Null(_player.CurrentBet);
        }

        [Test]
        public void WhenPlayerWin_ShouldCallWin()
        {
            _player.Bet(new Bet(new Chip(10), LuckyScore));
            
            _game.Play();
            
            Assert.AreEqual(1, _player.WinCalled);
        }

        [Test]
        public void WhenPlayerLose_ShouldCallLose()
        {
            _player.Bet(new Bet(new Chip(10), UnluckyScore));
            
            _game.Play();
            
            Assert.AreEqual(1, _player.LoseCalled);
        }
    }

    public class PlayerSpy : Player
    {
        public int WinCalled { get; private set; }
        public int LoseCalled { get; private set; }

        public override void Win(int chipsAmount)
        {
            WinCalled++;
            base.Win(chipsAmount);
        }
        
        public override void Lose()
        {
            LoseCalled++;
            base.Lose();
        }
    }
}