using System;
using System.Runtime.InteropServices;
using Domain;
using Xunit;
using Xunit.Sdk;

namespace Tests
{
    public class PlayerShould
    {
        [Fact]
        public void JoinGame()
        {
            var player = new Player();
            var game = new Game();

            player.JoinGame(game);

            Assert.True(player.IsInGame);
        }

        [Fact]
        public void LeaveGame()
        {
            var player = new Player();
            var game = new Game();
            player.JoinGame(game);

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Fact]
        public void CantLeaveGameIfNotJoined()
        {
            var player = new Player();

            Assert.Throws<Exception>(() => player.LeaveGame());
        }

        [Fact]
        public void JoinOnlyOneGame()
        {
            var player = new Player();
            var game1 = new Game();
            var game2 = new Game();

            player.JoinGame(game1);

            Assert.Throws<Exception>(() => player.JoinGame(game2));
        }

        [Fact]
        public void CanBuyChips()
        {
            var player = new Player();

            player.BuyChips(1);

            Assert.Equal(1, player.Chips);
        }

        [Fact]
        public void CanBet()
        {
            var player = new Player();

            player.Bet(10, 2);

            Assert.Equal(10, player.BetChips);
            Assert.Equal(2, player.BetScore);
        }
    }
}