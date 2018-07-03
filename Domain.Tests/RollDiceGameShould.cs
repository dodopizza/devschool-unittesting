using System;
using Xunit;

namespace Domain.Tests
{
    public class RollDiceGameShould
    {
        [Fact]
        //Я, как игра, не позволяю войти более чем 6 игрокам
        public void AddOnlySixPlayers()
        {
            var customGame = new RollDiceGame();
            for (var i = 0; i < 6; i++)
                customGame.AddPlayer(new Player());

            Action addPlayerAction = () => customGame.AddPlayer(new Player());
            Assert.Throws<TooManyPlayersException>(addPlayerAction);
        }
    }
}
