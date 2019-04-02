using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerPlay
    {
        [Fact]
        public void AndTheyWinThenChipsUpdated()
        {
            var game = RollDiceGameBuilder.GetGame().WithLuckyScore(2).Build();
            var player = PlayerBuilder.GetPlayer().JoinRollDiceGame(game).WithBet(1, 2).Build();

            game.Play();

            Assert.True(player.Has(new Chip(2)));
        }

        [Fact]
        public void AndTheyLoseThenChipsUpdated()
        {
            var game = RollDiceGameBuilder.GetGame().WithLuckyScore(2).Build();
            var player = PlayerBuilder.GetPlayer().JoinRollDiceGame(game).WithBet(1, 1).Build();

            game.Play();

            Assert.True(player.Has(new Chip(0)));
        }
    }
}