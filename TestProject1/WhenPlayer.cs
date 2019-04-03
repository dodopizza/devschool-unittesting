using System;
using Domain;
using Moq;
using Xunit;

namespace TestProject1
{
    public class WhenPlayer
    {
        [Fact]
        public void StartsGame_ItIsInGame()
        {
            var player = Player.New();

            player.Join(Game.WithRandomLuckyScore());

            Assert.True(player.IsInGame);
        }

        [Fact]
        public void IsInGame_ItCanNotStartsGameAgain()
        {
            var player = Player.New().InGame();

            Assert.Throws<InvalidOperationException>(
                () => player.Join(Game.WithRandomLuckyScore())
            );
        }

        [Fact]
        public void EndsGame_ItIsNoMoreInGame()
        {
            var player = Player.New().InGame();

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Fact]
        public void Buys10Chips_ItHasMoreThan5Chips()
        {
            var player = Player.New();

            player.Buy(new Chip(10));

            Assert.True(player.Has(new Chip(5)));
        }

        [Fact]
        public void MakeBet_ItHasCurrentBet()
        {
            var player = Player.New();
            var bet = Bet.New(5,13);

            player.Bet(bet);

            Assert.Equal(bet, player.CurrentBet);
        }

        [Fact]
        public void MakeBetAndLoose_ItHasNoCurrentBet()
        {
            var player = Player.New().MakeBet(5, 13);

            player.Loose();

            Assert.Null(player.CurrentBet);
        }

        [Fact]
        public void Wins_ItGetsChips()
        {
            var game = Game.WithLuckyScore(1);
            var player = Player.New().MakeBet(1, 1).InGame(game);

            game.Play();

            Assert.True(player.Has(new Chip(1)));
        }

        [Fact]
        public void Looses_ItGetsNothing()
        {
            var game = Game.WithLuckyScore(1);
            var player = Player.New().MakeBet(1, 2).InGame(game);

            game.Play();

            Assert.False(player.Has(new Chip(1)));
        }

        [Fact]
        public void Plays_GetScoreGetsCalledOnce()
        {
            var scoreSource = new Mock<IScoreSource>();
            scoreSource.Setup(source => source.GetScore()).Returns(1);
            var game = new RollDiceGame(scoreSource.Object);
            Player.New().MakeBet(1, 1).InGame(game);

            game.Play();

            scoreSource.Verify(_ => _.GetScore(), Times.Once);
        }

        [Fact]
        public void Wins_WinGetsCalledOnce()
        {
            var player = new Mock<IPlayer>();
            var game = Game.WithLuckyScore(1).JoinPlayer(player.Object);
            player.Setup(_ => _.CurrentBet).Returns(Bet.New(10, 1));

            game.Play();

            player.Verify(_ => _.Win(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Loses_LoseGetsCalledOnce()
        {
            var player = new Mock<IPlayer>();
            var game = Game.WithLuckyScore(1).JoinPlayer(player.Object);
            player.Setup(_ => _.CurrentBet).Returns(Bet.New(1, 2));

            game.Play();

            player.Verify(_ => _.Loose(), Times.Once);
        }
    }
}