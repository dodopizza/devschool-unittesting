using System;
using Xunit;

namespace Domain.Tests
{
    public class WhenPlayerBet
    {
        [Fact]
        public void AndBetWithAmount5ThenPlayerHasBetWithAmount5()
        {
            var player = Create.Player.WithChips(5).Please;
            
            player.Bet(5);
            
            Assert.Equal(5, player.CurrentBet);
        }
        
        [Fact]
        public void AndBetWithAmount15ThenPlayerHasBetWithAmount15()
        {
            var player = Create.Player.WithChips(15).Please;
            
            player.Bet(15);
            
            Assert.Equal(15, player.CurrentBet);
        }

        [Fact] 
        public void AndPlayerHas15ChipsAndBets5ThenPlayerHas10Chips()
        {
            var player = Create.Player.WithChips(15).Please;
            
            player.Bet(5);
            
            Assert.Equal(10, player.Amount);
        }
        
        [Fact] 
        public void AndPlayerHas5ChipsAndBets10ThenPlayerCantBet()
        {
            var player = Create.Player.WithChips(5).Please;

            Assert.Throws<InvalidOperationException>(() => player.Bet(10));
        }
    }
}