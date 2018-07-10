using System.ComponentModel;
using Domain;
using Moq;
using Xunit;

namespace DomainTests
{
    public class RollDiceGameTests
    {
        [Fact]
        [Description("Я, как игра, не позволяю войти более чем 6 игрокам")]
        public void ShouldThrowException_When7thPlayerJoin()
        {
            var game = new RollDiceGame();

            for (int i = 0; i < 6; i++)
            {
                var player = new Player();
                player.Join(game);
            }
            
            var wrongPlayer = new Player();
            Assert.Throws<TooManyPlayersException>(() => { wrongPlayer.Join(game); });
        }
        
        [Fact]
        [Description("Game.Play() бросает кубик")]
        public void ShouldThrowDice()
        {
            var dice = new Mock<IDice>();
            dice.Setup(x => x.Roll()).Returns(1);
            var game = new RollDiceGame(dice.Object);

            game.Play();

            dice.Verify(x => x.Roll(), Times.Once);
        }
    }
}