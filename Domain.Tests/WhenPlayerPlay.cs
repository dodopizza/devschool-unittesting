using Domain.Tests.Builders;
using Domain.Tests.Fakes;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerPlay
    {
        [Fact]
        public void AndTheyWinThenChipsUpdated()
        {
            var game = Create.Game.WithLuckyScore(2).Please();
            var player = Create.Player.JoinRollDiceGame(game).WithBet(1, 2).Please();

            game.Play();

            Assert.True(player.Has(new Chip(2)));
        }

        [Fact]
        public void AndTheyLoseThenChipsUpdated()
        {
            var game = Create.Game.WithLuckyScore(2).Please();
            var player = Create.Player.JoinRollDiceGame(game).WithBet(1, 1).Please();

            game.Play();

            Assert.True(player.Has(new Chip(0)));
        }
        
        [Fact]
        public void AndTheyWinThenPlayerAckAboutWin()
        {
            var game = Create.Game.WithLuckyScore(1).Please();
            var player1 = new PlayerMock(1);
            var player2 = new PlayerMock(1);
            game.AddPlayer(player1);
            game.AddPlayer(player2);

            game.Play();

            Assert.Equal(1,player1.WinCount);
            Assert.Equal(0, player1.LoseCount);
            
            Assert.Equal(1,player2.WinCount);
            Assert.Equal(0, player2.LoseCount);
        }
        
        [Fact]
        public void AndTheyLoseThenPlayerAckAboutLose()
        {
            var game = Create.Game.WithLuckyScore(1).Please();
            var player1 = new PlayerMock(2);
            var player2 = new PlayerMock(2);
            game.AddPlayer(player1);
            game.AddPlayer(player2);

            game.Play();

            Assert.Equal(0,player1.WinCount);
            Assert.Equal(1, player1.LoseCount);
            
            Assert.Equal(0,player2.WinCount);
            Assert.Equal(1, player2.LoseCount);
        }
        
        [Fact]
        public void ThenPlayersAckAboutWinAndLose()
        {
            var game = Create.Game.WithLuckyScore(1).Please();
            var player1 = new PlayerMock(1);
            var player2 = new PlayerMock(2);
            game.AddPlayer(player1);
            game.AddPlayer(player2);

            game.Play();

            Assert.Equal(1,player1.WinCount);
            Assert.Equal(0, player1.LoseCount);
            
            Assert.Equal(0,player2.WinCount);
            Assert.Equal(1, player2.LoseCount);
        }
    }
}