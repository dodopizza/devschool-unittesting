using System;
using Domain;
using Moq;
using Xunit;

namespace TestProject1
{
    public class WhenPlayer
    {
        private readonly RollDiceGame game;
        private readonly Player player = new Player();

        public WhenPlayer()
        {
            var scoreSource = new Mock<IScoreSource>();
            scoreSource.Setup(source => source.GetScore()).Returns(1);
            game = new RollDiceGame(scoreSource.Object);

            player.Join(game);
        }

        [Fact]
        public void StartsGame_ItIsInGame()
        {
            Assert.True(player.IsInGame);
        }

        [Fact]
        public void IsInGame_ItCanNotStartsGameAgain()
        {
            var scoreSource = new Mock<IScoreSource>();
            scoreSource.Setup(source => source.GetScore()).Returns(2);
            Assert.Throws<InvalidOperationException>(
                () => player.Join(new RollDiceGame(scoreSource.Object))
            );
        }

        [Fact]
        public void EndsGame_ItIsNoMoreInGame()
        {
            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Fact]
        public void Buys10Chips_ItHasMoreThan5Chips()
        {
            player.Buy(new Chip(10));

            Assert.True(player.Has(new Chip(5)));
        }

        [Fact]
        public void MakeBet_ItHasCurrentBet()
        {
            var bet = new Bet(new Chip(5), 13);
            player.Bet(bet);

            Assert.Equal(bet, player.CurrentBet);
        }

        [Fact]
        public void MakeBetAndLoose_ItHasNoCurrentBet()
        {
            var bet = new Bet(new Chip(5), 13);
            player.Bet(bet);
            player.Lose();

            Assert.Null(player.CurrentBet);
        }

        [Fact]
        public void Wins_ItGetsChips()
        {
            var bet = new Bet(new Chip(1), 1);
            player.Bet(bet);

            game.Play();

            Assert.True(player.Has(new Chip(1)));
        }

        [Fact]
        public void Looses_ItGetsNothing()
        {
            var bet = new Bet(new Chip(1), 2);
            player.Bet(bet);

            game.Play();

            Assert.False(player.Has(new Chip(1)));
        }
    }
}