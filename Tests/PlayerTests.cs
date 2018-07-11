using Domain;
using Moq;
using Xunit;

namespace Tests
{
    public class PlayerTests
    {
        [Fact]
        public void PlayerShouldLose_WhenBadBet()
        {
            var luckyBet = 1;
            var dice = new Mock<IDice>();
            dice.Setup(d => d.Roll()).Returns(3);
            var player = new Mock<IPlayer>();
            var chipAmount = 10;
            var chip = new Chip(chipAmount);
            var game = new RollDiceGame(dice.Object);
            
            var bet = new Bet(chip, 2);
            player.Setup(p => p.CurrentBet).Returns(bet);
            
            game.AddPlayer(player.Object);
            
            game.Play();
            
            player.Verify(x => x.Lose(), Times.Once);
        }
    }
}