using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerPlay
    {
        [Fact]
        public void AndTheyWinThenChipsUpdated()
        {
            var player = PlayerBuilder.GetPlayer().WithBet(1, 2).Build();
            var game = new RollDiceGame(new DiceMock(2));
            player.Join(game);
            
            game.Play();

            Assert.True(player.Has(new Chip(2)));
        }
        
        [Fact]
        public void AndTheyLoseThenChipsUpdated()
        {
            var player = PlayerBuilder.GetPlayer().WithBet(1, 1).Build();
            var game = new RollDiceGame(new DiceMock(2));
            player.Join(game);
            
            game.Play();

            Assert.True(player.Has(new Chip(0)));
        }
    }
}