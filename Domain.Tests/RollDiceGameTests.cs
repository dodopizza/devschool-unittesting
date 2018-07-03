using System;
using Xunit;

namespace Domain.Tests
{
    public class RollDiceGameTests
    {
        [Fact]
        //Я, как игра, не позволяю войти более чем 6 игрокам
        public void GameCantAdd7Players()
        {
            var customGame = new RollDiceGame();
            Action addPlayer = () => customGame.AddPlayer(new Player());

            for (var i = 0; i < 6; i++)
            {
                addPlayer();
            }

            Assert.Throws<TooManyPlayersException>(addPlayer);
        }
    }
}
