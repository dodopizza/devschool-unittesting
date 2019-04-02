using System;
using Xunit;

namespace Domain.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void WhenJoinThenPlayerJoined()
        {
            var player = new Player();
            var game = new RollDiceGame();
            
            player.Join(game);

            Assert.True(player.IsInGame);
        }
        
        [Fact]
        public void WhenPlayerInGameJoinThenPlayerNotJoined()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => player.Join(game));
        }
        
        [Fact]
        public void WhenJoinedPlayerLeaveThenPlayerLeft()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);
            
            player.LeaveGame();

            Assert.False(player.IsInGame);
        }
        
        [Fact]
        public void WhenPlayerNotInGameLeaveThenPlayerNotLeft()
        {
            var player = new Player();

            Assert.Throws<InvalidOperationException>(() => player.LeaveGame());
        }
        
        [Fact]
        public void WhenPlayerBetThenBetUpdated()
        {
            var player = new Player();
            var bet = new Bet(new Chip(1), 1);
            
            player.Bet(bet);

            Assert.Equal(bet, player.CurrentBet);
        }
    }
}