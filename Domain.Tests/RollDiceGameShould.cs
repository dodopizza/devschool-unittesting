using Moq;
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
            var dice = new Dice();
            var customGame = new RollDiceGame(dice);
            for (var i = 0; i < 6; i++)
                customGame.AddPlayer(new Player());

            Action addPlayerAction = () => customGame.AddPlayer(new Player());
            Assert.Throws<TooManyPlayersException>(addPlayerAction);
        }

        [Fact]
        // Game.Play() бросает кубик
        public void GetLuckyScoreFromDiceWhenPlay()
        {
            var diceMock = new Mock<IDice>();
            var game = new RollDiceGame(diceMock.Object);

            game.Play();

            diceMock.Verify(d => d.GetLuckyScore(), Times.Once);
        }

        [Fact]
        public void SetWinAllPlayersWithRightBet()
        {
            var diceStub = new Mock<IDice>();
            var game = new RollDiceGame(diceStub.Object);
            var playerMock = new Mock<Player>();

            diceStub.Setup(d => d.GetLuckyScore()).Returns(5);

            playerMock.Object.Join(game);
            playerMock.Object.Bet(new Bet(new Chip(10), 5));

            game.Play();

            playerMock.Verify(p => p.Win(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void SetLoseAllPlayersWithWrongBet()
        {
            var diceStub = new Mock<IDice>();
            var game = new RollDiceGame(diceStub.Object);
            var playerMock = new Mock<Player>();

            diceStub.Setup(d => d.GetLuckyScore()).Returns(5);

            playerMock.Object.Join(game);
            playerMock.Object.Bet(new Bet(new Chip(10), 8));

            game.Play();

            playerMock.Verify(p => p.Lose(), Times.Once);
        }
    }
}
