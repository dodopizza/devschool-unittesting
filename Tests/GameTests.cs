using System;
using Domain;
using Moq;
using Xunit;

namespace Tests
{
    public class GameTests
    {
        [Fact]
        public void SeventhPlayerJoinGame_SixPlayersInGame_ThrowsException()
        {
            var game = new RollDiceGame(new Dice());
            for (int i = 0; i < 6; i++)
            {
                new Player().Join(game);
            }

            Assert.Throws<TooManyPlayersException>(() =>
            {
                var player7 = new Player();
                player7.Join(game);
            });
        }
        
        [Fact]
        public void SixPlayersJoinGame_NoOneInGame_SixPlayersInGame()
        {
            var game = new RollDiceGame(new Dice());
            
            for (int i = 0; i < 6; i++)
            {
                new Player().Join(game);
            }

            Assert.Equal(6, game.PlayerCount);
        }
        
        [Fact]
        public void CallPlayerWin_PlayerLoseCalled()
        {
            //Arrange
            var luckyScore = 6;
            var diceMock = new Mock<IDice>();
            diceMock.Setup(d => d.Roll()).Returns(luckyScore);
            var game = new RollDiceGame(diceMock.Object);
            var playerMock = new Mock<IPlayer>();
            var chip = new Chip(1);
            var bet = new Bet(chip, 2);
            playerMock.Setup(x => x.Lose());
            playerMock.Setup(x => x.Bet(It.Is<Bet>(b=>b==bet)));
            playerMock.Setup(x => x.CurrentBet).Returns(bet);
            
            game.AddPlayer(playerMock.Object);
            
            //Act
            game.Play();
            
            //Assert
            playerMock.Verify(x=>x.Lose(),Times.Once);
        }        
    }
}

