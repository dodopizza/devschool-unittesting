using Xunit;

namespace Domain.Tests
{
    public class WhenRollDicePlayed
    {
        [Fact]
        public void OnceThenDiceRolledOnce()
        {
            var dice = new DiceMock(2);
            var game = RollDiceGameBuilder.GetGame().WithDice(dice).Build();

            game.Play();

            Assert.Equal(1, dice.GetScoreRaiseCount);
        }
        
        [Fact]
        public void TwiceThenDiceRolledTwice()
        {
            var dice = new DiceMock(2);
            var game = RollDiceGameBuilder.GetGame().WithDice(dice).Build();

            game.Play();
            game.Play();

            Assert.Equal(2, dice.GetScoreRaiseCount);
        }
    }
}