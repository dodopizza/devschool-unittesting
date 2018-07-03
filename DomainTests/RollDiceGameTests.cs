using System.ComponentModel;
using Domain;
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
    }
}