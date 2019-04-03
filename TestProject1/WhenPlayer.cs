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
            var player = Player.InGame();

            player.Join(Game.WithRandomLuckyScore());

            Assert.Throws<InvalidOperationException>(
                () => player.Join(Game.WithRandomLuckyScore())
            );
        }

        [Fact]
        public void EndsGame_ItIsNoMoreInGame()
        {
            var player = Player.InGame();

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
            var player = Player.New().MakeBet(1, 1)
            var game = GetMockedGame(1);
            player.Join(game);
            var bet = new Bet(new Chip(1), 1);
            player.Bet(bet);

            game.Play();

            Assert.True(player.Has(new Chip(1)));
        }

        [Fact]
        public void Looses_ItGetsNothing()
        {
            var player = new Player();
            var game = GetMockedGame(1);
            player.Join(game);
            var bet = new Bet(new Chip(1), 2);
            player.Bet(bet);

            game.Play();

            Assert.False(player.Has(new Chip(1)));
        }

        [Fact]
        public void Plays_GetScoreGetsCalledOnce()
        {
            var player = new Player();
            var scoreSource = new Mock<IScoreSource>();
            scoreSource.Setup(source => source.GetScore()).Returns(1);
            var game = new RollDiceGame(scoreSource.Object);
            player.Join(game);

            var bet = new Bet(new Chip(1), 1);
            player.Bet(bet);

            game.Play();

            scoreSource.Verify(_ => _.GetScore(), Times.Once);
        }

        [Fact]
        public void Wins_WinGetsCalledOnce()
        {
            var player = new Mock<IPlayer>();
            var game = GetMockedGame(1);
            game.AddPlayer(player.Object);
            player.Setup(_ => _.CurrentBet).Returns(new Bet(new Chip(10), 1));

            game.Play();

            player.Verify(_ => _.Win(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Loses_LoseGetsCalledOnce()
        {
            var player = new Mock<IPlayer>();
            var game = GetMockedGame(1);
            game.AddPlayer(player.Object);
            player.Setup(_ => _.CurrentBet).Returns(new Bet(new Chip(1), 2));

            game.Play();

            player.Verify(_ => _.Loose(), Times.Once);
        }
    }
}