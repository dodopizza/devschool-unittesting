using System;
using System.Linq;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerBet
    {
        [Fact]
        public void AndBetWithAmount5ThenPlayerHasBetWithAmount5()
        {
            var player = Create.Player.WithChips(5).Please;
            
            player.Bet(5, 1);
            
            Assert.Equal(5, player.CurrentBetAmount);
        }
        
        [Fact]
        public void AndBetWithAmount15ThenPlayerHasBetWithAmount15()
        {
            var player = Create.Player.WithChips(15).Please;
            
            player.Bet(15, 1);
            
            Assert.Equal(15, player.CurrentBetAmount);
        }

        [Fact] 
        public void AndPlayerHas15ChipsAndBets5ThenPlayerHas10Chips()
        {
            var player = Create.Player.WithChips(15).Please;
            
            player.Bet(5, 1);
            
            Assert.Equal(10, player.Amount);
        }
        
        [Fact] 
        public void AndPlayerHas5ChipsAndBets10ThenPlayerCantBet()
        {
            var player = Create.Player.WithChips(5).Please;

            Assert.Throws<InvalidOperationException>(() => player.Bet(10, 1));
        }
        
        [Fact] 
        public void With3BetsThenPlayerHas3Bets()
        {
            var player = Create.Player.WithChips(6).Please;
            
            player.Bet(1, 1);
            player.Bet(2, 1);
            player.Bet(3, 1);
            
            Assert.Equal(3, player.CurrentBets.Count());
        }

        [Fact]
        public void WithBetOn11And12And13ThenPlayerHasBetsOn11And12And13()
        {
            var player = Create.Player.WithChips(6).Please;

            player.Bet(1, 11);
            player.Bet(2, 12);
            player.Bet(3, 13);

            Assert.True(player.CurrentBets.Any(x => x.Score == 11));
            Assert.True(player.CurrentBets.Any(x => x.Score == 12));
            Assert.True(player.CurrentBets.Any(x => x.Score == 13));
        }
    }
}