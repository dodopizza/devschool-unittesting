using FluentAssertions;
using Xunit;

namespace Domain.Tests
{
    public class WhenRollDicePlayed
    {
        [Fact]
        public void OnceThenDiceRolledOnce()
        {
            var dice = Create.Dice.WithLuckyScore(2).Please();
            var game = Create.Game.WithDice(dice).Please();

            game.Play();

            dice.RollCount.Should().Be(1);
        }
        
        [Fact]
        public void TwiceThenDiceRolledTwice()
        {
            var dice = Create.Dice.WithLuckyScore(2).Please();
            var game = Create.Game.WithDice(dice).Please();

            game.Play();
            game.Play();

            dice.RollCount.Should().Be(2);
        }
    }
}