using System;
using Domain;
using Xunit;

namespace DomainTests
{
    public class PlayerShould
    {
        [Fact]
        public void NotJoinGame_IfAlreadyInGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => player.Join(game));
        }
        
        [Fact]
        public void JoinGame_IfNotInGame()
        {
            var player = new Player();
            var game = new RollDiceGame();
            
            player.Join(game);

            Assert.True(player.IsInGame);
        }

        [Fact]
        public void NotLeaveGame_IfNotInGame()
        {
            var player = new Player();
            
            Assert.Throws<InvalidOperationException>(() => player.LeaveGame());
        }

        [Fact]
        public void BeAbleToBuyChips()
        {
            var player = new Player();
            var chips = new Chip(10);
            
            player.Buy(chips);

            Assert.True(player.Has(chips));
        }

        [Fact]
        public void BeAbleToCreateBet()
        {
            var player = new Player();
            var chips = new Chip(10);
            var bet = new Bet(chips, 5);
            
            player.Bet(bet);
            
            Assert.Equal(bet, player.CurrentBet);
        }

        [Fact]
        public void NotHasCurrentBet_WhenHeLose()
        {
            var player = new Player();
            AddBetToPlayer(player);
            
            player.Lose();
            
            Assert.Null(player.CurrentBet);
        }
        
        [Fact]
        public void NotHasCurrentBet_WhenHeWin()
        {
            var player = new Player();
            AddBetToPlayer(player);
            
            player.Win(10);
            
            Assert.Null(player.CurrentBet);
        }

        [Fact]
        public void HasGetChips_WhenHeWin()
        {
            var player = new Player();
            
            player.Win(10);
            
            Assert.True(player.Has(new Chip(10)));
            Assert.False(player.Has(new Chip(11)));
        }

        private static void AddBetToPlayer(Player player)
        {
            var chips = new Chip(10);
            var bet = new Bet(chips, 5);
            player.Bet(bet);
        }       
    }
}